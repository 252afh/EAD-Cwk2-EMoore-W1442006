namespace EAD_Cwk2_EMoore_W1442006.Views
{
    partial class Report
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
            this.TotalIncomeLabel = new System.Windows.Forms.Label();
            this.TotalIncomeText = new System.Windows.Forms.TextBox();
            this.TotalExpenseText = new System.Windows.Forms.TextBox();
            this.TotalExpensesLabel = new System.Windows.Forms.Label();
            this.IncomeCountText = new System.Windows.Forms.TextBox();
            this.CountOfIncomeLabel = new System.Windows.Forms.Label();
            this.ExpenseCountText = new System.Windows.Forms.TextBox();
            this.CountOfExpensesLabel = new System.Windows.Forms.Label();
            this.BalanceText = new System.Windows.Forms.TextBox();
            this.BalanceLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // BackButton
            // 
            this.BackButton.Location = new System.Drawing.Point(13, 13);
            this.BackButton.Name = "BackButton";
            this.BackButton.Size = new System.Drawing.Size(84, 23);
            this.BackButton.TabIndex = 0;
            this.BackButton.Text = "Back to menu";
            this.BackButton.UseVisualStyleBackColor = true;
            // 
            // TotalIncomeLabel
            // 
            this.TotalIncomeLabel.AutoSize = true;
            this.TotalIncomeLabel.Location = new System.Drawing.Point(147, 162);
            this.TotalIncomeLabel.Name = "TotalIncomeLabel";
            this.TotalIncomeLabel.Size = new System.Drawing.Size(71, 13);
            this.TotalIncomeLabel.TabIndex = 1;
            this.TotalIncomeLabel.Text = "Total income:";
            // 
            // TotalIncomeText
            // 
            this.TotalIncomeText.Location = new System.Drawing.Point(224, 159);
            this.TotalIncomeText.Name = "TotalIncomeText";
            this.TotalIncomeText.Size = new System.Drawing.Size(100, 20);
            this.TotalIncomeText.TabIndex = 2;
            // 
            // TotalExpenseText
            // 
            this.TotalExpenseText.Location = new System.Drawing.Point(224, 185);
            this.TotalExpenseText.Name = "TotalExpenseText";
            this.TotalExpenseText.Size = new System.Drawing.Size(100, 20);
            this.TotalExpenseText.TabIndex = 4;
            // 
            // TotalExpensesLabel
            // 
            this.TotalExpensesLabel.AutoSize = true;
            this.TotalExpensesLabel.Location = new System.Drawing.Point(136, 188);
            this.TotalExpensesLabel.Name = "TotalExpensesLabel";
            this.TotalExpensesLabel.Size = new System.Drawing.Size(82, 13);
            this.TotalExpensesLabel.TabIndex = 3;
            this.TotalExpensesLabel.Text = "Total expenses:";
            // 
            // IncomeCountText
            // 
            this.IncomeCountText.Location = new System.Drawing.Point(224, 211);
            this.IncomeCountText.Name = "IncomeCountText";
            this.IncomeCountText.Size = new System.Drawing.Size(100, 20);
            this.IncomeCountText.TabIndex = 6;
            // 
            // CountOfIncomeLabel
            // 
            this.CountOfIncomeLabel.AutoSize = true;
            this.CountOfIncomeLabel.Location = new System.Drawing.Point(131, 214);
            this.CountOfIncomeLabel.Name = "CountOfIncomeLabel";
            this.CountOfIncomeLabel.Size = new System.Drawing.Size(87, 13);
            this.CountOfIncomeLabel.TabIndex = 5;
            this.CountOfIncomeLabel.Text = "Count of income:";
            // 
            // ExpenseCountText
            // 
            this.ExpenseCountText.Location = new System.Drawing.Point(224, 237);
            this.ExpenseCountText.Name = "ExpenseCountText";
            this.ExpenseCountText.Size = new System.Drawing.Size(100, 20);
            this.ExpenseCountText.TabIndex = 8;
            // 
            // CountOfExpensesLabel
            // 
            this.CountOfExpensesLabel.AutoSize = true;
            this.CountOfExpensesLabel.Location = new System.Drawing.Point(120, 240);
            this.CountOfExpensesLabel.Name = "CountOfExpensesLabel";
            this.CountOfExpensesLabel.Size = new System.Drawing.Size(98, 13);
            this.CountOfExpensesLabel.TabIndex = 7;
            this.CountOfExpensesLabel.Text = "Count of expenses:";
            // 
            // BalanceText
            // 
            this.BalanceText.Location = new System.Drawing.Point(629, 36);
            this.BalanceText.Name = "BalanceText";
            this.BalanceText.Size = new System.Drawing.Size(100, 20);
            this.BalanceText.TabIndex = 10;
            // 
            // BalanceLabel
            // 
            this.BalanceLabel.AutoSize = true;
            this.BalanceLabel.Location = new System.Drawing.Point(574, 39);
            this.BalanceLabel.Name = "BalanceLabel";
            this.BalanceLabel.Size = new System.Drawing.Size(49, 13);
            this.BalanceLabel.TabIndex = 9;
            this.BalanceLabel.Text = "Balance:";
            // 
            // Report
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.BalanceText);
            this.Controls.Add(this.BalanceLabel);
            this.Controls.Add(this.ExpenseCountText);
            this.Controls.Add(this.CountOfExpensesLabel);
            this.Controls.Add(this.IncomeCountText);
            this.Controls.Add(this.CountOfIncomeLabel);
            this.Controls.Add(this.TotalExpenseText);
            this.Controls.Add(this.TotalExpensesLabel);
            this.Controls.Add(this.TotalIncomeText);
            this.Controls.Add(this.TotalIncomeLabel);
            this.Controls.Add(this.BackButton);
            this.Name = "Report";
            this.Text = "Report";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BackButton;
        private System.Windows.Forms.Label TotalIncomeLabel;
        private System.Windows.Forms.Label TotalExpensesLabel;
        private System.Windows.Forms.Label CountOfIncomeLabel;
        private System.Windows.Forms.Label CountOfExpensesLabel;
        private System.Windows.Forms.Label BalanceLabel;
        public System.Windows.Forms.TextBox TotalIncomeText;
        public System.Windows.Forms.TextBox TotalExpenseText;
        public System.Windows.Forms.TextBox IncomeCountText;
        public System.Windows.Forms.TextBox ExpenseCountText;
        public System.Windows.Forms.TextBox BalanceText;
    }
}