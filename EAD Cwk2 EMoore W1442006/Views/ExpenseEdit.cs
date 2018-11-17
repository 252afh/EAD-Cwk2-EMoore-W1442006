using System;
using System.Linq;
using System.Windows.Forms;
using EAD_Cwk2_EMoore_W1442006.Controllers;
using EAD_Cwk2_EMoore_W1442006.DataAccess;
using EAD_Cwk2_EMoore_W1442006.Helpers;
using EAD_Cwk2_EMoore_W1442006.Models;

namespace EAD_Cwk2_EMoore_W1442006.Views
{
    public partial class ExpenseEdit : Form
    {
        public ExpenseEdit()
        {
            InitializeComponent();
            this.CancelButton.Click += ExpenseController.EditCancelClicked;
            this.Shown += ExpenseController.EditShown;
            this.PayeeDropDown.SelectedIndexChanged += ExpenseController.EditDropDownChanged;
            this.RecurringCheckbox.CheckedChanged += ExpenseController.EditRecurringChanged;
            this.SaveAndBackButton.Click += ExpenseController.EditSaveAndBack;
            this.SaveAndNewButton.Click += ExpenseController.EditSaveAndNew;
        }
    }
}
