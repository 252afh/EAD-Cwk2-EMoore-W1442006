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
            this.IncomeListView = new System.Windows.Forms.ListView();
            this.IncomeId = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Amount = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.PayerName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.PayerType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Recurring = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SetUpDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Reference = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.paymentColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lastPaidColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.BackButton = new System.Windows.Forms.Button();
            this.EditIncomeButton = new System.Windows.Forms.Button();
            this.AddIncomeButton = new System.Windows.Forms.Button();
            this.DeleteButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // IncomeListView
            // 
            this.IncomeListView.CheckBoxes = true;
            this.IncomeListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.IncomeId,
            this.Amount,
            this.PayerName,
            this.PayerType,
            this.Recurring,
            this.SetUpDate,
            this.Reference,
            this.paymentColumn,
            this.lastPaidColumn});
            this.IncomeListView.FullRowSelect = true;
            this.IncomeListView.GridLines = true;
            this.IncomeListView.Location = new System.Drawing.Point(36, 42);
            this.IncomeListView.MultiSelect = false;
            this.IncomeListView.Name = "IncomeListView";
            this.IncomeListView.Size = new System.Drawing.Size(729, 348);
            this.IncomeListView.TabIndex = 0;
            this.IncomeListView.UseCompatibleStateImageBehavior = false;
            this.IncomeListView.View = System.Windows.Forms.View.Details;
            // 
            // IncomeId
            // 
            this.IncomeId.Text = "Id";
            this.IncomeId.Width = 0;
            // 
            // Amount
            // 
            this.Amount.Text = "Amount";
            this.Amount.Width = 68;
            // 
            // PayerName
            // 
            this.PayerName.Text = "Payer name";
            this.PayerName.Width = 93;
            // 
            // PayerType
            // 
            this.PayerType.Text = "Type";
            this.PayerType.Width = 64;
            // 
            // Recurring
            // 
            this.Recurring.Text = "Recurring";
            this.Recurring.Width = 65;
            // 
            // SetUpDate
            // 
            this.SetUpDate.Text = "Set-up date";
            this.SetUpDate.Width = 118;
            // 
            // Reference
            // 
            this.Reference.Text = "PaymentReference";
            this.Reference.Width = 172;
            // 
            // paymentColumn
            // 
            this.paymentColumn.Text = "Interval";
            this.paymentColumn.Width = 66;
            // 
            // lastPaidColumn
            // 
            this.lastPaidColumn.Text = "Last Payment";
            this.lastPaidColumn.Width = 79;
            // 
            // BackButton
            // 
            this.BackButton.Location = new System.Drawing.Point(36, 13);
            this.BackButton.Name = "BackButton";
            this.BackButton.Size = new System.Drawing.Size(84, 23);
            this.BackButton.TabIndex = 0;
            this.BackButton.Text = "Back to menu";
            this.BackButton.UseVisualStyleBackColor = true;
            // 
            // EditIncomeButton
            // 
            this.EditIncomeButton.Location = new System.Drawing.Point(36, 397);
            this.EditIncomeButton.Name = "EditIncomeButton";
            this.EditIncomeButton.Size = new System.Drawing.Size(75, 23);
            this.EditIncomeButton.TabIndex = 1;
            this.EditIncomeButton.Text = "Edit income";
            this.EditIncomeButton.UseVisualStyleBackColor = true;
            // 
            // AddIncomeButton
            // 
            this.AddIncomeButton.Location = new System.Drawing.Point(689, 396);
            this.AddIncomeButton.Name = "AddIncomeButton";
            this.AddIncomeButton.Size = new System.Drawing.Size(75, 23);
            this.AddIncomeButton.TabIndex = 2;
            this.AddIncomeButton.Text = "Add income";
            this.AddIncomeButton.UseVisualStyleBackColor = true;
            // 
            // DeleteButton
            // 
            this.DeleteButton.Location = new System.Drawing.Point(354, 396);
            this.DeleteButton.Name = "DeleteButton";
            this.DeleteButton.Size = new System.Drawing.Size(90, 23);
            this.DeleteButton.TabIndex = 4;
            this.DeleteButton.Text = "Delete income";
            this.DeleteButton.UseVisualStyleBackColor = true;
            // 
            // IncomeView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.DeleteButton);
            this.Controls.Add(this.AddIncomeButton);
            this.Controls.Add(this.EditIncomeButton);
            this.Controls.Add(this.BackButton);
            this.Controls.Add(this.IncomeListView);
            this.Name = "IncomeView";
            this.Text = "Income";
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button BackButton;
        private System.Windows.Forms.Button EditIncomeButton;
        private System.Windows.Forms.Button AddIncomeButton;
        private System.Windows.Forms.ColumnHeader Reference;
        private System.Windows.Forms.ColumnHeader Amount;
        private System.Windows.Forms.ColumnHeader PayerName;
        private System.Windows.Forms.ColumnHeader PayerType;
        private System.Windows.Forms.ColumnHeader Recurring;
        private System.Windows.Forms.ColumnHeader SetUpDate;
        private System.Windows.Forms.ColumnHeader paymentColumn;
        private System.Windows.Forms.ColumnHeader lastPaidColumn;
        private System.Windows.Forms.ColumnHeader IncomeId;
        public System.Windows.Forms.ListView IncomeListView;
        private System.Windows.Forms.Button DeleteButton;
    }
}