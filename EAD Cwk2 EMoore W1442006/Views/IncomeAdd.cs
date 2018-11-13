using EAD_Cwk2_EMoore_W1442006.Helpers;
using EAD_Cwk2_EMoore_W1442006.Models;
using System;
using System.Windows.Forms;

namespace EAD_Cwk2_EMoore_W1442006.Views
{
    public partial class IncomeAdd : Form
    {
        public IncomeAdd()
        {
            InitializeComponent();

            foreach (var payer in ListAccessHelper.PayerList)
            {
                this.PayerDropDown.Items.Add(payer.Name);
            }
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Owner.Show();
            this.Close();
        }

        private void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            var checkState = this.RecurringCheckbox.Checked;

            this.InitialDatePicker.Value = DateTime.UtcNow;
            this.IntervalTextBox.Text = String.Empty;

            this.InitialDatePicker.Visible = checkState;
            this.InitialDatePicker.Enabled = checkState;
            this.InitialLabel.Visible = checkState;

            this.IntervalTextBox.Visible = checkState;
            this.IntervalTextBox.Visible = checkState;
            this.IntervalLabel.Visible = checkState;
        }

        private void SaveAndBackButton_Click(object sender, EventArgs e)
        {
            var reference = this.ReferenceText.Text;
            var amount = this.AmountInput.Text;
            var lastPaidDate = new DateTime();

            if (PayerDropDown.SelectedIndex == -1)
            {
                return;
            }

            var payer = ListAccessHelper.PayerList[PayerDropDown.SelectedIndex];
            var isRecurring = this.RecurringCheckbox.Checked;

            if (string.IsNullOrEmpty(reference) || string.IsNullOrEmpty(amount))
            {
                return;
            }

            var interval = 0;
            var initialDate = DateTime.UtcNow;

            if (isRecurring)
            {
                if (string.IsNullOrEmpty(this.IntervalTextBox.Text))
                {
                    return;
                }

                interval = Convert.ToInt32(this.IntervalTextBox.Text);
                initialDate = this.InitialDatePicker.Value;
                lastPaidDate = initialDate;
            }

            var income = new Income
            {
                Id = Guid.NewGuid(),
                Ref = reference,
                Amount = Convert.ToDecimal(amount),
                Interval = interval,
                IsRecurring = isRecurring,
                InitialPaidDate = initialDate,
                LastPaidDate = lastPaidDate,
                Payer = payer
            };

            ListAccessHelper.IncomeList.Add(income);


            this.Owner.Show();
            this.Close();
        }
    }
}
