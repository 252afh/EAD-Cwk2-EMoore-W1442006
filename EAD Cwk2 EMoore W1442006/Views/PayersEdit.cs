namespace EAD_Cwk2_EMoore_W1442006.Views
{
    using Controllers;
    using System.Windows.Forms;

    /// <summary>
    /// An instance of <see cref="PayersEdit"/> used to edit existing <see cref="Models.Payer"/> records
    /// </summary>
    public partial class PayersEdit : Form
    {
        /// <summary>
        /// Initialises a new <see cref="PayersEdit"/> view
        /// </summary>
        public PayersEdit()
        {
            InitializeComponent();
            this.PayerCombobox.SelectedIndexChanged += PayerController.EditIndexChanged;
            this.CancelButton.Click += PayerController.EditCancelClicked;
            this.Shown += PayerController.EditShown;
            this.SaveAndBackButton.Click += PayerController.EditSaveAndBack;
            this.SaveAndNewButton.Click += PayerController.EditSaveAndNew;
        }
    }
}
