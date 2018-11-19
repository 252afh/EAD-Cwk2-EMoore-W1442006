namespace EAD_Cwk2_EMoore_W1442006.Views
{
    using Controllers;
    using System.Windows.Forms;

    /// <summary>
    /// An instance of <see cref="Prediction"/> view
    /// </summary>
    public partial class Prediction : Form
    {
        /// <summary>
        /// Initialises a new <see cref="Prediction"/> view
        /// </summary>
        public Prediction()
        {
            InitializeComponent();
            this.BackButton.Click += PredictionController.BackButtonClicked;
            this.PredictionDatePicker.ValueChanged += PredictionController.PredictionDateChanged;
        }  
    }
}
