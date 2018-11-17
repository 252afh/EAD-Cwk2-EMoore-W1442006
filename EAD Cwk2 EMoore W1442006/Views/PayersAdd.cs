using System;
using System.Windows.Forms;
using EAD_Cwk2_EMoore_W1442006.Controllers;
using EAD_Cwk2_EMoore_W1442006.DataAccess;
using EAD_Cwk2_EMoore_W1442006.Helpers;

namespace EAD_Cwk2_EMoore_W1442006.Views
{
    public partial class PayersAdd : Form
    {
        private readonly DatabaseDataAccess DA = new DatabaseDataAccess();

        public PayersAdd()
        {
            InitializeComponent();
            this.CancelButton.Click += PayerController.AddCancelClick;
            this.SaveAndBackButton.Click += PayerController.AddSaveAndBack;
            this.SaveAndNewButton.Click += PayerController.AddSaveAndNew;
        }
    }
}
