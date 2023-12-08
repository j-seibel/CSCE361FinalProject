namespace CardGame.Models
{
    public class Player: IEloCalc
    {
        public string Name { get; set; }
        public string currentRoom { get; set; }
        public double ELO { get; set; }
        public Player(string Name, string currentRoom, double ELO) {
            this.Name = Name;
            this.currentRoom = currentRoom; 
            this.ELO = ELO;
        }

        public void updateElo(double oppRating,int result)
        {
            if(oppRating < 0 || result < 0 || result > 1)
            {
                throw new ArgumentException();
            }
            double expectedResult = 1.0 / (1.0 + Math.Pow(10, (oppRating - this.ELO) / 400.0));
            this.ELO += expectedResult * 10 * result;
        }


    }
}
