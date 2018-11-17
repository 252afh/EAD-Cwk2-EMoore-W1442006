using System;
using System.Windows.Forms;
using EAD_Cwk2_EMoore_W1442006.Controllers;
using EAD_Cwk2_EMoore_W1442006.Helpers;

namespace EAD_Cwk2_EMoore_W1442006.Views
{
    public partial class Payer : Form
    {
        /// <summary>
        /// The view to edit <see cref="Models.Payer"/>
        /// </summary>
        private PayersEdit PayerEditView;

        /// <summary>
        /// The view to add a new <see cref="Models.Payer"/>
        /// </summary>
        private PayersAdd PayerAddView;

        public Payer()
        {
            InitializeComponent();
            this.BackButton.Click += PayerController.ViewBackButton;
            this.EditPayerButton.Click += PayerController.EditPayerClicked;
            this.AddPayerButton.Click += PayerController.AddPayerClicked;
            this.VisibleChanged += PayerController.ViewVisibleChanged;
        }
    }
}
