using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using EAD_Cwk2_EMoore_W1442006.Models;

namespace EAD_Cwk2_EMoore_W1442006.Helpers
{
    public class ListAccessHelper
    {
        public static List<Payee> PayeeList = new List<Payee>();

        public static List<Payer> PayerList = new List<Payer>();

        public static List<Expense> ExpenseList = new List<Expense>();

        public static List<Income> IncomeList = new List<Income>();

        public static decimal Balance { get; private set; }

        public static void IncrementBalance(decimal increment)
        {
            Balance += increment;
        }

        public static void DecrementBalance(decimal decrement)
        {
            Balance += decrement;
        }

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
    }
}
