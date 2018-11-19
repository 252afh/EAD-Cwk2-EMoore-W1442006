namespace EAD_Cwk2_EMoore_W1442006.Helpers
{
    using Models;
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// An instance of <see cref="ListAccessHelper"/> class used to store a list of <see cref="Income"/>, <see cref="Expense"/>, <see cref="Payer"/>
    ///  and <see cref="Payee"/> objects, as well as store the current balance
    /// </summary>
    public class ListAccessHelper
    {
        /// <summary>
        /// A list of <see cref="Payee"/> objects accessible by the whole system
        /// </summary>
        public static List<Payee> PayeeList { get; } = new List<Payee>();

        /// <summary>
        /// A list of <see cref="Payer"/> objects accessible by the whole system
        /// </summary>
        public static List<Payer> PayerList { get; } = new List<Payer>();

        /// <summary>
        /// A list of <see cref="Expense"/> objects accessible by the whole system
        /// </summary>
        public static List<Expense> ExpenseList { get; } = new List<Expense>();

        /// <summary>
        /// A list of <see cref="Income"/> objects accessible by the whole system
        /// </summary>
        public static List<Income> IncomeList { get; } = new List<Income>();

        /// <summary>
        /// A decimal containing the current balance of the system
        /// </summary>
        public static decimal Balance { get; private set; }

        /// <summary>
        /// Used to increment the <see cref="Balance"/>
        /// </summary>
        /// <param name="increment">The amount to increment the balance by</param>
        public static void IncrementBalance(decimal increment)
        {
            Balance += increment;
        }

        /// <summary>
        /// Used to decrement the <see cref="Balance"/>
        /// </summary>
        /// <param name="decrement">The amount to decrement the balance by</param>
        public static void DecrementBalance(decimal decrement)
        {
            Balance -= decrement;
        }

        /// <summary>
        /// Used to find a <see cref="Payer"/> using the id
        /// </summary>
        /// <param name="id">The id to search</param>
        /// <returns>The id of the <see cref="Payer"/> or <c>null</c> if no <see cref="Payer"/> is found</returns>
        public static Payer FindPayer(Guid id)
        {
            foreach (var payer in PayerList)
            {
                if (payer.Id == id)
                {
                    return payer;
                }
            }

            return null;
        }

        /// <summary>
        /// Used to find a <see cref="Payee"/> using the id
        /// </summary>
        /// <param name="id">The id to search</param>
        /// <returns>The id of the <see cref="Payee"/> or <c>null</c> if no <see cref="Payee"/> is found</returns>
        public static Payee FindPayee(Guid id)
        {
            foreach (var payee in PayeeList)
            {
                if (payee.Id == id)
                {
                    return payee;
                }
            }

            return null;
        }

        /// <summary>
        /// Used to find a <see cref="Expense"/> using the id
        /// </summary>
        /// <param name="id">The id to search</param>
        /// <returns>The id of the <see cref="Expense"/> or <c>null</c> if no <see cref="Expense"/> is found</returns>
        public static Expense FindExpense(Guid id)
        {
            foreach (var expense in ExpenseList)
            {
                if (expense.Id == id)
                {
                    return expense;
                }
            }

            return null;
        }

        /// <summary>
        /// Used to find a <see cref="Income"/> using the id
        /// </summary>
        /// <param name="id">The id to search</param>
        /// <returns>The id of the <see cref="Income"/> or <c>null</c> if no <see cref="Income"/> is found</returns>
        public static Income FindIncome(Guid id)
        {
            foreach (var income in IncomeList)
            {
                if (income.Id == id)
                {
                    return income;
                }
            }

            return null;
        }
    }
}
