using System;
using System.Windows.Forms;
using EAD_Cwk2_EMoore_W1442006.Controllers;

namespace EAD_Cwk2_EMoore_W1442006.Views
{
    public partial class PayersEdit : Form
    {
        public PayersEdit()
        {
            InitializeComponent();
            this.PayerCombobox.SelectedIndexChanged += PayerController.EditIndexChanged;
            this.CancelButton.Click += PayerController.EditCancelClicked;
            this.Shown += PayerController.EditShown;
            this.SaveAndBackButton.Click += PayerController.EditSaveAndBack;
            this.SaveAndNewButton.Click += PayerController.EditSaveAndNew;
        }
    }
}
