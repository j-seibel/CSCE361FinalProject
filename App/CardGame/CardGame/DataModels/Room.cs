namespace CardGame.DataModels
{
    public class Room
    {

        
        public string roomID { get; set; }
        public string name { get; set; }
        
        public string userId { get; set; }

        public Room(String name, String roomID, string userId)
        {
            this.roomID = roomID;
            this.name = name;
            this.userId = userId;

        }
    }
}
