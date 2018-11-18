namespace EAD_Cwk2_EMoore_W1442006.Views
{
    using Controllers;
    using System.Windows.Forms;

    public partial class IncomeView : Form
    {
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
