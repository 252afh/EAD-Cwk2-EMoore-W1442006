namespace EAD_Cwk2_EMoore_W1442006.Views
{
    using Controllers;
    using System.Windows.Forms;

    public partial class ExpenseView : Form
    {
        public ExpenseView()
        {
            InitializeComponent();
            this.BackButton.Click += ExpenseController.ViewBackButton;
            this.EditButton.Click += ExpenseController.EditButtonClicked;
            this.AddButton.Click += ExpenseController.AddButtonClicked;
            this.VisibleChanged += ExpenseController.ViewVisibleChanged;
        }
    }
}
