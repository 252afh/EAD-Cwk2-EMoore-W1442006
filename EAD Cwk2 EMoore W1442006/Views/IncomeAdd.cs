namespace EAD_Cwk2_EMoore_W1442006.Views
{
    using Controllers;
    using System.Windows.Forms;

    /// <summary>
    /// An instance of <see cref="IncomeAdd"/> used to add new <see cref="Models.Income"/> records
    /// </summary>
    public partial class IncomeAdd : Form
    {
        /// <summary>
        /// Initialises a new instance of <see cref="IncomeAdd"/> view
        /// </summary>
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
