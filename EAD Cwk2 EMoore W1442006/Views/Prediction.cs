using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EAD_Cwk2_EMoore_W1442006.Helpers;

namespace EAD_Cwk2_EMoore_W1442006.Views
{
    public partial class Prediction : Form
    {
        public Prediction()
        {
            InitializeComponent();
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            this.Owner.Show();
            this.Close();
        }

        private void PredictionDatePicker_ValueChanged(object sender, EventArgs e)
        {
            this.BalanceOnDateText.Text = null;
            this.DaysToPredictionText.Text = null;
            this.OneOffExpensesText.Text = null;
            this.OneOffIncomeText.Text = null;
            this.RecurringExpensesText.Text = null;
            this.RecurringIncomeText.Text = null;

            var currentBalance = ListAccessHelper.Balance;
            var startBalance = currentBalance;

            var days = (DateTime.UtcNow - this.PredictionDatePicker.Value).Days;

            var predictionStart = DateTime.UtcNow.AddDays(days*-1);
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
                            payments += availableDays/expense.Interval;
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
                        var daysInPaymentPeriodAfter = (predictionEnd - income.LastPaidDate.AddDays(income.Interval)).Days;
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
                        var daysInPaymentPeriodAfter = (predictionEnd - expense.LastPaidDate.AddDays(expense.Interval)).Days;
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
            var balanceBeforeWithoutOneOffPayments = (currentBalanceWithoutRecurring - oneOffIncomeBefore) + oneOffExpenseBefore;
            var percentageGain = (currentBalanceWithoutRecurring - balanceBeforeWithoutOneOffPayments) / balanceBeforeWithoutOneOffPayments;
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

            this.BalanceOnDateText.Text = "£" + predictionAmount;
            this.DaysToPredictionText.Text = (predictionEnd - DateTime.UtcNow).Days.ToString();
            this.OneOffExpensesText.Text = "£" + oneOffExpenseBefore.ToString();
            this.OneOffIncomeText.Text = "£" + oneOffIncomeBefore.ToString();
            this.RecurringExpensesText.Text = "£" + recurringExpenseAfter.ToString();
            this.RecurringIncomeText.Text = "£" + recurringIncomeAfter.ToString();
        }
    }
}
