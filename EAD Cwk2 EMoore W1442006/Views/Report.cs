using System;
using System.Windows.Forms;
using EAD_Cwk2_EMoore_W1442006.Controllers;

namespace EAD_Cwk2_EMoore_W1442006.Views
{
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
