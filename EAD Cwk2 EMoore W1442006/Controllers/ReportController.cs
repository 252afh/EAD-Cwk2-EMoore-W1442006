using System.Collections.Generic;
using EAD_Cwk2_EMoore_W1442006.Models;

namespace EAD_Cwk2_EMoore_W1442006.Controllers
{
    using DataAccess;
    using Helpers;
    using System;
    using Views;

    /// <summary>
    /// An instance of <see cref="ReportController"/> that handles all logic regarding <see cref="Report"/> view
    /// </summary>
    public static class ReportController
    {
        /// <summary>
        /// An instance of <see cref="Report"/> class view
        /// </summary>
        public static Report ReportView { get; set; }

        /// <summary>
        /// An instance of <see cref="DatabaseDataAccess"/> class used for handling all database interactions
        /// </summary>
        private static DatabaseDataAccess DA { get; } = new DatabaseDataAccess();

        /// <summary>
        /// Handles the back button being pressed on a <see cref="Report"/> form
        /// </summary>
        /// <param name="sender">The sender object</param>
        /// <param name="e">Event arguments</param>
        public static void ViewBackButtonClick(object sender, EventArgs e)
        {
            ReportView.Owner.Show();
            ReportView.Close();
        }

        /// <summary>
        /// Handles a <see cref="Report"/> form being shown
        /// </summary>
        /// <param name="sender">The sender object</param>
        /// <param name="e">Event arguments</param>
        public static void ReportShown(object sender, EventArgs e)
        {
            ReportView.BalanceText.Text = ListAccessHelper.Balance.ToString("C");

            CalculateTotalIncome();
            CalculateTotalExpense();
            CalculateIncomeCount();
            CalculateExpenseCount();
        }

        /// <summary>
        /// Calculates the total income to date
        /// </summary>
        private static void CalculateTotalIncome()
        {
            var incomeList = new List<Income>();

            try
            {
                 // incomeList = DA.GetIncomes().Result;
            }
            catch (Exception ex)
            {
                ErrorHelper.SendError(ex);
            }

            var total = 0.00m;

            foreach (var income in incomeList)
            {
                if (income.IsRecurring)
                {
                    if (income.InitialPaidDate <= DateTime.UtcNow)
                    {
                        var days = (DateTime.UtcNow - income.InitialPaidDate).Days;
                        var payments = (days / income.Interval) + 1;
                        var paymentTotal = payments * income.Amount;
                        total += paymentTotal;
                    }
                }
                else
                {
                    if (income.InitialPaidDate <= DateTime.UtcNow)
                    {
                        total += income.Amount;
                    }
                }
            }

            ReportView.TotalIncomeText.Text = total.ToString("C");
        }

        /// <summary>
        /// Calculates all expense to date
        /// </summary>
        private static void CalculateTotalExpense()
        {
            var expenseList = new List<Expense>();

            try
            {
                // expenseList = DA.GetExpenses().Result;
            }
            catch(Exception ex)
            {
                ErrorHelper.SendError(ex);
            }

            var total = 0.00m;

            foreach (var expense in expenseList)
            {
                if (expense.IsRecurring)
                {
                    if (expense.InitialPaidDate <= DateTime.UtcNow)
                    {
                        var days = (DateTime.UtcNow - expense.InitialPaidDate).Days;
                        var payments = (days / expense.Interval) + 1;
                        var paymentTotal = payments * expense.Amount;
                        total += paymentTotal;
                    }
                }
                else
                {
                    if (expense.InitialPaidDate <= DateTime.UtcNow)
                    {
                        total += expense.Amount;
                    }
                }
            }

            ReportView.TotalExpenseText.Text = total.ToString("C");
        }

        /// <summary>
        /// Calculates a count of incomes in the system
        /// </summary>
        private static void CalculateIncomeCount()
        {
            var incomes = 0;

            try
            {
                // incomes = DA.GetIncomes().Result.Count;
            }
            catch (Exception ex)
            {
                ErrorHelper.SendError(ex);
            }

            ReportView.IncomeCountText.Text = incomes.ToString();
        }

        /// <summary>
        /// Calculates a count of expenses in the system
        /// </summary>
        private static void CalculateExpenseCount()
        {
            var expenseCount = 0;

            try
            {
                // expenseCount = DA.GetExpenses().Result.Count;
            }
            catch (Exception ex)
            {
                ErrorHelper.SendError(ex);
            }

            ReportView.ExpenseCountText.Text = expenseCount.ToString();
        }
    }
}
