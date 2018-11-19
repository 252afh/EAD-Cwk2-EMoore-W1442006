namespace EAD_Cwk2_EMoore_W1442006.Views
{
    using Controllers;
    using System.Windows.Forms;

    /// <summary>
    /// An instance of <see cref="ExpenseEdit"/> used to edit <see cref="Models.Expense"/>
    /// </summary>
    public partial class ExpenseEdit : Form
    {
        /// <summary>
        /// Initialises a new instance of <see cref="ExpenseEdit"/> view
        /// </summary>
        public ExpenseEdit()
        {
            InitializeComponent();
            this.CancelButton.Click += ExpenseController.EditCancelClicked;
            this.Shown += ExpenseController.EditShown;
            this.ExpenseDropDown.SelectedIndexChanged += ExpenseController.EditDropDownChanged;
            this.RecurringCheckbox.CheckedChanged += ExpenseController.EditRecurringChanged;
            this.SaveAndBackButton.Click += ExpenseController.EditSaveAndBack;
            this.SaveAndNewButton.Click += ExpenseController.EditSaveAndNew;
        }
    }
}
