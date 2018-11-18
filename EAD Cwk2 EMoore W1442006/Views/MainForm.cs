namespace EAD_Cwk2_EMoore_W1442006.Views
{
    using System;
    using System.Windows.Forms;
    using Controllers;
    using DataAccess;
    using Helpers;
    using Models;

    public partial class MainMenuForm : Form
    {
        private static DatabaseDataAccess DA { get; } = new DatabaseDataAccess();

        private static XmlDataAccess XmlDA { get; } = new XmlDataAccess();

        public MainMenuForm()
        {
            InitializeComponent();
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
            if (ReportController.ReportView == null)
            {
                ReportController.ReportView = new Report();
                ReportController.ReportView.FormClosed += this.ReportViewOnFormClosed;
            }

            ReportController.ReportView.Show(this);
            this.Hide();
        }

        private void ReportViewOnFormClosed(object sender, FormClosedEventArgs e)
        {
            ReportController.ReportView = null;
            this.Show();
        }

        private void ViewPredictionButton_Click(object sender, EventArgs e)
        {
            if (PredictionController.PredictionView == null)
            {
                PredictionController.PredictionView = new Prediction();
                PredictionController.PredictionView.FormClosed += this.PredictionViewOnFormClosed;
            }

            PredictionController.PredictionView.Show(this);
            this.Hide();
        }

        private void PredictionViewOnFormClosed(object sender, FormClosedEventArgs e)
        {
            PredictionController.PredictionView = null;
            this.Show();
        }

        private void MainMenuForm_Shown(object sender, EventArgs e)
        {
            CalculateBalance();
            this.balanceBox.Text = ListAccessHelper.Balance.ToString("C");
        }

        private static void CalculateBalance()
        {
            var nonRecurringIncome = 0.00m;
            var recurringIncome = 0.00m;
            var nonRecurringExpense = 0.00m;
            var recurringExpense = 0.00m;

            for (var index = 0; index < ListAccessHelper.IncomeList.Count; index++)
            {
                var income = ListAccessHelper.IncomeList[index];
                if (income.InitialPaidDate > DateTime.UtcNow)
                {
                    continue;
                }

                if (income.IsRecurring)
                {
                    recurringIncome += CalculateRecurringIncome(income);
                    ListAccessHelper.IncomeList[ListAccessHelper.IncomeList.IndexOf(income)] = income;
                    DA.EditIncome(income, income.Id);
                }
                else
                {
                    nonRecurringIncome += CalculateIncome(income);
                }
            }

            for (var index = 0; index < ListAccessHelper.ExpenseList.Count; index++)
            {
                var expense = ListAccessHelper.ExpenseList[index];
                if (expense.InitialPaidDate > DateTime.UtcNow)
                {
                    continue;
                }

                if (expense.IsRecurring)
                {
                    recurringExpense += CalculateRecurringExpense(expense);
                    ListAccessHelper.ExpenseList[ListAccessHelper.ExpenseList.IndexOf(expense)] = expense;
                    DA.EditExpense(expense, expense.Id);
                }
                else
                {
                    nonRecurringExpense += CalculateExpense(expense);
                }
            }

            ListAccessHelper.IncrementBalance(recurringIncome);
            ListAccessHelper.IncrementBalance(nonRecurringIncome);
            ListAccessHelper.DecrementBalance(recurringExpense);
            ListAccessHelper.DecrementBalance(nonRecurringExpense);

            XmlDA.SaveXml();
        }

        private static decimal CalculateRecurringExpense(Expense expense)
        {
            var days = (DateTime.UtcNow - expense.InitialPaidDate).Days;
            var payments = (days / expense.Interval) + 1;
            var paymentAmount = payments * expense.Amount;
            var remainder = days % expense.Interval;
            var lastPaid = DateTime.UtcNow.AddDays(-remainder);
            expense.LastPaidDate = lastPaid;

            return paymentAmount;
        }

        private static decimal CalculateExpense(Expense expense)
        {
            return expense.Amount;
        }

        private static decimal CalculateRecurringIncome(Income income)
        {
            var days = (DateTime.UtcNow - income.InitialPaidDate).Days;
            var payments = (days / income.Interval) + 1;
            var paymentAmount = payments * income.Amount;

            var remainder = days % income.Interval;
            var lastPaid = DateTime.UtcNow.AddDays(-remainder);
            income.LastPaidDate = lastPaid;

            return paymentAmount;
        }

        private static decimal CalculateIncome(Income income)
        {
            return income.Amount;
        }
    }
}
