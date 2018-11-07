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
    public partial class PayersAdd : Form
    {
        public PayersAdd()
        {
            InitializeComponent();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Owner.Show();
            this.Close();
        }

        private void SaveAndBackButton_Click(object sender, EventArgs e)
        {
            var name = this.NameText.Text;

            if (string.IsNullOrEmpty(name))
            {
                return;
            }

            var payer = new Models.Payer
            {
                Id = Guid.NewGuid(),
                Name = name,
                PaymentType = this.PaymentTypeText.Text
            };

            ListAccessHelper.PayerList.Add(payer);

            this.Owner.Show();
            this.Close();
        }
    }
}
