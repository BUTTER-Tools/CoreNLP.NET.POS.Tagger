using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using PluginContracts;
using TaggerOutputObjectLibrary;
using OutputHelperLib;

namespace POSTagCategoryCounts
{
    public class POSTagCategoryCounts : Plugin
    {


        public string[] InputType { get; } = { "TaggerOutputObject" };
        public string OutputType { get; } = "OutputArray";

        #region Plugin Details and Info

        public string PluginName { get; } = "Helper: POS Tag Category Frequencies";
        public string PluginType { get; } = "POS Taggers";
        public string PluginVersion { get; } = "1.0.1";
        public string PluginAuthor { get; } = "Ryan L. Boyd (ryan@ryanboyd.io)";
        public string PluginDescription { get; } = "This plugin takes the output of the CoreNLP POS Tagger and converts it into an array of POS category counts. This array can be passed to a \"Save Output to CSV\" plugin. This is a specialized helper that works only as an add-on to the CoreNLP POS Tagger plugin.";
        public bool TopLevel { get; } = false;
        public string PluginTutorial { get; } = "Coming Soon";
        public bool RawCounts = false;
        public Dictionary<int, string> OutputHeaderData { get; set;  }
        public bool InheritHeader { get; } = true;



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

            using (var form = new SettingsForm_POSTagCategoryCounts(RawCounts))
            {


                form.Icon = Properties.Resources.icon;
                form.Text = PluginName;

                var result = form.ShowDialog();
                if (result == DialogResult.OK)
                {
                    RawCounts = form.RawCount;
                }
            }

        }





        public Payload RunPlugin(Payload Input)
        {

            Payload pData = new Payload();
            pData.FileID = Input.FileID;
            pData.SegmentID = Input.SegmentID;

            //Dictionary<int, string> ModelTags { get; set; }
            //Dictionary<string, int> POSSums = new Dictionary<string, int>();



            for (int counter = 0; counter < Input.ObjectList.Count; counter++)
                {


                    string[] OutputArray = new string[((TaggerOutputObject)Input.ObjectList[counter]).ModelTags.Count + 2];
                    OutputArray[0] = ((TaggerOutputObject)Input.ObjectList[counter]).TotalWC.ToString();
                    OutputArray[1] = ((TaggerOutputObject)Input.ObjectList[counter]).TotalSentences.ToString();

                    for (int i = 0; i < ((TaggerOutputObject)Input.ObjectList[counter]).ModelTags.Count; i++)
                    {
                        if (RawCounts)
                        {
                            OutputArray[i + 2] = ((TaggerOutputObject)Input.ObjectList[counter]).
                            POSSums[((TaggerOutputObject)Input.ObjectList[counter]).ModelTags[i]].ToString();
                        }
                        else
                        {
                            if (((TaggerOutputObject)Input.ObjectList[counter]).TotalWC > 0)
                                OutputArray[i + 2] = ((((TaggerOutputObject)Input.ObjectList[counter]).
                                POSSums[((TaggerOutputObject)Input.ObjectList[counter]).ModelTags[i]] / (double)((TaggerOutputObject)Input.ObjectList[counter]).TotalWC) * 100).ToString();
                        }
                    }

                    pData.StringArrayList.Add(OutputArray);
                    pData.SegmentNumber.Add(Input.SegmentNumber[counter]);

                }

                 return (pData);


        }



        public void Initialize() {}



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
            RawCounts = Boolean.Parse(SettingsDict["RawCounts"]);
        }

        public Dictionary<string, string> ExportSettings(bool suppressWarnings)
        {
            Dictionary<string, string> SettingsDict = new Dictionary<string, string>();
            SettingsDict.Add("RawCounts", RawCounts.ToString());
            return (SettingsDict);
        }
        #endregion


    }

}
