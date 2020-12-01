using System;
using System.Windows.Forms;

namespace POSTaggedTextToTokens
{
    internal partial class SettingsForm_POSTaggedTextToTokens : Form
    {

        public bool TagsOnly { get; set; }

        public SettingsForm_POSTaggedTextToTokens(bool tagsOnly)
        {
            InitializeComponent();

            if (tagsOnly)
            {
                POSTTagsOnlyRadio.Checked = true;
            }
            else
            {
                POSTaggedTextRadio.Checked = true;
            }

        }

        private void OKButton_Click(object sender, EventArgs e)
        {
            this.TagsOnly = POSTTagsOnlyRadio.Checked;
            this.DialogResult = DialogResult.OK;
        }

 
    }
}
