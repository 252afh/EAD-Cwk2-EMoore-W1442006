namespace EAD_Cwk2_EMoore_W1442006.Views
{
    using Controllers;
    using System.Windows.Forms;

    /// <summary>
    /// An instance of <see cref="Payer"/> view used to view existing <see cref="Models.Payer"/> records
    /// </summary>
    public partial class Payer : Form
    {
        /// <summary>
        /// Initialises a new <see cref="Payer"/> view
        /// </summary>
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
