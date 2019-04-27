using System;
using System.Collections.Generic;

namespace TennisSimulator.Helpers
{
    public class MatchParameters : IMatchParameters
    {
        private readonly Random _rng;
        private readonly int _setCount;
        public MatchParameters(int setCount)
        {
            _rng = new Random();
            _setCount = setCount;
        }

        public int GetRandomScorer()
        {
            return _rng.Next(1, 3);
        }

        public List<ISet> InitialiseMatchSets()
        {
            List<ISet> sets = new List<ISet>(_setCount);

            for (int i = 0; i < _setCount; i++)
                sets.Add(new Set(0, 0));

            return sets;
        }
    }
}
