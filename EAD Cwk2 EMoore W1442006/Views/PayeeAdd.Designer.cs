namespace EAD_Cwk2_EMoore_W1442006.Views
{
    partial class PayeeAdd
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
            this.SaveAndNewButton = new System.Windows.Forms.Button();
            this.SaveAndBackButton = new System.Windows.Forms.Button();
            this.CancelButton = new System.Windows.Forms.Button();
            this.NameLabel = new System.Windows.Forms.Label();
            this.SortCodeLabel = new System.Windows.Forms.Label();
            this.AccNumberLabel = new System.Windows.Forms.Label();
            this.NameText = new System.Windows.Forms.TextBox();
            this.SortCodeText = new System.Windows.Forms.TextBox();
            this.AccNumberText = new System.Windows.Forms.TextBox();
            this.addressLabel = new System.Windows.Forms.Label();
            this.addressText = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // SaveAndNewButton
            // 
            this.SaveAndNewButton.Location = new System.Drawing.Point(12, 71);
            this.SaveAndNewButton.Name = "SaveAndNewButton";
            this.SaveAndNewButton.Size = new System.Drawing.Size(89, 23);
            this.SaveAndNewButton.TabIndex = 6;
            this.SaveAndNewButton.Text = "Save and new";
            this.SaveAndNewButton.UseVisualStyleBackColor = true;
            // 
            // SaveAndBackButton
            // 
            this.SaveAndBackButton.Location = new System.Drawing.Point(11, 41);
            this.SaveAndBackButton.Name = "SaveAndBackButton";
            this.SaveAndBackButton.Size = new System.Drawing.Size(90, 23);
            this.SaveAndBackButton.TabIndex = 5;
            this.SaveAndBackButton.Text = "Save and back";
            this.SaveAndBackButton.UseVisualStyleBackColor = true;
            // 
            // CancelButton
            // 
            this.CancelButton.Location = new System.Drawing.Point(12, 12);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(89, 23);
            this.CancelButton.TabIndex = 4;
            this.CancelButton.Text = "Cancel";
            this.CancelButton.UseVisualStyleBackColor = true;
            // 
            // NameLabel
            // 
            this.NameLabel.AutoSize = true;
            this.NameLabel.Location = new System.Drawing.Point(326, 153);
            this.NameLabel.Name = "NameLabel";
            this.NameLabel.Size = new System.Drawing.Size(38, 13);
            this.NameLabel.TabIndex = 6;
            this.NameLabel.Text = "Name:";
            // 
            // SortCodeLabel
            // 
            this.SortCodeLabel.AutoSize = true;
            this.SortCodeLabel.Location = new System.Drawing.Point(308, 205);
            this.SortCodeLabel.Name = "SortCodeLabel";
            this.SortCodeLabel.Size = new System.Drawing.Size(56, 13);
            this.SortCodeLabel.TabIndex = 7;
            this.SortCodeLabel.Text = "Sort code:";
            // 
            // AccNumberLabel
            // 
            this.AccNumberLabel.AutoSize = true;
            this.AccNumberLabel.Location = new System.Drawing.Point(276, 232);
            this.AccNumberLabel.Name = "AccNumberLabel";
            this.AccNumberLabel.Size = new System.Drawing.Size(88, 13);
            this.AccNumberLabel.TabIndex = 8;
            this.AccNumberLabel.Text = "Account number:";
            // 
            // NameText
            // 
            this.NameText.Location = new System.Drawing.Point(397, 150);
            this.NameText.Name = "NameText";
            this.NameText.Size = new System.Drawing.Size(100, 20);
            this.NameText.TabIndex = 0;
            // 
            // SortCodeText
            // 
            this.SortCodeText.Location = new System.Drawing.Point(397, 202);
            this.SortCodeText.MaxLength = 6;
            this.SortCodeText.Name = "SortCodeText";
            this.SortCodeText.Size = new System.Drawing.Size(100, 20);
            this.SortCodeText.TabIndex = 2;
            // 
            // AccNumberText
            // 
            this.AccNumberText.Location = new System.Drawing.Point(397, 229);
            this.AccNumberText.MaxLength = 8;
            this.AccNumberText.Name = "AccNumberText";
            this.AccNumberText.Size = new System.Drawing.Size(100, 20);
            this.AccNumberText.TabIndex = 3;
            // 
            // addressLabel
            // 
            this.addressLabel.AutoSize = true;
            this.addressLabel.Location = new System.Drawing.Point(316, 179);
            this.addressLabel.Name = "addressLabel";
            this.addressLabel.Size = new System.Drawing.Size(48, 13);
            this.addressLabel.TabIndex = 12;
            this.addressLabel.Text = "Address:";
            // 
            // addressText
            // 
            this.addressText.Location = new System.Drawing.Point(397, 176);
            this.addressText.Name = "addressText";
            this.addressText.Size = new System.Drawing.Size(100, 20);
            this.addressText.TabIndex = 1;
            // 
            // PayeeAdd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.addressText);
            this.Controls.Add(this.addressLabel);
            this.Controls.Add(this.AccNumberText);
            this.Controls.Add(this.SortCodeText);
            this.Controls.Add(this.NameText);
            this.Controls.Add(this.AccNumberLabel);
            this.Controls.Add(this.SortCodeLabel);
            this.Controls.Add(this.NameLabel);
            this.Controls.Add(this.SaveAndNewButton);
            this.Controls.Add(this.SaveAndBackButton);
            this.Controls.Add(this.CancelButton);
            this.Name = "PayeeAdd";
            this.Text = "PayeeAdd";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button SaveAndNewButton;
        private System.Windows.Forms.Button SaveAndBackButton;
        private System.Windows.Forms.Button CancelButton;
        private System.Windows.Forms.Label NameLabel;
        private System.Windows.Forms.Label SortCodeLabel;
        private System.Windows.Forms.Label AccNumberLabel;
        private System.Windows.Forms.Label addressLabel;
        public System.Windows.Forms.TextBox NameText;
        public System.Windows.Forms.TextBox SortCodeText;
        public System.Windows.Forms.TextBox AccNumberText;
        public System.Windows.Forms.TextBox addressText;
    }
}