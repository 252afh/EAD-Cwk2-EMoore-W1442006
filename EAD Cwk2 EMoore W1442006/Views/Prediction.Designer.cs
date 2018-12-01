namespace EAD_Cwk2_EMoore_W1442006.Views
{
    partial class Prediction
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
            this.BackButton = new System.Windows.Forms.Button();
            this.PredictionLabel = new System.Windows.Forms.Label();
            this.PredictionDatePicker = new System.Windows.Forms.DateTimePicker();
            this.DaysToLabel = new System.Windows.Forms.Label();
            this.DaysToPredictionText = new System.Windows.Forms.TextBox();
            this.OneOffIncomeText = new System.Windows.Forms.TextBox();
            this.RecurringIncomeText = new System.Windows.Forms.TextBox();
            this.OneOffExpensesText = new System.Windows.Forms.TextBox();
            this.RecurringExpensesText = new System.Windows.Forms.TextBox();
            this.OneOffIncomeLabel = new System.Windows.Forms.Label();
            this.RecurringIncomeLabel = new System.Windows.Forms.Label();
            this.OneOffExpenseLabel = new System.Windows.Forms.Label();
            this.RecurringExpensesLabel = new System.Windows.Forms.Label();
            this.BalanceOnDateText = new System.Windows.Forms.TextBox();
            this.BalanceOnDateLabel = new System.Windows.Forms.Label();
            this.IncludeRecurring = new System.Windows.Forms.CheckBox();
            this.PercentageIncreaseLabel = new System.Windows.Forms.Label();
            this.PercentageIncreaseText = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // BackButton
            // 
            this.BackButton.Location = new System.Drawing.Point(13, 13);
            this.BackButton.Name = "BackButton";
            this.BackButton.Size = new System.Drawing.Size(81, 23);
            this.BackButton.TabIndex = 1;
            this.BackButton.Text = "Back to menu";
            this.BackButton.UseVisualStyleBackColor = true;
            // 
            // PredictionLabel
            // 
            this.PredictionLabel.AutoSize = true;
            this.PredictionLabel.Location = new System.Drawing.Point(386, 18);
            this.PredictionLabel.Name = "PredictionLabel";
            this.PredictionLabel.Size = new System.Drawing.Size(80, 13);
            this.PredictionLabel.TabIndex = 1;
            this.PredictionLabel.Text = "Date to predict:";
            // 
            // PredictionDatePicker
            // 
            this.PredictionDatePicker.CustomFormat = "";
            this.PredictionDatePicker.Location = new System.Drawing.Point(472, 16);
            this.PredictionDatePicker.Name = "PredictionDatePicker";
            this.PredictionDatePicker.Size = new System.Drawing.Size(200, 20);
            this.PredictionDatePicker.TabIndex = 0;
            // 
            // DaysToLabel
            // 
            this.DaysToLabel.AutoSize = true;
            this.DaysToLabel.Location = new System.Drawing.Point(254, 117);
            this.DaysToLabel.Name = "DaysToLabel";
            this.DaysToLabel.Size = new System.Drawing.Size(95, 13);
            this.DaysToLabel.TabIndex = 3;
            this.DaysToLabel.Text = "Days to prediction:";
            // 
            // DaysToPredictionText
            // 
            this.DaysToPredictionText.Enabled = false;
            this.DaysToPredictionText.Location = new System.Drawing.Point(355, 114);
            this.DaysToPredictionText.Name = "DaysToPredictionText";
            this.DaysToPredictionText.Size = new System.Drawing.Size(100, 20);
            this.DaysToPredictionText.TabIndex = 4;
            this.DaysToPredictionText.TabStop = false;
            this.DaysToPredictionText.Text = "0";
            // 
            // OneOffIncomeText
            // 
            this.OneOffIncomeText.Enabled = false;
            this.OneOffIncomeText.Location = new System.Drawing.Point(355, 155);
            this.OneOffIncomeText.Name = "OneOffIncomeText";
            this.OneOffIncomeText.Size = new System.Drawing.Size(100, 20);
            this.OneOffIncomeText.TabIndex = 5;
            this.OneOffIncomeText.TabStop = false;
            this.OneOffIncomeText.Text = "0";
            // 
            // RecurringIncomeText
            // 
            this.RecurringIncomeText.Enabled = false;
            this.RecurringIncomeText.Location = new System.Drawing.Point(355, 194);
            this.RecurringIncomeText.Name = "RecurringIncomeText";
            this.RecurringIncomeText.Size = new System.Drawing.Size(100, 20);
            this.RecurringIncomeText.TabIndex = 6;
            this.RecurringIncomeText.TabStop = false;
            this.RecurringIncomeText.Text = "0";
            // 
            // OneOffExpensesText
            // 
            this.OneOffExpensesText.Enabled = false;
            this.OneOffExpensesText.Location = new System.Drawing.Point(355, 235);
            this.OneOffExpensesText.Name = "OneOffExpensesText";
            this.OneOffExpensesText.Size = new System.Drawing.Size(100, 20);
            this.OneOffExpensesText.TabIndex = 7;
            this.OneOffExpensesText.TabStop = false;
            this.OneOffExpensesText.Text = "0";
            // 
            // RecurringExpensesText
            // 
            this.RecurringExpensesText.Enabled = false;
            this.RecurringExpensesText.Location = new System.Drawing.Point(355, 276);
            this.RecurringExpensesText.Name = "RecurringExpensesText";
            this.RecurringExpensesText.Size = new System.Drawing.Size(100, 20);
            this.RecurringExpensesText.TabIndex = 8;
            this.RecurringExpensesText.TabStop = false;
            this.RecurringExpensesText.Text = "0";
            // 
            // OneOffIncomeLabel
            // 
            this.OneOffIncomeLabel.AutoSize = true;
            this.OneOffIncomeLabel.Location = new System.Drawing.Point(267, 158);
            this.OneOffIncomeLabel.Name = "OneOffIncomeLabel";
            this.OneOffIncomeLabel.Size = new System.Drawing.Size(82, 13);
            this.OneOffIncomeLabel.TabIndex = 9;
            this.OneOffIncomeLabel.Text = "One-off income:";
            // 
            // RecurringIncomeLabel
            // 
            this.RecurringIncomeLabel.AutoSize = true;
            this.RecurringIncomeLabel.Location = new System.Drawing.Point(256, 194);
            this.RecurringIncomeLabel.Name = "RecurringIncomeLabel";
            this.RecurringIncomeLabel.Size = new System.Drawing.Size(93, 13);
            this.RecurringIncomeLabel.TabIndex = 10;
            this.RecurringIncomeLabel.Text = "Recurring income:";
            // 
            // OneOffExpenseLabel
            // 
            this.OneOffExpenseLabel.AutoSize = true;
            this.OneOffExpenseLabel.Location = new System.Drawing.Point(256, 238);
            this.OneOffExpenseLabel.Name = "OneOffExpenseLabel";
            this.OneOffExpenseLabel.Size = new System.Drawing.Size(93, 13);
            this.OneOffExpenseLabel.TabIndex = 11;
            this.OneOffExpenseLabel.Text = "One-off expenses:";
            // 
            // RecurringExpensesLabel
            // 
            this.RecurringExpensesLabel.AutoSize = true;
            this.RecurringExpensesLabel.Location = new System.Drawing.Point(244, 279);
            this.RecurringExpensesLabel.Name = "RecurringExpensesLabel";
            this.RecurringExpensesLabel.Size = new System.Drawing.Size(105, 13);
            this.RecurringExpensesLabel.TabIndex = 12;
            this.RecurringExpensesLabel.Text = "Recurring Expenses:";
            // 
            // BalanceOnDateText
            // 
            this.BalanceOnDateText.Location = new System.Drawing.Point(571, 350);
            this.BalanceOnDateText.Name = "BalanceOnDateText";
            this.BalanceOnDateText.Size = new System.Drawing.Size(100, 20);
            this.BalanceOnDateText.TabIndex = 13;
            this.BalanceOnDateText.Text = "0";
            // 
            // BalanceOnDateLabel
            // 
            this.BalanceOnDateLabel.AutoSize = true;
            this.BalanceOnDateLabel.Location = new System.Drawing.Point(477, 353);
            this.BalanceOnDateLabel.Name = "BalanceOnDateLabel";
            this.BalanceOnDateLabel.Size = new System.Drawing.Size(88, 13);
            this.BalanceOnDateLabel.TabIndex = 14;
            this.BalanceOnDateLabel.Text = "Balance on date:";
            // 
            // IncludeRecurring
            // 
            this.IncludeRecurring.AutoSize = true;
            this.IncludeRecurring.Checked = true;
            this.IncludeRecurring.CheckState = System.Windows.Forms.CheckState.Checked;
            this.IncludeRecurring.Location = new System.Drawing.Point(355, 81);
            this.IncludeRecurring.Name = "IncludeRecurring";
            this.IncludeRecurring.Size = new System.Drawing.Size(153, 17);
            this.IncludeRecurring.TabIndex = 15;
            this.IncludeRecurring.Text = "Include recurring payments";
            this.IncludeRecurring.UseVisualStyleBackColor = true;
            // 
            // PercentageIncreaseLabel
            // 
            this.PercentageIncreaseLabel.AutoSize = true;
            this.PercentageIncreaseLabel.Location = new System.Drawing.Point(241, 319);
            this.PercentageIncreaseLabel.Name = "PercentageIncreaseLabel";
            this.PercentageIncreaseLabel.Size = new System.Drawing.Size(108, 13);
            this.PercentageIncreaseLabel.TabIndex = 17;
            this.PercentageIncreaseLabel.Text = "Percentage increase:";
            // 
            // PercentageIncreaseText
            // 
            this.PercentageIncreaseText.Enabled = false;
            this.PercentageIncreaseText.Location = new System.Drawing.Point(355, 316);
            this.PercentageIncreaseText.Name = "PercentageIncreaseText";
            this.PercentageIncreaseText.Size = new System.Drawing.Size(100, 20);
            this.PercentageIncreaseText.TabIndex = 16;
            this.PercentageIncreaseText.TabStop = false;
            this.PercentageIncreaseText.Text = "0";
            // 
            // Prediction
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.PercentageIncreaseLabel);
            this.Controls.Add(this.PercentageIncreaseText);
            this.Controls.Add(this.IncludeRecurring);
            this.Controls.Add(this.BalanceOnDateLabel);
            this.Controls.Add(this.BalanceOnDateText);
            this.Controls.Add(this.RecurringExpensesLabel);
            this.Controls.Add(this.OneOffExpenseLabel);
            this.Controls.Add(this.RecurringIncomeLabel);
            this.Controls.Add(this.OneOffIncomeLabel);
            this.Controls.Add(this.RecurringExpensesText);
            this.Controls.Add(this.OneOffExpensesText);
            this.Controls.Add(this.RecurringIncomeText);
            this.Controls.Add(this.OneOffIncomeText);
            this.Controls.Add(this.DaysToPredictionText);
            this.Controls.Add(this.DaysToLabel);
            this.Controls.Add(this.PredictionDatePicker);
            this.Controls.Add(this.PredictionLabel);
            this.Controls.Add(this.BackButton);
            this.Name = "Prediction";
            this.Text = "Prediction";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BackButton;
        private System.Windows.Forms.Label PredictionLabel;
        private System.Windows.Forms.Label DaysToLabel;
        private System.Windows.Forms.Label OneOffIncomeLabel;
        private System.Windows.Forms.Label RecurringIncomeLabel;
        private System.Windows.Forms.Label OneOffExpenseLabel;
        private System.Windows.Forms.Label RecurringExpensesLabel;
        private System.Windows.Forms.Label BalanceOnDateLabel;
        public System.Windows.Forms.DateTimePicker PredictionDatePicker;
        public System.Windows.Forms.TextBox DaysToPredictionText;
        public System.Windows.Forms.TextBox OneOffIncomeText;
        public System.Windows.Forms.TextBox RecurringIncomeText;
        public System.Windows.Forms.TextBox OneOffExpensesText;
        public System.Windows.Forms.TextBox RecurringExpensesText;
        public System.Windows.Forms.TextBox BalanceOnDateText;
        public System.Windows.Forms.CheckBox IncludeRecurring;
        private System.Windows.Forms.Label PercentageIncreaseLabel;
        public System.Windows.Forms.TextBox PercentageIncreaseText;
    }
}