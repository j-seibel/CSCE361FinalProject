namespace CardGame.Models
{
    public interface IEloCalc
    {
        public double ELO { get; }

        abstract void updateElo(double oppRating, int result);
    }
}
