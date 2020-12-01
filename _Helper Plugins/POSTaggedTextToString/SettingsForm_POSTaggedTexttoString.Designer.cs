namespace POSTaggedTextToString
{
    partial class SettingsForm_POSTaggedTexttoString
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
            this.POSTaggedTextRadio = new System.Windows.Forms.RadioButton();
            this.POSTTagsOnlyRadio = new System.Windows.Forms.RadioButton();
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
            // POSTaggedTextRadio
            // 
            this.POSTaggedTextRadio.AutoSize = true;
            this.POSTaggedTextRadio.Checked = true;
            this.POSTaggedTextRadio.Font = new System.Drawing.Font("MS Reference Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.POSTaggedTextRadio.Location = new System.Drawing.Point(39, 59);
            this.POSTaggedTextRadio.Name = "POSTaggedTextRadio";
            this.POSTaggedTextRadio.Size = new System.Drawing.Size(141, 20);
            this.POSTaggedTextRadio.TabIndex = 8;
            this.POSTaggedTextRadio.TabStop = true;
            this.POSTaggedTextRadio.Text = "POS-tagged Text";
            this.POSTaggedTextRadio.UseVisualStyleBackColor = true;
            // 
            // POSTTagsOnlyRadio
            // 
            this.POSTTagsOnlyRadio.AutoSize = true;
            this.POSTTagsOnlyRadio.Font = new System.Drawing.Font("MS Reference Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.POSTTagsOnlyRadio.Location = new System.Drawing.Point(39, 95);
            this.POSTTagsOnlyRadio.Name = "POSTTagsOnlyRadio";
            this.POSTTagsOnlyRadio.Size = new System.Drawing.Size(124, 20);
            this.POSTTagsOnlyRadio.TabIndex = 9;
            this.POSTTagsOnlyRadio.Text = "POS Tags Only";
            this.POSTTagsOnlyRadio.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("MS Reference Sans Serif", 9.75F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(39, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(297, 16);
            this.label1.TabIndex = 10;
            this.label1.Text = "What would you like to convert to a string?";
            // 
            // SettingsForm_POSTaggedTexttoString
            // 
            this.AcceptButton = this.OKButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(424, 194);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.POSTTagsOnlyRadio);
            this.Controls.Add(this.POSTaggedTextRadio);
            this.Controls.Add(this.OKButton);
            this.Name = "SettingsForm_POSTaggedTexttoString";
            this.Text = "SettingsForm_POSTaggedTexttoString";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button OKButton;
        private System.Windows.Forms.RadioButton POSTaggedTextRadio;
        private System.Windows.Forms.RadioButton POSTTagsOnlyRadio;
        private System.Windows.Forms.Label label1;
    }
}