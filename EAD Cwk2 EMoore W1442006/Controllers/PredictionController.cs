namespace EAD_Cwk2_EMoore_W1442006.Controllers
{
    using Helpers;
    using System;
    using Views;

    /// <summary>
    /// An instance of a <see cref="PredictionController"/> class that handles all logic for the <see cref="Prediction"/> view
    /// </summary>
    public static class PredictionController
    {
        /// <summary>
        /// An instance of <see cref="Prediction"/> class view
        /// </summary>
        public static Prediction PredictionView { get; set; }

        /// <summary>
        /// A decimal to contain the value for all recurring income before today
        /// </summary>
        private static decimal RecurringIncomeBefore { get; set; }

        /// <summary>
        /// A decimal to contain all recurring expenses before today
        /// </summary>
        private static decimal RecurringExpenseBefore { get; set; }

        /// <summary>
        /// A decimal to contain all one off income payments before today
        /// </summary>
        private static decimal NonRecurringIncomeBefore { get; set; }

        /// <summary>
        /// A decimal to contain all one off expense payments before today
        /// </summary>
        private static decimal NonRecurringExpenseBefore { get; set; }

        /// <summary>
        /// A decimal to contain the percentage gain
        /// </summary>
        private static decimal PercentageGain { get; set; }

        /// <summary>
        /// A decimal to contain all recurring income after today
        /// </summary>
        private static decimal RecurringIncomeAfter { get; set; }

        /// <summary>
        /// A decimal to contain all recurring expense after today
        /// </summary>
        private static decimal RecurringExpenseAfter { get; set; }
        
        /// <summary>
        /// A DateTime to represent the start of the prediction period
        /// </summary>
        private static DateTime PeriodStart { get; set; }

        /// <summary>
        /// A DateTime to represent the end of the prediction period
        /// </summary>
        private static DateTime PeriodEnd { get; set; }

        /// <summary>
        /// A decimal that contains the current balance when this view is loaded
        /// </summary>
        private static decimal CurrentBalance { get; } = ListAccessHelper.Balance;

        /// <summary>
        /// Handles the back button being clicked on a <see cref="Prediction"/> form
        /// </summary>
        /// <param name="sender">The sender object</param>
        /// <param name="e">Event arguments</param>
        public static void BackButtonClicked(object sender, EventArgs e)
        {
            PredictionView.Owner.Show();
            PredictionView.Close();
        }

        /// <summary>
        /// Handles the DateTime value of the prediction date being changed
        /// </summary>
        /// <param name="sender">The sender object</param>
        /// <param name="e">Event arguments</param>
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

        /// <summary>
        /// Calculates the predicted balance on the given date
        /// </summary>
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

        /// <summary>
        /// Calculates the percentage gain using the current balance and the previous balance
        /// Both previous and current balance are with recurring income/expense excluded
        /// </summary>
        /// <param name="current">The current balance without recurring payments</param>
        /// <param name="previous">The previous balance without recurring payments</param>
        /// <returns>The percentage gain from previous to current balance</returns>
        private static decimal CalculatePercentageGain(decimal current, decimal previous)
        {
            if (previous == 0)
            {
                return 0.00m;
            }

            var change = current - previous;
            return change / previous;
        }

        /// <summary>
        /// Calculates all recurring expenses after the current date and before the prediction date
        /// </summary>
        /// <returns>Total recurring expenses</returns>
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

        /// <summary>
        /// Calculates all recurring income after the current date and before the prediction end
        /// </summary>
        /// <returns>Total recurring income</returns>
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

        /// <summary>
        /// Calculates all non recurring expenses before the current date and after the prediction start date
        /// </summary>
        /// <returns>Total non recurring expenses</returns>
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

        /// <summary>
        /// Calculates all non recurring income before the current date and after the prediction start date
        /// </summary>
        /// <returns>Total non recurring income</returns>
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

        /// <summary>
        /// Calculates all recurring expense before the current date and after the prediction start date
        /// </summary>
        /// <returns>Total recurring expenses</returns>
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

        /// <summary>
        /// calculates all recurring income before the current date and after the prediction start date
        /// </summary>
        /// <returns>Total recurring income</returns>
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
