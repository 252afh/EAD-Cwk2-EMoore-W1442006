namespace EAD_Cwk2_EMoore_W1442006.Views
{
    using Controllers;
    using System.Windows.Forms;

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
