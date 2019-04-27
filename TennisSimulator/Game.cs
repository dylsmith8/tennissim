using System;
using TennisSimulator.Helpers;

namespace TennisSimulator
{
    public class Game
    {
        private readonly int _player1Id;
        private readonly int _player2Id;

        private readonly Score _score;

        public Game()
        {
            _player1Id = 1;
            _player2Id = 2;

            _score = new Score();
        }

        public int Play(IMatchParameters matchParameters)
        {
            if (matchParameters == null)
                throw new ArgumentNullException(nameof(matchParameters));

            while (true)
            {
               GameOutcome result = null;

                switch (matchParameters.GetRandomScorer())
                {
                    case 1:
                        result = _score.UpdateScore(_player1Id);
                        break;
                    case 2:
                        result = _score.UpdateScore(_player2Id);
                        break;
                    default:
                        throw new InvalidOperationException("Invalid scorer.");
                }

                if (result != null)
                    return result.GetWinner();       
            }
        }
    }
}
