using System;
using System.Windows.Forms;
using EAD_Cwk2_EMoore_W1442006.Helpers;
using EAD_Cwk2_EMoore_W1442006.Models;

namespace EAD_Cwk2_EMoore_W1442006.Views
{
    public partial class ExpenseAdd : Form
    {
        public ExpenseAdd()
        {
            InitializeComponent();

            foreach (var payee in ListAccessHelper.PayeeList)
            {
                this.PayeeDropDown.Items.Add(payee.Name);
            }
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Owner.Show();
            this.Close();
        }

        private void SaveAndBackButton_Click(object sender, EventArgs e)
        {
            var reference = this.ReferenceText.Text;
            var amount = this.AmountInput.Text;
            var lastPaidDate = new DateTime();

            if (PayeeDropDown.SelectedIndex == -1)
            {
                return;
            }

            var payee = ListAccessHelper.PayeeList[PayeeDropDown.SelectedIndex];
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

            var expense= new Expense
            {
                Id = Guid.NewGuid(),
                Ref = reference,
                Amount = Convert.ToDecimal(amount),
                Interval = interval,
                IsRecurring = isRecurring,
                InitialPaidDate = initialDate,
                LastPaidDate = lastPaidDate,
                Payee = payee
            };

            ListAccessHelper.ExpenseList.Add(expense);


            this.Owner.Show();
            this.Close();
        }

        private void RecurringCheckbox_CheckedChanged(object sender, EventArgs e)
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
    }
}
