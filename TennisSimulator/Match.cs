using System.Collections.Generic;
using System.Linq;
using TennisSimulator.Helpers;

namespace TennisSimulator
{
    public class Match
    {
        private List<Set> _sets;

        public Match()
        {
            _sets = new List<Set>();
        }

        public string Play(IMatchParameters matchParameters)
        {
            Set currentSet;

            // match must play until there is a result
            while (true)
            {            
                currentSet = new Set(0, 0);
                _sets.Add(currentSet);

                // continue playing some games until someone wins the current set
                while (currentSet.Winner == 0)
                {
                    var game = new Game();
                    int winner = game.Play(matchParameters);
                    currentSet.UpdateWinCount(winner);
                }                

                int potentialMatchWinner = DetermineMatchWinner();

                if (potentialMatchWinner == 1 || potentialMatchWinner == 2)
                    return string.Format("Player {0} has won the match. Final score: {1}", potentialMatchWinner,
                                string.Join(", ", _sets.Select(x => x.SetResult)));
            }
        }

        private int DetermineMatchWinner()
        {
            if (_sets.Where(x => x.Winner == 1).Count() == 2)
                return 1;
            else if (_sets.Where(x => x.Winner == 2).Count() == 2)
                return 2;

            return 0;
        }
    }
}