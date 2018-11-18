using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EAD_Cwk2_EMoore_W1442006.DataAccess;
using EAD_Cwk2_EMoore_W1442006.Helpers;
using EAD_Cwk2_EMoore_W1442006.Models;
using EAD_Cwk2_EMoore_W1442006.Views;

namespace EAD_Cwk2_EMoore_W1442006.Controllers
{
    public static class ExpenseController
    {
        private static ExpenseAdd ExpenseAdd { get; set; }

        private static ExpenseEdit ExpenseEdit { get; set; }

        private static Expense EditExpense { get; set; }

        public static ExpenseView ExpenseView { get; set; }

        private static DatabaseDataAccess DA { get; } = new DatabaseDataAccess();

        private static XmlDataAccess XmlDA { get; } = new XmlDataAccess();


        public static void ViewBackButton(object sender, EventArgs e)
        {
            ExpenseView.Owner.Show();
            ExpenseView.Close();
        }

        public static void EditButtonClicked(object sender, EventArgs e)
        {
            if (ExpenseEdit == null)
            {
                ExpenseEdit = new ExpenseEdit();
                ExpenseEdit.FormClosed += ExpenseEditViewOnFormClosed;
            }

            var selectedListItems = ExpenseView.ExpenseListView.SelectedItems;

            if (selectedListItems.Count > 0)
            {
                var selectedItem = selectedListItems[0];
                var expenseId = Guid.Parse(selectedItem.SubItems[0].Text);
                var expense = ListAccessHelper.FindExpense(expenseId);

                EditExpense = expense;
            }
            else
            {
                EditExpense = null;
            }

            ExpenseEdit.Show(ExpenseView);
            ExpenseView.Hide();
        }

        private static void ExpenseEditViewOnFormClosed(object sender, FormClosedEventArgs e)
        {
            ExpenseEdit = null;
            ExpenseView.Show();
        }

        public static void AddButtonClicked(object sender, EventArgs e)
        {
            if (ExpenseAdd == null)
            {
                ExpenseAdd = new ExpenseAdd();
                ExpenseAdd.FormClosed += ExpenseAddViewOnFormClosed;
            }

            ExpenseAdd.Show(ExpenseView);
            ExpenseView.Hide();
        }

        private static void ExpenseAddViewOnFormClosed(object sender, FormClosedEventArgs e)
        {
            ExpenseAdd = null;
            ExpenseView.Show();
        }

        public static void ViewVisibleChanged(object sender, EventArgs e)
        {
            ExpenseView.ExpenseListView.Items.Clear();

            foreach (var expense in ListAccessHelper.ExpenseList)
            {
                ExpenseView.ExpenseListView.Items.Add(new ListViewItem(new[]
                {
                    expense.Payee.Name,
                    expense.Ref,
                    expense.Amount.ToString("C"),
                    expense.IsRecurring ? "Yes" : "No",
                    expense.IsRecurring ? expense.Interval.ToString() + " days" : "-",
                    expense.InitialPaidDate.ToShortDateString(),
                    expense.IsRecurring ? expense.LastPaidDate.ToShortDateString() : "-"
                }));
            }
        }

        public static void EditCancelClicked(object sender, EventArgs e)
        {
            ExpenseEdit.Owner.Show();
            ExpenseEdit.Close();
        }

        public static void EditShown(object sender, EventArgs e)
        {
            foreach (var expense in ListAccessHelper.ExpenseList)
            {
                ExpenseEdit.ExpenseDropDown.Items.Add(expense.Payee.Name + " - " + expense.Ref);
            }

            if (EditExpense != null)
            {
                var index = ListAccessHelper.ExpenseList.IndexOf(EditExpense);
                ExpenseEdit.ExpenseDropDown.SelectedIndex = index;
            }
        }

        public static void EditDropDownChanged(object sender, EventArgs e)
        {
            if (ExpenseEdit.ExpenseDropDown.SelectedIndex == -1)
            {
                return;
            }

            EditExpense = ListAccessHelper.ExpenseList[ExpenseEdit.ExpenseDropDown.SelectedIndex];

            ExpenseEdit.ReferenceText.Text = EditExpense.Ref;
            ExpenseEdit.AmountNumeric.Text = EditExpense.Amount.ToString("C");

            foreach (var payee in ListAccessHelper.PayeeList)
            {
                ExpenseEdit.PayeeDropDown.Items.Add(payee.Name);
            }

            ExpenseEdit.PayeeDropDown.SelectedIndex =
                ListAccessHelper.PayeeList.IndexOf(EditExpense.Payee);

            ExpenseEdit.RecurringCheckbox.Checked = EditExpense.IsRecurring;

            var visible = ExpenseEdit.RecurringCheckbox.Checked;

            ExpenseEdit.IntervalLabel.Visible = visible;
            ExpenseEdit.IntervalText.Visible = visible;
            ExpenseEdit.StartDateLabel.Visible = visible;
            ExpenseEdit.InitialPaymentDateTime.Visible = visible;
            ExpenseEdit.IntervalText.Text = EditExpense.Interval.ToString();
            ExpenseEdit.InitialPaymentDateTime.Text = EditExpense.InitialPaidDate.ToShortDateString();
        }

        public static void EditRecurringChanged(object sender, EventArgs e)
        {
            var visible = ExpenseEdit.RecurringCheckbox.Checked;

            ExpenseEdit.IntervalLabel.Visible = visible;
            ExpenseEdit.IntervalText.Visible = visible;
            ExpenseEdit.StartDateLabel.Visible = visible;
            ExpenseEdit.InitialPaymentDateTime.Visible = visible;
        }

        public static void EditSaveAndBack(object sender, EventArgs e)
        {
            SaveEditExpense();
            ExpenseEdit.Owner.Show();
            ExpenseEdit.Close();
        }

        private static void SaveEditExpense()
        {
            var editedExpense = new Expense
            {
                Id = EditExpense.Id,
                Payee = ListAccessHelper.PayeeList[ExpenseEdit.PayeeDropDown.SelectedIndex],
                Ref = ExpenseEdit.ReferenceText.Text,
                Amount = Convert.ToDecimal(ExpenseEdit.AmountNumeric.Text),
                IsRecurring = ExpenseEdit.RecurringCheckbox.Checked,
                Interval = Convert.ToInt32(ExpenseEdit.IntervalText.Text),
                InitialPaidDate = DateTime.Parse(ExpenseEdit.InitialPaymentDateTime.Text),
                LastPaidDate = DateTime.Parse(ExpenseEdit.InitialPaymentDateTime.Text) > EditExpense.LastPaidDate ? DateTime.Parse(ExpenseEdit.InitialPaymentDateTime.Text) : EditExpense.LastPaidDate
            };

            var index = ListAccessHelper.ExpenseList.IndexOf(editedExpense);

            DA.EditExpense(editedExpense, editedExpense.Id);
            ListAccessHelper.ExpenseList[index] = editedExpense;
            XmlDA.SaveXml();
        }

        public static void EditSaveAndNew(object sender, EventArgs e)
        {
            SaveEditExpense();
            ClearEditFields();
        }

        private static void ClearEditFields()
        {
            ExpenseEdit.PayeeDropDown.SelectedIndex = 0;
            ExpenseEdit.RecurringCheckbox.Checked = false;
            ExpenseEdit.AmountNumeric.Value = 0.10m;
            ExpenseEdit.ExpenseDropDown.SelectedIndex = 0;
            ExpenseEdit.InitialPaymentDateTime.Value = DateTime.UtcNow;
            ExpenseEdit.IntervalText.Text = string.Empty;
            ExpenseEdit.ReferenceText.Text = string.Empty;
        }

        public static void AddShown(object sender, EventArgs e)
        {
            foreach (var payee in ListAccessHelper.PayeeList)
            {
                ExpenseAdd.PayeeDropDown.Items.Add(payee.Name);
            }
        }

        public static void ExpenseCancelClick(object sender, EventArgs e)
        {
            ExpenseAdd.Owner.Show();
            ExpenseAdd.Close();
        }

        public static void AddSaveAndBack(object sender, EventArgs e)
        {
            SaveAddExpense();
            ExpenseAdd.Owner.Show();
            ExpenseAdd.Close();
        }

        private static void SaveAddExpense()
        {
            var reference = ExpenseAdd.ReferenceText.Text;
            var amount = ExpenseAdd.AmountInput.Text;
            var lastPaidDate = new DateTime();

            if (ExpenseAdd.PayeeDropDown.SelectedIndex == -1)
            {
                return;
            }

            var payee = ListAccessHelper.PayeeList[ExpenseAdd.PayeeDropDown.SelectedIndex];
            var isRecurring = ExpenseAdd.RecurringCheckbox.Checked;

            if (string.IsNullOrEmpty(reference) || string.IsNullOrEmpty(amount))
            {
                return;
            }

            var interval = 0;
            var initialDate = DateTime.UtcNow;

            if (isRecurring)
            {
                if (string.IsNullOrEmpty(ExpenseAdd.IntervalTextBox.Text))
                {
                    return;
                }

                interval = Convert.ToInt32(ExpenseAdd.IntervalTextBox.Text);
                initialDate = ExpenseAdd.InitialDatePicker.Value;
                lastPaidDate = initialDate;
            }

            var expense = new Expense
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

            DA.InsertExpense(expense);
            ListAccessHelper.ExpenseList.Add(expense);
            XmlDA.SaveXml();
        }

        public static void AddSaveAndNew(object sender, EventArgs e)
        {
            SaveAddExpense();
            ClearAddFields();
        }

        private static void ClearAddFields()
        {
            ExpenseAdd.AmountInput.Value = 0.10m;
            ExpenseAdd.InitialDatePicker.Value = DateTime.UtcNow;
            ExpenseAdd.IntervalTextBox.Text = string.Empty;
            ExpenseAdd.PayeeDropDown.SelectedIndex = 0;
            ExpenseAdd.RecurringCheckbox.Checked = false;
            ExpenseAdd.ReferenceText.Text = string.Empty;
        }

        public static void AddRecurringChanged(object sender, EventArgs e)
        {
            var checkState = ExpenseAdd.RecurringCheckbox.Checked;

            ExpenseAdd.InitialDatePicker.Value = DateTime.UtcNow;
            ExpenseAdd.IntervalTextBox.Text = string.Empty;

            ExpenseAdd.InitialDatePicker.Visible = checkState;
            ExpenseAdd.InitialDatePicker.Enabled = checkState;
            ExpenseAdd.InitialLabel.Visible = checkState;

            ExpenseAdd.IntervalTextBox.Visible = checkState;
            ExpenseAdd.IntervalTextBox.Visible = checkState;
            ExpenseAdd.IntervalLabel.Visible = checkState;
        }
    }
}
