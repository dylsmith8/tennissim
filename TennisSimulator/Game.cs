using System;
using TennisSimulator.Enums;
using TennisSimulator.Helpers;

namespace TennisSimulator
{
    public class Game
    {
        private readonly int _player1Id;
        private readonly int _player2Id;

        private Score _score;

        public Game()
        {
            _player1Id = 1;
            _player2Id = 2;

            _score = new Score();
        }

        public string Play(IMatchParameters matchParameters)
        {
            while (true)
            {
                Tuple<GameOutcome, Outcome> result = null;

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

                if (result.Item2 != null)
                {
                    return result.Item2.ToString();
                }           
            }
        }
    }
}
