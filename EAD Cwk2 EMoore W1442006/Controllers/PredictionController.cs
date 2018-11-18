using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EAD_Cwk2_EMoore_W1442006.Helpers;
using EAD_Cwk2_EMoore_W1442006.Views;

namespace EAD_Cwk2_EMoore_W1442006.Controllers
{
    public static class PredictionController
    {
        public static Prediction PredictionView { get; set; }

        private static decimal RecurringIncomeBefore { get; set; }

        private static decimal RecurringExpenseBefore { get; set; }

        private static decimal NonRecurringIncomeBefore { get; set; }

        private static decimal NonRecurringExpenseBefore { get; set; }

        private static decimal PercentageGain { get; set; }

        private static decimal RecurringIncomeAfter { get; set; }

        private static decimal RecurringExpenseAfter { get; set; }
        
        private static DateTime PeriodStart { get; set; }

        private static DateTime PeriodEnd { get; set; }

        private static decimal CurrentBalance { get; } = ListAccessHelper.Balance;

        public static void BackButtonClicked(object sender, EventArgs e)
        {
            PredictionView.Owner.Show();
            PredictionView.Close();
        }

        public static void PredictionDateChanged(object sender, EventArgs e)
        {
            var periodLength = (PredictionView.PredictionDatePicker.Value - DateTime.UtcNow).Days;
            PeriodStart = DateTime.UtcNow.AddDays(-periodLength);
            PeriodEnd = PredictionView.PredictionDatePicker.Value;

            PredictionView.BalanceOnDateText.Text = string.Empty;
            PredictionView.DaysToPredictionText.Text = string.Empty;
            PredictionView.OneOffExpensesText.Text = string.Empty;
            PredictionView.OneOffIncomeText.Text = string.Empty;
            PredictionView.RecurringExpensesText.Text = string.Empty;
            PredictionView.RecurringIncomeText.Text = string.Empty;

            CalculatePrediction();
        }

        private static void CalculatePrediction()
        {
            RecurringIncomeBefore = CalculateRecurringIncomeBefore();
            RecurringExpenseBefore = CalculateRecurringExpenseBefore();
            NonRecurringIncomeBefore = CalculateNonRecurringIncomeBefore();
            NonRecurringExpenseBefore = CalculateNonRecurringExpenseBefore();
            RecurringIncomeAfter = CalculateRecurringIncomeAfter();
            RecurringExpenseAfter = CalculateRecurringExpenseAfter();

            var currentWithoutRecurring = CurrentBalance - RecurringIncomeBefore;
            currentWithoutRecurring += RecurringExpenseBefore;

            var previousWithoutAny = currentWithoutRecurring - NonRecurringIncomeBefore;
            previousWithoutAny += NonRecurringExpenseBefore;

            PercentageGain = CalculatePercentageGain(currentWithoutRecurring, previousWithoutAny);

            if (PercentageGain > 0)
            {
                PercentageGain += 1.00m;
            }
            else
            {
                PercentageGain -= 1.00m;
            }

            var percentageIncreased = currentWithoutRecurring * PercentageGain;

            var predictedTotal = percentageIncreased - RecurringExpenseAfter;
            predictedTotal += RecurringIncomeAfter;

            PredictionView.BalanceOnDateText.Text = predictedTotal.ToString("C");
            PredictionView.DaysToPredictionText.Text = (PeriodEnd - DateTime.UtcNow).Days.ToString() + " days";
            PredictionView.OneOffExpensesText.Text = NonRecurringExpenseBefore.ToString("C");
            PredictionView.OneOffIncomeText.Text = NonRecurringIncomeBefore.ToString("C");
            PredictionView.RecurringExpensesText.Text = RecurringExpenseAfter.ToString("C");
            PredictionView.RecurringIncomeText.Text = RecurringIncomeAfter.ToString("C");
        }

        private static decimal CalculatePercentageGain(decimal current, decimal previous)
        {
            if (previous == 0)
            {
                return 0.00m;
            }

            var change = current - previous;
            return change / previous;
        }

        private static decimal CalculateRecurringExpenseAfter()
        {
            var recurringExpenseAfterTotal = 0.00m;

            foreach (var expense in ListAccessHelper.ExpenseList)
            {
                if (!expense.IsRecurring || expense.InitialPaidDate > PeriodEnd)
                {
                    continue;
                }

                var startDate = expense.InitialPaidDate;

                while (startDate < DateTime.UtcNow)
                {
                    startDate = startDate.AddDays(expense.Interval);
                }

                var remainingdays = (PeriodEnd - startDate).Days;
                var payments = (remainingdays / expense.Interval) + 1;
                var paymentAmount = payments * expense.Amount;
                recurringExpenseAfterTotal += paymentAmount;
            }

            return recurringExpenseAfterTotal;
        }

        private static decimal CalculateRecurringIncomeAfter()
        {
            var recurringIncomeAfterTotal = 0.00m;

            foreach (var income in ListAccessHelper.IncomeList)
            {
                if (!income.IsRecurring || income.InitialPaidDate > PeriodEnd)
                {
                    continue;
                }

                var startDate = income.InitialPaidDate;

                while (startDate < DateTime.UtcNow)
                {
                    startDate = startDate.AddDays(income.Interval);
                }

                var remainingdays = (PeriodEnd - startDate).Days;
                var payments = (remainingdays / income.Interval) + 1;
                var paymentAmount = payments * income.Amount;
                recurringIncomeAfterTotal += paymentAmount;
            }

            return recurringIncomeAfterTotal;
        }

        private static decimal CalculateNonRecurringExpenseBefore()
        {
            var nonRecurringExpenseBefore = 0.00m;

            foreach (var expense in ListAccessHelper.ExpenseList)
            {
                if (expense.IsRecurring || expense.InitialPaidDate > DateTime.UtcNow)
                {
                    continue;
                }

                if (expense.InitialPaidDate > PeriodStart)
                {
                    nonRecurringExpenseBefore += expense.Amount;
                }
            }

            return nonRecurringExpenseBefore;
        }

        private static decimal CalculateNonRecurringIncomeBefore()
        {
            var nonRecurringIncomeBefore = 0.00m;

            foreach (var income in ListAccessHelper.IncomeList)
            {
                if (income.IsRecurring || income.InitialPaidDate > DateTime.UtcNow)
                {
                    continue;
                }

                if (income.InitialPaidDate > PeriodStart)
                {
                    nonRecurringIncomeBefore += income.Amount;
                }
            }

            return nonRecurringIncomeBefore;
        }

        private static decimal CalculateRecurringExpenseBefore()
        {
            var recurringExpenseBeforeTotal = 0.00m;

            foreach (var expense in ListAccessHelper.ExpenseList)
            {
                if (!expense.IsRecurring || expense.InitialPaidDate > DateTime.UtcNow)
                {
                    continue;
                }

                var startDate = expense.InitialPaidDate;

                while (startDate < PeriodStart)
                {
                    startDate = startDate.AddDays(expense.Interval);
                }

                var remainingdays = (DateTime.UtcNow - startDate).Days;
                var payments = (remainingdays / expense.Interval) + 1;
                var paymentAmount = payments * expense.Amount;
                recurringExpenseBeforeTotal += paymentAmount;
            }

            return recurringExpenseBeforeTotal;
        }

        private static decimal CalculateRecurringIncomeBefore()
        {
            var recurringIncomeBeforeTotal = 0.00m;

            foreach (var income in ListAccessHelper.IncomeList)
            {
                if (!income.IsRecurring || income.InitialPaidDate > DateTime.UtcNow)
                {
                    continue;
                }

                var startDate = income.InitialPaidDate;

                while (startDate < PeriodStart)
                {
                    startDate = startDate.AddDays(income.Interval);
                }

                var remainingdays = (DateTime.UtcNow - startDate).Days;
                var payments = (remainingdays / income.Interval) + 1;
                var paymentAmount = payments * income.Amount;
                recurringIncomeBeforeTotal += paymentAmount;
            }

            return recurringIncomeBeforeTotal;
        }
    }
}
