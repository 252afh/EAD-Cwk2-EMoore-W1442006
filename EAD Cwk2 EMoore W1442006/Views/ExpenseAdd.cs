namespace EAD_Cwk2_EMoore_W1442006.Views
{
    using Controllers;
    using System.Windows.Forms;

    /// <summary>
    /// An instance of <see cref="ExpenseAdd"/> used to add new <see cref="Models.Expense"/>
    /// </summary>
    public partial class ExpenseAdd : Form
    {
        /// <summary>
        /// Initialises an new instance of <see cref="ExpenseAdd"/> view
        /// </summary>
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
