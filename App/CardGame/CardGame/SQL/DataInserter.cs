namespace CardGame.SQL;
using CardGame.SQL;
using Microsoft.Extensions.Hosting;
using System;
using System.Data;
using System.Data.SqlClient;
    

public class DataInserter
{

    public static void createPlayer(string username)
    {
        string sql = "insert into Player (username, ELO, gamesPlayed, gamesWon) values (@username, 1000, 0, 0);";
        SqlCommand cmd = new SqlCommand(sql, ConnectionAccessor.GetConnection());
        SqlParameter[] param = new SqlParameter[2];
        param[0] = new SqlParameter("@username", username);
        cmd.Parameters.AddWithValue("@username", username);
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

        int roomId = DataLoader.getRoomId(roomCode);
        DataInserter.createPlayerRoomConnection(hostId, roomId);
    }

    public static void createPlayerRoomConnection(string username, int roomId)
    {
        string sql = "update Player set roomId = @roomId where username = @username;";
        SqlCommand cmd = new SqlCommand(sql, ConnectionAccessor.GetConnection());
        SqlParameter[] param = new SqlParameter[2];
        param[0] = new SqlParameter("@username", username);
        param[1] = new SqlParameter("roomId", roomId);
        cmd.Parameters.AddWithValue("@username", username);
        cmd.Parameters.AddWithValue("@roomId", roomId);
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

    public static void addNumPlayerRoom(int roomId)
    {
        int numPlayers = DataLoader.getNumPlayers(roomId) + 1;
        string sql = "update Room set numPlayers = @numPlayers where roomId = @roomId;";
        SqlCommand cmd = new SqlCommand(sql, ConnectionAccessor.GetConnection());
        SqlParameter[] param = new SqlParameter[2];
        param[0] = new SqlParameter("@numPlayers", numPlayers);
        param[1] = new SqlParameter("roomId", roomId);
        cmd.Parameters.AddWithValue("@numPlayers", numPlayers);
        cmd.Parameters.AddWithValue("@roomId", roomId);
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

    public static void removeNumPlayerRoom(int roomId)
    {
        int numPlayers = DataLoader.getNumPlayers(roomId) - 1;
        string sql = "update Room set numPlayers = @numPlayers where roomId = @roomId;";
        SqlCommand cmd = new SqlCommand(sql, ConnectionAccessor.GetConnection());
        SqlParameter[] param = new SqlParameter[2];
        param[0] = new SqlParameter("@numPlayers", numPlayers);
        param[1] = new SqlParameter("roomId", roomId);
        cmd.Parameters.AddWithValue("@numPlayers", numPlayers);
        cmd.Parameters.AddWithValue("@roomId", roomId);
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

    public static void playerJoinRoom(string username, string roomCode)
    {
        int roomId = DataLoader.getRoomId(roomCode);
        DataInserter.addNumPlayerRoom(roomId);
        DataInserter.createPlayerRoomConnection(username, roomId);
    }

    public static void playerLeaveRoom(string username, string roomCode)
    {
        int roomId = DataLoader.getRoomId(roomCode);
        DataInserter.removeNumPlayerRoom(roomId);
        string sql = "update Player set roomId = NULL where username = @username;";
        SqlCommand cmd = new SqlCommand(sql, ConnectionAccessor.GetConnection());
        SqlParameter[] param = new SqlParameter[1];
        param[0] = new SqlParameter("@username", username);
        cmd.Parameters.AddWithValue("@username", username);
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
