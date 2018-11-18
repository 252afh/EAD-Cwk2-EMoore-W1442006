﻿namespace EAD_Cwk2_EMoore_W1442006.Controllers
{
    using DataAccess;
    using Helpers;
    using System;
    using System.Windows.Forms;
    using Views;
    using Payer = Models.Payer;

    public static class PayerController
    {
        private static PayersEdit PayersEdit { get; set; }

        private static Payer EditedPayer { get; set; }

        private static PayersAdd PayersAdd { get; set; }

        public static Views.Payer PayerView { get; set; }

        private static DatabaseDataAccess DA { get; } = new DatabaseDataAccess();

        private static XmlDataAccess XmlDA { get; } = new XmlDataAccess();


        public static void EditPayer(Payer payer)
        {
            var editedPayer = new Payer
            {
                Id = payer.Id,
                Name = PayersEdit.NameText.Text,
                PaymentType = PayersEdit.PaymentTypeText.Text
            };

            var index = PayersEdit.PayerCombobox.SelectedIndex;

            DA.EditPayer(editedPayer, payer.Id);
            ListAccessHelper.PayerList[index] = editedPayer;
            XmlDA.SaveXml();
        }

        public static void ClearEditFields()
        {
            PayersEdit.NameText.Text = string.Empty;
            PayersEdit.PaymentTypeText.Text = string.Empty;
            PayersEdit.PayerCombobox.SelectedIndex = 0;
        }

        public static void EditIndexChanged(object sender, EventArgs e)
        {
            EditedPayer = ListAccessHelper.PayerList[PayersEdit.PayerCombobox.SelectedIndex];

            PayersEdit.NameText.Text = EditedPayer.Name;
            PayersEdit.PaymentTypeText.Text = EditedPayer.PaymentType;
        }

        public static void EditCancelClicked(object sender, EventArgs e)
        {
            PayersEdit.Owner.Show();
            PayersEdit.Close();
        }

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

        public static void EditSaveAndBack(object sender, EventArgs e)
        {
            EditPayer(EditedPayer);
            PayersEdit.Owner.Show();
            PayersEdit.Close();
        }

        public static void EditSaveAndNew(object sender, EventArgs e)
        {
            EditPayer(EditedPayer);
            ClearEditFields();
        }

        public static void AddCancelClick(object sender, EventArgs e)
        {
            PayersAdd.Owner.Show();
            PayersAdd.Close();
        }

        private static void AddNewPayer()
        {
            var name = PayersAdd.NameText.Text;

            if (string.IsNullOrEmpty(name))
            {
                return;
            }

            var payer = new Payer
            {
                Id = Guid.NewGuid(),
                Name = name,
                PaymentType = PayersAdd.PaymentTypeText.Text
            };

            DA.InsertPayer(payer);
            ListAccessHelper.PayerList.Add(payer);
            XmlDA.SaveXml();
        }

        private static void ClearAddFields()
        {
            PayersAdd.NameText.Text = string.Empty;
            PayersAdd.PaymentTypeText.Text = string.Empty;
        }

        public static void AddSaveAndBack(object sender, EventArgs e)
        {
            AddNewPayer();
            PayersAdd.Owner.Show();
            PayersAdd.Close();
        }

        public static void AddSaveAndNew(object sender, EventArgs e)
        {
            AddNewPayer();
            ClearAddFields();
        }

        public static void ViewBackButton(object sender, EventArgs e)
        {
            PayerView.Owner.Show();
            PayerView.Close();
        }

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

        private static void PayerEditViewOnFormClosed(object sender, FormClosedEventArgs e)
        {
            PayersEdit = null;
            PayerView.Show();
        }

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

        private static void PayerAddViewOnFormClosed(object sender, FormClosedEventArgs e)
        {
            PayersAdd = null;
            PayerView.Show();
        }

        public static void ViewVisibleChanged(object sender, EventArgs e)
        {
            PayerView.PayerListView.Items.Clear();

            foreach (var payer in ListAccessHelper.PayerList)
            {
                PayerView.PayerListView.Items.Add(new ListViewItem(new[] { payer.Id.ToString(), payer.Name, payer.PaymentType }));
            }
        }
    }
}
