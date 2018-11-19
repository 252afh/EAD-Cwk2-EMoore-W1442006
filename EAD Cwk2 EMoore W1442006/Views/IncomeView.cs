namespace EAD_Cwk2_EMoore_W1442006.Views
{
    using Controllers;
    using System.Windows.Forms;

    /// <summary>
    /// An instance of <see cref="IncomeView"/> used to view existing <see cref="Models.Income"/> records
    /// </summary>
    public partial class IncomeView : Form
    {
        /// <summary>
        /// Initialises a new <see cref="IncomeView"/> view
        /// </summary>
        public IncomeView()
        {
            InitializeComponent();
            this.BackButton.Click += IncomeController.ViewBackButton;
            this.EditIncomeButton.Click += IncomeController.EditButtonClicked;
            this.AddIncomeButton.Click += IncomeController.AddButtonClicked;
            this.VisibleChanged += IncomeController.ViewVisibleChanged;
        }
    }
}
