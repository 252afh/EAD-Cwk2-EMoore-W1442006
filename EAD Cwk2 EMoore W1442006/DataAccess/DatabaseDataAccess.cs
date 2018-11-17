using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EAD_Cwk2_EMoore_W1442006.Helpers;
using EAD_Cwk2_EMoore_W1442006.Models;
using EAD_Cwk2_EMoore_W1442006.Properties;
using MySql.Data.MySqlClient;

namespace EAD_Cwk2_EMoore_W1442006.DataAccess
{
    public class DatabaseDataAccess
    {

        private static readonly string ConnectionString = Settings.Default.ConnectionString;
        private readonly MySqlConnection conn = new MySqlConnection(ConnectionString);

        public async void InsertExpense(Expense expense)
        {
            using (conn)
            using (var comm = conn.CreateCommand())
            {
                await conn.OpenAsync();

                comm.CommandText =
                    "INSERT INTO " +
                    "expense(Id, PayeeId, Reference, Amount, IsRecurring, PaymentInterval, InitialPaidDate, LastPaidDate) " +
                    "VALUES (?Id, ?PayeeId, ?Reference, ?Amount, ?IsRecurring, ?PaymentInterval, ?InitialPaidDate, ?LastPaidDate);";
                comm.Parameters.AddWithValue("?Id", expense.Id.ToString());
                comm.Parameters.AddWithValue("?PayeeId", expense.Payee.Id.ToString());
                comm.Parameters.AddWithValue("?Reference", expense.Ref);
                comm.Parameters.AddWithValue("?Amount", expense.Amount.ToString().Replace(",", "."));
                comm.Parameters.AddWithValue("?IsRecurring", expense.IsRecurring? 1 : 0);
                comm.Parameters.AddWithValue("?PaymentInterval", expense.Interval);
                comm.Parameters.AddWithValue("?InitialPaidDate", expense.InitialPaidDate);
                comm.Parameters.AddWithValue("?LastPaidDate", expense.LastPaidDate);

                await comm.ExecuteNonQueryAsync();

                await conn.CloseAsync();
            }
        }

        public async void InsertIncome(Income income)
        {
            using (conn)
            using (var comm = conn.CreateCommand())
            {
                await conn.OpenAsync();

                comm.CommandText =
                    "INSERT INTO " +
                    "income(Id, PayerId, Reference, Amount, IsRecurring, PaymentInterval, InitialPaidDate, LastPaidDate) " +
                    "VALUES (@Id, @PayerId, @Reference, @Amount, @IsRecurring, @PaymentInterval, @InitialPaidDate, @LastPaidDate)";
                comm.Parameters.AddWithValue("@Id", income.Id.ToString());
                comm.Parameters.AddWithValue("@PayerId", income.Payer.Id.ToString());
                comm.Parameters.AddWithValue("@Reference", income.Ref);
                comm.Parameters.AddWithValue("@Amount", income.Amount.ToString().Replace(",", "."));
                comm.Parameters.AddWithValue("@IsRecurring", income.IsRecurring? 1 : 0);
                comm.Parameters.AddWithValue("@PaymentInterval", income.Interval);
                comm.Parameters.AddWithValue("@InitialPaidDate", income.InitialPaidDate);
                comm.Parameters.AddWithValue("@LastPaidDate", income.LastPaidDate);

                await comm.ExecuteNonQueryAsync();

                await conn.CloseAsync();
            }
        }

        public async void InsertPayee(Payee payee)
        {
            using (conn)
            using (var comm = conn.CreateCommand())
            {
                await conn.OpenAsync();

                comm.CommandText = "INSERT INTO " +
                                   "payee(Id, Name, SortCode, AccountNumber, Address) " +
                                   "VALUES (@Id, @Name, @SortCode, @AccountNumber, @Address)";

                comm.Parameters.AddWithValue("@Id", payee.Id.ToString());
                comm.Parameters.AddWithValue("@Name", payee.Name);
                comm.Parameters.AddWithValue("@SortCode", payee.SortCode);
                comm.Parameters.AddWithValue("@AccountNumber", payee.AccNumber);
                comm.Parameters.AddWithValue("@Address", payee.Address);

                await comm.ExecuteNonQueryAsync();

                await conn.CloseAsync();
            }
        }

        public async void InsertPayer(Payer payer)
        {
            using (conn)
            using (var comm = conn.CreateCommand())
            {
                await conn.OpenAsync();

                comm.CommandText = "INSERT INTO " +
                                   "payer(Id, Name, PaymentType) " +
                                   "VALUES (@Id, @Name, @PaymentType)";

                comm.Parameters.AddWithValue("@Id", payer.Id.ToString());
                comm.Parameters.AddWithValue("@Name", payer.Name);
                comm.Parameters.AddWithValue("@PaymentType", payer.PaymentType);

                await comm.ExecuteNonQueryAsync();

                await conn.CloseAsync();
            }
        }

        public async Task<List<Expense>> GetExpenses()
        {
            using (conn)
            using (var comm = conn.CreateCommand())
            {
                await conn.OpenAsync();

                comm.CommandText = "SELECT * FROM expense";

                var expenses = new List<Expense>();
                var reader = comm.ExecuteReader();

                while (reader.ReadAsync().Result)
                {
                    var expense = new Expense
                    {
                        Id = reader.GetGuid(0),
                        Payee = ListAccessHelper.FindPayee(reader.GetGuid(1)),
                        Ref = reader.GetString(2),
                        Amount = reader.GetDecimal(3),
                        IsRecurring = reader.GetBoolean(4),
                        Interval = reader.GetInt32(5),
                        InitialPaidDate = reader.GetDateTime(6),
                        LastPaidDate = reader.GetDateTime(7)
                    };

                    expenses.Add(expense);
                }

                await conn.CloseAsync();

                return expenses;
            }
        }
        
        public async Task<List<Income>> GetIncomes()
        {
            using (conn)
            using (var comm = conn.CreateCommand())
            {
                await conn.OpenAsync();

                comm.CommandText = "SELECT * FROM income";

                var incomes = new List<Income>();
                var reader = comm.ExecuteReader();

                while (reader.ReadAsync().Result)
                {
                    var income = new Income
                    {
                        Id = reader.GetGuid(0),
                        Payer = ListAccessHelper.FindPayer(reader.GetGuid(1)),
                        Ref = reader.GetString(2),
                        Amount = reader.GetDecimal(3),
                        IsRecurring = reader.GetBoolean(4),
                        Interval = reader.GetInt32(5),
                        InitialPaidDate = reader.GetDateTime(6),
                        LastPaidDate = reader.GetDateTime(7)
                    };

                    incomes.Add(income);
                }

                await conn.CloseAsync();

                return incomes;
            }
        }

        public async Task<List<Payee>> GetPayees()
        {
            using (conn)
            using (var comm = conn.CreateCommand())
            {
                await conn.OpenAsync();

                comm.CommandText = "SELECT * FROM payee";

                var payees = new List<Payee>();
                var reader = comm.ExecuteReader();

                while (reader.ReadAsync().Result)
                {
                    var payee = new Payee
                    {
                        Id = reader.GetGuid(0),
                        Name = reader.GetString(1),
                        SortCode = reader.GetString(2),
                        AccNumber = reader.GetString(3),
                        Address = reader.GetString(4)
                    };

                    payees.Add(payee);
                }

                await conn.CloseAsync();

                return payees;
            }
        }

        public async Task<List<Payer>> GetPayers()
        {
            using (conn)
            using (var comm = conn.CreateCommand())
            {
                await conn.OpenAsync();

                comm.CommandText = "SELECT * FROM payer";

                var payers = new List<Payer>();
                var reader = comm.ExecuteReader();

                while (reader.ReadAsync().Result)
                {
                    var payer = new Payer
                    {
                        Id = reader.GetGuid(0),
                        PaymentType = reader.GetString(1),
                        Name = reader.GetString(2),
                    };

                    payers.Add(payer);
                }

                await conn.CloseAsync();

                return payers;
            }
        }

        public async void EditExpense(Expense expense, Guid Id)
        {
            using (conn)
            using (var comm = conn.CreateCommand())
            {
                await conn.OpenAsync();

                comm.CommandText = "UPDATE expense " +
                                   "SET Id = @NewId, PayeeId = @PayeeId, Reference = @Reference, Amount = @Amount, " +
                                   "IsRecurring = @IsRecurring, PaymentInterval = @PaymentInterval, InitialPaidDate = @InitialPaidDate, " +
                                   "LastPaidDate = @LastPaidDate WHERE Id = @Id;";

                comm.Parameters.AddWithValue("@NewId", expense.Id.ToString());
                comm.Parameters.AddWithValue("@PayeeId", expense.Payee.Id.ToString());
                comm.Parameters.AddWithValue("@Reference", expense.Ref);
                comm.Parameters.AddWithValue("@Amount", expense.Amount.ToString().Replace(",", "."));
                comm.Parameters.AddWithValue("@IsRecurring", expense.IsRecurring ? 1 : 0);
                comm.Parameters.AddWithValue("@PaymentInterval", expense.Interval);
                comm.Parameters.AddWithValue("@InitialPaidDate", expense.InitialPaidDate);
                comm.Parameters.AddWithValue("@LastPaidDate", expense.LastPaidDate);
                comm.Parameters.AddWithValue("@Id", Id.ToString());

                await comm.ExecuteNonQueryAsync();

                await conn.CloseAsync();
            }
        }

        public async void EditIncome(Income income, Guid Id)
        {
            using (conn)
            using (var comm = conn.CreateCommand())
            {
                await conn.OpenAsync();

                comm.CommandText = "UPDATE expense " +
                                   "SET Id = @NewId, PayerId = @PayerId, Reference = @Reference, Amount = @Amount, " +
                                   "IsRecurring = @IsRecurring, PaymentInterval = @PaymentInterval, InitialPaidDate = @InitialPaidDate, " +
                                   "LastPaidDate = @LastPaidDate " +
                                   "WHERE Id = @Id;";

                comm.Parameters.AddWithValue("@NewId", income.Id.ToString());
                comm.Parameters.AddWithValue("@PayerId", income.Payer.Id.ToString());
                comm.Parameters.AddWithValue("@Reference", income.Ref);
                comm.Parameters.AddWithValue("@Amount", income.Amount.ToString().Replace(",", "."));
                comm.Parameters.AddWithValue("@IsRecurring", income.IsRecurring ? 1 : 0);
                comm.Parameters.AddWithValue("@PaymentInterval", income.Interval);
                comm.Parameters.AddWithValue("@InitialPaidDate", income.InitialPaidDate);
                comm.Parameters.AddWithValue("@LastPaidDate", income.LastPaidDate);
                comm.Parameters.AddWithValue("@Id", Id.ToString());

                await comm.ExecuteNonQueryAsync();

                await conn.CloseAsync();
            }
        }

        public async void EditPayee(Payee payee, Guid Id)
        {
            using (conn)
            using (var comm = conn.CreateCommand())
            {
                await conn.OpenAsync();

                comm.CommandText = "UPDATE payee " +
                                   "SET Id = @NewId, Name = @Name, SortCode = @SortCode, " +
                                   "AccountNumber = @AccountNumber, Address = @Address " +
                                   "WHERE Id = @Id;";

                comm.Parameters.AddWithValue("@NewId", payee.Id.ToString());
                comm.Parameters.AddWithValue("@Name", payee.Name);
                comm.Parameters.AddWithValue("@SortCode", payee.SortCode);
                comm.Parameters.AddWithValue("@AccountNumber", payee.AccNumber);
                comm.Parameters.AddWithValue("@Address", payee.Address);
                comm.Parameters.AddWithValue("@Id", Id.ToString());

                await comm.ExecuteNonQueryAsync();

                await conn.CloseAsync();
            }
        }

        public async void EditPayer(Payer payer, Guid Id)
        {
            using (conn)
            using (var comm = conn.CreateCommand())
            {
                await conn.OpenAsync();

                comm.CommandText = "UPDATE payee " +
                                   "SET Id = @NewId, Name = @Name, " +
                                   "PaymentType = @PaymentType " +
                                   "WHERE Id = @Id;";

                comm.Parameters.AddWithValue("@NewId", payer.Id.ToString());
                comm.Parameters.AddWithValue("@Name", payer.Name);
                comm.Parameters.AddWithValue("@PaymentType", payer.PaymentType);
                comm.Parameters.AddWithValue("@Id", Id.ToString());

                await comm.ExecuteNonQueryAsync();

                await conn.CloseAsync();
            }
        }
    }
}
