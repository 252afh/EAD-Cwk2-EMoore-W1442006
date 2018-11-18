namespace EAD_Cwk2_EMoore_W1442006.Controllers
{
    using DataAccess;
    using Helpers;
    using Models;
    using System;
    using System.Windows.Forms;
    using Views;

    public static class PayeeController
    {
        private static Payee EditPayee { get; set; }

        private static PayeeEdit PayeeEdit { get; set; }

        private static PayeeAdd PayeeAdd { get; set; }

        public static PayeeViewForm PayeeView { get; set; }

        private static DatabaseDataAccess DA { get; } = new DatabaseDataAccess();

        private static XmlDataAccess XmlDA { get; } = new XmlDataAccess();

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

        private static void PayeeEditViewOnFormClosed(object sender, FormClosedEventArgs e)
        {
            PayeeEdit = null;
            PayeeView.Show();
        }

        public static void AddPayeeClick(object sender, EventArgs e)
        {
            if (PayeeAdd == null)
            {
                PayeeAdd = new PayeeAdd();
                PayeeAdd.FormClosed += PayeeAddViewOnClick;
            }

            PayeeView.Hide();
            PayeeAdd.Show(PayeeView);
        }

        private static void PayeeAddViewOnClick(object sender, EventArgs e)
        {
            PayeeAdd = null;
            PayeeView.Show();
        }

        public static void BackClick(object sender, EventArgs e)
        {
            PayeeView.Owner.Show();
            PayeeView.Close();
        }

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

        public static void AddCancelClick(object sender, EventArgs e)
        {
            PayeeAdd.Owner.Show();
            PayeeAdd.Close();
        }


        public static void AddSaveAndBack(object sender, EventArgs e)
        {
            AddPayee();
            PayeeAdd.Owner.Show();
            PayeeAdd.Close();
        }

        private static void AddPayee()
        {
            var payeeName = PayeeAdd.NameText.Text;
            var address = PayeeAdd.addressText.Text;
            var sortCode = PayeeAdd.SortCodeText.Text;
            var accNumber = PayeeAdd.AccNumberText.Text;

            if (string.IsNullOrEmpty(payeeName) || string.IsNullOrEmpty(sortCode) || string.IsNullOrEmpty(accNumber) || string.IsNullOrEmpty(address))
            {
                return;
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
        }

        public static void AddSaveAndNew(object sender, EventArgs e)
        {
            AddPayee();
            ClearAddFields();
        }

        private static void ClearAddFields()
        {
            PayeeAdd.AccNumberText.Text = string.Empty;
            PayeeAdd.NameText.Text = string.Empty;
            PayeeAdd.SortCodeText.Text = string.Empty;
            PayeeAdd.addressText.Text = string.Empty;
        }

        public static void EditCancelClick(object sender, EventArgs e)
        {
            PayeeEdit.Owner.Show();
            PayeeEdit.Close();
        }

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

        public static void EditSaveAndBack(object sender, EventArgs e)
        {
            SaveEditPayee();
            PayeeEdit.Owner.Show();
            PayeeEdit.Close();
        }

        private static void SaveEditPayee()
        {
            var editedPayee = new Payee
            {
                Id = EditPayee.Id,
                AccNumber = PayeeEdit.AccNumberText.Text,
                Address = PayeeEdit.addressText.Text,
                Name = PayeeEdit.NameText.Text,
                SortCode = PayeeEdit.SortCodeText.Text
            };

            var selectedIndex = PayeeEdit.PayeeCombobox.SelectedIndex;

            DA.EditPayee(editedPayee, editedPayee.Id);
            ListAccessHelper.PayeeList[selectedIndex] = editedPayee;
            XmlDA.SaveXml();
        }

        public static void EditsaveAndNew(object sender, EventArgs e)
        {
            SaveEditPayee();
            ClearEditFields();
        }

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
