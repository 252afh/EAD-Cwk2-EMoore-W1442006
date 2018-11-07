namespace EAD_Cwk2_EMoore_W1442006.Views
{
    partial class MainMenuForm
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
            this.ViewPayeeButton = new System.Windows.Forms.Button();
            this.ViewPayersButton = new System.Windows.Forms.Button();
            this.ViewExpensesButton = new System.Windows.Forms.Button();
            this.ViewIncomeButton = new System.Windows.Forms.Button();
            this.ViewReportButton = new System.Windows.Forms.Button();
            this.ViewPredictionButton = new System.Windows.Forms.Button();
            this.balanceLabel = new System.Windows.Forms.Label();
            this.balanceBox = new System.Windows.Forms.TextBox();
            this.SaveButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ViewPayeeButton
            // 
            this.ViewPayeeButton.Location = new System.Drawing.Point(12, 68);
            this.ViewPayeeButton.Name = "ViewPayeeButton";
            this.ViewPayeeButton.Size = new System.Drawing.Size(130, 124);
            this.ViewPayeeButton.TabIndex = 0;
            this.ViewPayeeButton.Text = "View Payees";
            this.ViewPayeeButton.UseVisualStyleBackColor = true;
            this.ViewPayeeButton.Click += new System.EventHandler(this.ViewPayeeButton_Click);
            // 
            // ViewPayersButton
            // 
            this.ViewPayersButton.Location = new System.Drawing.Point(219, 68);
            this.ViewPayersButton.Name = "ViewPayersButton";
            this.ViewPayersButton.Size = new System.Drawing.Size(130, 124);
            this.ViewPayersButton.TabIndex = 1;
            this.ViewPayersButton.Text = "View Payers";
            this.ViewPayersButton.UseVisualStyleBackColor = true;
            this.ViewPayersButton.Click += new System.EventHandler(this.ViewPayersButton_Click);
            // 
            // ViewExpensesButton
            // 
            this.ViewExpensesButton.Location = new System.Drawing.Point(658, 68);
            this.ViewExpensesButton.Name = "ViewExpensesButton";
            this.ViewExpensesButton.Size = new System.Drawing.Size(130, 124);
            this.ViewExpensesButton.TabIndex = 2;
            this.ViewExpensesButton.Text = "View Expenses";
            this.ViewExpensesButton.UseVisualStyleBackColor = true;
            this.ViewExpensesButton.Click += new System.EventHandler(this.ViewExpensesButton_Click);
            // 
            // ViewIncomeButton
            // 
            this.ViewIncomeButton.Location = new System.Drawing.Point(437, 68);
            this.ViewIncomeButton.Name = "ViewIncomeButton";
            this.ViewIncomeButton.Size = new System.Drawing.Size(130, 124);
            this.ViewIncomeButton.TabIndex = 3;
            this.ViewIncomeButton.Text = "View Income";
            this.ViewIncomeButton.UseVisualStyleBackColor = true;
            this.ViewIncomeButton.Click += new System.EventHandler(this.ViewIncomeButton_Click);
            // 
            // ViewReportButton
            // 
            this.ViewReportButton.Location = new System.Drawing.Point(219, 314);
            this.ViewReportButton.Name = "ViewReportButton";
            this.ViewReportButton.Size = new System.Drawing.Size(130, 124);
            this.ViewReportButton.TabIndex = 4;
            this.ViewReportButton.Text = "View Report";
            this.ViewReportButton.UseVisualStyleBackColor = true;
            this.ViewReportButton.Click += new System.EventHandler(this.ViewReportButton_Click);
            // 
            // ViewPredictionButton
            // 
            this.ViewPredictionButton.Location = new System.Drawing.Point(437, 314);
            this.ViewPredictionButton.Name = "ViewPredictionButton";
            this.ViewPredictionButton.Size = new System.Drawing.Size(130, 124);
            this.ViewPredictionButton.TabIndex = 5;
            this.ViewPredictionButton.Text = "View Prediction";
            this.ViewPredictionButton.UseVisualStyleBackColor = true;
            this.ViewPredictionButton.Click += new System.EventHandler(this.ViewPredictionButton_Click);
            // 
            // balanceLabel
            // 
            this.balanceLabel.AutoSize = true;
            this.balanceLabel.Location = new System.Drawing.Point(633, 27);
            this.balanceLabel.Name = "balanceLabel";
            this.balanceLabel.Size = new System.Drawing.Size(49, 13);
            this.balanceLabel.TabIndex = 6;
            this.balanceLabel.Text = "Balance:";
            // 
            // balanceBox
            // 
            this.balanceBox.Location = new System.Drawing.Point(688, 24);
            this.balanceBox.Name = "balanceBox";
            this.balanceBox.Size = new System.Drawing.Size(100, 20);
            this.balanceBox.TabIndex = 7;
            // 
            // SaveButton
            // 
            this.SaveButton.Location = new System.Drawing.Point(22, 16);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(75, 23);
            this.SaveButton.TabIndex = 8;
            this.SaveButton.Text = "Save";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // MainMenuForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.balanceBox);
            this.Controls.Add(this.balanceLabel);
            this.Controls.Add(this.ViewPredictionButton);
            this.Controls.Add(this.ViewReportButton);
            this.Controls.Add(this.ViewIncomeButton);
            this.Controls.Add(this.ViewExpensesButton);
            this.Controls.Add(this.ViewPayersButton);
            this.Controls.Add(this.ViewPayeeButton);
            this.Name = "MainMenuForm";
            this.Text = "Main Menu";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ViewPayeeButton;
        private System.Windows.Forms.Button ViewPayersButton;
        private System.Windows.Forms.Button ViewExpensesButton;
        private System.Windows.Forms.Button ViewIncomeButton;
        private System.Windows.Forms.Button ViewReportButton;
        private System.Windows.Forms.Button ViewPredictionButton;
        private System.Windows.Forms.Label balanceLabel;
        private System.Windows.Forms.TextBox balanceBox;
        private System.Windows.Forms.Button SaveButton;
    }
}

