using System.IO;

namespace EAD_Cwk2_EMoore_W1442006.DataAccess
{
    using Helpers;
    using Models;
    using Properties;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Xml.Linq;

    /// <summary>
    /// An instance of <see cref="XmlDataAccess"/> used to handle all logic regarding XML data storage
    /// </summary>
    public class XmlDataAccess
    {
        /// <summary>
        /// Handles loading <see cref="Payer"/> objects from XML
        /// </summary>
        /// <param name="data">The XElement containing all stored data</param>
        private void LoadPayers(XElement data)
        {
            try
            {
                IEnumerable<XElement> payers = data.Element("Payers").Elements();

                foreach (var payer in payers)
                {
                    ListAccessHelper.PayerList.Add(new Payer
                    {
                        Name = payer.Attribute("Name")?.Value,
                        Id = Guid.Parse(payer.Attribute("Id")?.Value ?? throw new NullReferenceException()),
                        PaymentType = payer.Attribute("Type")?.Value
                    });
                }
            }
            catch (NullReferenceException ex)
            {
                ErrorHelper.SendError(ex);
            }
        }

        /// <summary>
        /// Handles loading <see cref="Payee"/> objects from XML
        /// </summary>
        /// <param name="data">The XElement containing all stored data</param>
        private void LoadPayees(XElement data)
        {
            try
            {
                IEnumerable<XElement> payees = data.Element("Payees")?.Elements();

                foreach (var payee in payees)
                {
                    ListAccessHelper.PayeeList.Add(new Payee
                    {
                        Id = Guid.Parse(payee.Attribute("Id")?.Value ?? throw new NullReferenceException()),
                        AccNumber = payee.Attribute("AccNumber")?.Value,
                        Address = payee.Attribute("Address")?.Value,
                        Name = payee.Attribute("Name")?.Value,
                        SortCode = payee.Attribute("SortCode")?.Value
                    });
                }
            }
            catch (NullReferenceException ex)
            {
                ErrorHelper.SendError(ex);
            }
        }

        /// <summary>
        /// Handles loading <see cref="Income"/> objects from XML
        /// </summary>
        /// <param name="data">The XElement containing all stored data</param>
        private void LoadIncome(XElement data)
        {
            try
            {
                IEnumerable<XElement> incomes = data.Element("Incomes")?.Elements();

                foreach (var income in incomes)
                {
                    ListAccessHelper.IncomeList.Add(new Income
                    {
                        Amount = (decimal) income.Attribute("Amount"),
                        Id = Guid.Parse(income.Attribute("Id")?.Value ?? throw new NullReferenceException()),
                        InitialPaidDate = DateTime.Parse(income.Attribute("InitialDate")?.Value),
                        Interval = int.Parse(income.Attribute("Interval")?.Value ?? throw new NullReferenceException()),
                        IsRecurring = bool.Parse(income.Attribute("IsRecurring")?.Value ?? throw new NullReferenceException()),
                        LastPaidDate = DateTime.Parse(income.Attribute("LastPaidDate")?.Value),
                        Ref = income.Attribute("Reference")?.Value,
                        Payer = ListAccessHelper.FindPayer(Guid.Parse(income.Attribute("Payer")?.Value ?? throw new NullReferenceException()))
                    });
                }
            }
            catch (NullReferenceException ex)
            {
                ErrorHelper.SendError(ex);
            }
        }

        /// <summary>
        /// Handles loading <see cref="Expense"/> objects from XML
        /// </summary>
        /// <param name="data">The XElement containing all stored data</param>
        private void LoadExpense(XElement data)
        {
            try
            {
                IEnumerable<XElement> expenses = data.Element("Expenses")?.Elements();

                foreach (var expense in expenses)
                {
                    ListAccessHelper.ExpenseList.Add(new Expense
                    {
                        Amount = (decimal) expense.Attribute("Amount"),
                        Id = Guid.Parse(expense.Attribute("Id")?.Value ?? throw new NullReferenceException()),
                        InitialPaidDate = DateTime.Parse(expense.Attribute("InitialDate")?.Value),
                        Interval = int.Parse(expense.Attribute("Interval")?.Value ?? throw new NullReferenceException()),
                        IsRecurring = bool.Parse(expense.Attribute("IsRecurring")?.Value ?? throw new NullReferenceException()),
                        LastPaidDate = DateTime.Parse(expense.Attribute("LastPaidDate")?.Value),
                        Ref = expense.Attribute("Reference")?.Value,
                        Payee = ListAccessHelper.FindPayee(Guid.Parse(expense.Attribute("Payer")?.Value ?? throw new NullReferenceException()))
                    });
                }
            }
            catch (NullReferenceException ex)
            {
                ErrorHelper.SendError(ex);
            }
        }

        /// <summary>
        /// Handles setting the url and loading the XElement containg all stored data
        /// </summary>
        public void LoadXml()
        {
            try
            {
                var url = Settings.Default.XMLLocation;
                var data = XElement.Load(url);

                LoadPayers(data);
                LoadPayees(data);
                LoadIncome(data);
                LoadExpense(data);
            }
            catch (Exception ex)
            {
                if (ex is FileNotFoundException)
                {
                    //swallow as the file will be created on save   
                }
                else
                {
                    ErrorHelper.SendError(ex);
                }
            }
        }

        /// <summary>
        /// Handles saving all lists back into XML
        /// </summary>
        public void SaveXml()
        {
            var saveData = new XElement("Data",
                PayersElement(),
                PayeesElement(),
                IncomeElement(),
                ExpensesElement()
                );

            saveData.Save(Settings.Default.XMLLocation);
        }

        /// <summary>
        /// Handles constructing the <see cref="Payer"/> XElement
        /// </summary>
        /// <returns>An XElement containing all <see cref="Payer"/> objects</returns>
        private XElement PayersElement()
        {
            return new XElement("Payers", ListAccessHelper.PayerList.Select(payer =>
                new XElement("payer",
                    new XAttribute("Id", payer.Id),
                    new XAttribute("Name", payer.Name),
                    new XAttribute("Type", payer.PaymentType))));
        }

        /// <summary>
        /// Handles constructing the <see cref="Payee"/> XElement
        /// </summary>
        /// <returns>An XElement containing all <see cref="Payee"/> objects</returns>
        private XElement PayeesElement()
        {
            return new XElement("Payees", ListAccessHelper.PayeeList.Select(payee =>
                new XElement("payee",
                    new XAttribute("Id", payee.Id),
                    new XAttribute("Name", payee.Name),
                    new XAttribute("AccNumber", payee.AccNumber),
                    new XAttribute("SortCode", payee.SortCode),
                    new XAttribute("Address", payee.Address))));
        }

        /// <summary>
        /// Handles constructing the <see cref="Income"/> XElement
        /// </summary>
        /// <returns>An XElement containing all <see cref="Income"/> objects</returns>
        private XElement IncomeElement()
        {
            return new XElement("Incomes", ListAccessHelper.IncomeList.Select(income =>
                new XElement("income",
                    new XAttribute("Id", income.Id),
                    new XAttribute("Amount", income.Amount),
                    new XAttribute("InitialDate", income.InitialPaidDate),
                    new XAttribute("Interval", income.Interval),
                    new XAttribute("IsRecurring", income.IsRecurring),
                    new XAttribute("LastPaidDate", income.LastPaidDate),
                    new XAttribute("Reference", income.Ref),
                    new XAttribute("Payer", income.Payer.Id))));

        }

        /// <summary>
        /// Handles constructing the <see cref="Expense"/> XElement
        /// </summary>
        /// <returns>An XElement containing all <see cref="Expense"/> objects</returns>
        private XElement ExpensesElement()
        {
            return new XElement("Expenses", ListAccessHelper.ExpenseList.Select(expense =>
                new XElement("expense",
                    new XAttribute("Id", expense.Id),
                    new XAttribute("Amount", expense.Amount),
                    new XAttribute("InitialDate", expense.InitialPaidDate),
                    new XAttribute("Interval", expense.Interval),
                    new XAttribute("IsRecurring", expense.IsRecurring),
                    new XAttribute("LastPaidDate", expense.LastPaidDate),
                    new XAttribute("Reference", expense.Ref),
                    new XAttribute("Payer", expense.Payee.Id))));
        }
    }
}
