namespace EAD_Cwk2_EMoore_W1442006.Views
{
    partial class PayeeEdit
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
            this.CancelButton = new System.Windows.Forms.Button();
            this.SaveAndBackButton = new System.Windows.Forms.Button();
            this.SaveAndNewButton = new System.Windows.Forms.Button();
            this.addressText = new System.Windows.Forms.TextBox();
            this.addressLabel = new System.Windows.Forms.Label();
            this.AccNumberText = new System.Windows.Forms.TextBox();
            this.SortCodeText = new System.Windows.Forms.TextBox();
            this.NameText = new System.Windows.Forms.TextBox();
            this.AccNumberLabel = new System.Windows.Forms.Label();
            this.SortCodeLabel = new System.Windows.Forms.Label();
            this.NameLabel = new System.Windows.Forms.Label();
            this.PayeeCombobox = new System.Windows.Forms.ComboBox();
            this.PayeeLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // CancelButton
            // 
            this.CancelButton.Location = new System.Drawing.Point(13, 13);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(89, 23);
            this.CancelButton.TabIndex = 5;
            this.CancelButton.Text = "Cancel";
            this.CancelButton.UseVisualStyleBackColor = true;
            // 
            // SaveAndBackButton
            // 
            this.SaveAndBackButton.Location = new System.Drawing.Point(12, 42);
            this.SaveAndBackButton.Name = "SaveAndBackButton";
            this.SaveAndBackButton.Size = new System.Drawing.Size(90, 23);
            this.SaveAndBackButton.TabIndex = 6;
            this.SaveAndBackButton.Text = "Save and back";
            this.SaveAndBackButton.UseVisualStyleBackColor = true;
            // 
            // SaveAndNewButton
            // 
            this.SaveAndNewButton.Location = new System.Drawing.Point(13, 72);
            this.SaveAndNewButton.Name = "SaveAndNewButton";
            this.SaveAndNewButton.Size = new System.Drawing.Size(89, 23);
            this.SaveAndNewButton.TabIndex = 7;
            this.SaveAndNewButton.Text = "Save and new";
            this.SaveAndNewButton.UseVisualStyleBackColor = true;
            // 
            // addressText
            // 
            this.addressText.Location = new System.Drawing.Point(411, 202);
            this.addressText.Name = "addressText";
            this.addressText.Size = new System.Drawing.Size(100, 20);
            this.addressText.TabIndex = 2;
            // 
            // addressLabel
            // 
            this.addressLabel.AutoSize = true;
            this.addressLabel.Location = new System.Drawing.Point(357, 205);
            this.addressLabel.Name = "addressLabel";
            this.addressLabel.Size = new System.Drawing.Size(48, 13);
            this.addressLabel.TabIndex = 20;
            this.addressLabel.Text = "Address:";
            // 
            // AccNumberText
            // 
            this.AccNumberText.Location = new System.Drawing.Point(411, 255);
            this.AccNumberText.MaxLength = 8;
            this.AccNumberText.Name = "AccNumberText";
            this.AccNumberText.Size = new System.Drawing.Size(100, 20);
            this.AccNumberText.TabIndex = 4;
            // 
            // SortCodeText
            // 
            this.SortCodeText.Location = new System.Drawing.Point(411, 228);
            this.SortCodeText.MaxLength = 6;
            this.SortCodeText.Name = "SortCodeText";
            this.SortCodeText.Size = new System.Drawing.Size(100, 20);
            this.SortCodeText.TabIndex = 3;
            // 
            // NameText
            // 
            this.NameText.Location = new System.Drawing.Point(411, 176);
            this.NameText.Name = "NameText";
            this.NameText.Size = new System.Drawing.Size(100, 20);
            this.NameText.TabIndex = 1;
            // 
            // AccNumberLabel
            // 
            this.AccNumberLabel.AutoSize = true;
            this.AccNumberLabel.Location = new System.Drawing.Point(317, 258);
            this.AccNumberLabel.Name = "AccNumberLabel";
            this.AccNumberLabel.Size = new System.Drawing.Size(88, 13);
            this.AccNumberLabel.TabIndex = 16;
            this.AccNumberLabel.Text = "Account number:";
            // 
            // SortCodeLabel
            // 
            this.SortCodeLabel.AutoSize = true;
            this.SortCodeLabel.Location = new System.Drawing.Point(349, 231);
            this.SortCodeLabel.Name = "SortCodeLabel";
            this.SortCodeLabel.Size = new System.Drawing.Size(56, 13);
            this.SortCodeLabel.TabIndex = 15;
            this.SortCodeLabel.Text = "Sort code:";
            // 
            // NameLabel
            // 
            this.NameLabel.AutoSize = true;
            this.NameLabel.Location = new System.Drawing.Point(367, 179);
            this.NameLabel.Name = "NameLabel";
            this.NameLabel.Size = new System.Drawing.Size(38, 13);
            this.NameLabel.TabIndex = 14;
            this.NameLabel.Text = "Name:";
            // 
            // PayeeCombobox
            // 
            this.PayeeCombobox.FormattingEnabled = true;
            this.PayeeCombobox.Location = new System.Drawing.Point(411, 43);
            this.PayeeCombobox.Name = "PayeeCombobox";
            this.PayeeCombobox.Size = new System.Drawing.Size(121, 21);
            this.PayeeCombobox.TabIndex = 0;
            // 
            // PayeeLabel
            // 
            this.PayeeLabel.AutoSize = true;
            this.PayeeLabel.Location = new System.Drawing.Point(368, 46);
            this.PayeeLabel.Name = "PayeeLabel";
            this.PayeeLabel.Size = new System.Drawing.Size(37, 13);
            this.PayeeLabel.TabIndex = 23;
            this.PayeeLabel.Text = "Payee";
            // 
            // PayeeEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.PayeeLabel);
            this.Controls.Add(this.PayeeCombobox);
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
            this.Name = "PayeeEdit";
            this.Text = "PayeeEdit";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button CancelButton;
        private System.Windows.Forms.Button SaveAndBackButton;
        private System.Windows.Forms.Button SaveAndNewButton;
        private System.Windows.Forms.Label addressLabel;
        private System.Windows.Forms.Label AccNumberLabel;
        private System.Windows.Forms.Label SortCodeLabel;
        private System.Windows.Forms.Label NameLabel;
        private System.Windows.Forms.Label PayeeLabel;
        public System.Windows.Forms.TextBox addressText;
        public System.Windows.Forms.TextBox AccNumberText;
        public System.Windows.Forms.TextBox SortCodeText;
        public System.Windows.Forms.TextBox NameText;
        public System.Windows.Forms.ComboBox PayeeCombobox;
    }
}