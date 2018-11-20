namespace EAD_Cwk2_EMoore_W1442006.Controllers
{
    using DataAccess;
    using Helpers;
    using System;
    using System.Windows.Forms;
    using Views;
    using Payer = Models.Payer;

    /// <summary>
    /// An instance of <see cref="PayerController"/> that handles logic for all <see cref="Payer"/> related views
    /// </summary>
    public static class PayerController
    {
        /// <summary>
        /// An instance of <see cref="Views.PayersEdit"/> class view
        /// </summary>
        private static PayersEdit PayersEdit { get; set; }

        /// <summary>
        /// An instance of <see cref="Payer"/> used for editing an existing record
        /// </summary>
        private static Payer EditedPayer { get; set; }

        /// <summary>
        /// An instance of <see cref="Views.PayersAdd"/> class view
        /// </summary>
        private static PayersAdd PayersAdd { get; set; }

        /// <summary>
        /// An instance of <see cref="Views.PayerView"/> class view
        /// </summary>
        public static Views.PayerView PayerView { get; set; }

        /// <summary>
        /// An instance of <see cref="DatabaseDataAccess"/> used for database interactions
        /// </summary>
        private static DatabaseDataAccess DA { get; } = new DatabaseDataAccess();

        /// <summary>
        /// An instance of <see cref="XmlDataAccess"/> used for loading and saving XML
        /// </summary>
        private static XmlDataAccess XmlDA { get; } = new XmlDataAccess();

        /// <summary>
        /// Handles saving an edited <see cref="Payer"/>
        /// </summary>
        public static bool EditPayer()
        {
            var name = PayersEdit.NameText.Text;
            var paymentType = PayersEdit.PaymentTypeText.Text;

            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(paymentType))
            {
                return false;
            }

            var editedPayer = new Payer
            {
                Id = EditedPayer.Id,
                Name = PayersEdit.NameText.Text,
                PaymentType = PayersEdit.PaymentTypeText.Text
            };

            var index = PayersEdit.PayerCombobox.SelectedIndex;

            DA.EditPayer(editedPayer, EditedPayer.Id);
            ListAccessHelper.PayerList[index] = editedPayer;
            XmlDA.SaveXml();
            return true;
        }

        /// <summary>
        /// Handles clearing all fields on a <see cref="Views.PayersEdit"/> form
        /// </summary>
        public static void ClearEditFields()
        {
            PayersEdit.NameText.Text = string.Empty;
            PayersEdit.PaymentTypeText.Text = string.Empty;
            PayersEdit.PayerCombobox.SelectedIndex = 0;
        }

        /// <summary>
        /// Handles the dropdown value changing on a <see cref="Views.PayersEdit"/> form
        /// </summary>
        /// <param name="sender">The sender object</param>
        /// <param name="e">Event arguments</param>
        public static void EditIndexChanged(object sender, EventArgs e)
        {
            EditedPayer = ListAccessHelper.PayerList[PayersEdit.PayerCombobox.SelectedIndex];

            PayersEdit.NameText.Text = EditedPayer.Name;
            PayersEdit.PaymentTypeText.Text = EditedPayer.PaymentType;
        }

        /// <summary>
        /// Handles the cancel button being pressed on a <see cref="Views.PayersEdit"/> form
        /// </summary>
        /// <param name="sender">The sender object</param>
        /// <param name="e">Event arguments</param>
        public static void EditCancelClicked(object sender, EventArgs e)
        {
            PayersEdit.Owner.Show();
            PayersEdit.Close();
        }

        /// <summary>
        /// Handles a <see cref="Views.PayersEdit"/> form being shown
        /// </summary>
        /// <param name="sender">The sender object</param>
        /// <param name="e">Event arguments</param>
        public static void EditShown(object sender, EventArgs e)
        {
            foreach (var payer in ListAccessHelper.PayerList)
            {
                PayersEdit.PayerCombobox.Items.Add(payer.Name + " - " + payer.PaymentType);
            }

            if (EditedPayer != null)
            {
                var index = ListAccessHelper.PayerList.IndexOf(EditedPayer);
                PayersEdit.PayerCombobox.SelectedIndex = index;
            }
        }

        /// <summary>
        /// Handles the save and back button being pressed on a <see cref="Views.PayersEdit"/> form
        /// </summary>
        /// <param name="sender">The sender object</param>
        /// <param name="e">Event arguments</param>
        public static void EditSaveAndBack(object sender, EventArgs e)
        {
            var success = EditPayer();

            if (success)
            {
                PayersEdit.Owner.Show();
                PayersEdit.Close();
            }
        }

        /// <summary>
        /// Handles the save and new button being pressed on a <see cref="Views.PayersEdit"/> form
        /// </summary>
        /// <param name="sender">The sender object</param>
        /// <param name="e">Event arguments</param>
        public static void EditSaveAndNew(object sender, EventArgs e)
        {
            var success = EditPayer();

            if (success)
            {
                ClearEditFields();
            }
        }

        /// <summary>
        /// Handles the cancel button being pressed on a <see cref="Views.PayersAdd"/> form
        /// </summary>
        /// <param name="sender">The sender object</param>
        /// <param name="e">Event arguments</param>
        public static void AddCancelClick(object sender, EventArgs e)
        {
            PayersAdd.Owner.Show();
            PayersAdd.Close();
        }

        /// <summary>
        /// Handles adding a new <see cref="Payer"/>
        /// </summary>
        private static bool AddNewPayer()
        {
            var name = PayersAdd.NameText.Text;
            var paymentType = PayersAdd.PaymentTypeText.Text;

            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(paymentType))
            {
                return false;
            }

            var payer = new Payer
            {
                Id = Guid.NewGuid(),
                Name = name,
                PaymentType = paymentType
            };

            DA.InsertPayer(payer);
            ListAccessHelper.PayerList.Add(payer);
            XmlDA.SaveXml();
            return true;
        }

        /// <summary>
        /// Handles clearing all fields on a <see cref="Views.PayersAdd"/> form
        /// </summary>
        private static void ClearAddFields()
        {
            PayersAdd.NameText.Text = string.Empty;
            PayersAdd.PaymentTypeText.Text = string.Empty;
        }

        /// <summary>
        /// Handles the save and back button being pressed on a <see cref="Views.PayersAdd"/> form
        /// </summary>
        /// <param name="sender">The sender object</param>
        /// <param name="e">Event arguments</param>
        public static void AddSaveAndBack(object sender, EventArgs e)
        {
            var success = AddNewPayer();

            if (success)
            {
                PayersAdd.Owner.Show();
                PayersAdd.Close();
            }
        }

        /// <summary>
        /// Handles the save and new button being pressed on a <see cref="Views.PayersAdd"/> form
        /// </summary>
        /// <param name="sender">The sender object</param>
        /// <param name="e">Event arguments</param>
        public static void AddSaveAndNew(object sender, EventArgs e)
        {
            var success = AddNewPayer();

            if (success)
            {
                ClearAddFields();
            }
        }

        /// <summary>
        /// Handles the back buton being pressed on a <see cref="Views.PayerView"/> form
        /// </summary>
        /// <param name="sender">The sender object</param>
        /// <param name="e">Event arguments</param>
        public static void ViewBackButton(object sender, EventArgs e)
        {
            PayerView.Owner.Show();
            PayerView.Close();
        }

        /// <summary>
        /// Handles a new <see cref="Views.PayersEdit"/> form being opened from a <see cref="Views.PayerView"/> form
        /// </summary>
        /// <param name="sender">The sender object</param>
        /// <param name="e">Event arguments</param>
        public static void EditPayerClicked(object sender, EventArgs e)
        {
            if (PayersEdit == null)
            {
                PayersEdit = new PayersEdit();
                PayersEdit.FormClosed += PayerEditViewOnFormClosed;
            }

            var selectedItems = PayerView.PayerListView.SelectedItems;

            if (selectedItems.Count > 0)
            {
                var selectedItem = selectedItems[0];
                var payerId = Guid.Parse(selectedItem.SubItems[0].Text);
                var payer = ListAccessHelper.FindPayer(payerId);

                EditedPayer = payer;
            }
            else
            {
                EditedPayer = null;
            }

            PayersEdit.Show(PayerView);
            PayerView.Hide();
        }

        /// <summary>
        /// Handles a <see cref="PayeeEdit"/> form being closed
        /// </summary>
        /// <param name="sender">The sender object</param>
        /// <param name="e">Event arguments</param>
        private static void PayerEditViewOnFormClosed(object sender, FormClosedEventArgs e)
        {
            PayersEdit = null;
            PayerView.Show();
        }

        /// <summary>
        /// Handles a <see cref="Views.PayersAdd"/> form being opened from a <see cref="Views.PayerView"/> form
        /// </summary>
        /// <param name="sender">The sender object</param>
        /// <param name="e">Event arguments</param>
        public static void AddPayerClicked(object sender, EventArgs e)
        {
            if (PayersAdd == null)
            {
                PayersAdd = new PayersAdd();
                PayersAdd.FormClosed += PayerAddViewOnFormClosed;
            }

            PayersAdd.Show(PayerView);
            PayerView.Hide();
        }

        /// <summary>
        /// Handles a <see cref="Views.PayersAdd"/> form being closed
        /// </summary>
        /// <param name="sender">The sender object</param>
        /// <param name="e">Event arguments</param>
        private static void PayerAddViewOnFormClosed(object sender, FormClosedEventArgs e)
        {
            PayersAdd = null;
            PayerView.Show();
        }

        /// <summary>
        /// Handles the visibility of a <see cref="Views.PayerView"/> form being changed
        /// </summary>
        /// <param name="sender">The sender object</param>
        /// <param name="e">Event arguments</param>
        public static void ViewVisibleChanged(object sender, EventArgs e)
        {
            PopulateListView();
        }

        /// <summary>
        /// Handles populating the list view with <see cref="Payer"/> items
        /// </summary>
        private static void PopulateListView()
        {
            PayerView.PayerListView.Items.Clear();

            foreach (var payer in ListAccessHelper.PayerList)
            {
                PayerView.PayerListView.Items.Add(new ListViewItem(new[]
                    {payer.Id.ToString(), payer.Name, payer.PaymentType}));
            }
        }

        /// <summary>
        /// Handles deleting a <see cref="Payer"/> record
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public static void DeletePayer(object sender, EventArgs e)
        {
            try
            {
                var selectedListItems = PayerView.PayerListView.SelectedItems;

                if (selectedListItems.Count > 0)
                {
                    var selectedItem = selectedListItems[0];
                    var payerId = Guid.Parse(selectedItem.SubItems[0].Text);
                    var payer = ListAccessHelper.FindPayer(payerId);

                    ListAccessHelper.PayerList.Remove(payer);
                    XmlDA.SaveXml();
                    DA.DeletePayer(payerId);
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
