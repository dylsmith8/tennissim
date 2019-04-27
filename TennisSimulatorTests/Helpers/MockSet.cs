using TennisSimulator.Helpers;

namespace TennisSimulatorTests.Helpers
{
    public class MockSet : ISet
    {
        public int Winner { get; private set; }
        public string SetResult { get; private set; }

        public MockSet(int winner) 
        {
            Winner = winner;

            if (Winner == 1) SetResult = string.Format("{0}-{1}", 6, 0);
            else if (Winner == 2) SetResult = string.Format("{0}-{1}", 0, 6);
        }

        public void UpdateWinCount(int playerId)
        {
            // do nothing.. never called from the mock
        }
    }
}
