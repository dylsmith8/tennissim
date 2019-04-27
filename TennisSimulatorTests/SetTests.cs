using Microsoft.VisualStudio.TestTools.UnitTesting;
using TennisSimulator;
using TennisSimulatorTests.Helpers;

namespace TennisSimulatorTests
{
    [TestClass]
    public class SetTests
    {
        [TestMethod]
        [Description("Player 1 straight set win")]
        public void Player1WinsInStraightSets()
        {
            string setWinnerSequence = "11";
            MockMatchParameters mockParams = new MockMatchParameters(setWinnerSequence);

            var match = new Match(mockParams);
            var result = match.Play();

            Assert.AreEqual("Player 1 has won the match. Final score: 6-0, 6-0", result);
        }

        [TestMethod]
        [Description("Player 2 straight set win")]
        public void Player2StraightSetWin()
        {
            string setWinnerSequence = "22";
            MockMatchParameters mockParams = new MockMatchParameters(setWinnerSequence);

            var match = new Match(mockParams);
            var result = match.Play();

            Assert.AreEqual("Player 2 has won the match. Final score: 0-6, 0-6", result);
        }

        [TestMethod]
        [Description("Player 1 win: 6-0, 0-6, 6-0")]
        public void GoToThreeSets_Player1Win()
        {
            string setWinnerSequence = "121";
            MockMatchParameters mockParams = new MockMatchParameters(setWinnerSequence);

            var match = new Match(mockParams);
            var result = match.Play();

            Assert.AreEqual("Player 1 has won the match. Final score: 6-0, 0-6, 6-0", result);
        }

        [TestMethod]
        [Description("Player 2 win: 0-6, 6-0, 0-6")]
        public void GoToThreeSets_Player2Win()
        {
            string setWinnerSequence = "212";
            MockMatchParameters mockParams = new MockMatchParameters(setWinnerSequence);

            var match = new Match(mockParams);
            var result = match.Play();

            Assert.AreEqual("Player 2 has won the match. Final score: 0-6, 6-0, 0-6", result);
        }
    }
}
