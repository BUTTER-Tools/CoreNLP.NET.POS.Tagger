namespace POSTagCategoryCounts
{
    partial class SettingsForm_POSTagCategoryCounts
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.OKButton = new System.Windows.Forms.Button();
            this.RawCountRadio = new System.Windows.Forms.RadioButton();
            this.RelativeFrequencyRadio = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // OKButton
            // 
            this.OKButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OKButton.Location = new System.Drawing.Point(153, 143);
            this.OKButton.Name = "OKButton";
            this.OKButton.Size = new System.Drawing.Size(118, 40);
            this.OKButton.TabIndex = 7;
            this.OKButton.Text = "OK";
            this.OKButton.UseVisualStyleBackColor = true;
            this.OKButton.Click += new System.EventHandler(this.OKButton_Click);
            // 
            // RawCountRadio
            // 
            this.RawCountRadio.AutoSize = true;
            this.RawCountRadio.Checked = true;
            this.RawCountRadio.Font = new System.Drawing.Font("MS Reference Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RawCountRadio.Location = new System.Drawing.Point(39, 59);
            this.RawCountRadio.Name = "RawCountRadio";
            this.RawCountRadio.Size = new System.Drawing.Size(249, 20);
            this.RawCountRadio.TabIndex = 8;
            this.RawCountRadio.TabStop = true;
            this.RawCountRadio.Text = "Convert POS Tags to Raw Counts";
            this.RawCountRadio.UseVisualStyleBackColor = true;
            // 
            // RelativeFrequencyRadio
            // 
            this.RelativeFrequencyRadio.AutoSize = true;
            this.RelativeFrequencyRadio.Font = new System.Drawing.Font("MS Reference Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RelativeFrequencyRadio.Location = new System.Drawing.Point(39, 95);
            this.RelativeFrequencyRadio.Name = "RelativeFrequencyRadio";
            this.RelativeFrequencyRadio.Size = new System.Drawing.Size(307, 20);
            this.RelativeFrequencyRadio.TabIndex = 9;
            this.RelativeFrequencyRadio.Text = "Convert POS Tags to Relative Frequencies";
            this.RelativeFrequencyRadio.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("MS Reference Sans Serif", 9.75F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(36, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(324, 16);
            this.label1.TabIndex = 10;
            this.label1.Text = "How would you like to format your POS counts?";
            // 
            // SettingsForm_POSTagCategoryCounts
            // 
            this.AcceptButton = this.OKButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(424, 194);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.RelativeFrequencyRadio);
            this.Controls.Add(this.RawCountRadio);
            this.Controls.Add(this.OKButton);
            this.Name = "SettingsForm_POSTagCategoryCounts";
            this.Text = "SettingsForm_POSTaggedTexttoString";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button OKButton;
        private System.Windows.Forms.RadioButton RawCountRadio;
        private System.Windows.Forms.RadioButton RelativeFrequencyRadio;
        private System.Windows.Forms.Label label1;
    }
}