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
            this.AmountInput = new System.Windows.Forms.NumericUpDown();
            this.InitialDatePicker = new System.Windows.Forms.DateTimePicker();
            this.InitialLabel = new System.Windows.Forms.Label();
            this.IntervalTextBox = new System.Windows.Forms.TextBox();
            this.PayerDropDown = new System.Windows.Forms.ComboBox();
            this.RecurringCheckbox = new System.Windows.Forms.CheckBox();
            this.IntervalLabel = new System.Windows.Forms.Label();
            this.PayerLabel = new System.Windows.Forms.Label();
            this.RecurringLabel = new System.Windows.Forms.Label();
            this.AmountLabel = new System.Windows.Forms.Label();
            this.ReferenceText = new System.Windows.Forms.TextBox();
            this.ReferenceLabel = new System.Windows.Forms.Label();
            this.IncomeDropDown = new System.Windows.Forms.ComboBox();
            this.ExpenseLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.AmountInput)).BeginInit();
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
            // AmountInput
            // 
            this.AmountInput.DecimalPlaces = 2;
            this.AmountInput.Increment = new decimal(new int[] {
            50,
            0,
            0,
            131072});
            this.AmountInput.Location = new System.Drawing.Point(376, 155);
            this.AmountInput.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.AmountInput.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.AmountInput.Name = "AmountInput";
            this.AmountInput.Size = new System.Drawing.Size(120, 20);
            this.AmountInput.TabIndex = 2;
            this.AmountInput.Value = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            // 
            // InitialDatePicker
            // 
            this.InitialDatePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.InitialDatePicker.Location = new System.Drawing.Point(375, 301);
            this.InitialDatePicker.MaxDate = new System.DateTime(2019, 12, 31, 0, 0, 0, 0);
            this.InitialDatePicker.MinDate = new System.DateTime(2017, 10, 1, 0, 0, 0, 0);
            this.InitialDatePicker.Name = "InitialDatePicker";
            this.InitialDatePicker.Size = new System.Drawing.Size(200, 20);
            this.InitialDatePicker.TabIndex = 6;
            this.InitialDatePicker.Value = new System.DateTime(2018, 10, 27, 17, 51, 8, 0);
            this.InitialDatePicker.Visible = false;
            // 
            // InitialLabel
            // 
            this.InitialLabel.AutoSize = true;
            this.InitialLabel.Location = new System.Drawing.Point(313, 304);
            this.InitialLabel.Name = "InitialLabel";
            this.InitialLabel.Size = new System.Drawing.Size(56, 13);
            this.InitialLabel.TabIndex = 33;
            this.InitialLabel.Text = "Start date:";
            this.InitialLabel.Visible = false;
            // 
            // IntervalTextBox
            // 
            this.IntervalTextBox.Location = new System.Drawing.Point(375, 269);
            this.IntervalTextBox.Name = "IntervalTextBox";
            this.IntervalTextBox.Size = new System.Drawing.Size(100, 20);
            this.IntervalTextBox.TabIndex = 5;
            this.IntervalTextBox.Visible = false;
            // 
            // PayerDropDown
            // 
            this.PayerDropDown.FormattingEnabled = true;
            this.PayerDropDown.Location = new System.Drawing.Point(375, 181);
            this.PayerDropDown.Name = "PayerDropDown";
            this.PayerDropDown.Size = new System.Drawing.Size(121, 21);
            this.PayerDropDown.TabIndex = 3;
            // 
            // RecurringCheckbox
            // 
            this.RecurringCheckbox.AutoSize = true;
            this.RecurringCheckbox.Location = new System.Drawing.Point(375, 211);
            this.RecurringCheckbox.Name = "RecurringCheckbox";
            this.RecurringCheckbox.Size = new System.Drawing.Size(15, 14);
            this.RecurringCheckbox.TabIndex = 4;
            this.RecurringCheckbox.UseVisualStyleBackColor = true;
            // 
            // IntervalLabel
            // 
            this.IntervalLabel.AutoSize = true;
            this.IntervalLabel.Location = new System.Drawing.Point(240, 272);
            this.IntervalLabel.Name = "IntervalLabel";
            this.IntervalLabel.Size = new System.Drawing.Size(126, 13);
            this.IntervalLabel.TabIndex = 29;
            this.IntervalLabel.Text = "Days between payments:";
            this.IntervalLabel.Visible = false;
            // 
            // PayerLabel
            // 
            this.PayerLabel.AutoSize = true;
            this.PayerLabel.Location = new System.Drawing.Point(329, 184);
            this.PayerLabel.Name = "PayerLabel";
            this.PayerLabel.Size = new System.Drawing.Size(37, 13);
            this.PayerLabel.TabIndex = 28;
            this.PayerLabel.Text = "Payer:";
            // 
            // RecurringLabel
            // 
            this.RecurringLabel.AutoSize = true;
            this.RecurringLabel.Location = new System.Drawing.Point(270, 209);
            this.RecurringLabel.Name = "RecurringLabel";
            this.RecurringLabel.Size = new System.Drawing.Size(99, 13);
            this.RecurringLabel.TabIndex = 27;
            this.RecurringLabel.Text = "Recurring payment:";
            // 
            // AmountLabel
            // 
            this.AmountLabel.AutoSize = true;
            this.AmountLabel.Location = new System.Drawing.Point(308, 157);
            this.AmountLabel.Name = "AmountLabel";
            this.AmountLabel.Size = new System.Drawing.Size(61, 13);
            this.AmountLabel.TabIndex = 26;
            this.AmountLabel.Text = "Amount (£):";
            // 
            // ReferenceText
            // 
            this.ReferenceText.Location = new System.Drawing.Point(375, 129);
            this.ReferenceText.Name = "ReferenceText";
            this.ReferenceText.Size = new System.Drawing.Size(153, 20);
            this.ReferenceText.TabIndex = 1;
            // 
            // ReferenceLabel
            // 
            this.ReferenceLabel.AutoSize = true;
            this.ReferenceLabel.Location = new System.Drawing.Point(309, 132);
            this.ReferenceLabel.Name = "ReferenceLabel";
            this.ReferenceLabel.Size = new System.Drawing.Size(60, 13);
            this.ReferenceLabel.TabIndex = 24;
            this.ReferenceLabel.Text = "Reference:";
            // 
            // IncomeDropDown
            // 
            this.IncomeDropDown.FormattingEnabled = true;
            this.IncomeDropDown.Location = new System.Drawing.Point(335, 41);
            this.IncomeDropDown.Name = "IncomeDropDown";
            this.IncomeDropDown.Size = new System.Drawing.Size(232, 21);
            this.IncomeDropDown.TabIndex = 0;
            // 
            // ExpenseLabel
            // 
            this.ExpenseLabel.AutoSize = true;
            this.ExpenseLabel.Location = new System.Drawing.Point(265, 41);
            this.ExpenseLabel.Name = "ExpenseLabel";
            this.ExpenseLabel.Size = new System.Drawing.Size(42, 13);
            this.ExpenseLabel.TabIndex = 36;
            this.ExpenseLabel.Text = "Income";
            // 
            // IncomeEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.IncomeDropDown);
            this.Controls.Add(this.ExpenseLabel);
            this.Controls.Add(this.AmountInput);
            this.Controls.Add(this.InitialDatePicker);
            this.Controls.Add(this.InitialLabel);
            this.Controls.Add(this.IntervalTextBox);
            this.Controls.Add(this.PayerDropDown);
            this.Controls.Add(this.RecurringCheckbox);
            this.Controls.Add(this.IntervalLabel);
            this.Controls.Add(this.PayerLabel);
            this.Controls.Add(this.RecurringLabel);
            this.Controls.Add(this.AmountLabel);
            this.Controls.Add(this.ReferenceText);
            this.Controls.Add(this.ReferenceLabel);
            this.Controls.Add(this.SaveAndNewButton);
            this.Controls.Add(this.SaveAndBackButton);
            this.Controls.Add(this.CancelButton);
            this.Name = "IncomeEdit";
            this.Text = "IncomeEdit";
            ((System.ComponentModel.ISupportInitialize)(this.AmountInput)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button SaveAndNewButton;
        private System.Windows.Forms.Button SaveAndBackButton;
        private System.Windows.Forms.Button CancelButton;
        private System.Windows.Forms.Label PayerLabel;
        private System.Windows.Forms.Label RecurringLabel;
        private System.Windows.Forms.Label AmountLabel;
        private System.Windows.Forms.Label ReferenceLabel;
        private System.Windows.Forms.Label ExpenseLabel;
        public System.Windows.Forms.NumericUpDown AmountInput;
        public System.Windows.Forms.DateTimePicker InitialDatePicker;
        public System.Windows.Forms.Label InitialLabel;
        public System.Windows.Forms.TextBox IntervalTextBox;
        public System.Windows.Forms.ComboBox PayerDropDown;
        public System.Windows.Forms.CheckBox RecurringCheckbox;
        public System.Windows.Forms.Label IntervalLabel;
        public System.Windows.Forms.TextBox ReferenceText;
        public System.Windows.Forms.ComboBox IncomeDropDown;
    }
}