using System;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Diagnostics.Metrics;
using System.Numerics;

namespace CardGame.SQL
{
    public class ConnectionAccessor
    {

        private static SqlConnection _connection =
            new(
                "Data Source =CONNORM-LAPTOP\\SQLEXPRESS;initial catalog = master; trusted_connection=true");

        public static void TestDatabaseConnection()
        {
            try
            {
                _connection.Open();
                if (_connection.State == ConnectionState.Open)
                {
                    System.Diagnostics.Debug.WriteLine("Connection Successful!\n\n\n\n");
                    string selectQuery = "insert into Player(gamesPlayed, gamesWon, solitaireELO, warELO) values (201 , 8, 2300, 2000);";
                    using (SqlCommand command = new SqlCommand(selectQuery, _connection))
                    {
                        int rowsAffected = command.ExecuteNonQuery();
                    }

                }
                else {
                    System.Diagnostics.Debug.WriteLine("Connection Unsuccsessful\n\n\n\n");
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex);
            }
            _connection.Close();

        }

        public static void CreateConnection()
        {
            try
            {
                _connection.Open();
                
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex);
            }
        }

        public static void CloseConnection()
        {
            try
            {
                _connection.Close();

            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex);
            }
        }

        public static SqlConnection GetConnection()
        {
            return _connection;
        }
    }
}