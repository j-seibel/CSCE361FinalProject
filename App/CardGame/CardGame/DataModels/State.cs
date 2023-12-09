namespace CardGame.DataModels
{
    public class State
    {
        public int won { get; set; }
        public CardInfo myCard { get; set; }
        public CardInfo opCard { get; set; }
    }

    public class CardInfo
    {
        public string suit { get; set; }
        public string value { get; set; }
    }

}
