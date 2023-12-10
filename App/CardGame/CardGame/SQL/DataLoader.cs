namespace CardGame.SQL;
using CardGame.SQL;
using System;
using System.Data;
using System.Data.SqlClient;
    
public class DataLoader
{


    public static int[] getPlayerInfo(string username)
    {
        int[] playerInfo = { -1, -1, -1 };
        string sql = "select gamesPlayed, gamesWon, ELO  from Player " +
                     "where username=@username;";
        SqlCommand cmd = new SqlCommand(sql, ConnectionAccessor.GetConnection());
        SqlParameter[] param = new SqlParameter[2];
        param[0] = new SqlParameter("@username", username);
        cmd.Parameters.Add(param[0]);;
        ConnectionAccessor.CreateConnection();
        SqlDataReader reader = cmd.ExecuteReader();
        try
        {
            while (reader.Read())
            {
                playerInfo[0] = reader.GetInt32(0);
                playerInfo[1] = reader.GetInt32(1);
                playerInfo[2] = reader.GetInt32(2);

                System.Diagnostics.Debug.WriteLine(playerInfo[0]);
                System.Diagnostics.Debug.WriteLine(playerInfo[1]);
                System.Diagnostics.Debug.WriteLine(playerInfo[2]);
            }
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine(ex);
        }
        ConnectionAccessor.CloseConnection();

        return playerInfo;
    }

    public static int getNumPlayers(int roomId)
    {
        int numPlayers = -1;
        string sql = "select numPlayers from Room where roomId=@roomId";
        SqlCommand cmd = new SqlCommand(sql, ConnectionAccessor.GetConnection());
        SqlParameter[] param = new SqlParameter[1];
        param[0] = new SqlParameter("@roomId", roomId);
        cmd.Parameters.Add(param[0]);
        ConnectionAccessor.CreateConnection();
        SqlDataReader reader = cmd.ExecuteReader();
        try
        {
            while (reader.Read())
            {
                numPlayers = reader.GetInt32(0);
                System.Diagnostics.Debug.WriteLine(numPlayers);
            }
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine(ex);
        }
        ConnectionAccessor.CloseConnection();

        return numPlayers;
    }

    public static int getRoomId(string roomCode)
    {
        int roomId = -1;
        string sql = "select roomId from Room where roomCode=@roomCode";
        SqlCommand cmd = new SqlCommand(sql, ConnectionAccessor.GetConnection());
        SqlParameter[] param = new SqlParameter[1];
        param[0] = new SqlParameter("@roomCode", roomCode);
        cmd.Parameters.Add(param[0]);
        ConnectionAccessor.CreateConnection();
        SqlDataReader reader = cmd.ExecuteReader();
        try
        {
            while (reader.Read())
            {
                roomId = reader.GetInt32(0);
                System.Diagnostics.Debug.WriteLine(roomId);
            }
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine(ex);
        }
        ConnectionAccessor.CloseConnection();

        return roomId;
    }

}
