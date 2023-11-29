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
            System.Diagnostics.Debug.WriteLine("Inserted Succesfully!\n");
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine(ex);
        }
        ConnectionAccessor.CloseConnection();
    }

    public static void createRoom(string hostId, string roomCode)
    {
        string sql = "insert into Room (hostId, roomCode, numPlayers) values (@hostId, @roomCode, @numPlayers);";
        SqlCommand cmd = new SqlCommand(sql, ConnectionAccessor.GetConnection());
        SqlParameter[] param = new SqlParameter[3];
        param[0] = new SqlParameter("@hostId", hostId);
        param[1] = new SqlParameter("@roomCode", roomCode);
        param[2] = new SqlParameter("@numPlayers", 1);
        cmd.Parameters.AddWithValue("@hostId", hostId);
        cmd.Parameters.AddWithValue("@roomCode", roomCode);
        cmd.Parameters.AddWithValue("@numPlayers", 1);
        try
        {
            ConnectionAccessor.CreateConnection();
            cmd.ExecuteNonQuery();
            System.Diagnostics.Debug.WriteLine("Inserted Succesfully!\n");
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine(ex);
        }
        ConnectionAccessor.CloseConnection();
    }

}
