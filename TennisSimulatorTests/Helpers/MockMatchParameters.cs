using System;
using System.Collections.Generic;
using System.Linq;
using TennisSimulator.Helpers;

namespace TennisSimulatorTests.Helpers
{
    public class MockMatchParameters : IMatchParameters
    {
        private bool _player1IsScorer;
        private bool _togglePlayers;

        private int togglecount = 0;

        private bool _useScoreSequence;
        private List<char> _scorerSequence;

        private List<char> _setWinningSequence;

        public MockMatchParameters(bool player1IsScorer, bool toggleScorer)
        {
            _player1IsScorer = player1IsScorer;
            _togglePlayers = toggleScorer;
        }

        public MockMatchParameters(string scoreSequence, bool useScoreSequence) : this(false, false)
        {
            _useScoreSequence = true;
            _scorerSequence = scoreSequence.ToCharArray().ToList();
        }

        public MockMatchParameters(string setWinningSequence)
        {
            _setWinningSequence = setWinningSequence.ToCharArray().ToList();
        }

        public int GetRandomScorer()
        {
            if (_togglePlayers)
            {
                togglecount++;
                if (togglecount < 10)
                    _player1IsScorer = !_player1IsScorer;
                else _togglePlayers = false;
            }

            if (_useScoreSequence)
            {
                for (int i = 0; i < _scorerSequence.Count;)
                {
                    int toReturn = Convert.ToInt32(new string(_scorerSequence[i], 1));
                    _scorerSequence.RemoveAt(i);
                    return toReturn;
                }
            }

            return _player1IsScorer ? 1 : 2;
        }

        public List<ISet> InitialiseMatchSets()
        {
            List<ISet> mockSets = new List<ISet>();
            foreach (char winner in _setWinningSequence)
                mockSets.Add(new MockSet(Convert.ToInt32(new string(winner, 1))));

            return mockSets;
        }
    }
}
