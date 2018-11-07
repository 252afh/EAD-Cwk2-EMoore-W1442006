namespace EAD_Cwk2_EMoore_W1442006.Views
{
    partial class IncomeEdit
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
            this.SuspendLayout();
            // 
            // SaveAndNewButton
            // 
            this.SaveAndNewButton.Location = new System.Drawing.Point(12, 71);
            this.SaveAndNewButton.Name = "SaveAndNewButton";
            this.SaveAndNewButton.Size = new System.Drawing.Size(89, 23);
            this.SaveAndNewButton.TabIndex = 8;
            this.SaveAndNewButton.Text = "Save and new";
            this.SaveAndNewButton.UseVisualStyleBackColor = true;
            // 
            // SaveAndBackButton
            // 
            this.SaveAndBackButton.Location = new System.Drawing.Point(11, 41);
            this.SaveAndBackButton.Name = "SaveAndBackButton";
            this.SaveAndBackButton.Size = new System.Drawing.Size(90, 23);
            this.SaveAndBackButton.TabIndex = 7;
            this.SaveAndBackButton.Text = "Save and back";
            this.SaveAndBackButton.UseVisualStyleBackColor = true;
            // 
            // CancelButton
            // 
            this.CancelButton.Location = new System.Drawing.Point(12, 12);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(89, 23);
            this.CancelButton.TabIndex = 6;
            this.CancelButton.Text = "Cancel";
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // IncomeEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.SaveAndNewButton);
            this.Controls.Add(this.SaveAndBackButton);
            this.Controls.Add(this.CancelButton);
            this.Name = "IncomeEdit";
            this.Text = "IncomeEdit";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button SaveAndNewButton;
        private System.Windows.Forms.Button SaveAndBackButton;
        private System.Windows.Forms.Button CancelButton;
    }
}