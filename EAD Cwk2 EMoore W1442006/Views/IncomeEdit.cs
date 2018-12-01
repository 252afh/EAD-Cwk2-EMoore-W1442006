namespace EAD_Cwk2_EMoore_W1442006.Views
{
    using Controllers;
    using System.Windows.Forms;

    /// <summary>
    /// An instance of <see cref="IncomeEdit"/> used to edit <see cref="Models.Income"/> records
    /// </summary>
    public partial class IncomeEdit : Form
    {
        /// <summary>
        /// Initialises a new <see cref="IncomeEdit"/> view
        /// </summary>
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
