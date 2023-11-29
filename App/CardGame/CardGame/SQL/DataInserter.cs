namespace CardGame.SQL;
using CardGame.SQL;
using System;
using System.Data;
using System.Data.SqlClient;
    

public class DataInserter
{

    public static void addPlayer(string username, string password)
    {
        string sql = "insert into Player (username, password) values (@username, @password);";
        SqlCommand cmd = new SqlCommand(sql, ConnectionAccessor.GetConnection());
        SqlParameter[] param = new SqlParameter[2];
        param[0] = new SqlParameter("@username", username);
        param[1] = new SqlParameter("@password", password);
        cmd.Parameters.AddWithValue("@username", username);
        cmd.Parameters.AddWithValue("@password", password);
        try
        {
            ConnectionAccessor.CreateConnection();
            cmd.ExecuteNonQuery();
            System.Diagnostics.Debug.WriteLine("Inserted Succesffuly!\n");
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine(ex);
        }
        ConnectionAccessor.CloseConnection();
    }

}
