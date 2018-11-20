namespace EAD_Cwk2_EMoore_W1442006.Views
{
    using Controllers;
    using System.Windows.Forms;

    /// <summary>
    /// An instance of <see cref="PayeeViewForm"/> used to view existing <see cref="Models.Payee"/> records
    /// </summary>
    public partial class PayeeViewForm : Form
    {
        /// <summary>
        /// Initialises a new <see cref="PayeeViewForm"/> view
        /// </summary>
        public PayeeViewForm()
        {
            InitializeComponent();
            this.editPayee.Click += PayeeController.EditPayeeClick;
            this.addPayee.Click += PayeeController.AddPayeeClick;
            this.backButton.Click += PayeeController.BackClick;
            this.VisibleChanged += PayeeController.ViewVisibleChanged;
            this.DeleteButton.Click += PayeeController.DeletePayee;
        }
    }
}
