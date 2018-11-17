using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EAD_Cwk2_EMoore_W1442006.Helpers;
using EAD_Cwk2_EMoore_W1442006.Views;

namespace EAD_Cwk2_EMoore_W1442006.Controllers
{
    public static class PredictionController
    {
        public static Prediction PredictionView;

        public static void BackButtonClicked(object sender, EventArgs e)
        {
            PredictionView.Owner.Show();
            PredictionView.Close();
        }

        public static void PredictionDateChanged(object sender, EventArgs e)
        {
            PredictionView.BalanceOnDateText.Text = null;
            PredictionView.DaysToPredictionText.Text = null;
            PredictionView.OneOffExpensesText.Text = null;
            PredictionView.OneOffIncomeText.Text = null;
            PredictionView.RecurringExpensesText.Text = null;
            PredictionView.RecurringIncomeText.Text = null;

            var currentBalance = ListAccessHelper.Balance;
            var startBalance = currentBalance;

            var days = (DateTime.UtcNow - PredictionView.PredictionDatePicker.Value).Days;

            var predictionStart = DateTime.UtcNow.AddDays(days * -1);
            var predictionEnd = DateTime.UtcNow.AddDays(days);

            decimal recurringIncomeBefore = 0;
            decimal oneOffIncomeBefore = 0;
            decimal recurringExpenseBefore = 0;
            decimal oneOffExpenseBefore = 0;
            decimal recurringIncomeAfter = 0;
            decimal recurringExpenseAfter = 0;
            decimal predictionAmount = 0;
            decimal predictedOneOffPercentageGain = 0;

            foreach (var expense in ListAccessHelper.ExpenseList)
            {
                if (expense.IsRecurring)
                {
                    if (expense.InitialPaidDate <= DateTime.UtcNow &&
                        (expense.InitialPaidDate >= predictionStart ||
                         (expense.LastPaidDate.AddDays(expense.Interval) >= predictionStart &&
                          expense.LastPaidDate.AddDays(expense.Interval) <= DateTime.UtcNow)))
                    {
                        if (expense.LastPaidDate < predictionStart &&
                            (expense.LastPaidDate.AddDays(expense.Interval) >= predictionStart &&
                             expense.LastPaidDate.AddDays(expense.Interval) <= DateTime.UtcNow))
                        {
                            var firstPaymentInsidePeriod = expense.LastPaidDate.AddDays(expense.Interval);
                            var payments = 1;
                            var availableDays = (DateTime.UtcNow - firstPaymentInsidePeriod).Days;
                            payments += availableDays / expense.Interval;
                            var paymentAmountForRecurring = payments * expense.Amount;

                            recurringExpenseBefore += paymentAmountForRecurring;
                        }
                    }
                }
                else
                {
                    if (expense.InitialPaidDate >= predictionStart && expense.InitialPaidDate <= DateTime.UtcNow)
                    {
                        oneOffExpenseBefore += expense.Amount;
                    }
                }
            }

            foreach (var income in ListAccessHelper.IncomeList)
            {
                if (income.IsRecurring)
                {
                    // Checks the payment is within the previous period of the next payment will fall into this category
                    if (income.InitialPaidDate <= DateTime.UtcNow &&
                        (income.LastPaidDate >= predictionStart ||
                         (income.LastPaidDate.AddDays(income.Interval) >= predictionStart &&
                          income.LastPaidDate.AddDays(income.Interval) <= DateTime.UtcNow)))
                    {
                        var payments = 1;
                        DateTime firstPaymentInPeriod;

                        if (income.LastPaidDate >= predictionStart)
                        {
                            firstPaymentInPeriod = income.LastPaidDate;
                        }
                        else
                        {
                            firstPaymentInPeriod = income.LastPaidDate.AddDays(income.Interval);
                        }

                        var daysInPayment = (DateTime.UtcNow - firstPaymentInPeriod).Days;
                        payments += (daysInPayment / income.Interval);
                        var amount = payments * income.Amount;

                        recurringIncomeBefore += amount;
                    }
                }
                else
                {
                    if (income.InitialPaidDate >= predictionStart && income.InitialPaidDate <= DateTime.UtcNow)
                    {
                        oneOffIncomeBefore += income.Amount;
                    }
                }
            }

            foreach (var income in ListAccessHelper.IncomeList)
            {
                if (!income.IsRecurring)
                {
                    continue;
                }

                if ((income.InitialPaidDate >= DateTime.Now && income.InitialPaidDate <= predictionEnd) ||
                    (income.LastPaidDate.AddDays(income.Interval) >= DateTime.Now &&
                     income.LastPaidDate.AddDays(income.Interval) <= predictionEnd))
                {
                    if (income.InitialPaidDate < DateTime.Now)
                    {
                        // means it is within the date with the interval added
                        var daysInPaymentPeriodAfter =
                            (predictionEnd - income.LastPaidDate.AddDays(income.Interval)).Days;
                        var incomeAmount = ((daysInPaymentPeriodAfter / income.Interval) + 1) * income.Amount;
                        // Add to var or add to total balance for final prediction?
                        recurringIncomeAfter += incomeAmount;
                    }
                    else
                    {
                        var daysInPaymentPeriod = (predictionEnd - income.LastPaidDate).Days;
                        var paymentsInPaymentPeriod = daysInPaymentPeriod / income.Interval;
                        var paymentAmount = (paymentsInPaymentPeriod + 1) * income.Amount;
                        recurringIncomeAfter += paymentAmount;
                    }
                }
            }


            foreach (var expense in ListAccessHelper.ExpenseList)
            {
                if (!expense.IsRecurring)
                {
                    continue;
                }

                if ((expense.InitialPaidDate >= DateTime.Now && expense.InitialPaidDate <= predictionEnd) ||
                    (expense.LastPaidDate.AddDays(expense.Interval) >= DateTime.Now &&
                     expense.LastPaidDate.AddDays(expense.Interval) <= predictionEnd))
                {
                    if (expense.InitialPaidDate < DateTime.Now)
                    {
                        // means it is within the date with the interval added
                        var daysInPaymentPeriodAfter =
                            (predictionEnd - expense.LastPaidDate.AddDays(expense.Interval)).Days;
                        var incomeAmount = ((daysInPaymentPeriodAfter / expense.Interval) + 1) * expense.Amount;
                        // Add to var or add to total balance for final prediction?
                        recurringExpenseAfter += incomeAmount;
                    }
                    else
                    {
                        var daysInPaymentPeriod = (predictionEnd - expense.LastPaidDate).Days;
                        var paymentsInPaymentPeriod = daysInPaymentPeriod / expense.Interval;
                        var paymentAmount = (paymentsInPaymentPeriod + 1) * expense.Amount;
                        recurringExpenseAfter += paymentAmount;
                    }
                }
            }


            // work out percentage increase

            var currentBalanceWithoutRecurring = (currentBalance - recurringIncomeBefore) + recurringExpenseBefore;
            var balanceBeforeWithoutOneOffPayments =
                (currentBalanceWithoutRecurring - oneOffIncomeBefore) + oneOffExpenseBefore;
            var percentageGain = (currentBalanceWithoutRecurring - balanceBeforeWithoutOneOffPayments) /
                                 balanceBeforeWithoutOneOffPayments;
            if (percentageGain > 0)
            {
                predictedOneOffPercentageGain =
                    currentBalanceWithoutRecurring + (currentBalanceWithoutRecurring * percentageGain);
            }
            else
            {
                predictedOneOffPercentageGain =
                    currentBalanceWithoutRecurring - (currentBalanceWithoutRecurring * percentageGain);
            }

            var predictedRecurringAfter = recurringIncomeAfter - recurringExpenseAfter;

            predictionAmount = predictedOneOffPercentageGain + predictedRecurringAfter;

            PredictionView.BalanceOnDateText.Text = "£" + predictionAmount;
            PredictionView.DaysToPredictionText.Text = (predictionEnd - DateTime.UtcNow).Days.ToString();
            PredictionView.OneOffExpensesText.Text = "£" + oneOffExpenseBefore.ToString();
            PredictionView.OneOffIncomeText.Text = "£" + oneOffIncomeBefore.ToString();
            PredictionView.RecurringExpensesText.Text = "£" + recurringExpenseAfter.ToString();
            PredictionView.RecurringIncomeText.Text = "£" + recurringIncomeAfter.ToString();

        }
    }
}
