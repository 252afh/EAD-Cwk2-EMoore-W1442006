namespace EAD_Cwk2_EMoore_W1442006.Views
{
    using Controllers;
    using System.Windows.Forms;

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
