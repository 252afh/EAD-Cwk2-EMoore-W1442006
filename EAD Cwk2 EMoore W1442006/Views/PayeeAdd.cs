using System;
using System.Windows.Forms;
using EAD_Cwk2_EMoore_W1442006.Controllers;
using EAD_Cwk2_EMoore_W1442006.DataAccess;
using EAD_Cwk2_EMoore_W1442006.Helpers;
using EAD_Cwk2_EMoore_W1442006.Models;

namespace EAD_Cwk2_EMoore_W1442006.Views
{
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
