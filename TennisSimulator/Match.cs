using System;
using System.Collections.Generic;
using System.Linq;
using TennisSimulator.Helpers;

namespace TennisSimulator
{
    public class Match
    {
        private readonly List<ISet> _playedSets;
        private readonly IMatchParameters _matchParameters;

        public Match(IMatchParameters matchParameters)
        {
            _matchParameters = matchParameters ?? throw new ArgumentNullException(nameof(matchParameters));
            _playedSets = matchParameters.InitialiseMatchSets();
        }

        public string Play()
        {
            ISet currentSet;

            // match must play until there is a result
            foreach (var set in _playedSets)
            {
                currentSet = set;

                // continue playing some games until someone wins the current set
                while (currentSet.Winner == 0)
                {
                    var game = new Game();
                    int winner = game.Play(_matchParameters);
                    currentSet.UpdateWinCount(winner);
                }                

                int potentialMatchWinner = DetermineMatchWinner();

                if (potentialMatchWinner == 1 || potentialMatchWinner == 2)
                    return string.Format("Player {0} has won the match. Final score: {1}", potentialMatchWinner,
                                string.Join(", ", _playedSets.Select(x => x.SetResult)));
            }

            return "Result could not be determined";
        }

        private int DetermineMatchWinner()
        {
            if (_playedSets.Where(x => x.Winner == 1).Count() == 2)
                return 1;
            else if (_playedSets.Where(x => x.Winner == 2).Count() == 2)
                return 2;

            return 0;
        }
    }
}