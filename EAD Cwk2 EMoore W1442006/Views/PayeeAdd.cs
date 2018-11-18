namespace EAD_Cwk2_EMoore_W1442006.Views
{
    using Controllers;
    using System.Windows.Forms;

    public partial class PayeeAdd : Form
    {
        public PayeeAdd()
        {
            InitializeComponent();
            this.CancelButton.Click += PayeeController.AddCancelClick;
            this.SaveAndBackButton.Click += PayeeController.AddSaveAndBack;
            this.SaveAndNewButton.Click += PayeeController.AddSaveAndNew;
        }
    }
}
