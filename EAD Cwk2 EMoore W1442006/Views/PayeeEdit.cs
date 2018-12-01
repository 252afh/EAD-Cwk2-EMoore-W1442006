namespace EAD_Cwk2_EMoore_W1442006.Views
{
    using Controllers;
    using System.Windows.Forms;

    /// <summary>
    /// An instance of <see cref="PayeeEdit"/> used to edit <see cref="Models.Payee"/> records
    /// </summary>
    public partial class PayeeEdit : Form
    {
        /// <summary>
        /// Initialises a new <see cref="PayeeEdit"/> view
        /// </summary>
        public PayeeEdit()
        {
            InitializeComponent();
            this.CancelButton.Click += PayeeController.EditCancelClick;
            this.Shown += PayeeController.EditShown;
            this.PayeeCombobox.SelectedIndexChanged += PayeeController.SelectedIndexChanged;
            this.SaveAndBackButton.Click += PayeeController.EditSaveAndBack;
            this.SaveAndNewButton.Click += PayeeController.EditsaveAndNew;
        }
    }
}
