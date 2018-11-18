namespace EAD_Cwk2_EMoore_W1442006.Views
{
    using Controllers;
    using System.Windows.Forms;

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
