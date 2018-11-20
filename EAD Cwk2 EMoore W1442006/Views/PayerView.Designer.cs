namespace EAD_Cwk2_EMoore_W1442006.Views
{
    partial class PayerView
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
            this.PayerListView = new System.Windows.Forms.ListView();
            this.PayerId = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.PayerName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.PayerType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.BackButton = new System.Windows.Forms.Button();
            this.EditPayerButton = new System.Windows.Forms.Button();
            this.AddPayerButton = new System.Windows.Forms.Button();
            this.DeleteButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // PayerListView
            // 
            this.PayerListView.CheckBoxes = true;
            this.PayerListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.PayerId,
            this.PayerName,
            this.PayerType});
            this.PayerListView.FullRowSelect = true;
            this.PayerListView.GridLines = true;
            this.PayerListView.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.PayerListView.Location = new System.Drawing.Point(35, 39);
            this.PayerListView.MultiSelect = false;
            this.PayerListView.Name = "PayerListView";
            this.PayerListView.Size = new System.Drawing.Size(730, 350);
            this.PayerListView.TabIndex = 0;
            this.PayerListView.UseCompatibleStateImageBehavior = false;
            this.PayerListView.View = System.Windows.Forms.View.Details;
            // 
            // PayerId
            // 
            this.PayerId.Text = "Id";
            this.PayerId.Width = 0;
            // 
            // PayerName
            // 
            this.PayerName.Text = "Name";
            this.PayerName.Width = 304;
            // 
            // PayerType
            // 
            this.PayerType.Text = "Payer Type";
            this.PayerType.Width = 422;
            // 
            // BackButton
            // 
            this.BackButton.Location = new System.Drawing.Point(35, 13);
            this.BackButton.Name = "BackButton";
            this.BackButton.Size = new System.Drawing.Size(81, 23);
            this.BackButton.TabIndex = 0;
            this.BackButton.Text = "Back to menu";
            this.BackButton.UseVisualStyleBackColor = true;
            // 
            // EditPayerButton
            // 
            this.EditPayerButton.Location = new System.Drawing.Point(35, 397);
            this.EditPayerButton.Name = "EditPayerButton";
            this.EditPayerButton.Size = new System.Drawing.Size(81, 23);
            this.EditPayerButton.TabIndex = 1;
            this.EditPayerButton.Text = "Edit payer";
            this.EditPayerButton.UseVisualStyleBackColor = true;
            // 
            // AddPayerButton
            // 
            this.AddPayerButton.Location = new System.Drawing.Point(690, 396);
            this.AddPayerButton.Name = "AddPayerButton";
            this.AddPayerButton.Size = new System.Drawing.Size(75, 23);
            this.AddPayerButton.TabIndex = 2;
            this.AddPayerButton.Text = "Add payer";
            this.AddPayerButton.UseVisualStyleBackColor = true;
            // 
            // DeleteButton
            // 
            this.DeleteButton.Location = new System.Drawing.Point(362, 397);
            this.DeleteButton.Name = "DeleteButton";
            this.DeleteButton.Size = new System.Drawing.Size(90, 23);
            this.DeleteButton.TabIndex = 6;
            this.DeleteButton.Text = "Delete payer";
            this.DeleteButton.UseVisualStyleBackColor = true;
            // 
            // PayerView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.DeleteButton);
            this.Controls.Add(this.AddPayerButton);
            this.Controls.Add(this.EditPayerButton);
            this.Controls.Add(this.BackButton);
            this.Controls.Add(this.PayerListView);
            this.Name = "PayerView";
            this.Text = "Payers";
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button BackButton;
        private System.Windows.Forms.Button EditPayerButton;
        private System.Windows.Forms.Button AddPayerButton;
        private System.Windows.Forms.ColumnHeader PayerName;
        private System.Windows.Forms.ColumnHeader PayerType;
        private System.Windows.Forms.ColumnHeader PayerId;
        public System.Windows.Forms.ListView PayerListView;
        private System.Windows.Forms.Button DeleteButton;
    }
}