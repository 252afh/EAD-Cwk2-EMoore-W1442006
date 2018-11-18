namespace EAD_Cwk2_EMoore_W1442006.Views
{
    using Controllers;
    using System.Windows.Forms;

    public partial class PayersAdd : Form
    {
        public PayersAdd()
        {
            InitializeComponent();
            this.CancelButton.Click += PayerController.AddCancelClick;
            this.SaveAndBackButton.Click += PayerController.AddSaveAndBack;
            this.SaveAndNewButton.Click += PayerController.AddSaveAndNew;
        }
    }
}
