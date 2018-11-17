using System;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Linq;
using EAD_Cwk2_EMoore_W1442006.Controllers;
using EAD_Cwk2_EMoore_W1442006.Helpers;

namespace EAD_Cwk2_EMoore_W1442006.Views
{
    public partial class MainMenuForm : Form
    {
        /// <summary>
        /// The <see cref="Report"/> view
        /// </summary>
        private Report ReportView;

        /// <summary>
        /// The <see cref="Prediction"/> view
        /// </summary>
        private Prediction PredictionView;

        public MainMenuForm()
        {
            InitializeComponent();
            this.balanceBox.Text = "£" + ListAccessHelper.Balance.ToString();
        }

        private void ViewPayeeButton_Click(object sender, EventArgs e)
        {
            if (PayeeController.PayeeView == null)
            {
                PayeeController.PayeeView = new PayeeViewForm();
                PayeeController.PayeeView.FormClosed += this.PayeeViewOnFormClosed;
            }

            PayeeController.PayeeView.Show(this);
            this.Hide();
        }

        private void PayeeViewOnFormClosed(object sender, FormClosedEventArgs e)
        {
            PayeeController.PayeeView = null;
            this.Show();
        }

        private void ViewPayersButton_Click(object sender, EventArgs e)
        {
            if (PayerController.PayerView == null)
            {
                PayerController.PayerView = new Payer();
                PayerController.PayerView.FormClosed += this.PayerViewOnFormClosed;
            }

            PayerController.PayerView.Show(this);
            this.Hide();
        }

        private void PayerViewOnFormClosed(object sender, FormClosedEventArgs e)
        {
            PayerController.PayerView = null;
            this.Show();
        }

        private void ViewIncomeButton_Click(object sender, EventArgs e)
        {
            if (IncomeController.IncomeView == null)
            {
                IncomeController.IncomeView = new IncomeView();
                IncomeController.IncomeView.FormClosed += this.IncomeViewOnFormClosed;
            }

            IncomeController.IncomeView.Show(this);
            this.Hide();
        }

        private void IncomeViewOnFormClosed(object sender, FormClosedEventArgs e)
        {
            IncomeController.IncomeView = null;
            this.Show();
        }

        private void ViewExpensesButton_Click(object sender, EventArgs e)
        {
            if (ExpenseController.ExpenseView == null)
            {
                ExpenseController.ExpenseView = new ExpenseView();
                ExpenseController.ExpenseView.FormClosed += this.ExpenseViewOnFormClosed;
            }

            ExpenseController.ExpenseView.Show(this);
            this.Hide();
        }

        private void ExpenseViewOnFormClosed(object sender, FormClosedEventArgs e)
        {
            ExpenseController.ExpenseView = null;
            this.Show();
        }

        private void ViewReportButton_Click(object sender, EventArgs e)
        {
            if (this.ReportView == null)
            {
                this.ReportView = new Report();
                this.ReportView.FormClosed += this.ReportViewOnFormClosed;
            }

            this.ReportView.Show(this);
            this.Hide();
        }

        private void ReportViewOnFormClosed(object sender, FormClosedEventArgs e)
        {
            this.ReportView = null;
            this.Show();
        }

        private void ViewPredictionButton_Click(object sender, EventArgs e)
        {
            if (this.PredictionView == null)
            {
                this.PredictionView = new Prediction();
                this.PredictionView.FormClosed += this.PredictionViewOnFormClosed;
            }

            this.PredictionView.Show(this);
            this.Hide();
        }

        private void PredictionViewOnFormClosed(object sender, FormClosedEventArgs e)
        {
            this.PredictionView = null;
            this.Show();
        }
    }
}
