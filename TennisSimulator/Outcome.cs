namespace TennisSimulator
{
    public class Outcome
    {
        private int _winner;
        private string _finalScore;

        public Outcome(int winner, string finalScore)
        {
            _winner = winner;
            _finalScore = finalScore;
        }

        public override string ToString()
        {
            return string.Format("Player {0} has won the game.\n {1}", _winner, _finalScore);
        }
    }
}
