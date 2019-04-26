using System;

namespace TennisSimulator.Helpers
{
    public class MatchParameters : IMatchParameters
    {
        private readonly Random _rng;
        public MatchParameters()
        {
            _rng = new Random();
        }

        public int GetRandomScorer()
        {
            return _rng.Next(1, 3);
        }
    }
}
