namespace EAD_Cwk2_EMoore_W1442006.Views
{
    partial class IncomeView
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
            this.listView1 = new System.Windows.Forms.ListView();
            this.BackButton = new System.Windows.Forms.Button();
            this.EditIncomeButton = new System.Windows.Forms.Button();
            this.AddIncomeButton = new System.Windows.Forms.Button();
            this.Amount = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.PayerName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.PayerType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Recurring = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SetUpDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Reference = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // listView1
            // 
            this.listView1.CheckBoxes = true;
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Reference,
            this.Amount,
            this.PayerName,
            this.PayerType,
            this.Recurring,
            this.SetUpDate});
            this.listView1.GridLines = true;
            this.listView1.Location = new System.Drawing.Point(36, 42);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(729, 348);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // BackButton
            // 
            this.BackButton.Location = new System.Drawing.Point(36, 13);
            this.BackButton.Name = "BackButton";
            this.BackButton.Size = new System.Drawing.Size(84, 23);
            this.BackButton.TabIndex = 1;
            this.BackButton.Text = "Back to menu";
            this.BackButton.UseVisualStyleBackColor = true;
            this.BackButton.Click += new System.EventHandler(this.BackButton_Click);
            // 
            // EditIncomeButton
            // 
            this.EditIncomeButton.Location = new System.Drawing.Point(36, 397);
            this.EditIncomeButton.Name = "EditIncomeButton";
            this.EditIncomeButton.Size = new System.Drawing.Size(75, 23);
            this.EditIncomeButton.TabIndex = 2;
            this.EditIncomeButton.Text = "Edit income";
            this.EditIncomeButton.UseVisualStyleBackColor = true;
            this.EditIncomeButton.Click += new System.EventHandler(this.EditIncomeButton_Click);
            // 
            // AddIncomeButton
            // 
            this.AddIncomeButton.Location = new System.Drawing.Point(689, 396);
            this.AddIncomeButton.Name = "AddIncomeButton";
            this.AddIncomeButton.Size = new System.Drawing.Size(75, 23);
            this.AddIncomeButton.TabIndex = 3;
            this.AddIncomeButton.Text = "Add income";
            this.AddIncomeButton.UseVisualStyleBackColor = true;
            this.AddIncomeButton.Click += new System.EventHandler(this.AddIncomeButton_Click);
            // 
            // Amount
            // 
            this.Amount.DisplayIndex = 0;
            this.Amount.Text = "Amount";
            this.Amount.Width = 68;
            // 
            // PayerName
            // 
            this.PayerName.DisplayIndex = 1;
            this.PayerName.Text = "Payer name";
            this.PayerName.Width = 93;
            // 
            // PayerType
            // 
            this.PayerType.DisplayIndex = 2;
            this.PayerType.Text = "Type";
            this.PayerType.Width = 112;
            // 
            // Recurring
            // 
            this.Recurring.DisplayIndex = 3;
            this.Recurring.Text = "Recurring";
            this.Recurring.Width = 65;
            // 
            // SetUpDate
            // 
            this.SetUpDate.DisplayIndex = 4;
            this.SetUpDate.Text = "Set-up date";
            this.SetUpDate.Width = 118;
            // 
            // Reference
            // 
            this.Reference.DisplayIndex = 5;
            this.Reference.Text = "PaymentReference";
            this.Reference.Width = 269;
            // 
            // IncomeView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.AddIncomeButton);
            this.Controls.Add(this.EditIncomeButton);
            this.Controls.Add(this.BackButton);
            this.Controls.Add(this.listView1);
            this.Name = "IncomeView";
            this.Text = "Income";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.Button BackButton;
        private System.Windows.Forms.Button EditIncomeButton;
        private System.Windows.Forms.Button AddIncomeButton;
        private System.Windows.Forms.ColumnHeader Reference;
        private System.Windows.Forms.ColumnHeader Amount;
        private System.Windows.Forms.ColumnHeader PayerName;
        private System.Windows.Forms.ColumnHeader PayerType;
        private System.Windows.Forms.ColumnHeader Recurring;
        private System.Windows.Forms.ColumnHeader SetUpDate;
    }
}