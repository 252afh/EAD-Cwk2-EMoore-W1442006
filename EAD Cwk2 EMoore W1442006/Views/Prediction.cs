namespace EAD_Cwk2_EMoore_W1442006.Views
{
    using Controllers;
    using System.Windows.Forms;

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
