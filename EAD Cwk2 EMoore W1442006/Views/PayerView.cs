namespace EAD_Cwk2_EMoore_W1442006.Views
{
    using Controllers;
    using System.Windows.Forms;

    public partial class Payer : Form
    {
        public Payer()
        {
            InitializeComponent();
            this.BackButton.Click += PayerController.ViewBackButton;
            this.EditPayerButton.Click += PayerController.EditPayerClicked;
            this.AddPayerButton.Click += PayerController.AddPayerClicked;
            this.VisibleChanged += PayerController.ViewVisibleChanged;
        }
    }
}
