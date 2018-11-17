namespace EAD_Cwk2_EMoore_W1442006.Views
{
    partial class ExpenseView
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
            this.ExpenseListView = new System.Windows.Forms.ListView();
            this.ExpenseId = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.payeeColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.refColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.amountColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.recurringColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.intervalColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.initialColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lastPaymentColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.BackButton = new System.Windows.Forms.Button();
            this.EditButton = new System.Windows.Forms.Button();
            this.AddButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ExpenseListView
            // 
            this.ExpenseListView.CheckBoxes = true;
            this.ExpenseListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ExpenseId,
            this.payeeColumn,
            this.refColumn,
            this.amountColumn,
            this.recurringColumn,
            this.intervalColumn,
            this.initialColumn,
            this.lastPaymentColumn});
            this.ExpenseListView.FullRowSelect = true;
            this.ExpenseListView.GridLines = true;
            this.ExpenseListView.Location = new System.Drawing.Point(38, 47);
            this.ExpenseListView.MultiSelect = false;
            this.ExpenseListView.Name = "ExpenseListView";
            this.ExpenseListView.Size = new System.Drawing.Size(730, 344);
            this.ExpenseListView.TabIndex = 0;
            this.ExpenseListView.UseCompatibleStateImageBehavior = false;
            this.ExpenseListView.View = System.Windows.Forms.View.Details;
            // 
            // ExpenseId
            // 
            this.ExpenseId.Text = "Id";
            this.ExpenseId.Width = 0;
            // 
            // payeeColumn
            // 
            this.payeeColumn.Text = "Payee";
            this.payeeColumn.Width = 96;
            // 
            // refColumn
            // 
            this.refColumn.Text = "Reference";
            this.refColumn.Width = 189;
            // 
            // amountColumn
            // 
            this.amountColumn.Text = "Amount";
            this.amountColumn.Width = 85;
            // 
            // recurringColumn
            // 
            this.recurringColumn.Text = "Recurring";
            this.recurringColumn.Width = 59;
            // 
            // intervalColumn
            // 
            this.intervalColumn.Text = "Interval";
            this.intervalColumn.Width = 68;
            // 
            // initialColumn
            // 
            this.initialColumn.Text = "Initial Payment";
            this.initialColumn.Width = 112;
            // 
            // lastPaymentColumn
            // 
            this.lastPaymentColumn.Text = "Last Payment";
            this.lastPaymentColumn.Width = 116;
            // 
            // BackButton
            // 
            this.BackButton.Location = new System.Drawing.Point(38, 18);
            this.BackButton.Name = "BackButton";
            this.BackButton.Size = new System.Drawing.Size(84, 23);
            this.BackButton.TabIndex = 0;
            this.BackButton.Text = "Back to menu";
            this.BackButton.UseVisualStyleBackColor = true;
            // 
            // EditButton
            // 
            this.EditButton.Location = new System.Drawing.Point(38, 397);
            this.EditButton.Name = "EditButton";
            this.EditButton.Size = new System.Drawing.Size(84, 23);
            this.EditButton.TabIndex = 1;
            this.EditButton.Text = "Edit expense";
            this.EditButton.UseVisualStyleBackColor = true;
            // 
            // AddButton
            // 
            this.AddButton.Location = new System.Drawing.Point(688, 397);
            this.AddButton.Name = "AddButton";
            this.AddButton.Size = new System.Drawing.Size(80, 23);
            this.AddButton.TabIndex = 2;
            this.AddButton.Text = "Add expense";
            this.AddButton.UseVisualStyleBackColor = true;
            // 
            // ExpenseView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.AddButton);
            this.Controls.Add(this.EditButton);
            this.Controls.Add(this.BackButton);
            this.Controls.Add(this.ExpenseListView);
            this.Name = "ExpenseView";
            this.Text = "Expense";
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button BackButton;
        private System.Windows.Forms.Button EditButton;
        private System.Windows.Forms.Button AddButton;
        private System.Windows.Forms.ColumnHeader refColumn;
        private System.Windows.Forms.ColumnHeader payeeColumn;
        private System.Windows.Forms.ColumnHeader amountColumn;
        private System.Windows.Forms.ColumnHeader recurringColumn;
        private System.Windows.Forms.ColumnHeader intervalColumn;
        private System.Windows.Forms.ColumnHeader initialColumn;
        private System.Windows.Forms.ColumnHeader lastPaymentColumn;
        private System.Windows.Forms.ColumnHeader ExpenseId;
        public System.Windows.Forms.ListView ExpenseListView;
    }
}