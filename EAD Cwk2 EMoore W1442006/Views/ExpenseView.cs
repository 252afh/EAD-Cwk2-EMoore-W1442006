namespace EAD_Cwk2_EMoore_W1442006.Views
{
    using Controllers;
    using System.Windows.Forms;

    /// <summary>
    /// An instance of <see cref="ExpenseView"/> used to view current <see cref="Models.Expense"/> records
    /// </summary>
    public partial class ExpenseView : Form
    {
        /// <summary>
        /// Initialises a new instance of <see cref="ExpenseView"/> view
        /// </summary>
        public ExpenseView()
        {
            InitializeComponent();
            this.BackButton.Click += ExpenseController.ViewBackButton;
            this.EditButton.Click += ExpenseController.EditButtonClicked;
            this.AddButton.Click += ExpenseController.AddButtonClicked;
            this.VisibleChanged += ExpenseController.ViewVisibleChanged;
            this.DeleteButton.Click += ExpenseController.DeleteExpense;
        }
    }
}
