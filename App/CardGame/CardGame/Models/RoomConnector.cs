using CardGame.DataModels;
using CardGame.SQL;
namespace CardGame.Models
{
    public static class RoomUtilites
    {
        public static void joinRoom(Room roomToJoin)
        {
            try
            {
                DataInserter.playerJoinRoom(roomToJoin.name, roomToJoin.roomID);

            }catch (Exception)
            {
                throw new Exception("Failed to join room");
            }


        }


        public static void createRoom(Room roomToJoin)
        {
            try
            {
                DataInserter.createRoom(roomToJoin.name, roomToJoin.roomID);
                joinRoom(roomToJoin);

            }
            catch (Exception)
            {
                throw new Exception("Failed to create room");
            }


        }


        public static void leaveRoom(Room roomToJoin)
        {
            try
            {
                DataInserter.playerLeaveRoom(roomToJoin.name, roomToJoin.roomID);

            }
            catch (Exception )
            {
                throw new Exception("Failed to leave room");
            }


        }

    }
}
