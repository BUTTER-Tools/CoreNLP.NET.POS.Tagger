using System.IO;
using System.Windows.Forms;

namespace CoreNLPPOSTagger
{
    internal partial class SettingsForm_CoreNLPNET : Form
    {


        #region Get and Set Options

        public string SelectedModel { get; set; }

       #endregion



        public SettingsForm_CoreNLPNET(string SelectedModel, string ModelsDirectory)
        {
            InitializeComponent();

            DirectoryInfo d = new DirectoryInfo(ModelsDirectory);

            foreach (var file in d.GetFiles("*.*"))
            {
                if (file.Name.EndsWith(".tagger") || file.Name.EndsWith(".model")) ModelSelectionBox.Items.Add(file.Name);
            }

            try
            {
                ModelSelectionBox.SelectedIndex = ModelSelectionBox.FindStringExact(SelectedModel);
            }
            catch
            {
                ModelSelectionBox.SelectedIndex = 0;
            }


        }



       

        private void OKButton_Click(object sender, System.EventArgs e)
        {
            this.SelectedModel = ModelSelectionBox.SelectedItem.ToString();
            this.DialogResult = DialogResult.OK;
        }
    }
}
