using Microsoft.VisualStudio.TestTools.UnitTesting;
using TennisSimulator;
using TennisSimulator.Helpers;
namespace TennisSimulatorTests
{
    [TestClass]
    public class MatchTests
    {
        [TestMethod]
        [Description("Simulate 50 tennis matches to test its suitably random")]
        public void MatchSimulation1()
        {
            SimulateMatch(50);
        }

        [TestMethod]
        [Description("Simulate 100000 tennis matches to test its suitably random")]
        public void MatchSimulation2()
        {
            SimulateMatch(100000);
        }

        private void SimulateMatch(int numberOfMatches)
        {
            int p1WinCount = 0;
            int p2WinCount = 0;

            var matchParams = new MatchParameters(3);

            for (int i = 0; i < numberOfMatches; i++)
            {
                var match = new Match(matchParams);
                string result = match.Play();

                char winner = result[7];

                Assert.IsTrue(winner == '1' || winner == '2');

                if (winner == '1') p1WinCount++;
                else p2WinCount++;
            }

            Assert.IsTrue(p1WinCount > 0);
            Assert.IsTrue(p2WinCount > 0);
        }
    }
}
