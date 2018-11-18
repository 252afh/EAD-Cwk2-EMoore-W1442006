namespace EAD_Cwk2_EMoore_W1442006.Views
{
    using Controllers;
    using System.Windows.Forms;

    public partial class Report : Form
    {
        public Report()
        {
            InitializeComponent();
            this.BackButton.Click += ReportController.ViewBackButtonClick;
            this.Shown += ReportController.ReportShown;
        }
    }
}
