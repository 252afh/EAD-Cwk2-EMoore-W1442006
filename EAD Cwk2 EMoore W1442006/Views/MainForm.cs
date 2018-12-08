namespace EAD_Cwk2_EMoore_W1442006.Views
{
    using System;
    using System.Windows.Forms;
    using Controllers;
    using DataAccess;
    using Helpers;
    using Models;

    /// <summary>
    /// An instance of <see cref="MainMenuForm"/> used to navigate to sub forms
    /// </summary>
    public partial class MainMenuForm : Form
    {
        /// <summary>
        /// An instance of <see cref="DatabaseDataAccess"/> used to handle all database interactions
        /// </summary>
        private static DatabaseDataAccess DA { get; } = new DatabaseDataAccess();

        /// <summary>
        /// An instance of <see cref="XmlDataAccess"/> used to handle all XML interactions
        /// </summary>
        private static XmlDataAccess XmlDA { get; } = new XmlDataAccess();

        /// <summary>
        /// Initialises an instance of <see cref="MainMenuForm"/> view
        /// </summary>
        public MainMenuForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles navigating to a new <see cref="PayeeViewForm"/> view
        /// </summary>
        /// <param name="sender">The sender object</param>
        /// <param name="e">Event arguments</param>
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

        /// <summary>
        /// Handles  a <see cref="PayeeViewForm"/> closing
        /// </summary>
        /// <param name="sender">The sender object</param>
        /// <param name="e">Event arguments</param>
        private void PayeeViewOnFormClosed(object sender, FormClosedEventArgs e)
        {
            PayeeController.PayeeView = null;
            this.Show();
        }

        /// <summary>
        /// Handles navigating to a <see cref="PayerView"/> view
        /// </summary>
        /// <param name="sender">The sender object</param>
        /// <param name="e">Event arguments</param>
        private void ViewPayersButton_Click(object sender, EventArgs e)
        {
            if (PayerController.PayerView == null)
            {
                PayerController.PayerView = new PayerView();
                PayerController.PayerView.FormClosed += this.PayerViewOnFormClosed;
            }

            PayerController.PayerView.Show(this);
            this.Hide();
        }

        /// <summary>
        /// Handles closing a <see cref="PayerView"/> view
        /// </summary>
        /// <param name="sender">The sender object</param>
        /// <param name="e">Event arguments</param>
        private void PayerViewOnFormClosed(object sender, FormClosedEventArgs e)
        {
            PayerController.PayerView = null;
            this.Show();
        }

        /// <summary>
        /// Handles navigating to an <see cref="IncomeView"/> view
        /// </summary>
        /// <param name="sender">The sender object</param>
        /// <param name="e">Event arguments</param>
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

        /// <summary>
        /// Handles a <see cref="IncomeView"/> closing
        /// </summary>
        /// <param name="sender">The sender object</param>
        /// <param name="e">Event arguments</param>
        private void IncomeViewOnFormClosed(object sender, FormClosedEventArgs e)
        {
            IncomeController.IncomeView = null;
            this.Show();
        }

        /// <summary>
        /// Handles navigating to a <see cref="ExpenseView"/> view
        /// </summary>
        /// <param name="sender">The sender object</param>
        /// <param name="e">Event arguments</param>
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

        /// <summary>
        /// Handles a <see cref="ExpenseView"/> closing
        /// </summary>
        /// <param name="sender">The sender object</param>
        /// <param name="e">Event arguments</param>
        private void ExpenseViewOnFormClosed(object sender, FormClosedEventArgs e)
        {
            ExpenseController.ExpenseView = null;
            this.Show();
        }

        /// <summary>
        /// Handles navigating to a <see cref="Report"/> view
        /// </summary>
        /// <param name="sender">The sender object</param>
        /// <param name="e">Event arguments</param>
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

        /// <summary>
        /// Handles a <see cref="Report"/> view closing
        /// </summary>
        /// <param name="sender">The sender object</param>
        /// <param name="e">Event arguments</param>
        private void ReportViewOnFormClosed(object sender, FormClosedEventArgs e)
        {
            ReportController.ReportView = null;
            this.Show();
        }

        /// <summary>
        /// Handles navigating to a <see cref="Prediction"/> view
        /// </summary>
        /// <param name="sender">The sender object</param>
        /// <param name="e">Event arguments</param>
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

        /// <summary>
        /// Handles a <see cref="Prediction"/> view closing
        /// </summary>
        /// <param name="sender">The sender object</param>
        /// <param name="e">Event arguments</param>
        private void PredictionViewOnFormClosed(object sender, FormClosedEventArgs e)
        {
            PredictionController.PredictionView = null;
            this.Show();
        }

        /// <summary>
        /// Handles a <see cref="MainMenu"/> being shown
        /// </summary>
        /// <param name="sender">The sender object</param>
        /// <param name="e">Event arguments</param>
        private void MainMenuForm_Shown(object sender, EventArgs e)
        {
            CalculateBalance();
            this.balanceBox.Text = ListAccessHelper.Balance.ToString("C");
        }

        /// <summary>
        /// Calculates the current balance based on <see cref="Expense"/> and <see cref="Income"/> records
        /// </summary>
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
                    // DA.EditIncome(income, income.Id);
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
                    // DA.EditExpense(expense, expense.Id);
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

        /// <summary>
        /// Calculates recurring expenses before today
        /// </summary>
        /// <param name="expense">The expense to calculate</param>
        /// <returns>A decimal value of the expense total</returns>
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

        /// <summary>
        /// Calculates non recurring expenses before today
        /// </summary>
        /// <param name="expense">The expense to calculate</param>
        /// <returns>A decimal value of the expense total</returns>
        private static decimal CalculateExpense(Expense expense)
        {
            return expense.Amount;
        }

        /// <summary>
        /// Calculates recurring incomes before today
        /// </summary>
        /// <param name="income">The income to calculate</param>
        /// <returns>A decimal value of the income total</returns>
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

        /// <summary>
        /// Calculates non recurring incomes before today
        /// </summary>
        /// <param name="income">The income to calculate</param>
        /// <returns>A decimal value of the income total</returns>
        private static decimal CalculateIncome(Income income)
        {
            return income.Amount;
        }
    }
}
