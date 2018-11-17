using System;
using System.Windows.Forms;
using EAD_Cwk2_EMoore_W1442006.Controllers;
using EAD_Cwk2_EMoore_W1442006.Helpers;
using EAD_Cwk2_EMoore_W1442006.Models;

namespace EAD_Cwk2_EMoore_W1442006.Views
{
    public partial class ExpenseView : Form
    {
        public ExpenseView()
        {
            InitializeComponent();
            this.BackButton.Click += ExpenseController.ViewBackButton;
            this.EditButton.Click += ExpenseController.EditButtonClicked;
            this.AddButton.Click += ExpenseController.AddButtonClicked;
            this.VisibleChanged += ExpenseController.ViewVisibleChanged;
        }
    }
}
