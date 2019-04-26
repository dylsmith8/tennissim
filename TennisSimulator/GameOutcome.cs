namespace TennisSimulator
{
    public class GameOutcome
    {
        private int _winner;

        public GameOutcome(int winner)
        {
            _winner = winner;
        }

        public int GetWinner()
        {
            return _winner;
        }
    }
}
