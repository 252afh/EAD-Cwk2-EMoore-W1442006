using System;
using System.Windows.Forms;
using EAD_Cwk2_EMoore_W1442006.Controllers;
using EAD_Cwk2_EMoore_W1442006.DataAccess;
using EAD_Cwk2_EMoore_W1442006.Helpers;
using EAD_Cwk2_EMoore_W1442006.Models;

namespace EAD_Cwk2_EMoore_W1442006.Views
{
    public partial class ExpenseAdd : Form
    {
        public ExpenseAdd()
        {
            InitializeComponent();
            this.Shown += ExpenseController.AddShown;
            this.CancelButton.Click += ExpenseController.ExpenseCancelClick;
            this.SaveAndBackButton.Click += ExpenseController.AddSaveAndBack;
            this.SaveAndNewButton.Click += ExpenseController.AddSaveAndNew;
            this.RecurringCheckbox.CheckedChanged += ExpenseController.AddRecurringChanged;
        }
    }
}
