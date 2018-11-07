using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EAD_Cwk2_EMoore_W1442006.Helpers;
using EAD_Cwk2_EMoore_W1442006.Models;

namespace EAD_Cwk2_EMoore_W1442006.Views
{
    public partial class Payer : Form
    {
        /// <summary>
        /// The view to edit <see cref="Models.Payer"/>
        /// </summary>
        private PayersEdit PayerEditView;

        /// <summary>
        /// The view to add a new <see cref="Models.Payer"/>
        /// </summary>
        private PayersAdd PayerAddView;

        public Payer()
        {
            InitializeComponent();
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            this.Owner.Show();
            this.Close();
        }

        private void EditPayerButton_Click(object sender, EventArgs e)
        {
            if (this.PayerEditView == null)
            {
                this.PayerEditView = new PayersEdit();
                this.PayerEditView.FormClosed += this.PayerEditViewOnFormClosed;
            }

            this.PayerEditView.Show(this);
            this.Hide();
        }

        private void PayerEditViewOnFormClosed(object sender, FormClosedEventArgs e)
        {
            this.PayerEditView = null;
            this.Show();
        }

        private void AddPayerButton_Click(object sender, EventArgs e)
        {
            if (this.PayerAddView == null)
            {
                this.PayerAddView = new PayersAdd();
                this.PayerAddView.FormClosed += PayerAddViewOnFormClosed;
            }

            this.PayerAddView.Show(this);
            this.Hide();
        }

        private void PayerAddViewOnFormClosed(object sender, FormClosedEventArgs e)
        {
            this.PayerAddView = null;
            this.Show();
        }

        private void Payer_VisibleChanged(object sender, EventArgs e)
        {
            PayerListView.Items.Clear();

            foreach (var payer in ListAccessHelper.PayerList)
            {
                PayerListView.Items.Add(new ListViewItem(new[] { payer.Id.ToString(), payer.Name, payer.PaymentType }));
            }
        }
    }
}
