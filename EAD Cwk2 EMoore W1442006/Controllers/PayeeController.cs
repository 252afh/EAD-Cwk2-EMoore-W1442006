namespace EAD_Cwk2_EMoore_W1442006.Controllers
{
    using DataAccess;
    using Helpers;
    using Models;
    using System;
    using System.Windows.Forms;
    using Views;

    /// <summary>
    /// An instance of <see cref="PayeeController"/> that handles logic for all <see cref="Payee"/> related forms
    /// </summary>
    public static class PayeeController
    {
        /// <summary>
        /// An instance of <see cref="Payee"/> used for editing an existing record
        /// </summary>
        private static Payee EditPayee { get; set; }

        /// <summary>
        /// An instance of the <see cref="Views.PayeeEdit"/> form
        /// </summary>
        private static PayeeEdit PayeeEdit { get; set; }

        /// <summary>
        /// An instance of the <see cref="Views.PayeeAdd"/> form
        /// </summary>
        private static PayeeAdd PayeeAdd { get; set; }

        /// <summary>
        /// An instance of the <see cref="PayeeViewForm"/> form
        /// </summary>
        public static PayeeViewForm PayeeView { get; set; }

        /// <summary>
        /// An instance of the <see cref="DatabaseDataAccess"/> class used for handling database interactions
        /// </summary>
        private static DatabaseDataAccess DA { get; } = new DatabaseDataAccess();

        /// <summary>
        /// An instance of the <see cref="XmlDataAccess"/> class used for handling XML loading and saving
        /// </summary>
        private static XmlDataAccess XmlDA { get; } = new XmlDataAccess();

        /// <summary>
        ///  Handles opening a <see cref="Views.PayeeEdit"/> form being opened from a <see cref="PayeeViewForm"/> forms
        /// </summary>
        /// <param name="sender">The sender object</param>
        /// <param name="e">Event arguments</param>
        public static void EditPayeeClick(object sender, EventArgs e)
        {
            if (PayeeEdit == null)
            {
                PayeeEdit = new PayeeEdit();
                PayeeEdit.FormClosed += PayeeEditViewOnFormClosed;
            }

            var selectedItems = PayeeView.payeeListView.SelectedItems;

            if (selectedItems.Count > 0)
            {
                var selecteditem = selectedItems[0];
                var payeeId = Guid.Parse(selecteditem.SubItems[0].Text);
                var payee = ListAccessHelper.FindPayee(payeeId);

                EditPayee = payee;
            }
            else
            {
                EditPayee = null;
            }

            PayeeEdit.Show(PayeeView);
            PayeeView.Hide();
        }

        /// <summary>
        ///  Handles a <see cref="Views.PayeeEdit"/> form being closed
        /// </summary>
        /// <param name="sender">The sender object</param>
        /// <param name="e">Event arguments</param>
        private static void PayeeEditViewOnFormClosed(object sender, FormClosedEventArgs e)
        {
            PayeeEdit = null;
            PayeeView.Show();
        }

        /// <summary>
        /// Handles a <see cref="Views.PayeeAdd"/> form being opened from a <see cref="PayeeViewForm"/> form
        /// </summary>
        /// <param name="sender">The sender object</param>
        /// <param name="e">Event arguments</param>
        public static void AddPayeeClick(object sender, EventArgs e)
        {
            if (PayeeAdd == null)
            {
                PayeeAdd = new PayeeAdd();
                PayeeAdd.FormClosed += PayeeAddViewOnClick;
            }

            PayeeAdd.Show(PayeeView);
            PayeeView.Hide();
        }

        /// <summary>
        /// Handles a <see cref="Views.PayeeAdd"/> form being opened from a <see cref="Views.PayeeAdd"/> form
        /// </summary>
        /// <param name="sender">The sender object</param>
        /// <param name="e">Event arguments</param>
        private static void PayeeAddViewOnClick(object sender, EventArgs e)
        {
            PayeeAdd = null;
            PayeeView.Show();
        }

        /// <summary>
        /// Handles the back button being clicked on a <see cref="PayeeViewForm"/> form
        /// </summary>
        /// <param name="sender">The sender object</param>
        /// <param name="e">Event arguments</param>
        public static void BackClick(object sender, EventArgs e)
        {
            PayeeView.Owner.Show();
            PayeeView.Close();
        }

        /// <summary>
        /// Handles the visibility of a <see cref="PayeeViewForm"/> being changed
        /// </summary>
        /// <param name="sender">The sender object</param>
        /// <param name="e">Event arguments</param>
        public static void ViewVisibleChanged(object sender, EventArgs e)
        {
            PayeeView.payeeListView.Items.Clear();

            foreach (var payee in ListAccessHelper.PayeeList)
            {
                PayeeView.payeeListView.Items.Add(new ListViewItem(new[]
                {
                    payee.Id.ToString(),
                    payee.Name,
                    payee.Address,
                    payee.AccNumber,
                    payee.SortCode
                }));
            }
        }

        /// <summary>
        /// Handles the cancel button being clicked on a <see cref="Views.PayeeAdd"/> form
        /// </summary>
        /// <param name="sender">The sender object</param>
        /// <param name="e">Event arguments</param>
        public static void AddCancelClick(object sender, EventArgs e)
        {
            PayeeAdd.Owner.Show();
            PayeeAdd.Close();
        }

        /// <summary>
        /// Handles the save and back button being clicked on a <see cref="Views.PayeeAdd"/> form
        /// </summary>
        /// <param name="sender">The sender object</param>
        /// <param name="e">Event arguments</param>
        public static void AddSaveAndBack(object sender, EventArgs e)
        {
            var success = AddPayee();

            if (success)
            {
                PayeeAdd.Owner.Show();
                PayeeAdd.Close();
            }
        }

        /// <summary>
        /// Handles adding a new <see cref="Payee"/>
        /// </summary>
        private static bool AddPayee()
        {
            var payeeName = PayeeAdd.NameText.Text;
            var address = PayeeAdd.addressText.Text;
            var sortCode = PayeeAdd.SortCodeText.Text;
            var accNumber = PayeeAdd.AccNumberText.Text;

            if (string.IsNullOrEmpty(payeeName) || string.IsNullOrEmpty(sortCode) || string.IsNullOrEmpty(accNumber) || string.IsNullOrEmpty(address))
            {
                return false;
            }

            var payee = new Payee
            {
                Id = Guid.NewGuid(),
                Name = payeeName,
                Address = address,
                AccNumber = accNumber,
                SortCode = sortCode
            };

            DA.InsertPayee(payee);
            ListAccessHelper.PayeeList.Add(payee);
            XmlDA.SaveXml();
            return true;
        }

        /// <summary>
        /// Handles the save and back button being pressed on a <see cref="Views.PayeeAdd"/> form
        /// </summary>
        /// <param name="sender">The sender object</param>
        /// <param name="e">Event arguments</param>
        public static void AddSaveAndNew(object sender, EventArgs e)
        {
            var success = AddPayee();

            if (success)
            {
                ClearAddFields();
            }
        }

        /// <summary>
        /// Handles clearing all fields on a <see cref="Views.PayeeAdd"/> form
        /// </summary>
        private static void ClearAddFields()
        {
            PayeeAdd.AccNumberText.Text = string.Empty;
            PayeeAdd.NameText.Text = string.Empty;
            PayeeAdd.SortCodeText.Text = string.Empty;
            PayeeAdd.addressText.Text = string.Empty;
        }

        /// <summary>
        /// Handles the back button being pressed on a <see cref="Views.PayeeEdit"/> form
        /// </summary>
        /// <param name="sender">The sender object</param>
        /// <param name="e">Event arguments</param>
        public static void EditCancelClick(object sender, EventArgs e)
        {
            PayeeEdit.Owner.Show();
            PayeeEdit.Close();
        }

        /// <summary>
        /// Handles an <see cref="Views.PayeeEdit"/> form being shown
        /// </summary>
        /// <param name="sender">The sender object</param>
        /// <param name="e">Event arguments</param>
        public static void EditShown(object sender, EventArgs e)
        {
            foreach (var payee in ListAccessHelper.PayeeList)
            {
                PayeeEdit.PayeeCombobox.Items.Add(payee.Name + " - " + payee.AccNumber);
            }

            if (EditPayee != null)
            {
                var index = ListAccessHelper.PayeeList.IndexOf(EditPayee);
                PayeeEdit.PayeeCombobox.SelectedIndex = index;
            }
        }

        /// <summary>
        /// Handles the dropdown value changing on a <see cref="Views.PayeeEdit"/> form
        /// </summary>
        /// <param name="sender">The sender object</param>
        /// <param name="e">Event arguments</param>
        public static void SelectedIndexChanged(object sender, EventArgs e)
        {
            if (PayeeEdit.PayeeCombobox.SelectedIndex == -1)
            {
                return;
            }

            EditPayee = ListAccessHelper.PayeeList[PayeeEdit.PayeeCombobox.SelectedIndex];

            PayeeEdit.AccNumberText.Text = EditPayee.AccNumber;
            PayeeEdit.NameText.Text = EditPayee.Name;
            PayeeEdit.SortCodeText.Text = EditPayee.SortCode;
            PayeeEdit.addressText.Text = EditPayee.Address;
        }

        /// <summary>
        /// Handles the save and back button being pressed on a <see cref="Views.PayeeEdit"/> forms
        /// </summary>
        /// <param name="sender">The sender object</param>
        /// <param name="e">Event arguments</param>
        public static void EditSaveAndBack(object sender, EventArgs e)
        {
            var success = SaveEditPayee();

            if (success)
            {
                PayeeEdit.Owner.Show();
                PayeeEdit.Close();
            }
        }

        /// <summary>
        /// Handles saving a new <see cref="Payee"/>
        /// </summary>
        private static bool SaveEditPayee()
        {
            var address = PayeeEdit.addressText.Text;
            var acc = PayeeEdit.AccNumberText.Text;
            var name = PayeeEdit.NameText.Text;
            var sortcode = PayeeEdit.SortCodeText.Text;

            if (string.IsNullOrEmpty(address) || string.IsNullOrEmpty(acc) || string.IsNullOrEmpty(name) ||
                string.IsNullOrEmpty(sortcode))
            {
                return false;
            }

            var editedPayee = new Payee
            {
                Id = EditPayee.Id,
                AccNumber = acc,
                Address = address,
                Name = name,
                SortCode = sortcode
            };

            var selectedIndex = PayeeEdit.PayeeCombobox.SelectedIndex;

            DA.EditPayee(editedPayee, editedPayee.Id);
            ListAccessHelper.PayeeList[selectedIndex] = editedPayee;
            XmlDA.SaveXml();
            return true;
        }

        /// <summary>
        /// Handles the save and new button being pressed on a <see cref="Views.PayeeEdit"/> form
        /// </summary>
        /// <param name="sender">The sender object</param>
        /// <param name="e">Event arguments</param>
        public static void EditsaveAndNew(object sender, EventArgs e)
        {
            var success = SaveEditPayee();

            if (success)
            {
                ClearEditFields();
            }
        }

        /// <summary>
        /// Handles clearing all fields on a <see cref="Views.PayeeEdit"/> form
        /// </summary>
        private static void ClearEditFields()
        {
            PayeeEdit.PayeeCombobox.SelectedIndex = 0;
            PayeeEdit.AccNumberText.Text = string.Empty;
            PayeeEdit.NameText.Text = string.Empty;
            PayeeEdit.SortCodeText.Text = string.Empty;
            PayeeEdit.addressText.Text = string.Empty;
        }
    }
}
