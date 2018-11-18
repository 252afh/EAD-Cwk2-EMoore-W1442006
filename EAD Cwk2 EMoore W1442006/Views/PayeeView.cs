namespace EAD_Cwk2_EMoore_W1442006.Views
{
    using Controllers;
    using System.Windows.Forms;

    public partial class PayeeViewForm : Form
    {
        public PayeeViewForm()
        {
            InitializeComponent();
            this.editPayee.Click += PayeeController.EditPayeeClick;
            this.addPayee.Click += PayeeController.AddPayeeClick;
            this.backButton.Click += PayeeController.BackClick;
            this.VisibleChanged += PayeeController.ViewVisibleChanged;
        }
    }
}
