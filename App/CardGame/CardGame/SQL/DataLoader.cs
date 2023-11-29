namespace CardGame.SQL;
using CardGame.SQL;
using System;
using System.Data;
using System.Data.SqlClient;
    
public class DataLoader
{

    public static string getPassword(string username)
    {
        string password = null;
        string sql = "select password from Player where username=@username";
        SqlCommand cmd = new SqlCommand(sql, ConnectionAccessor.GetConnection());
        SqlParameter[] param = new SqlParameter[1];
        param[0] = new SqlParameter("@username", username);
        cmd.Parameters.Add(param[0]);
        ConnectionAccessor.CreateConnection();
        SqlDataReader reader = cmd.ExecuteReader();
        try
        {
            while (reader.Read())
            {
                password = reader["password"].ToString();
                System.Diagnostics.Debug.WriteLine(password);
            }
        }
        catch(Exception ex)
        {
            System.Diagnostics.Debug.WriteLine(ex);
        }
        ConnectionAccessor.CloseConnection();
        
        return password;
    }

    public static int[] getPlayerInfo(string username, string password)
    {
        int[] playerInfo = { -1, -1, -1, -1 };
        string sql = "select gamesPlayed, gamesWon, solitaireELO, warELO  from Player " +
                     "where username=@username AND password=@password";
        SqlCommand cmd = new SqlCommand(sql, ConnectionAccessor.GetConnection());
        SqlParameter[] param = new SqlParameter[2];
        param[0] = new SqlParameter("@username", username);
        param[1] = new SqlParameter("@password", password);
        cmd.Parameters.Add(param[0]);
        cmd.Parameters.Add(param[1]);
        ConnectionAccessor.CreateConnection();
        SqlDataReader reader = cmd.ExecuteReader();
        try
        {
            while (reader.Read())
            {
                playerInfo[0] = reader.GetInt32(0);
                playerInfo[1] = reader.GetInt32(1);
                playerInfo[2] = reader.GetInt32(2);
                playerInfo[3] = reader.GetInt32(3);

                System.Diagnostics.Debug.WriteLine(playerInfo[0]);
                System.Diagnostics.Debug.WriteLine(playerInfo[1]);
                System.Diagnostics.Debug.WriteLine(playerInfo[2]);
                System.Diagnostics.Debug.WriteLine(playerInfo[3]);
            }
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine(ex);
        }
        ConnectionAccessor.CloseConnection();

        return playerInfo;
    }

}
