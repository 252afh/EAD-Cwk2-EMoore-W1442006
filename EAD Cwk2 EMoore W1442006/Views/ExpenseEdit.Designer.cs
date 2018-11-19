namespace EAD_Cwk2_EMoore_W1442006.Views
{
    partial class ExpenseEdit
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
            this.ExpenseLabel = new System.Windows.Forms.Label();
            this.ExpenseDropDown = new System.Windows.Forms.ComboBox();
            this.ReferenceText = new System.Windows.Forms.TextBox();
            this.ReferenceLabel = new System.Windows.Forms.Label();
            this.IntervalLabel = new System.Windows.Forms.Label();
            this.IntervalText = new System.Windows.Forms.TextBox();
            this.AmountNumeric = new System.Windows.Forms.NumericUpDown();
            this.AmountLabel = new System.Windows.Forms.Label();
            this.PayeeLabel = new System.Windows.Forms.Label();
            this.PayeeDropDown = new System.Windows.Forms.ComboBox();
            this.StartDateLabel = new System.Windows.Forms.Label();
            this.InitialPaymentDateTime = new System.Windows.Forms.DateTimePicker();
            this.RecurringCheckbox = new System.Windows.Forms.CheckBox();
            this.RecurringLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.AmountNumeric)).BeginInit();
            this.SuspendLayout();
            // 
            // SaveAndNewButton
            // 
            this.SaveAndNewButton.Location = new System.Drawing.Point(12, 71);
            this.SaveAndNewButton.Name = "SaveAndNewButton";
            this.SaveAndNewButton.Size = new System.Drawing.Size(89, 23);
            this.SaveAndNewButton.TabIndex = 9;
            this.SaveAndNewButton.Text = "Save and new";
            this.SaveAndNewButton.UseVisualStyleBackColor = true;
            // 
            // SaveAndBackButton
            // 
            this.SaveAndBackButton.Location = new System.Drawing.Point(11, 41);
            this.SaveAndBackButton.Name = "SaveAndBackButton";
            this.SaveAndBackButton.Size = new System.Drawing.Size(90, 23);
            this.SaveAndBackButton.TabIndex = 8;
            this.SaveAndBackButton.Text = "Save and back";
            this.SaveAndBackButton.UseVisualStyleBackColor = true;
            // 
            // CancelButton
            // 
            this.CancelButton.Location = new System.Drawing.Point(12, 12);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(89, 23);
            this.CancelButton.TabIndex = 7;
            this.CancelButton.Text = "Cancel";
            this.CancelButton.UseVisualStyleBackColor = true;
            // 
            // ExpenseLabel
            // 
            this.ExpenseLabel.AutoSize = true;
            this.ExpenseLabel.Location = new System.Drawing.Point(272, 41);
            this.ExpenseLabel.Name = "ExpenseLabel";
            this.ExpenseLabel.Size = new System.Drawing.Size(48, 13);
            this.ExpenseLabel.TabIndex = 9;
            this.ExpenseLabel.Text = "Expense";
            // 
            // ExpenseDropDown
            // 
            this.ExpenseDropDown.FormattingEnabled = true;
            this.ExpenseDropDown.Location = new System.Drawing.Point(342, 41);
            this.ExpenseDropDown.Name = "ExpenseDropDown";
            this.ExpenseDropDown.Size = new System.Drawing.Size(232, 21);
            this.ExpenseDropDown.TabIndex = 0;
            // 
            // ReferenceText
            // 
            this.ReferenceText.Location = new System.Drawing.Point(342, 143);
            this.ReferenceText.Name = "ReferenceText";
            this.ReferenceText.Size = new System.Drawing.Size(100, 20);
            this.ReferenceText.TabIndex = 1;
            // 
            // ReferenceLabel
            // 
            this.ReferenceLabel.AutoSize = true;
            this.ReferenceLabel.Location = new System.Drawing.Point(276, 146);
            this.ReferenceLabel.Name = "ReferenceLabel";
            this.ReferenceLabel.Size = new System.Drawing.Size(60, 13);
            this.ReferenceLabel.TabIndex = 12;
            this.ReferenceLabel.Text = "Reference:";
            // 
            // IntervalLabel
            // 
            this.IntervalLabel.AutoSize = true;
            this.IntervalLabel.Location = new System.Drawing.Point(210, 292);
            this.IntervalLabel.Name = "IntervalLabel";
            this.IntervalLabel.Size = new System.Drawing.Size(126, 13);
            this.IntervalLabel.TabIndex = 14;
            this.IntervalLabel.Text = "Days between payments:";
            this.IntervalLabel.Visible = false;
            // 
            // IntervalText
            // 
            this.IntervalText.Location = new System.Drawing.Point(342, 289);
            this.IntervalText.Name = "IntervalText";
            this.IntervalText.Size = new System.Drawing.Size(100, 20);
            this.IntervalText.TabIndex = 5;
            this.IntervalText.Visible = false;
            // 
            // AmountNumeric
            // 
            this.AmountNumeric.DecimalPlaces = 2;
            this.AmountNumeric.Location = new System.Drawing.Point(342, 169);
            this.AmountNumeric.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.AmountNumeric.Name = "AmountNumeric";
            this.AmountNumeric.Size = new System.Drawing.Size(100, 20);
            this.AmountNumeric.TabIndex = 2;
            // 
            // AmountLabel
            // 
            this.AmountLabel.AutoSize = true;
            this.AmountLabel.Location = new System.Drawing.Point(278, 171);
            this.AmountLabel.Name = "AmountLabel";
            this.AmountLabel.Size = new System.Drawing.Size(58, 13);
            this.AmountLabel.TabIndex = 16;
            this.AmountLabel.Text = "Amount(£):";
            // 
            // PayeeLabel
            // 
            this.PayeeLabel.AutoSize = true;
            this.PayeeLabel.Location = new System.Drawing.Point(296, 198);
            this.PayeeLabel.Name = "PayeeLabel";
            this.PayeeLabel.Size = new System.Drawing.Size(40, 13);
            this.PayeeLabel.TabIndex = 17;
            this.PayeeLabel.Text = "Payee:";
            // 
            // PayeeDropDown
            // 
            this.PayeeDropDown.FormattingEnabled = true;
            this.PayeeDropDown.Location = new System.Drawing.Point(342, 195);
            this.PayeeDropDown.Name = "PayeeDropDown";
            this.PayeeDropDown.Size = new System.Drawing.Size(121, 21);
            this.PayeeDropDown.TabIndex = 3;
            // 
            // StartDateLabel
            // 
            this.StartDateLabel.AutoSize = true;
            this.StartDateLabel.Location = new System.Drawing.Point(280, 321);
            this.StartDateLabel.Name = "StartDateLabel";
            this.StartDateLabel.Size = new System.Drawing.Size(56, 13);
            this.StartDateLabel.TabIndex = 19;
            this.StartDateLabel.Text = "Start date:";
            this.StartDateLabel.Visible = false;
            // 
            // InitialPaymentDateTime
            // 
            this.InitialPaymentDateTime.Location = new System.Drawing.Point(342, 315);
            this.InitialPaymentDateTime.Name = "InitialPaymentDateTime";
            this.InitialPaymentDateTime.Size = new System.Drawing.Size(200, 20);
            this.InitialPaymentDateTime.TabIndex = 6;
            this.InitialPaymentDateTime.Visible = false;
            // 
            // RecurringCheckbox
            // 
            this.RecurringCheckbox.AutoSize = true;
            this.RecurringCheckbox.Location = new System.Drawing.Point(342, 222);
            this.RecurringCheckbox.Name = "RecurringCheckbox";
            this.RecurringCheckbox.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.RecurringCheckbox.Size = new System.Drawing.Size(15, 14);
            this.RecurringCheckbox.TabIndex = 4;
            this.RecurringCheckbox.UseVisualStyleBackColor = true;
            // 
            // RecurringLabel
            // 
            this.RecurringLabel.AutoSize = true;
            this.RecurringLabel.Location = new System.Drawing.Point(237, 222);
            this.RecurringLabel.Name = "RecurringLabel";
            this.RecurringLabel.Size = new System.Drawing.Size(99, 13);
            this.RecurringLabel.TabIndex = 22;
            this.RecurringLabel.Text = "Recurring payment:";
            // 
            // ExpenseEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.RecurringLabel);
            this.Controls.Add(this.RecurringCheckbox);
            this.Controls.Add(this.InitialPaymentDateTime);
            this.Controls.Add(this.StartDateLabel);
            this.Controls.Add(this.PayeeDropDown);
            this.Controls.Add(this.PayeeLabel);
            this.Controls.Add(this.AmountLabel);
            this.Controls.Add(this.AmountNumeric);
            this.Controls.Add(this.IntervalLabel);
            this.Controls.Add(this.IntervalText);
            this.Controls.Add(this.ReferenceLabel);
            this.Controls.Add(this.ReferenceText);
            this.Controls.Add(this.ExpenseDropDown);
            this.Controls.Add(this.ExpenseLabel);
            this.Controls.Add(this.SaveAndNewButton);
            this.Controls.Add(this.SaveAndBackButton);
            this.Controls.Add(this.CancelButton);
            this.Name = "ExpenseEdit";
            this.Text = "ExpenseEdit";
            ((System.ComponentModel.ISupportInitialize)(this.AmountNumeric)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button SaveAndNewButton;
        private System.Windows.Forms.Button SaveAndBackButton;
        private System.Windows.Forms.Button CancelButton;
        private System.Windows.Forms.Label ExpenseLabel;
        private System.Windows.Forms.Label ReferenceLabel;
        private System.Windows.Forms.Label AmountLabel;
        private System.Windows.Forms.Label PayeeLabel;
        private System.Windows.Forms.Label RecurringLabel;
        public System.Windows.Forms.ComboBox ExpenseDropDown;
        public System.Windows.Forms.TextBox ReferenceText;
        public System.Windows.Forms.TextBox IntervalText;
        public System.Windows.Forms.NumericUpDown AmountNumeric;
        public System.Windows.Forms.ComboBox PayeeDropDown;
        public System.Windows.Forms.DateTimePicker InitialPaymentDateTime;
        public System.Windows.Forms.CheckBox RecurringCheckbox;
        public System.Windows.Forms.Label IntervalLabel;
        public System.Windows.Forms.Label StartDateLabel;
    }
}