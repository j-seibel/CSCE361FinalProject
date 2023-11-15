using System;
using System.Data;
using System.Data.SqlClient;
using System.Numerics;

namespace CardGame.SQL
{
    public class ConnectionAccessor
    {
        private static string _connectionString = "Data Source =CONNORM-LAPTOP\\SQLEXPRESS;initial catalog=master;trusted_connection=true";
        public ConnectionAccessor()
        {
            
        }

        public static void TestDatabaseConnection()
        {
            SqlConnection connection = new SqlConnection(_connectionString);
            try
            {
                connection.Open();
                if (connection.State == ConnectionState.Open)
                {
                    System.Diagnostics.Debug.WriteLine("Connection Successful!\n\n\n\n");
                    string selectQuery =
                        "insert into Player(username, password, gamesPlayed, gamesWon, solitaireELO, warELO) values ('cjdimes12', 'jpxfr33d', 5 , 4, 1300, 2500);";
                    using (SqlCommand command = new SqlCommand(selectQuery, connection))
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
                System.Diagnostics.Debug.WriteLine("connection failed\n\n\n\n");
            }
            connection.Close();
        }
    }
}