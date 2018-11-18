namespace EAD_Cwk2_EMoore_W1442006.Views
{
    using Controllers;
    using System.Windows.Forms;

    public partial class PayeeEdit : Form
    {
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
