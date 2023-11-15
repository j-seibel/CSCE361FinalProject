using System;
using System.Data;
using System.Data.SqlClient;

namespace SQL
{
    public class ConnectionAccessor
    {
        private string connectionString = "Data Source =CONNORM-LAPTOP\\SQLEXPRESS;initial catalog=master;trusted_connection=true";
        public ConnectionAccessor()
        {
            
        }

        public static void TestDatabaseConnection()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                connection.Open();
                if (connection.State == ConnectionState.Open)
                {
                    Console.WriteLine("Connection Successful!");
                }
                else
                {
                    Console.WriteLine("Connection Unsuccsessful");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("connection failed");
            }
            connection.Close();
        }
    }
}