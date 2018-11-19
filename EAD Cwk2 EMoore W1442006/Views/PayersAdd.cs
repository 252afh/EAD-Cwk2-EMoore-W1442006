namespace EAD_Cwk2_EMoore_W1442006.Views
{
    using Controllers;
    using System.Windows.Forms;

    /// <summary>
    /// An instance of <see cref="PayersAdd"/> used to add new <see cref="Models.Payer"/> records
    /// </summary>
    public partial class PayersAdd : Form
    {
        /// <summary>
        /// Initialises a new <see cref="PayersAdd"/> view
        /// </summary>
        public PayersAdd()
        {
            InitializeComponent();
            this.CancelButton.Click += PayerController.AddCancelClick;
            this.SaveAndBackButton.Click += PayerController.AddSaveAndBack;
            this.SaveAndNewButton.Click += PayerController.AddSaveAndNew;
        }
    }
}
