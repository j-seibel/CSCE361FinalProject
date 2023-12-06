using CardGame.DataModels;
using CardGame.SQL;
namespace CardGame.Models.RoomConnector
{
    public class RoomUtilites
    {
        public static void joinRoom(Room roomToJoin)
        {
            try
            {
                DataInserter.playerJoinRoom(roomToJoin.userId, roomToJoin.roomID);

            }catch (Exception e)
            {
                throw new Exception();
            }


        }


        public static void createRoom(Room roomToJoin)
        {
            try
            {
                DataInserter.createRoom(roomToJoin.roomID, roomToJoin.userId);

            }
            catch (Exception e)
            {
                throw new Exception();
            }


        }


        public static void leaveRoom(Room roomToJoin)
        {
            try
            {
                DataInserter.playerLeaveRoom(roomToJoin.userId, roomToJoin.roomID);

            }
            catch (Exception e)
            {
                throw new Exception();
            }


        }

    }
}
