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

        public MockMatchParameters(bool player1IsScorer, bool toggleScorer)
        {
            this._player1IsScorer = player1IsScorer;
            this._togglePlayers = toggleScorer;
        }

        public MockMatchParameters(string scoreSequence, bool useScoreSequence) : this(false, false)
        {
            _useScoreSequence = true;
            _scorerSequence = scoreSequence.ToCharArray().ToList();
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
                for (int i = 0; i < _scorerSequence.Count; i++)
                {
                    int toReturn = Convert.ToInt32(new string(_scorerSequence[i], 1));
                    _scorerSequence.RemoveAt(i);
                    return toReturn;
                }
            }

            return _player1IsScorer ? 1 : 2;
        }
    }
}
