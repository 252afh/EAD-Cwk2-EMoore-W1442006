namespace EAD_Cwk2_EMoore_W1442006.Views
{
    using Controllers;
    using System.Windows.Forms;

    /// <summary>
    /// An instance of a <see cref="Report"/> view
    /// </summary>
    public partial class Report : Form
    {
        /// <summary>
        /// Initialises a new <see cref="Report"/> view
        /// </summary>
        public Report()
        {
            InitializeComponent();
            this.BackButton.Click += ReportController.ViewBackButtonClick;
            this.Shown += ReportController.ReportShown;
        }
    }
}
