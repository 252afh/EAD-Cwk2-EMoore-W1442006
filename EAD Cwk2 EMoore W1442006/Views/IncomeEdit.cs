using System;
using System.Windows.Forms;
using EAD_Cwk2_EMoore_W1442006.Controllers;
using EAD_Cwk2_EMoore_W1442006.DataAccess;
using EAD_Cwk2_EMoore_W1442006.Helpers;
using EAD_Cwk2_EMoore_W1442006.Models;

namespace EAD_Cwk2_EMoore_W1442006.Views
{
    public partial class IncomeEdit : Form
    {

        public IncomeEdit()
        {
            InitializeComponent();
            this.CancelButton.Click += IncomeController.EditCancelClicked;
            this.IncomeDropDown.SelectedIndexChanged += IncomeController.EditIndexChanged;
            this.Shown += IncomeController.EditShown;
            this.RecurringCheckbox.CheckedChanged += IncomeController.EditRecurringChanged;
            this.SaveAndBackButton.Click += IncomeController.EditSaveAndBack;
            this.SaveAndNewButton.Click += IncomeController.EditSaveAndNew;
        }
    }
}
