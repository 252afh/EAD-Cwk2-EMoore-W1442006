namespace EAD_Cwk2_EMoore_W1442006.Views
{
    partial class PayersEdit
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
            this.PaymentTypeLabel = new System.Windows.Forms.Label();
            this.PaymentTypeText = new System.Windows.Forms.TextBox();
            this.NameText = new System.Windows.Forms.TextBox();
            this.nameLabel = new System.Windows.Forms.Label();
            this.PayerLabel = new System.Windows.Forms.Label();
            this.PayerCombobox = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // SaveAndNewButton
            // 
            this.SaveAndNewButton.Location = new System.Drawing.Point(12, 71);
            this.SaveAndNewButton.Name = "SaveAndNewButton";
            this.SaveAndNewButton.Size = new System.Drawing.Size(89, 23);
            this.SaveAndNewButton.TabIndex = 5;
            this.SaveAndNewButton.Text = "Save and new";
            this.SaveAndNewButton.UseVisualStyleBackColor = true;
            // 
            // SaveAndBackButton
            // 
            this.SaveAndBackButton.Location = new System.Drawing.Point(11, 41);
            this.SaveAndBackButton.Name = "SaveAndBackButton";
            this.SaveAndBackButton.Size = new System.Drawing.Size(90, 23);
            this.SaveAndBackButton.TabIndex = 4;
            this.SaveAndBackButton.Text = "Save and back";
            this.SaveAndBackButton.UseVisualStyleBackColor = true;
            // 
            // CancelButton
            // 
            this.CancelButton.Location = new System.Drawing.Point(12, 12);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(89, 23);
            this.CancelButton.TabIndex = 3;
            this.CancelButton.Text = "Cancel";
            this.CancelButton.UseVisualStyleBackColor = true;
            // 
            // PaymentTypeLabel
            // 
            this.PaymentTypeLabel.AutoSize = true;
            this.PaymentTypeLabel.Location = new System.Drawing.Point(312, 232);
            this.PaymentTypeLabel.Name = "PaymentTypeLabel";
            this.PaymentTypeLabel.Size = new System.Drawing.Size(74, 13);
            this.PaymentTypeLabel.TabIndex = 13;
            this.PaymentTypeLabel.Text = "Payment type:";
            // 
            // PaymentTypeText
            // 
            this.PaymentTypeText.Location = new System.Drawing.Point(389, 229);
            this.PaymentTypeText.Name = "PaymentTypeText";
            this.PaymentTypeText.Size = new System.Drawing.Size(100, 20);
            this.PaymentTypeText.TabIndex = 2;
            // 
            // NameText
            // 
            this.NameText.Location = new System.Drawing.Point(389, 202);
            this.NameText.Name = "NameText";
            this.NameText.Size = new System.Drawing.Size(100, 20);
            this.NameText.TabIndex = 1;
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.Location = new System.Drawing.Point(345, 205);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(38, 13);
            this.nameLabel.TabIndex = 10;
            this.nameLabel.Text = "Name:";
            // 
            // PayerLabel
            // 
            this.PayerLabel.AutoSize = true;
            this.PayerLabel.Location = new System.Drawing.Point(349, 46);
            this.PayerLabel.Name = "PayerLabel";
            this.PayerLabel.Size = new System.Drawing.Size(34, 13);
            this.PayerLabel.TabIndex = 25;
            this.PayerLabel.Text = "Payer";
            // 
            // PayerCombobox
            // 
            this.PayerCombobox.FormattingEnabled = true;
            this.PayerCombobox.Location = new System.Drawing.Point(389, 43);
            this.PayerCombobox.Name = "PayerCombobox";
            this.PayerCombobox.Size = new System.Drawing.Size(121, 21);
            this.PayerCombobox.TabIndex = 0;
            // 
            // PayersEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.PayerLabel);
            this.Controls.Add(this.PayerCombobox);
            this.Controls.Add(this.PaymentTypeLabel);
            this.Controls.Add(this.PaymentTypeText);
            this.Controls.Add(this.NameText);
            this.Controls.Add(this.nameLabel);
            this.Controls.Add(this.SaveAndNewButton);
            this.Controls.Add(this.SaveAndBackButton);
            this.Controls.Add(this.CancelButton);
            this.Name = "PayersEdit";
            this.Text = "PayersEdit";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button SaveAndNewButton;
        private System.Windows.Forms.Button SaveAndBackButton;
        private System.Windows.Forms.Button CancelButton;
        private System.Windows.Forms.Label PaymentTypeLabel;
        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.Label PayerLabel;
        public System.Windows.Forms.TextBox NameText;
        public System.Windows.Forms.TextBox PaymentTypeText;
        public System.Windows.Forms.ComboBox PayerCombobox;
    }
}