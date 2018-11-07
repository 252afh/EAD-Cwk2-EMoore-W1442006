﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EAD_Cwk2_EMoore_W1442006.Models;

namespace EAD_Cwk2_EMoore_W1442006.Views
{
    public partial class IncomeView : Form
    {
        /// <summary>
        /// The view for editing an <see cref="Income"/>
        /// </summary>
        private IncomeEdit IncomeEditView;
        
        /// <summary>
        /// The view for adding an <see cref="Income"/>
        /// </summary>
        private IncomeAdd IncomeAddView;

        public IncomeView()
        {
            InitializeComponent();
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            this.Owner.Show();
            this.Close();
        }

        private void EditIncomeButton_Click(object sender, EventArgs e)
        {
            if (this.IncomeEditView == null)
            {
                this.IncomeEditView = new IncomeEdit();
                this.IncomeEditView.FormClosed += this.IncomeEditViewOnFormClosed;
            }

            this.IncomeEditView.Show(this);
            this.Hide();
        }

        private void IncomeEditViewOnFormClosed(object sender, FormClosedEventArgs e)
        {
            this.IncomeEditView = null;
            this.Show();
        }

        private void AddIncomeButton_Click(object sender, EventArgs e)
        {
            if (this.IncomeAddView == null)
            {
                this.IncomeAddView = new IncomeAdd();
                this.IncomeAddView.FormClosed += this.IncomeAddViewOnFormClosed;
            }

            this.IncomeAddView.Show(this);
            this.Hide();
        }

        private void IncomeAddViewOnFormClosed(object sender, FormClosedEventArgs e)
        {
            this.IncomeAddView = null;
            this.Show();
        }
    }
}
