using System;
using System.Windows.Forms;
using EAD_Cwk2_EMoore_W1442006.Controllers;
using EAD_Cwk2_EMoore_W1442006.DataAccess;
using EAD_Cwk2_EMoore_W1442006.Helpers;
using EAD_Cwk2_EMoore_W1442006.Models;

namespace EAD_Cwk2_EMoore_W1442006.Views
{
    public partial class PayeeEdit : Form
    {
        public PayeeEdit()
        {
            InitializeComponent();
            this.CancelButton.Click += PayeeController.EditCancelClick;
            this.Shown += PayeeController.EditShown;
            this.PayeeCombobox.SelectedIndexChanged += PayeeController.SelectedIndexChanged;
            this.SaveAndBackButton.Click += PayeeController.EditSaveAndBack;
            this.SaveAndNewButton.Click += PayeeController.EditsaveAndNew;
        }
    }
}
