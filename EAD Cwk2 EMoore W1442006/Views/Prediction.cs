using System;
using System.Windows.Forms;
using EAD_Cwk2_EMoore_W1442006.Controllers;
using EAD_Cwk2_EMoore_W1442006.Helpers;

namespace EAD_Cwk2_EMoore_W1442006.Views
{
    public partial class Prediction : Form
    {
        public Prediction()
        {
            InitializeComponent();
            this.BackButton.Click += PredictionController.BackButtonClicked;
            this.PredictionDatePicker.ValueChanged += PredictionController.PredictionDateChanged;
        }  
    }
}
