namespace EAD_Cwk2_EMoore_W1442006.DataAccess
{
    using Helpers;
    using Models;
    using MySql.Data.MySqlClient;
    using Properties;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    /// <summary>
    /// An instance of <see cref="DatabaseDataAccess"/> used for handling all database interaction logic
    /// </summary>
    public class DatabaseDataAccess
    {
        /// <summary>
        /// The connection string to connect to the local MySql Server
        /// </summary>
        private static string ConnectionString { get; } = Settings.Default.ConnectionString;

        /// <summary>
        /// An instance of a <see cref="MySqlConnection"/> used for interactions with the local MySql server
        /// </summary>
        private MySqlConnection Conn { get; } = new MySqlConnection(ConnectionString);

        /// <summary>
        /// Handles inserting a new <see cref="Expense"/> into the database
        /// </summary>
        /// <param name="expense">The <see cref="Expense"/> to be inserted</param>
        public async void InsertExpense(Expense expense)
        {
            try
            {
                using (Conn)
                using (var comm = Conn.CreateCommand())
                {
                    await Conn.OpenAsync();

                    comm.CommandText =
                        "INSERT INTO " +
                        "expense(Id, PayeeId, Reference, Amount, IsRecurring, PaymentInterval, InitialPaidDate, LastPaidDate) " +
                        "VALUES (?Id, ?PayeeId, ?Reference, ?Amount, ?IsRecurring, ?PaymentInterval, ?InitialPaidDate, ?LastPaidDate);";
                    comm.Parameters.AddWithValue("?Id", expense.Id.ToString());
                    comm.Parameters.AddWithValue("?PayeeId", expense.Payee.Id.ToString());
                    comm.Parameters.AddWithValue("?Reference", expense.Ref);
                    comm.Parameters.AddWithValue("?Amount", expense.Amount.ToString().Replace(",", "."));
                    comm.Parameters.AddWithValue("?IsRecurring", expense.IsRecurring ? 1 : 0);
                    comm.Parameters.AddWithValue("?PaymentInterval", expense.Interval);
                    comm.Parameters.AddWithValue("?InitialPaidDate", expense.InitialPaidDate);
                    comm.Parameters.AddWithValue("?LastPaidDate", expense.LastPaidDate);

                    await comm.ExecuteNonQueryAsync();

                    await Conn.CloseAsync();
                }
            }
            catch (Exception ex)
            {
                ErrorHelper.SendError(ex);
            }
        }

        /// <summary>
        /// Handles inserting a new <see cref="Income"/> into the database
        /// </summary>
        /// <param name="income">The <see cref="Income"/> to be inserted</param>
        public async void InsertIncome(Income income)
        {
            try
            {
                using (Conn)
                using (var comm = Conn.CreateCommand())
                {
                    await Conn.OpenAsync();

                    comm.CommandText =
                        "INSERT INTO " +
                        "income(Id, PayerId, Reference, Amount, IsRecurring, PaymentInterval, InitialPaidDate, LastPaidDate) " +
                        "VALUES (@Id, @PayerId, @Reference, @Amount, @IsRecurring, @PaymentInterval, @InitialPaidDate, @LastPaidDate)";
                    comm.Parameters.AddWithValue("@Id", income.Id.ToString());
                    comm.Parameters.AddWithValue("@PayerId", income.Payer.Id.ToString());
                    comm.Parameters.AddWithValue("@Reference", income.Ref);
                    comm.Parameters.AddWithValue("@Amount", income.Amount.ToString().Replace(",", "."));
                    comm.Parameters.AddWithValue("@IsRecurring", income.IsRecurring ? 1 : 0);
                    comm.Parameters.AddWithValue("@PaymentInterval", income.Interval);
                    comm.Parameters.AddWithValue("@InitialPaidDate", income.InitialPaidDate);
                    comm.Parameters.AddWithValue("@LastPaidDate", income.LastPaidDate);

                    await comm.ExecuteNonQueryAsync();

                    await Conn.CloseAsync();
                }
            }
            catch (Exception ex)
            {
                ErrorHelper.SendError(ex);
            }
        }

        /// <summary>
        /// Handles inserting a new <see cref="Payee"/> into the database
        /// </summary>
        /// <param name="payee">The <see cref="Payee"/> to be inserted</param>
        public async void InsertPayee(Payee payee)
        {
            try
            {
                using (Conn)
                using (var comm = Conn.CreateCommand())
                {
                    await Conn.OpenAsync();

                    comm.CommandText = "INSERT INTO " +
                                       "payee(Id, Name, SortCode, AccountNumber, Address) " +
                                       "VALUES (@Id, @Name, @SortCode, @AccountNumber, @Address)";

                    comm.Parameters.AddWithValue("@Id", payee.Id.ToString());
                    comm.Parameters.AddWithValue("@Name", payee.Name);
                    comm.Parameters.AddWithValue("@SortCode", payee.SortCode);
                    comm.Parameters.AddWithValue("@AccountNumber", payee.AccNumber);
                    comm.Parameters.AddWithValue("@Address", payee.Address);

                    await comm.ExecuteNonQueryAsync();

                    await Conn.CloseAsync();
                }
            }
            catch (Exception ex)
            {
                ErrorHelper.SendError(ex);
            }
        }

        /// <summary>
        /// Handles inserting a new <see cref="Payer"/> into the database
        /// </summary>
        /// <param name="payer">The <see cref="Payer"/> to be inserted</param>
        public async void InsertPayer(Payer payer)
        {
            try
            {
                using (Conn)
                using (var comm = Conn.CreateCommand())
                {
                    await Conn.OpenAsync();

                    comm.CommandText = "INSERT INTO " +
                                       "payer(Id, Name, PaymentType) " +
                                       "VALUES (@Id, @Name, @PaymentType)";

                    comm.Parameters.AddWithValue("@Id", payer.Id.ToString());
                    comm.Parameters.AddWithValue("@Name", payer.Name);
                    comm.Parameters.AddWithValue("@PaymentType", payer.PaymentType);

                    await comm.ExecuteNonQueryAsync();

                    await Conn.CloseAsync();
                }
            }
            catch (Exception ex)
            {
                ErrorHelper.SendError(ex);
            }
        }

        /// <summary>
        /// Handles retrieving all <see cref="Expense"/> records from the database
        /// </summary>
        /// <returns>A list of <see cref="Expense"/> objects</returns>
        public async Task<List<Expense>> GetExpenses()
        {
            try
            {
                using (Conn)
                using (var comm = Conn.CreateCommand())
                {
                    await Conn.OpenAsync();

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

                    await Conn.CloseAsync();

                    return expenses;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred retrieving expenses from the database", ex);
            }
        }
        
        /// <summary>
        /// Handles retrieving all <see cref="Income"/> records from the database
        /// </summary>
        /// <returns>A list of <see cref="Income"/> objects</returns>
        public async Task<List<Income>> GetIncomes()
        {
            try
            {
                using (Conn)
                using (var comm = Conn.CreateCommand())
                {
                    await Conn.OpenAsync();

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

                    await Conn.CloseAsync();

                    return incomes;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred retrieving incomes from the database", ex);
            }
        }

        /// <summary>
        /// Handles retrieiving all <see cref="Payee"/> records from the database
        /// </summary>
        /// <returns>A list of <see cref="Payee"/> objects</returns>
        public async Task<List<Payee>> GetPayees()
        {
            try
            {
                using (Conn)
                using (var comm = Conn.CreateCommand())
                {
                    await Conn.OpenAsync();

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

                    await Conn.CloseAsync();

                    return payees;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred retrieving payees from the database", ex);
            }
        }

        /// <summary>
        /// Handles retrieving all <see cref="Payer"/> records from the database
        /// </summary>
        /// <returns>A list of <see cref="Payer"/> objects</returns>
        public async Task<List<Payer>> GetPayers()
        {
            try
            {
                using (Conn)
                using (var comm = Conn.CreateCommand())
                {
                    await Conn.OpenAsync();

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

                    await Conn.CloseAsync();

                    return payers;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred retrieving payers from the database", ex);
            }
        }

        /// <summary>
        /// Handles updating an <see cref="Expense"/> record in the database
        /// </summary>
        /// <param name="expense">The updated <see cref="Expense"/></param>
        /// <param name="id">The id of the <see cref="Expense"/> to update</param>
        public async void EditExpense(Expense expense, Guid id)
        {
            try
            {
                using (Conn)
                using (var comm = Conn.CreateCommand())
                {
                    await Conn.OpenAsync();

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
                    comm.Parameters.AddWithValue("@Id", id.ToString());

                    await comm.ExecuteNonQueryAsync();

                    await Conn.CloseAsync();
                }
            }
            catch (Exception ex)
            {
                ErrorHelper.SendError(ex);
            }
        }

        /// <summary>
        /// Handles updating an <see cref="Income"/> record in the database
        /// </summary>
        /// <param name="income">The updated <see cref="Income"/></param>
        /// <param name="id">The id of the <see cref="Income"/> to update</param>
        public async void EditIncome(Income income, Guid id)
        {
            try
            {
                using (Conn)
                using (var comm = Conn.CreateCommand())
                {
                    await Conn.OpenAsync();

                    comm.CommandText = "UPDATE income " +
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
                    comm.Parameters.AddWithValue("@Id", id.ToString());

                    await comm.ExecuteNonQueryAsync();

                    await Conn.CloseAsync();
                }
            }
            catch (Exception ex)
            {
                ErrorHelper.SendError(ex);
            }
        }

        /// <summary>
        /// Handles updating a <see cref="Payee"/> record in the database
        /// </summary>
        /// <param name="payee">The updated <see cref="Payee"/></param>
        /// <param name="id">The id of the <see cref="Payee"/> to update</param>
        public async void EditPayee(Payee payee, Guid id)
        {
            try
            {
                using (Conn)
                using (var comm = Conn.CreateCommand())
                {
                    await Conn.OpenAsync();

                    comm.CommandText = "UPDATE payee " +
                                       "SET Id = @NewId, Name = @Name, SortCode = @SortCode, " +
                                       "AccountNumber = @AccountNumber, Address = @Address " +
                                       "WHERE Id = @Id;";

                    comm.Parameters.AddWithValue("@NewId", payee.Id.ToString());
                    comm.Parameters.AddWithValue("@Name", payee.Name);
                    comm.Parameters.AddWithValue("@SortCode", payee.SortCode);
                    comm.Parameters.AddWithValue("@AccountNumber", payee.AccNumber);
                    comm.Parameters.AddWithValue("@Address", payee.Address);
                    comm.Parameters.AddWithValue("@Id", id.ToString());

                    await comm.ExecuteNonQueryAsync();

                    await Conn.CloseAsync();
                }
            }
            catch (Exception ex)
            {
                ErrorHelper.SendError(ex);
            }
        }

        /// <summary>
        /// Handles updating a <see cref="Payer"/> record in the database
        /// </summary>
        /// <param name="payer">The updated <see cref="Payer"/></param>
        /// <param name="id">The id of the <see cref="Payer"/> to update</param>
        public async void EditPayer(Payer payer, Guid id)
        {
            try
            {
                using (Conn)
                using (var comm = Conn.CreateCommand())
                {
                    await Conn.OpenAsync();

                    comm.CommandText = "UPDATE payee " +
                                       "SET Id = @NewId, Name = @Name, " +
                                       "PaymentType = @PaymentType " +
                                       "WHERE Id = @Id;";

                    comm.Parameters.AddWithValue("@NewId", payer.Id.ToString());
                    comm.Parameters.AddWithValue("@Name", payer.Name);
                    comm.Parameters.AddWithValue("@PaymentType", payer.PaymentType);
                    comm.Parameters.AddWithValue("@Id", id.ToString());

                    await comm.ExecuteNonQueryAsync();

                    await Conn.CloseAsync();
                }
            }
            catch (Exception ex)
            {
                ErrorHelper.SendError(ex);
            }
        }
    }
}
