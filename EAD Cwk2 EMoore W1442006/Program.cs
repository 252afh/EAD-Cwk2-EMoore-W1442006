using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Xml.Linq;
using EAD_Cwk2_EMoore_W1442006.DataAccess;
using EAD_Cwk2_EMoore_W1442006.Helpers;
using EAD_Cwk2_EMoore_W1442006.Models;
using EAD_Cwk2_EMoore_W1442006.Views;
using Payer = EAD_Cwk2_EMoore_W1442006.Models.Payer;

namespace EAD_Cwk2_EMoore_W1442006
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            new XmlDataAccess().LoadXml();
            CalculateBalance();
            Application.Run(new MainMenuForm());
        }

        private static void CalculateBalance()
        {
            foreach (var income in ListAccessHelper.IncomeList)
            {
                if (income.IsRecurring && income.InitialPaidDate <= DateTime.UtcNow)
                {
                    var payments = 1;
                    payments += (DateTime.UtcNow - income.InitialPaidDate).Days / income.Interval;
                    var paymentAmount = payments * income.Amount;
                    ListAccessHelper.IncrementBalance(decimal.Round(paymentAmount, 2, MidpointRounding.AwayFromZero));
                }
                else
                {
                    ListAccessHelper.IncrementBalance(income.Amount);
                }
            }

            foreach (var expense in ListAccessHelper.ExpenseList)
            {
                if (expense.IsRecurring)
                {
                    var payments = 1;
                    payments += (DateTime.UtcNow - expense.InitialPaidDate).Days / expense.Interval;
                    var paymentAmount = payments * expense.Amount;
                    ListAccessHelper.DecrementBalance(decimal.Round(paymentAmount, 2, MidpointRounding.AwayFromZero));
                }
                else
                {
                    ListAccessHelper.DecrementBalance(expense.Amount);
                }
            }
        }
    }
}
