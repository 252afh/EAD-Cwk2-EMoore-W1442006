namespace EAD_Cwk2_EMoore_W1442006.Controllers
{
    using DataAccess;
    using Helpers;
    using Models;
    using System;
    using System.Windows.Forms;
    using Views;

    /// <summary>
    /// An instance of the <see cref="IncomeController"/> class that handles all logic for <see cref="Income"/> related forms
    /// </summary>
    public static class IncomeController
    {
        /// <summary>
        /// An instance of <see cref="Views.IncomeView"/> class view
        /// </summary>
        public static IncomeView IncomeView { get; set; }

        /// <summary>
        /// An instance of the <see cref="Views.IncomeAdd"/> class view
        /// </summary>
        private static IncomeAdd IncomeAdd { get; set; }

        /// <summary>
        /// An instance of the <see cref="Views.IncomeEdit"/> class view
        /// </summary>
        private static IncomeEdit IncomeEdit { get; set; }

        /// <summary>
        /// An instance of an <see cref="Income"/> model used for editing existing income
        /// </summary>
        private static Income EditIncome { get; set; }

        /// <summary>
        /// An instance of <see cref="DatabaseDataAccess"/> class for handling database interactions
        /// </summary>
        private static DatabaseDataAccess DA { get; } = new DatabaseDataAccess();

        /// <summary>
        /// An instance of <see cref="XmlDataAccess"/> class for handling XML saving and loading
        /// </summary>
        private static XmlDataAccess XmlDA { get; } = new XmlDataAccess();

        /// <summary>
        ///  Handles the back button being pressed on the <see cref="Views.IncomeView"/> form
        /// </summary>
        /// <param name="sender">The sender object</param>
        /// <param name="e">Event arguments</param>
        public static void ViewBackButton(object sender, EventArgs e)
        {
            IncomeView.Owner.Show();
            IncomeView.Close();
        }

        /// <summary>
        ///  Handles the <see cref="Views.IncomeEdit"/> form being opened from the <see cref="Views.IncomeView"/> form
        /// </summary>
        /// <param name="sender">The sender object</param>
        /// <param name="e">Event arguments</param>
        public static void EditButtonClicked(object sender, EventArgs e)
        {
            if (IncomeEdit == null)
            {
                IncomeEdit = new IncomeEdit();
                IncomeEdit.FormClosed += IncomeEditViewOnFormClosed;
            }

            var selectedListItems = IncomeView.IncomeListView.SelectedItems;

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

        /// <summary>
        ///  Handles the <see cref="Views.IncomeEdit"/> form being closed
        /// </summary>
        /// <param name="sender">The sender object</param>
        /// <param name="e">Event arguments</param>
        private static void IncomeEditViewOnFormClosed(object sender, FormClosedEventArgs e)
        {
            IncomeEdit = null;
            IncomeView.Show();
        }

        /// <summary>
        ///  Handles the <see cref="Views.IncomeAdd"/> form being opened from the <see cref="Views.IncomeView"/> form
        /// </summary>
        /// <param name="sender">The sender object</param>
        /// <param name="e">Event arguments</param>
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

        /// <summary>
        ///  Handles the <see cref="Views.IncomeAdd"/> form being closed
        /// </summary>
        /// <param name="sender">The sender object</param>
        /// <param name="e">Event arguments</param>
        private static void IncomeAddViewOnFormClosed(object sender, FormClosedEventArgs e)
        {
            IncomeAdd = null;
            IncomeView.Show();
        }

        /// <summary>
        ///  Handles the <see cref="Views.IncomeView"/> form visibility changing
        /// </summary>
        /// <param name="sender">The sender object</param>
        /// <param name="e">Event arguments</param>
        public static void ViewVisibleChanged(object sender, EventArgs e)
        {
            PopulateListView();
        }

        /// <summary>
        /// Handles populating the list view with <see cref="Income"/> items
        /// </summary>
        private static void PopulateListView()
        {
            IncomeView.IncomeListView.Items.Clear();

            foreach (var income in ListAccessHelper.IncomeList)
            {
                IncomeView.IncomeListView.Items.Add(new ListViewItem(new[]
                {
                    income.Id.ToString(),
                    income.Amount.ToString("C"),
                    income.Payer.Name,
                    income.Payer.PaymentType,
                    income.IsRecurring ? "Yes" : "No",
                    income.InitialPaidDate.ToShortDateString(),
                    income.Ref,
                    income.IsRecurring ? income.Interval.ToString() + " days" : "-",
                    income.IsRecurring ? income.LastPaidDate.ToShortDateString() : "-"
                }));
            }
        }

        /// <summary>
        ///  Handles the cancel button being clicked on the <see cref="Views.IncomeEdit"/>
        /// </summary>
        /// <param name="sender">The sender object</param>
        /// <param name="e">Event arguments</param>
        public static void EditCancelClicked(object sender, EventArgs e)
        {
            IncomeEdit.Owner.Show();
            IncomeEdit.Close();
        }

        /// <summary>
        ///  Handles the income drop down value being changed on the <see cref="Views.IncomeEdit"/> form
        /// </summary>
        /// <param name="sender">The sender object</param>
        /// <param name="e">Event arguments</param>
        public static void EditIndexChanged(object sender, EventArgs e)
        {
            if (IncomeEdit.IncomeDropDown.SelectedIndex == -1)
            {
                return;
            }

            EditIncome = ListAccessHelper.IncomeList[IncomeEdit.IncomeDropDown.SelectedIndex];

            IncomeEdit.ReferenceText.Text = EditIncome.Ref;
            IncomeEdit.AmountInput.Text = EditIncome.Amount.ToString("C");

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

        /// <summary>
        ///  Handles the <see cref="Views.IncomeEdit"/> form being shown
        /// </summary>
        /// <param name="sender">The sender object</param>
        /// <param name="e">Event arguments</param>
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

        /// <summary>
        ///  Handles the recurring checkbox value being changed on the <see cref="Views.IncomeEdit"/> form
        /// </summary>
        /// <param name="sender">The sender object</param>
        /// <param name="e">Event arguments</param>
        public static void EditRecurringChanged(object sender, EventArgs e)
        {
            var visible = IncomeEdit.RecurringCheckbox.Checked;

            IncomeEdit.IntervalLabel.Visible = visible;
            IncomeEdit.IntervalTextBox.Visible = visible;
            IncomeEdit.InitialLabel.Visible = visible;
            IncomeEdit.InitialDatePicker.Visible = visible;
        }

        /// <summary>
        ///  Handles the save and back button being pressed on the <see cref="Views.IncomeEdit"/> form
        /// </summary>
        /// <param name="sender">The sender object</param>
        /// <param name="e">Event arguments</param>
        public static void EditSaveAndBack(object sender, EventArgs e)
        {
            var success = SaveEditIncome();

            if (success)
            {
                IncomeEdit.Owner.Show();
                IncomeEdit.Close();
            }
        }

        /// <summary>
        /// Handles saving an edited <see cref="Income"/>
        /// </summary>
        private static bool SaveEditIncome()
        {
            var reference = IncomeEdit.ReferenceText.Text;
            var amount = IncomeEdit.AmountInput.Value;

            if (string.IsNullOrEmpty(reference) || amount == decimal.Zero)
            {
                return false;
            }

            var isRecurring = IncomeEdit.RecurringCheckbox.Checked;

            if (isRecurring && string.IsNullOrEmpty(IncomeEdit.IntervalTextBox.Text))
            {
                return false;
            }

            var editedIncome = new Income
            {
                Id = EditIncome.Id,
                Payer = ListAccessHelper.PayerList[IncomeEdit.PayerDropDown.SelectedIndex],
                Ref = reference,
                Amount = amount,
                IsRecurring = isRecurring,
                Interval = Convert.ToInt32(IncomeEdit.IntervalTextBox.Text),
                InitialPaidDate = DateTime.Parse(IncomeEdit.InitialDatePicker.Text),
                LastPaidDate = DateTime.Parse(IncomeEdit.InitialDatePicker.Text) > EditIncome.LastPaidDate ? DateTime.Parse(IncomeEdit.InitialDatePicker.Text) : EditIncome.LastPaidDate
            };

            var index = ListAccessHelper.IncomeList.IndexOf(EditIncome);

            DA.EditIncome(editedIncome, EditIncome.Id);
            ListAccessHelper.IncomeList[index] = editedIncome;
            XmlDA.SaveXml();
            return true;
        }

        /// <summary>
        ///  Handles the save and new button being pressed on the <see cref="Views.IncomeEdit"/> form
        /// </summary>
        /// <param name="sender">The sender object</param>
        /// <param name="e">Event arguments</param>
        public static void EditSaveAndNew(object sender, EventArgs e)
        {
            var success = SaveEditIncome();

            if (success)
            {
                ClearEditFields();
            }
        }

        /// <summary>
        /// Handles clearing all fields on the <see cref="Views.IncomeEdit"/> form
        /// </summary>
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

        /// <summary>
        ///  Handles the <see cref="Views.IncomeAdd"/> form being shown
        /// </summary>
        /// <param name="sender">The sender object</param>
        /// <param name="e">Event arguments</param>
        public static void AddShown(object sender, EventArgs e)
        {
            foreach (var payer in ListAccessHelper.PayerList)
            {
                IncomeAdd.PayerDropDown.Items.Add(payer.Name);
            }
        }

        /// <summary>
        ///  Handles the cancel button being clicked on the <see cref="Views.IncomeAdd"/> form
        /// </summary>
        /// <param name="sender">The sender object</param>
        /// <param name="e">Event arguments</param>
        public static void AddCancelClicked(object sender, EventArgs e)
        {
            IncomeAdd.Owner.Show();
            IncomeAdd.Close();
        }

        /// <summary>
        ///  Handles the recurring checkbox value being changed on the <see cref="Views.IncomeAdd"/> form
        /// </summary>
        /// <param name="sender">The sender object</param>
        /// <param name="e">Event arguments</param>
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

        /// <summary>
        ///  Handles the save and back button being pressed on the <see cref="Views.IncomeAdd"/> form
        /// </summary>
        /// <param name="sender">The sender object</param>
        /// <param name="e">Event arguments</param>
        public static void AddSaveAndBack(object sender, EventArgs e)
        {
            var success = SaveAddIncome();

            if (success)
            {
                IncomeAdd.Owner.Show();
                IncomeAdd.Close();
            }
        }

        /// <summary>
        /// Handles saving a new <see cref="Income"/>
        /// </summary>
        private static bool SaveAddIncome()
        {
            var reference = IncomeAdd.ReferenceText.Text;
            var amount = IncomeAdd.AmountInput.Value;
            var lastPaidDate = new DateTime();

            if (IncomeAdd.PayerDropDown.SelectedIndex == -1)
            {
                return false;
            }

            var payer = ListAccessHelper.PayerList[IncomeAdd.PayerDropDown.SelectedIndex];
            var isRecurring = IncomeAdd.RecurringCheckbox.Checked;

            if (string.IsNullOrEmpty(reference) || amount == decimal.Zero)
            {
                return false;
            }

            var interval = 0;
            var initialDate = DateTime.UtcNow;

            if (isRecurring)
            {
                if (string.IsNullOrEmpty(IncomeAdd.IntervalTextBox.Text))
                {
                    return false;
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
            return true;
        }

        /// <summary>
        ///  Handles the save and new button being clicked on the <see cref="Views.IncomeAdd"/> forms
        /// </summary>
        /// <param name="sender">The sender object</param>
        /// <param name="e">Event arguments</param>
        public static void AddSaveAndNew(object sender, EventArgs e)
        {
            var success = SaveAddIncome();

            if (success)
            {
                ClearAddFields();
            }
        }

        /// <summary>
        /// Handles clearing all fields on the <see cref="Views.IncomeAdd"/> form
        /// </summary>
        private static void ClearAddFields()
        {
            IncomeAdd.RecurringCheckbox.Checked = false;
            IncomeAdd.AmountInput.Value = 0.10m;
            IncomeAdd.InitialDatePicker.Value = DateTime.UtcNow;
            IncomeAdd.IntervalTextBox.Text = string.Empty;
            IncomeAdd.PayerDropDown.SelectedIndex = 0;
            IncomeAdd.ReferenceText.Text = string.Empty;
        }

        /// <summary>
        /// Handles deleting an <see cref="Income"/> record
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public static void DeleteIncome(object sender, EventArgs e)
        {
            try
            {
                var selectedListItems = IncomeView.IncomeListView.SelectedItems;

                if (selectedListItems.Count > 0)
                {
                    var selectedItem = selectedListItems[0];
                    var incomeId = Guid.Parse(selectedItem.SubItems[0].Text);
                    var income = ListAccessHelper.FindIncome(incomeId);

                    ListAccessHelper.IncomeList.Remove(income);
                    XmlDA.SaveXml();
                    DA.DeleteIncome(incomeId);
                    PopulateListView();
                }
            }
            catch (Exception ex)
            {
                ErrorHelper.SendError(ex);
            }
        }
    }
}
