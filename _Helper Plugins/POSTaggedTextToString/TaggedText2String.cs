using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using PluginContracts;
using TaggerOutputObjectLibrary;
using OutputHelperLib;

namespace POSTaggedTextToString
{
    public class TaggedText2String : Plugin
    {

        public string[] InputType { get; } = { "TaggerOutputObject" };
        public string OutputType { get; } = "String";

        #region Plugin Details and Info

        public string PluginName { get; } = "Helper: POS-Tagged Text to String";
        public string PluginType { get; } = "POS Taggers";
        public string PluginVersion { get; } = "1.0.2";
        public string PluginAuthor { get; } = "Ryan L. Boyd (ryan@ryanboyd.io)";
        public string PluginDescription { get; } = "This plugin take the output of the CoreNLP Part of Speech Tagger and merges the tagged tokens into a single string. This is a specialized helper that works only as an add-on to the CoreNLP POS Tagger plugin.";
        public bool TopLevel { get; } = false;
        public string PluginTutorial { get; } = "Coming Soon";




        public bool TagsOnly = false;
        public bool InheritHeader { get; } = false;
        public Dictionary<int, string> OutputHeaderData { get; set;  } = new Dictionary<int, string>(){
                                                                                            {0, "TaggedText"}
                                                                                        };

        

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

            using (var form = new SettingsForm_POSTaggedTexttoString(TagsOnly))
            {


                form.Icon = Properties.Resources.icon;
                form.Text = PluginName;

                var result = form.ShowDialog();
                if (result == DialogResult.OK)
                {
                    TagsOnly = form.TagsOnly;
                }
            }

        }





        public Payload RunPlugin(Payload Input)
        {

            Payload pData = new Payload();
            pData.FileID = Input.FileID;
            pData.SegmentID = Input.SegmentID;



            for (int counter = 0; counter < Input.ObjectList.Count; counter++)
                {
                    if (TagsOnly)
                    {
                        pData.StringList.Add(string.Join(" ", ((TaggerOutputObject)Input.ObjectList[counter]).TaggedText_TagsOnly));
                    }
                    else
                    {
                        pData.StringList.Add(string.Join(" ", ((TaggerOutputObject)Input.ObjectList[counter]).TaggedText));
                    }
                    pData.SegmentNumber.Add(Input.SegmentNumber[counter]);

                }

                return(pData);


        }



        public void Initialize() { }


        public bool InspectSettings()
        {
            return true;
        }


        public Payload FinishUp(Payload Input)
        {
            return (Input);
        }



        #region Import/Export Settings
        public void ImportSettings(Dictionary<string, string> SettingsDict)
        {
            TagsOnly = Boolean.Parse(SettingsDict["TagsOnly"]);
        }

        public Dictionary<string, string> ExportSettings(bool suppressWarnings)
        {
            Dictionary<string, string> SettingsDict = new Dictionary<string, string>();
            SettingsDict.Add("TagsOnly", TagsOnly.ToString());
            return (SettingsDict);
        }
        #endregion


    }

}
