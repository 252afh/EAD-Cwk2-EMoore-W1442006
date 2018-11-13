using System;
using EAD_Cwk2_EMoore_W1442006.Models;
using EAD_Cwk2_EMoore_W1442006.Properties;
using MySql.Data.MySqlClient;

namespace EAD_Cwk2_EMoore_W1442006.DataAccess
{
    public class DatabaseDataAccess
    {

        private static string ConnectionString = Settings.Default.ConnectionString;
        private MySqlConnection conn = new MySqlConnection(ConnectionString);

        public async void InsertExpense(Expense expense)
        {
            using (conn)
            using (var comm = conn.CreateCommand())
            {
                await conn.OpenAsync();

                comm.CommandText =
                    "INSERT INTO " +
                    "expense(Id, PayeeId, Reference, Amount, IsRecurring, Interval, InitialPaidDate, LastPaidDate) " +
                    "VALUES (@Id, @PayeeId, @Reference, @Amount, @IsRecurring, @Interval, @InitialPaidDate, @LastPaidDate)";
                comm.Parameters.AddWithValue("@Id", expense.Id);
                comm.Parameters.AddWithValue("@PayeeId", expense.Payee.Id);
                comm.Parameters.AddWithValue("@Reference", expense.Ref);
                comm.Parameters.AddWithValue("@Amount", expense.Amount);
                comm.Parameters.AddWithValue("@IsRecurring", expense.IsRecurring);
                comm.Parameters.AddWithValue("@Interval", expense.Interval);
                comm.Parameters.AddWithValue("@InitialPaidDate", expense.InitialPaidDate);
                comm.Parameters.AddWithValue("@LastPaidDate", expense.LastPaidDate);

                await comm.ExecuteNonQueryAsync();

                await conn.CloseAsync();
            }
        }

        public async void InsertIncome()
        {
            using (conn)
            {

            }
        }

        public void InsertPayee()
        {
            using (conn)
            {

            }
        }

        public void InsertPayer()
        {
            using (conn)
            {

            }
        }

        public void GetExpenses()
        {
            using (conn)
            {

            }
        }

        public void GetIncomes()
        {
            using (conn)
            {

            }
        }

        public void GetPayees()
        {
            using (conn)
            {

            }
        }

        public void GetPayers()
        {
            using (conn)
            {

            }
        }
    }
}
