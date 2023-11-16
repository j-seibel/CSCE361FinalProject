using System;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.Metrics;
using System.Numerics;

namespace CardGame.SQL
{
    public class ConnectionAccessor
    {
        private static string _connectionString = "Server=localhost\\SQLEXPRESS; Database = master; Trusted_Connection = True;";
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
                    string selectQuery = "INSERT INTO Employee (EmpID, LastName, FirstName) VALUES (9, 'Joe' ,  'MAMA');";
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