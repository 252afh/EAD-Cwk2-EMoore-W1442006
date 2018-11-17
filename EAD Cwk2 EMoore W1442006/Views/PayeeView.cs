using System;
using System.Windows.Forms;
using EAD_Cwk2_EMoore_W1442006.Controllers;
using EAD_Cwk2_EMoore_W1442006.Helpers;
using EAD_Cwk2_EMoore_W1442006.Models;

namespace EAD_Cwk2_EMoore_W1442006.Views
{
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
