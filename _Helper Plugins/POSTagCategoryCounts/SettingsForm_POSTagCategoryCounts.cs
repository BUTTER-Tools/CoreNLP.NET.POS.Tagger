using System;
using System.Windows.Forms;

namespace POSTagCategoryCounts
{
    internal partial class SettingsForm_POSTagCategoryCounts : Form
    {

        public bool RawCount { get; set; }

        public SettingsForm_POSTagCategoryCounts(bool rawCount)
        {
            InitializeComponent();

            if (rawCount)
            {
                RawCountRadio.Checked = true;
            }
            else
            {
                RelativeFrequencyRadio.Checked = true;
            }

        }

        private void OKButton_Click(object sender, EventArgs e)
        {
            this.RawCount = RawCountRadio.Checked;
            this.DialogResult = DialogResult.OK;
        }

 
    }
}
