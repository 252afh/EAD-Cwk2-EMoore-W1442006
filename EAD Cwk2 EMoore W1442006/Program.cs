using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Xml.Linq;
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
            LoadXml();
            CalculateBalance();
            Application.Run(new MainMenuForm());
        }

        private static void LoadXml()
        {
            string url = "C:\\Users\\Elliot\\Documents\\SaveFile.xml";

            XElement data = XElement.Load(url);
            IEnumerable<XElement> payers = data.Element("Payers").Elements();

            foreach (var payer in payers)
            {
                ListAccessHelper.PayerList.Add(new Payer
                {
                    Name = payer.Attribute("Name").Value,
                    Id = Guid.Parse(payer.Attribute("Id").Value),
                    PaymentType = payer.Attribute("Type").Value
                });
            }
            
            IEnumerable<XElement> payees = data.Element("Payees").Elements();

            foreach (var payee in payees)
            {
                ListAccessHelper.PayeeList.Add(new Payee
                {
                    Id = Guid.Parse(payee.Attribute("Id").Value),
                    AccNumber = payee.Attribute("AccNumber").Value,
                    Address = payee.Attribute("Address").Value,
                    Name = payee.Attribute("Name").Value,
                    SortCode = payee.Attribute("SortCode").Value
                });
            }

            IEnumerable<XElement> incomes = data.Element("Incomes").Elements();

            foreach (var income in incomes)
            {
                ListAccessHelper.IncomeList.Add(new Income
                {
                    Amount = (decimal)income.Attribute("Amount"),
                    Id = Guid.Parse(income.Attribute("Id").Value),
                    InitialPaidDate = DateTime.Parse(income.Attribute("InitialDate").Value),
                    Interval = int.Parse(income.Attribute("Interval").Value),
                    IsRecurring = bool.Parse(income.Attribute("IsRecurring").Value),
                    LastPaidDate = DateTime.Parse(income.Attribute("LastPaidDate").Value),
                    Ref = income.Attribute("Reference").Value,
                    Payer = ListAccessHelper.FindPayer(Guid.Parse(income.Attribute("Payer").Value))
                });
            }

            // Make sure to throw errors or send a silent email and delete the index if the payer or payee below cannot be found

            IEnumerable<XElement> expenses = data.Element("Expenses").Elements();

            foreach (var expense in expenses)
            {
                ListAccessHelper.ExpenseList.Add(new Expense
                {
                    Amount = (decimal)expense.Attribute("Amount"),
                    Id = Guid.Parse(expense.Attribute("Id").Value),
                    InitialPaidDate = DateTime.Parse(expense.Attribute("InitialDate").Value),
                    Interval = int.Parse(expense.Attribute("Interval").Value),
                    IsRecurring = bool.Parse(expense.Attribute("IsRecurring").Value),
                    LastPaidDate = DateTime.Parse(expense.Attribute("LastPaidDate").Value),
                    Ref = expense.Attribute("Reference").Value,
                    Payee = ListAccessHelper.FindPayee(Guid.Parse(expense.Attribute("Payer").Value))
                });
            }
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
