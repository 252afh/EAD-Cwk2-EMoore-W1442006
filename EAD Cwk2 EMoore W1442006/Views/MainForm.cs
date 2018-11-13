using System;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Linq;
using EAD_Cwk2_EMoore_W1442006.Helpers;

namespace EAD_Cwk2_EMoore_W1442006.Views
{
    public partial class MainMenuForm : Form
    {
        /// <summary>
        /// The view for <see cref="Models.Payee"/>s
        /// </summary>
        private PayeeViewForm PayeeView;

        /// <summary>
        /// The view for <see cref="Models.Payer"/>s
        /// </summary>
        private Payer PayerView;
        
        /// <summary>
        /// The view for <see cref="Models.Income"/>
        /// </summary>
        private IncomeView IncomeView;

        /// <summary>
        /// The view for <see cref="Models.Expense"/>
        /// </summary>
        private ExpenseView ExpenseView;

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
            if (this.PayeeView == null)
            {
                this.PayeeView = new PayeeViewForm();
                this.PayeeView.FormClosed += this.PayeeViewOnFormClosed;
            }

            this.PayeeView.Show(this);
            this.Hide();
        }

        private void PayeeViewOnFormClosed(object sender, FormClosedEventArgs e)
        {
            this.PayeeView = null;
            this.Show();
        }

        private void ViewPayersButton_Click(object sender, EventArgs e)
        {
            if (this.PayerView == null)
            {
                this.PayerView = new Payer();
                this.PayerView.FormClosed += this.PayerViewOnFormClosed;
            }

            this.PayerView.Show(this);
            this.Hide();
        }

        private void PayerViewOnFormClosed(object sender, FormClosedEventArgs e)
        {
            this.PayerView = null;
            this.Show();
        }

        private void ViewIncomeButton_Click(object sender, EventArgs e)
        {
            if (this.IncomeView == null)
            {
                this.IncomeView = new IncomeView();
                this.IncomeView.FormClosed += this.IncomeViewOnFormClosed;
            }

            IncomeView.Show(this);
            this.Hide();
        }

        private void IncomeViewOnFormClosed(object sender, FormClosedEventArgs e)
        {
            this.IncomeView = null;
            this.Show();
        }

        private void ViewExpensesButton_Click(object sender, EventArgs e)
        {
            if (this.ExpenseView == null)
            {
                this.ExpenseView = new ExpenseView();
                this.ExpenseView.FormClosed += this.ExpenseViewOnFormClosed;
            }

            this.ExpenseView.Show(this);
            this.Hide();
        }

        private void ExpenseViewOnFormClosed(object sender, FormClosedEventArgs e)
        {
            this.ExpenseView = null;
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

        private void SaveButton_Click(object sender, EventArgs e)
        {
            var payers = new XElement("Payers", ListAccessHelper.PayerList.Select(payer =>
                new XElement("payer",
                    new XAttribute("Id", payer.Id),
                    new XAttribute("Name", payer.Name),
                    new XAttribute("Type", payer.PaymentType))));

            var payees = new XElement("Payees", ListAccessHelper.PayeeList.Select(payee =>
                    new XElement("payee",
                        new XAttribute("Id", payee.Id),
                        new XAttribute("Name", payee.Name),
                        new XAttribute("AccNumber", payee.AccNumber),
                        new XAttribute("SortCode", payee.AccNumber),
                        new XAttribute("Address", payee.Address))));

            var incomes = new XElement("Incomes", ListAccessHelper.IncomeList.Select(income =>
                new XElement("income",
                    new XAttribute("Id", income.Id),
                    new XAttribute("Amount", income.Amount),
                    new XAttribute("InitialDate", income.InitialPaidDate),
                    new XAttribute("Interval", income.Interval),
                    new XAttribute("IsRecurring", income.IsRecurring),
                    new XAttribute("LastPaidDate", income.LastPaidDate),
                    new XAttribute("Reference", income.Ref),
                    new XAttribute("Payer", income.Payer.Id))));

            var expenses = new XElement("Expenses", ListAccessHelper.ExpenseList.Select(expense =>
                new XElement("expense",
                    new XAttribute("Id", expense.Id),
                    new XAttribute("Amount", expense.Amount),
                    new XAttribute("InitialDate", expense.InitialPaidDate),
                    new XAttribute("Interval", expense.Interval),
                    new XAttribute("IsRecurring", expense.IsRecurring),
                    new XAttribute("LastPaidDate", expense.LastPaidDate),
                    new XAttribute("Reference", expense.Ref),
                    new XAttribute("Payer", expense.Payee.Id))));

            var saveData = new XElement("Data",
                payers,
                payees,
                incomes,
                expenses
                );

            saveData.Save("C:\\Users\\Elliot\\Documents\\SaveFile.xml");
        }
    }
}
