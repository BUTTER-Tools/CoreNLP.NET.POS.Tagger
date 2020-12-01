using System;
using System.Collections.Generic;
using TaggerOutputObjectLibrary;
using PluginContracts;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using java.util;
using edu.stanford.nlp.tagger.maxent;
using edu.stanford.nlp.ling;
using OutputHelperLib;

namespace CoreNLPPOSTagger
{
    public class CoreNLP_POSTagger : Plugin
    {

        public string[] InputType { get; } = { "String" };
        public string OutputType { get; } = "TaggerOutputObject";



        #region Setup Tagger Details
        public static string jarRoot = Path.Combine(Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory), 
                                        "Plugins" + Path.DirectorySeparatorChar + 
                                        "Dependencies" + Path.DirectorySeparatorChar + @"stanford-postagger-full-2018-02-27");
        public static string modelsDirectory = Path.Combine(jarRoot, @"models");
        public string SelectedModel { get; set; } = "english-bidirectional-distsim.tagger";
        public MaxentTagger tagger { get; set; }
        public int NumberOfTagsInModel { get; set; }
        public bool TopLevel { get; } = false;

        //header stuff
        public bool InheritHeader { get; } = false;
        public Dictionary<int, string> OutputHeaderData { get; set; }
        #endregion
        private List<string> posTags { get; set; }

        #region Plugin Details and Info

        public string PluginName { get; } = "Stanford Part of Speech Tagger";
        public string PluginType { get; } = "POS Taggers";
        public string PluginVersion { get; } = "3.9.1";
        public string PluginAuthor { get; } = "Ryan L. Boyd (ryan@ryanboyd.io)";
        public string PluginDescription { get; } = "Part of Speech Tagger using the Stanford.NLP.NET port of the CoreNLP tagger. Takes strings/texts as inputs and will tag the Parts of Speech using your specified model (which can be set in the Plugin Settings). Use the POS helpers to convert the CoreNLP output into POS-tagged text and POS frequency counts." + Environment.NewLine + Environment.NewLine +
            "For more information on Stanford's CoreNLP:" + Environment.NewLine + "https://stanfordnlp.github.io/CoreNLP/" + Environment.NewLine + Environment.NewLine +
            "For more information on Stanford.NLP.NET:" + Environment.NewLine + "http://sergey-tihon.github.io/Stanford.NLP.NET/samples/POSTagger.html" + Environment.NewLine + Environment.NewLine +
            "Manning, Christopher D., Mihai Surdeanu, John Bauer, Jenny Finkel, Steven J. Bethard, and David McClosky. 2014. The Stanford CoreNLP Natural Language Processing Toolkit In Proceedings of the 52nd Annual Meeting of the Association for Computational Linguistics: System Demonstrations, pp. 55-60.";
        public string PluginTutorial { get; } = "Coming Soon";

        public Icon GetPluginIcon
        {
            get
            {
                return Properties.Resources.icon;
            }
        }

        #endregion


        public void ChangeSettings()
        {
            using (var form = new SettingsForm_CoreNLPNET(SelectedModel, modelsDirectory))
            {


                form.Icon = Properties.Resources.icon;
                form.Text = PluginName;

                var result = form.ShowDialog();
                if (result == DialogResult.OK)
                {
                    SelectedModel = form.SelectedModel;
                }
            }
        }



        public Payload RunPlugin(Payload Input)
        {

            //custom class to hold all of the relevant output
            
            Payload pData = new Payload();
            pData.FileID = Input.FileID;
            pData.SegmentID = Input.SegmentID;
            pData.ObjectList = new List<object>();



                #region For Each Incoming Text
                for (int counter = 0; counter < Input.StringList.Count; counter++)
                {

                    #region Setting Up the Output Object with basic data that we'll work with later
                    TaggerOutputObject TaggerOutput = new TaggerOutputObject();
                    TaggerOutput.ModelTags = new Dictionary<int, string>();
                   

                    for (int i = 0; i < NumberOfTagsInModel; i++)
                    {
                        TaggerOutput.ModelTags.Add(i, posTags[i]);
                        TaggerOutput.POSSums.Add(posTags[i], 0);
                    }
                    #endregion


                    #region Segment Sentences, Prepare to Tag
                    var sentences = MaxentTagger.tokenizeText(new java.io.StringReader(Input.StringList[counter])).toArray();
                    TaggerOutput.TotalSentences = sentences.Length;
                    TaggerOutput.TotalWC = 0;
                    #endregion


                    #region Do the Actual Tagging

                    List<string> TaggedText = new List<string>();
                    List<string> TaggedText_TagsOnly = new List<string>();

                    foreach (ArrayList sentence in sentences)
                    {

                        try { 

                            var taggedSentence = tagger.tagSentence(sentence);
  
                            Iterator it = taggedSentence.iterator();

                            while (it.hasNext())
                            { 
                                TaggedWord token = (TaggedWord)it.next();
                                TaggedText.Add(token.toString());
                                TaggedText_TagsOnly.Add(token.tag().ToString());
                                TaggerOutput.POSSums[token.tag()] += 1;
                                TaggerOutput.TotalWC += 1;
                            }

                        }
                        catch (OutOfMemoryException OOM)
                        {
                            MessageBox.Show("Plugin Error: Core NLP POS Tagger. One or more of your files caused an Out of Memory error. This means that you do not have enough RAM to process the current text. This is often caused by extremely complex / messy language samples with run-on sentences or other peculiar constructions, paired with a computer that does not have enough RAM to handle such processing.", "Plugin Error (Out of Memory): Core NLP POS Tagger", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                    }
                    TaggerOutput.TaggedText = TaggedText.ToArray();
                    TaggerOutput.TaggedText_TagsOnly = TaggedText_TagsOnly.ToArray();
                    #endregion

                    pData.ObjectList.Add(TaggerOutput);
                    pData.SegmentNumber.Add(Input.SegmentNumber[counter]);

                }
                #endregion

                return (pData);


        }




        public void Initialize()
        {
            tagger = new MaxentTagger(modelsDirectory + @"/" + SelectedModel);
            NumberOfTagsInModel = tagger.numTags();

            //make sure that we organize our header for the CSV writer
            OutputHeaderData = new Dictionary<int, string>();
            OutputHeaderData.Add(0, "TokenCount");
            OutputHeaderData.Add(1, "SentenceCount");

            posTags = new List<string>();
            for (int i = 0; i < NumberOfTagsInModel; i++) posTags.Add(tagger.getTag(i));
            posTags.Sort();

            for (int i = 0; i < NumberOfTagsInModel; i++) OutputHeaderData.Add(i + 2, posTags[i]);

        }



        public bool InspectSettings()
        {
            return true;
        }


        #region Import and Export Settings
        public Dictionary<string, string> ExportSettings(bool suppressWarnings)
        {
            Dictionary<string, string> Settings = new Dictionary<string, string>();
            Settings.Add("SelectedModel", SelectedModel);
            return (Settings);
        }

        public void ImportSettings(Dictionary<string, string> Settings)
        {
            SelectedModel = Settings["SelectedModel"];
        }
        #endregion


        public Payload FinishUp(Payload Input)
        {
            tagger = new MaxentTagger(modelsDirectory + @"/" + SelectedModel);
            return (Input);
        }


    }
}
