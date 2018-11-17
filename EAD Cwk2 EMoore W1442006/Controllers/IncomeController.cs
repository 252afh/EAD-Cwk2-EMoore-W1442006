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
    public static class IncomeController
    {
        public static IncomeView IncomeView;
        private static IncomeAdd IncomeAdd;
        private static IncomeEdit IncomeEdit;
        private static Income EditIncome;
        private static DatabaseDataAccess DA = new DatabaseDataAccess();
        private static XmlDataAccess XmlDA = new XmlDataAccess();

        public static void ViewBackButton(object sender, EventArgs e)
        {
            IncomeView.Owner.Show();
            IncomeView.Close();
        }

        public static void EditButtonClicked(object sender, EventArgs e)
        {
            if (IncomeEdit == null)
            {
                IncomeEdit = new IncomeEdit();
                IncomeEdit.FormClosed += IncomeEditViewOnFormClosed;
            }

            var selectedListItems = IncomeView.listView1.SelectedItems;

            if (selectedListItems.Count > 0)
            {
                var selectedItem = selectedListItems[0];
                var incomeId = Guid.Parse(selectedItem.SubItems[0].Text);
                var income = ListAccessHelper.FindIncome(incomeId);

                EditIncome = income;
            }
            else
            {
                EditIncome = null;
            }

            IncomeEdit.Show(IncomeView);
            IncomeView.Hide();
        }

        private static void IncomeEditViewOnFormClosed(object sender, FormClosedEventArgs e)
        {
            IncomeEdit = null;
            IncomeView.Show();
        }

        public static void AddButtonClicked(object sender, EventArgs e)
        {
            if (IncomeAdd == null)
            {
                IncomeAdd = new IncomeAdd();
                IncomeAdd.FormClosed += IncomeAddViewOnFormClosed;
            }

            IncomeAdd.Show(IncomeView);
            IncomeView.Hide();
        }

        private static void IncomeAddViewOnFormClosed(object sender, FormClosedEventArgs e)
        {
            IncomeAdd = null;
            IncomeView.Show();
        }

        public static void ViewVisibleChanged(object sender, EventArgs e)
        {
            IncomeView.listView1.Items.Clear();

            foreach (var income in ListAccessHelper.IncomeList)
            {
                IncomeView.listView1.Items.Add(new ListViewItem(new[]
                {
                    "£" + income.Amount.ToString(),
                    income.Payer.Name,
                    income.Payer.PaymentType,
                    income.IsRecurring? "Yes" : "No",
                    income.InitialPaidDate.ToShortDateString(),
                    income.Ref,
                    income.IsRecurring ? income.Interval.ToString() + " days" : "-",
                    income.IsRecurring ? income.LastPaidDate.ToShortDateString() : "-"
                }));
            }
        }


        public static void EditCancelClicked(object sender, EventArgs e)
        {
            IncomeEdit.Owner.Show();
            IncomeEdit.Close();
        }

        public static void EditIndexChanged(object sender, EventArgs e)
        {
            if (IncomeEdit.IncomeDropDown.SelectedIndex == -1)
            {
                return;
            }

            EditIncome = ListAccessHelper.IncomeList[IncomeEdit.IncomeDropDown.SelectedIndex];

            IncomeEdit.ReferenceText.Text = EditIncome.Ref;
            IncomeEdit.AmountInput.Text = EditIncome.Amount.ToString();

            foreach (var payer in ListAccessHelper.PayerList)
            {
                IncomeEdit.PayerDropDown.Items.Add(payer.Name);
            }

            IncomeEdit.PayerDropDown.SelectedIndex =
                ListAccessHelper.PayerList.IndexOf(EditIncome.Payer);

            IncomeEdit.RecurringCheckbox.Checked = EditIncome.IsRecurring;

            var visible = IncomeEdit.RecurringCheckbox.Checked;

            IncomeEdit.IntervalLabel.Visible = visible;
            IncomeEdit.IntervalTextBox.Visible = visible;
            IncomeEdit.InitialLabel.Visible = visible;
            IncomeEdit.InitialDatePicker.Visible = visible;

            IncomeEdit.IntervalTextBox.Text = EditIncome.Interval.ToString();

            IncomeEdit.InitialDatePicker.Text = EditIncome.InitialPaidDate.ToShortDateString();
        }

        public static void EditShown(object sender, EventArgs e)
        {
            foreach (var income in ListAccessHelper.IncomeList)
            {
                IncomeEdit.IncomeDropDown.Items.Add(income.Payer.Name + " - " + income.Ref);
            }

            if (EditIncome != null)
            {
                var index = ListAccessHelper.IncomeList.IndexOf(EditIncome);
                IncomeEdit.IncomeDropDown.SelectedIndex = index;
            }
        }

        public static void EditRecurringChanged(object sender, EventArgs e)
        {
            var visible = IncomeEdit.RecurringCheckbox.Checked;

            IncomeEdit.IntervalLabel.Visible = visible;
            IncomeEdit.IntervalTextBox.Visible = visible;
            IncomeEdit.InitialLabel.Visible = visible;
            IncomeEdit.InitialDatePicker.Visible = visible;
        }

        public static void EditSaveAndBack(object sender, EventArgs e)
        {
            SaveEditIncome();
            IncomeEdit.Owner.Show();
            IncomeEdit.Close();
        }

        private static void SaveEditIncome()
        {
            var editedIncome = new Income
            {
                Id = EditIncome.Id,
                Payer = ListAccessHelper.PayerList[IncomeEdit.PayerDropDown.SelectedIndex],
                Ref = IncomeEdit.ReferenceText.Text,
                Amount = Convert.ToDecimal(IncomeEdit.AmountInput.Text),
                IsRecurring = IncomeEdit.RecurringCheckbox.Checked,
                Interval = Convert.ToInt32(IncomeEdit.IntervalTextBox.Text),
                InitialPaidDate = DateTime.Parse(IncomeEdit.InitialDatePicker.Text),
                LastPaidDate = DateTime.Parse(IncomeEdit.InitialDatePicker.Text) > EditIncome.LastPaidDate ? DateTime.Parse(IncomeEdit.InitialDatePicker.Text) : EditIncome.LastPaidDate
            };

            var index = ListAccessHelper.IncomeList.IndexOf(EditIncome);

            DA.EditIncome(editedIncome, EditIncome.Id);
            ListAccessHelper.IncomeList[index] = editedIncome;
            XmlDA.SaveXml();
        }

        public static void EditSaveAndNew(object sender, EventArgs e)
        {
            SaveEditIncome();
            ClearEditFields();
        }

        private static void ClearEditFields()
        {
            IncomeEdit.IncomeDropDown.SelectedIndex = 0;
            IncomeEdit.RecurringCheckbox.Checked = false;
            IncomeEdit.AmountInput.Value = 0.10m;
            IncomeEdit.InitialDatePicker.Value = DateTime.UtcNow;
            IncomeEdit.IntervalTextBox.Text = string.Empty;
            IncomeEdit.PayerDropDown.SelectedIndex = 0;
            IncomeEdit.ReferenceText.Text = string.Empty;
        }

        public static void AddShown(object sender, EventArgs e)
        {
            foreach (var payer in ListAccessHelper.PayerList)
            {
                IncomeAdd.PayerDropDown.Items.Add(payer.Name);
            }
        }

        public static void AddCancelClicked(object sender, EventArgs e)
        {
            IncomeAdd.Owner.Show();
            IncomeAdd.Close();
        }

        public static void AddRecurringChange(object sender, EventArgs e)
        {
            var checkState = IncomeAdd.RecurringCheckbox.Checked;

            IncomeAdd.InitialDatePicker.Value = DateTime.UtcNow;
            IncomeAdd.IntervalTextBox.Text = string.Empty;

            IncomeAdd.InitialDatePicker.Visible = checkState;
            IncomeAdd.InitialDatePicker.Enabled = checkState;
            IncomeAdd.InitialLabel.Visible = checkState;

            IncomeAdd.IntervalTextBox.Visible = checkState;
            IncomeAdd.IntervalTextBox.Visible = checkState;
            IncomeAdd.IntervalLabel.Visible = checkState;
        }

        public static void AddSaveAndBack(object sender, EventArgs e)
        {
            SaveAddIncome();
            IncomeAdd.Owner.Show();
            IncomeAdd.Close();
        }

        private static void SaveAddIncome()
        {
            var reference = IncomeAdd.ReferenceText.Text;
            var amount = IncomeAdd.AmountInput.Text;
            var lastPaidDate = new DateTime();

            if (IncomeAdd.PayerDropDown.SelectedIndex == -1)
            {
                return;
            }

            var payer = ListAccessHelper.PayerList[IncomeAdd.PayerDropDown.SelectedIndex];
            var isRecurring = IncomeAdd.RecurringCheckbox.Checked;

            if (string.IsNullOrEmpty(reference) || string.IsNullOrEmpty(amount))
            {
                return;
            }

            var interval = 0;
            var initialDate = DateTime.UtcNow;

            if (isRecurring)
            {
                if (string.IsNullOrEmpty(IncomeAdd.IntervalTextBox.Text))
                {
                    return;
                }

                interval = Convert.ToInt32(IncomeAdd.IntervalTextBox.Text);
                initialDate = IncomeAdd.InitialDatePicker.Value;
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

            DA.InsertIncome(income);
            ListAccessHelper.IncomeList.Add(income);
            XmlDA.SaveXml();
        }

        public static void AddSaveAndNew(object sender, EventArgs e)
        {
            SaveAddIncome();
            ClearAddFields();
        }

        private static void ClearAddFields()
        {
            IncomeAdd.RecurringCheckbox.Checked = false;
            IncomeAdd.AmountInput.Value = 0.10m;
            IncomeAdd.InitialDatePicker.Value = DateTime.UtcNow;
            IncomeAdd.IntervalTextBox.Text = string.Empty;
            IncomeAdd.PayerDropDown.SelectedIndex = 0;
            IncomeAdd.ReferenceText.Text = string.Empty;
        }
    }
}
