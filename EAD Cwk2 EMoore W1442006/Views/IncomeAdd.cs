using EAD_Cwk2_EMoore_W1442006.Helpers;
using EAD_Cwk2_EMoore_W1442006.Models;
using System;
using System.Windows.Forms;
using EAD_Cwk2_EMoore_W1442006.Controllers;
using EAD_Cwk2_EMoore_W1442006.DataAccess;

namespace EAD_Cwk2_EMoore_W1442006.Views
{
    public partial class IncomeAdd : Form
    {
        public IncomeAdd()
        {
            InitializeComponent();
            this.Shown += IncomeController.AddShown;
            this.CancelButton.Click += IncomeController.AddCancelClicked;
            this.RecurringCheckbox.CheckedChanged += IncomeController.AddRecurringChange;
            this.SaveAndBackButton.Click += IncomeController.AddSaveAndBack;
            this.SaveAndNewButton.Click += IncomeController.AddSaveAndNew;
        }
    }
}
