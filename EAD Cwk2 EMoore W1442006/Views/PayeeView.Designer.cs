namespace EAD_Cwk2_EMoore_W1442006.Views
{
    partial class PayeeViewForm
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
            this.payeeListView = new System.Windows.Forms.ListView();
            this.PayeeId = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.PayerName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.PayerAddress = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.PayerAccNumber = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.PayerSortCode = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.backButton = new System.Windows.Forms.Button();
            this.editPayee = new System.Windows.Forms.Button();
            this.addPayee = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // payeeListView
            // 
            this.payeeListView.CheckBoxes = true;
            this.payeeListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.PayeeId,
            this.PayerName,
            this.PayerAddress,
            this.PayerAccNumber,
            this.PayerSortCode});
            this.payeeListView.FullRowSelect = true;
            this.payeeListView.GridLines = true;
            this.payeeListView.Location = new System.Drawing.Point(56, 42);
            this.payeeListView.MultiSelect = false;
            this.payeeListView.Name = "payeeListView";
            this.payeeListView.Size = new System.Drawing.Size(702, 362);
            this.payeeListView.TabIndex = 0;
            this.payeeListView.UseCompatibleStateImageBehavior = false;
            this.payeeListView.View = System.Windows.Forms.View.Details;
            // 
            // PayeeId
            // 
            this.PayeeId.Text = "Id";
            this.PayeeId.Width = 0;
            // 
            // PayerName
            // 
            this.PayerName.Text = "Name";
            this.PayerName.Width = 147;
            // 
            // PayerAddress
            // 
            this.PayerAddress.Text = "Address";
            this.PayerAddress.Width = 300;
            // 
            // PayerAccNumber
            // 
            this.PayerAccNumber.Text = "Account Number";
            this.PayerAccNumber.Width = 150;
            // 
            // PayerSortCode
            // 
            this.PayerSortCode.Text = "Sort Code";
            this.PayerSortCode.Width = 100;
            // 
            // backButton
            // 
            this.backButton.Location = new System.Drawing.Point(56, 12);
            this.backButton.Name = "backButton";
            this.backButton.Size = new System.Drawing.Size(83, 23);
            this.backButton.TabIndex = 0;
            this.backButton.Text = "Back to menu";
            this.backButton.UseVisualStyleBackColor = true;
            // 
            // editPayee
            // 
            this.editPayee.Location = new System.Drawing.Point(56, 415);
            this.editPayee.Name = "editPayee";
            this.editPayee.Size = new System.Drawing.Size(75, 23);
            this.editPayee.TabIndex = 1;
            this.editPayee.Text = "Edit payee";
            this.editPayee.UseVisualStyleBackColor = true;
            // 
            // addPayee
            // 
            this.addPayee.Location = new System.Drawing.Point(683, 415);
            this.addPayee.Name = "addPayee";
            this.addPayee.Size = new System.Drawing.Size(75, 23);
            this.addPayee.TabIndex = 2;
            this.addPayee.Text = "Add payee";
            this.addPayee.UseVisualStyleBackColor = true;
            // 
            // PayeeViewForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.addPayee);
            this.Controls.Add(this.editPayee);
            this.Controls.Add(this.backButton);
            this.Controls.Add(this.payeeListView);
            this.Name = "PayeeViewForm";
            this.Text = "Payee";
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button backButton;
        private System.Windows.Forms.Button editPayee;
        private System.Windows.Forms.Button addPayee;
        private System.Windows.Forms.ColumnHeader PayerName;
        private System.Windows.Forms.ColumnHeader PayerAddress;
        private System.Windows.Forms.ColumnHeader PayerAccNumber;
        private System.Windows.Forms.ColumnHeader PayerSortCode;
        private System.Windows.Forms.ColumnHeader PayeeId;
        public System.Windows.Forms.ListView payeeListView;
    }
}