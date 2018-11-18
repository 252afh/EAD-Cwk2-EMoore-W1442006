using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EAD_Cwk2_EMoore_W1442006.DataAccess;
using EAD_Cwk2_EMoore_W1442006.Helpers;
using EAD_Cwk2_EMoore_W1442006.Views;

namespace EAD_Cwk2_EMoore_W1442006.Controllers
{
    public static class ReportController
    {
        public static Report ReportView { get; set; }

        private static DatabaseDataAccess DA { get; } = new DatabaseDataAccess();

        public static void ViewBackButtonClick(object sender, EventArgs e)
        {
            ReportView.Owner.Show();
            ReportView.Close();
        }

        public static void ReportShown(object sender, EventArgs e)
        {
            ReportView.BalanceText.Text = ListAccessHelper.Balance.ToString("C");

            CalculateTotalIncome();
            CalculateTotalExpense();
            CalculateIncomeCount();
            CalculateExpenseCount();
        }

        private static void CalculateTotalIncome()
        {
            var incomeList = DA.GetIncomes().Result;
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

        private static void CalculateTotalExpense()
        {
            var expenseList = DA.GetExpenses().Result;
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

        private static void CalculateIncomeCount()
        {
            var incomeCount = DA.GetIncomes().Result.Count;
            ReportView.IncomeCountText.Text = incomeCount.ToString();
        }

        private static void CalculateExpenseCount()
        {
            var expenseCount = DA.GetExpenses().Result.Count;
            ReportView.ExpenseCountText.Text = expenseCount.ToString();
        }
    }
}
