using System;
using TennisSimulator.Helpers;

namespace TennisSimulator
{
    public class Set : ISet
    {
        private int _player1WinCount;
        private int _player2WinCount;
        private const int MIN_WIN_COUNT = 6;   

        public int Winner { get; private set; }
        public string SetResult { get; private set; }
        
        public Set(int player1WinCount, int player2WinCount)
        {
            _player1WinCount = player1WinCount;
            _player2WinCount = player2WinCount;
            Winner = 0;
        }

        public void UpdateWinCount(int playerId)
        {
            if (playerId == 1)
                _player1WinCount++;
            else if (playerId == 2)
                _player2WinCount++;
            else
                throw new InvalidOperationException("Could not update win count of an invalid player.");

            DetermineSetWinner();
        }

        private void DetermineSetWinner()
        {
            if (_player1WinCount >= MIN_WIN_COUNT || _player2WinCount >= MIN_WIN_COUNT)
            {
                if (Math.Abs(_player1WinCount - _player2WinCount) >= 2)
                {
                    if (_player1WinCount > _player2WinCount)
                    {
                        Winner = 1;
                        SetResult = string.Format("{0}-{1}", _player1WinCount, _player2WinCount);
                    }
                    else
                    {
                        Winner = 2;
                        SetResult = string.Format("{0}-{1}", _player1WinCount, _player2WinCount);
                    }
                }
            }
        }
    }
}
