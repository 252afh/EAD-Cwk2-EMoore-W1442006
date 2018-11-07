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
            this.BackButton = new System.Windows.Forms.Button();
            this.EditButton = new System.Windows.Forms.Button();
            this.AddButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ExpenseListView
            // 
            this.ExpenseListView.CheckBoxes = true;
            this.ExpenseListView.Location = new System.Drawing.Point(38, 47);
            this.ExpenseListView.Name = "ExpenseListView";
            this.ExpenseListView.Size = new System.Drawing.Size(730, 344);
            this.ExpenseListView.TabIndex = 0;
            this.ExpenseListView.UseCompatibleStateImageBehavior = false;
            // 
            // BackButton
            // 
            this.BackButton.Location = new System.Drawing.Point(38, 18);
            this.BackButton.Name = "BackButton";
            this.BackButton.Size = new System.Drawing.Size(84, 23);
            this.BackButton.TabIndex = 1;
            this.BackButton.Text = "Back to menu";
            this.BackButton.UseVisualStyleBackColor = true;
            this.BackButton.Click += new System.EventHandler(this.BackButton_Click);
            // 
            // EditButton
            // 
            this.EditButton.Location = new System.Drawing.Point(38, 397);
            this.EditButton.Name = "EditButton";
            this.EditButton.Size = new System.Drawing.Size(84, 23);
            this.EditButton.TabIndex = 2;
            this.EditButton.Text = "Edit expense";
            this.EditButton.UseVisualStyleBackColor = true;
            this.EditButton.Click += new System.EventHandler(this.EditButton_Click);
            // 
            // AddButton
            // 
            this.AddButton.Location = new System.Drawing.Point(688, 397);
            this.AddButton.Name = "AddButton";
            this.AddButton.Size = new System.Drawing.Size(80, 23);
            this.AddButton.TabIndex = 3;
            this.AddButton.Text = "Add expense";
            this.AddButton.UseVisualStyleBackColor = true;
            this.AddButton.Click += new System.EventHandler(this.AddButton_Click);
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

        private System.Windows.Forms.ListView ExpenseListView;
        private System.Windows.Forms.Button BackButton;
        private System.Windows.Forms.Button EditButton;
        private System.Windows.Forms.Button AddButton;
    }
}