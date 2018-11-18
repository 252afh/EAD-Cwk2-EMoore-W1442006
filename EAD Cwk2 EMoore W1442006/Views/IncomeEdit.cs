namespace EAD_Cwk2_EMoore_W1442006.Views
{
    using Controllers;
    using System.Windows.Forms;

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
