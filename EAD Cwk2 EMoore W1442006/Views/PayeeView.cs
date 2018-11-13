using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EAD_Cwk2_EMoore_W1442006.Controllers;
using EAD_Cwk2_EMoore_W1442006.Helpers;
using EAD_Cwk2_EMoore_W1442006.Models;

namespace EAD_Cwk2_EMoore_W1442006.Views
{
    public partial class PayeeViewForm : Form
    {
        /// <summary>
        /// The view for editing a <see cref="Payee"/>
        /// </summary>
        private PayeeEdit PayeeEditView;

        /// <summary>
        /// The view for adding a <see cref="Payee"/>
        /// </summary>
        private PayeeAdd PayeeAddView;

        public PayeeViewForm()
        {
            InitializeComponent();
        }

        private void EditPayee_Click(object sender, EventArgs e)
        {
            if (this.PayeeEditView == null)
            {
                this.PayeeEditView = new PayeeEdit();
                this.PayeeEditView.FormClosed += this.PayeeEditViewOnFormClosed;
            }
            this.PayeeEditView.Show(this);
            this.Hide();
        }

        private void PayeeEditViewOnFormClosed(object sender, FormClosedEventArgs e)
        {
            this.PayeeEditView = null;
            this.Show();
        }

        private void AddPayee_Click(object sender, EventArgs e)
        {
            if (this.PayeeAddView == null)
            {
                this.PayeeAddView = new PayeeAdd();
                this.PayeeAddView.Click += this.PayeeAddViewOnClick;
            }

            this.Hide();
            this.PayeeAddView.Show(this);
        }

        private void PayeeAddViewOnClick(object sender, EventArgs e)
        {
            this.PayeeAddView = null;
            this.Show();
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            this.Owner.Show();
            this.Close();
        }

        private void PayeeViewForm_VisibleChanged(object sender, EventArgs e)
        {
            this.payeeListView.Items.Clear();

            foreach (var payee in ListAccessHelper.PayeeList)
            {
                payeeListView.Items.Add(new ListViewItem(new[]
                {
                    payee.Name,
                    payee.Address,
                    payee.AccNumber,
                    payee.SortCode
                }));
            }
        }
    }
}
