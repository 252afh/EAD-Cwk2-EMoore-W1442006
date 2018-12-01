namespace EAD_Cwk2_EMoore_W1442006.Views
{
    using Controllers;
    using System.Windows.Forms;

    /// <summary>
    /// An instance of <see cref="PayeeAdd"/> used to add new <see cref="Models.Payee"/> records
    /// </summary>
    public partial class PayeeAdd : Form
    {
        /// <summary>
        /// Initialises a new <see cref="PayeeAdd"/> view
        /// </summary>
        public PayeeAdd()
        {
            InitializeComponent();
            this.CancelButton.Click += PayeeController.AddCancelClick;
            this.SaveAndBackButton.Click += PayeeController.AddSaveAndBack;
            this.SaveAndNewButton.Click += PayeeController.AddSaveAndNew;
        }
    }
}
