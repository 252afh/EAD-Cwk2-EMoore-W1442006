using System;
using System.Windows.Forms;
using EAD_Cwk2_EMoore_W1442006.Helpers;
using EAD_Cwk2_EMoore_W1442006.Models;

namespace EAD_Cwk2_EMoore_W1442006.Views
{
    public partial class PayeeAdd : Form
    {
        public PayeeAdd()
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
            var payeeName = this.NameText.Text;
            var address = this.addressText.Text;
            var sortCode = this.SortCodeText.Text;
            var accNumber = this.AccNumberText.Text;

            if (string.IsNullOrEmpty(payeeName) || string.IsNullOrEmpty(sortCode) || string.IsNullOrEmpty(accNumber) || string.IsNullOrEmpty(address))
            {
                return;
            }

            ListAccessHelper.PayeeList.Add(new Payee
            {
                Id = Guid.NewGuid(),
                Name = payeeName,
                Address = address,
                AccNumber = accNumber,
                SortCode = sortCode
            });

            this.Owner.Show();
            this.Close();
        }
    }
}
