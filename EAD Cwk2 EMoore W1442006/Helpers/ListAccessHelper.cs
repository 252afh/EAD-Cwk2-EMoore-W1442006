using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EAD_Cwk2_EMoore_W1442006.Models;

namespace EAD_Cwk2_EMoore_W1442006.Helpers
{
    public class ListAccessHelper
    {
        public static List<Payee> PayeeList = new List<Payee>();

        public static List<Payer> PayerList = new List<Payer>();

        public static List<Expense> ExpenseList = new List<Expense>();

        public static List<Income> IncomeList = new List<Income>();
    }
}
