namespace EAD_Cwk2_EMoore_W1442006.Controllers
{
    using DataAccess;
    using Helpers;
    using Models;
    using System;
    using System.Windows.Forms;
    using Views;

    /// <summary>
    /// An instance of <see cref="ExpenseController"/> that handles logic for all <see cref="Expense"/> related views
    /// </summary>
    public static class ExpenseController
    {
        /// <summary>
        /// An instance of <see cref="Views.ExpenseAdd"/> class view
        /// </summary>
        private static ExpenseAdd ExpenseAdd { get; set; }

        /// <summary>
        /// An instance of <see cref="Views.ExpenseEdit"/> class view
        /// </summary>
        private static ExpenseEdit ExpenseEdit { get; set; }

        /// <summary>
        /// An instance of an <see cref="Expense"/> model used for editing an existing expense
        /// </summary>
        private static Expense EditExpense { get; set; }

        /// <summary>
        /// An instance of <see cref="Views.ExpenseView"/> class view
        /// </summary>
        public static ExpenseView ExpenseView { get; set; }

        /// <summary>
        /// An instance of <see cref="DatabaseDataAccess"/> class for handling database interactions
        /// </summary>
        private static DatabaseDataAccess DA { get; } = new DatabaseDataAccess();

        /// <summary>
        /// An instance of <see cref="XmlDataAccess"/> class for handling XML loading and saving
        /// </summary>
        private static XmlDataAccess XmlDA { get; } = new XmlDataAccess();

        /// <summary>
        /// Handles backward navigation
        /// </summary>
        /// <param name="sender">The sender object</param>
        /// <param name="e">Event arguments</param>
        public static void ViewBackButton(object sender, EventArgs e)
        {
            ExpenseView.Owner.Show();
            ExpenseView.Close();
        }

        /// <summary>
        /// Handles navigating to the <see cref="Views.ExpenseEdit"/>
        /// </summary>
        /// <param name="sender">The sender object</param>
        /// <param name="e">Event arguments</param>
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

        /// <summary>
        /// Handles the <see cref="Views.ExpenseEdit"/> form being closed
        /// </summary>
        /// <param name="sender">The sender object</param>
        /// <param name="e">Event arguments</param>
        private static void ExpenseEditViewOnFormClosed(object sender, FormClosedEventArgs e)
        {
            ExpenseEdit = null;
            ExpenseView.Show();
        }

        /// <summary>
        /// Handles navigating to <see cref="Views.ExpenseAdd"/>
        /// </summary>
        /// <param name="sender">The sender object</param>
        /// <param name="e">Event arguments</param>
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

        /// <summary>
        /// Handles the <see cref="Views.ExpenseAdd"/> form being closed
        /// </summary>
        /// <param name="sender">The sender argument</param>
        /// <param name="e">Event arguments</param>
        private static void ExpenseAddViewOnFormClosed(object sender, FormClosedEventArgs e)
        {
            ExpenseAdd = null;
            ExpenseView.Show();
        }

        /// <summary>
        /// Handles the <see cref="Views.ExpenseView"/> form being shown
        /// </summary>
        /// <param name="sender">The sender argument</param>
        /// <param name="e">Event arguments</param>
        public static void ViewVisibleChanged(object sender, EventArgs e)
        {
            PopulateListView();
        }

        /// <summary>
        /// Populates the list view with <see cref="Expense"/> items
        /// </summary>
        private static void PopulateListView()
        {
            ExpenseView.ExpenseListView.Items.Clear();

            foreach (var expense in ListAccessHelper.ExpenseList)
            {
                ExpenseView.ExpenseListView.Items.Add(new ListViewItem(new[]
                {
                    expense.Id.ToString(),
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

        /// <summary>
        /// Handles the cancel button being pressed on the <see cref="Views.ExpenseEdit"/> form
        /// </summary>
        /// <param name="sender">The sender object</param>
        /// <param name="e">Event arguments</param>
        public static void EditCancelClicked(object sender, EventArgs e)
        {
            ExpenseEdit.Owner.Show();
            ExpenseEdit.Close();
        }

        /// <summary>
        ///  Handles the <see cref="Views.ExpenseEdit"/> view being shown
        /// </summary>
        /// <param name="sender">The sender object</param>
        /// <param name="e">Event arguments</param>
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

        /// <summary>
        ///  Handles the expense drop down being changed on the <see cref="Views.ExpenseEdit"/> form
        /// </summary>
        /// <param name="sender">The sender object</param>
        /// <param name="e">Event arguments</param>
        public static void EditDropDownChanged(object sender, EventArgs e)
        {
            if (ExpenseEdit.ExpenseDropDown.SelectedIndex == -1)
            {
                return;
            }

            EditExpense = ListAccessHelper.ExpenseList[ExpenseEdit.ExpenseDropDown.SelectedIndex];
            ExpenseEdit.ReferenceText.Text = EditExpense.Ref;
            ExpenseEdit.AmountNumeric.Value = EditExpense.Amount;

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

        /// <summary>
        ///  Handles the checkbox value being changed on the <see cref="Views.ExpenseEdit"/> form
        /// </summary>
        /// <param name="sender">The sender object</param>
        /// <param name="e">Event arguments</param>
        public static void EditRecurringChanged(object sender, EventArgs e)
        {
            var visible = ExpenseEdit.RecurringCheckbox.Checked;

            ExpenseEdit.IntervalLabel.Visible = visible;
            ExpenseEdit.IntervalText.Visible = visible;
            ExpenseEdit.StartDateLabel.Visible = visible;
            ExpenseEdit.InitialPaymentDateTime.Visible = visible;
        }

        /// <summary>
        ///  Handles the save and back button being pressed on the <see cref="Views.ExpenseEdit"/> form
        /// </summary>
        /// <param name="sender">The sender object</param>
        /// <param name="e">Event arguments</param>
        public static void EditSaveAndBack(object sender, EventArgs e)
        {
            var success = SaveEditExpense();

            if (success)
            {
                ExpenseEdit.Owner.Show();
                ExpenseEdit.Close();
            }
        }

        /// <summary>
        ///  Handles saving an edited <see cref="Expense"/>
        /// </summary>
        private static bool SaveEditExpense()
        {
            var reference = ExpenseEdit.ReferenceText.Text;
            var amount = ExpenseEdit.AmountNumeric.Value;

            if (string.IsNullOrEmpty(reference) || amount == decimal.Zero)
            {
                return false;
            }

            var isRecurring = ExpenseEdit.RecurringCheckbox.Checked;

            if (isRecurring && string.IsNullOrEmpty(ExpenseEdit.IntervalText.Text))
            {
                return false;
            }

            if (ExpenseEdit.PayeeDropDown.SelectedIndex == -1)
            {
                return false;
            }

            var editedExpense = new Expense
            {
                Id = EditExpense.Id,
                Payee = ListAccessHelper.PayeeList[ExpenseEdit.PayeeDropDown.SelectedIndex],
                Ref = reference,
                Amount = amount,
                IsRecurring = isRecurring,
                Interval = Convert.ToInt32(ExpenseEdit.IntervalText.Text),
                InitialPaidDate = DateTime.Parse(ExpenseEdit.InitialPaymentDateTime.Text),
                LastPaidDate = DateTime.Parse(ExpenseEdit.InitialPaymentDateTime.Text) > EditExpense.LastPaidDate ? DateTime.Parse(ExpenseEdit.InitialPaymentDateTime.Text) : EditExpense.LastPaidDate
            };

            var index = ListAccessHelper.ExpenseList.IndexOf(editedExpense);

            DA.EditExpense(editedExpense, editedExpense.Id);
            ListAccessHelper.ExpenseList[index] = editedExpense;
            XmlDA.SaveXml();
            return true;
        }

        /// <summary>
        ///  Handles the save and new button being pressed on the <see cref="Views.ExpenseEdit"/> form
        /// </summary>
        /// <param name="sender">The sender object</param>
        /// <param name="e">Event arguments</param>
        public static void EditSaveAndNew(object sender, EventArgs e)
        {
            SaveEditExpense();
            ClearEditFields();
        }

        /// <summary>
        ///  Handles clearing all fields on the <see cref="Views.ExpenseEdit"/> form
        /// </summary>
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

        /// <summary>
        ///  Handles the add new expense button being pressed on the <see cref="Views.ExpenseView"/> form
        /// </summary>
        /// <param name="sender">The sender object</param>
        /// <param name="e">Event arguments</param>
        public static void AddShown(object sender, EventArgs e)
        {
            foreach (var payee in ListAccessHelper.PayeeList)
            {
                ExpenseAdd.PayeeDropDown.Items.Add(payee.Name);
            }
        }

        /// <summary>
        ///  Handles the cancel button being pressed on the <see cref="Views.ExpenseAdd"/> form
        /// </summary>
        /// <param name="sender">The sender object</param>
        /// <param name="e">Event arguments</param>
        public static void ExpenseCancelClick(object sender, EventArgs e)
        {
            ExpenseAdd.Owner.Show();
            ExpenseAdd.Close();
        }

        /// <summary>
        ///  Handles the save and back button being pressed on the <see cref="Views.ExpenseAdd"/> form
        /// </summary>
        /// <param name="sender">The sender object</param>
        /// <param name="e">Event arguments</param>
        public static void AddSaveAndBack(object sender, EventArgs e)
        {
            var success = SaveAddExpense();

            if (success)
            {
                ExpenseAdd.Owner.Show();
                ExpenseAdd.Close();
            }
        }

        /// <summary>
        ///  Handles saving a new <see cref="Expense"/>
        /// </summary>
        private static bool SaveAddExpense()
        {
            var reference = ExpenseAdd.ReferenceText.Text;
            var amount = ExpenseAdd.AmountInput.Value;
            var lastPaidDate = new DateTime();

            if (ExpenseAdd.PayeeDropDown.SelectedIndex == -1)
            {
                return false;
            }

            var payee = ListAccessHelper.PayeeList[ExpenseAdd.PayeeDropDown.SelectedIndex];
            var isRecurring = ExpenseAdd.RecurringCheckbox.Checked;

            if (string.IsNullOrEmpty(reference) || amount == decimal.Zero)
            {
                return false;
            }

            var interval = 0;
            var initialDate = DateTime.UtcNow;

            if (isRecurring)
            {
                if (string.IsNullOrEmpty(ExpenseAdd.IntervalTextBox.Text))
                {
                    return false;
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
            return true;
        }

        /// <summary>
        ///  Handles the save and new button being pressed on the <see cref="Views.ExpenseAdd"/> form
        /// </summary>
        /// <param name="sender">The sender object</param>
        /// <param name="e">Event arguments</param>
        public static void AddSaveAndNew(object sender, EventArgs e)
        {
            var success = SaveAddExpense();

            if (success)
            {
                ClearAddFields();
            }
        }

        /// <summary>
        ///  Handles clearing all fields on the <see cref="Views.ExpenseAdd"/> form
        /// </summary>
        private static void ClearAddFields()
        {
            ExpenseAdd.AmountInput.Value = 0.10m;
            ExpenseAdd.InitialDatePicker.Value = DateTime.UtcNow;
            ExpenseAdd.IntervalTextBox.Text = string.Empty;
            ExpenseAdd.PayeeDropDown.SelectedIndex = 0;
            ExpenseAdd.RecurringCheckbox.Checked = false;
            ExpenseAdd.ReferenceText.Text = string.Empty;
        }

        /// <summary>
        ///  Handles the checkbox value being changed on the <see cref="Views.ExpenseAdd"/> form
        /// </summary>
        /// <param name="sender">The sender object</param>
        /// <param name="e">Event arguments</param>
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

        /// <summary>
        /// Handles the deletion of an <see cref="Expense"/>
        /// </summary>
        /// <param name="sender">The sender object</param>
        /// <param name="e">Event arguments</param>
        public static void DeleteExpense(object sender, EventArgs e)
        {
            try
            {
                var selectedListItems = ExpenseView.ExpenseListView.SelectedItems;

                if (selectedListItems.Count > 0)
                {
                    var selectedItem = selectedListItems[0];
                    var expenseId = Guid.Parse(selectedItem.SubItems[0].Text);
                    var expense = ListAccessHelper.FindExpense(expenseId);
                    
                    ListAccessHelper.ExpenseList.Remove(expense);
                    XmlDA.SaveXml();
                    DA.DeleteExpense(expenseId);
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
