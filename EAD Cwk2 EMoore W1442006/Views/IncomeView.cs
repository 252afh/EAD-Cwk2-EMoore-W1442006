using System;
using System.Windows.Forms;
using EAD_Cwk2_EMoore_W1442006.Controllers;
using EAD_Cwk2_EMoore_W1442006.Helpers;
using EAD_Cwk2_EMoore_W1442006.Models;

namespace EAD_Cwk2_EMoore_W1442006.Views
{
    public partial class IncomeView : Form
    {
        /// <summary>
        /// The view for editing an <see cref="Income"/>
        /// </summary>
        private IncomeEdit IncomeEditView;
        
        /// <summary>
        /// The view for adding an <see cref="Income"/>
        /// </summary>
        private IncomeAdd IncomeAddView;

        public IncomeView()
        {
            InitializeComponent();
            this.BackButton.Click += IncomeController.ViewBackButton;
            this.EditIncomeButton.Click += IncomeController.EditButtonClicked;
            this.AddIncomeButton.Click += IncomeController.AddButtonClicked;
            this.VisibleChanged += IncomeController.ViewVisibleChanged;
        }
    }
}
