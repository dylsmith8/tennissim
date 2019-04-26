using System;
using TennisSimulator.Helpers;

namespace TennisSimulatorTests.Helpers
{
    public class MockMatchParameters : IMatchParameters
    {
        public int GetRandomScorer()
        {
            throw new NotImplementedException();
        }
    }
}
