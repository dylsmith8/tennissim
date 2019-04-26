using TennisSimulatorTests.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TennisSimulator;
using System;

namespace TennisSimulatorTests
{
    [TestClass]
    public class RallyTests
    {
        [TestMethod]
        [Description("Only player 1 scores points till victory")]
        public void Player1Wins()
        {
            MockMatchParameters mockParams = new MockMatchParameters(true, false); // player one scores first

            var game = new Game();
            string result = game.Play(mockParams);

            Assert.AreEqual("Player 1 has won the game.\n Player 1: Adv. Player 2: Love", result);
        }
    
        [TestMethod]
        [Description("Only player 2 scores points till victory")]
        public void Player2Wins()
        {
            MockMatchParameters mockParams = new MockMatchParameters(false, false); // player one scores first

            var game = new Game();
            string result = game.Play(mockParams);

            Assert.AreEqual("Player 2 has won the game.\n Player 1: Love. Player 2: Adv", result);
        }

        [TestMethod]
        [Description("Game played up till deuece - player 1 then wins after advantage")]
        public void Deuce()
        {
            MockMatchParameters mockParams = new MockMatchParameters(true, true); // player one scores first

            var game = new Game();
            string result = game.Play(mockParams);
            Assert.AreEqual("Player 1 has won the game.\n Player 1: Forty. Player 2: Winner", result);
        }

        [TestMethod]
        [Description("Reasonable test 1")]
        public void ReasonableTest1()
        {
            string scoreSequence = "11211"; // 15 30 15 40 Player 1 wins

            MockMatchParameters mockParams = new MockMatchParameters(scoreSequence, true); // player one scores first
            var game = new Game();

            string result = game.Play(mockParams);
            Assert.AreEqual("Player 1 has won the game.\n Player 1: Adv. Player 2: Fifteen", result);
        }

        [TestMethod]
        [Description("Invalid scorer passed in")]
        public void InvalidScorer()
        {
            try
            {
                string bogusScorer = "0";
                MockMatchParameters mockParams = new MockMatchParameters(bogusScorer, true); // player one scores first
                var game = new Game();

                game.Play(mockParams);

                Assert.Fail("Should have failed with an InvalidOperationException 'Invalid scorer.'");
            }
            catch (InvalidOperationException e)
            {
                // Should get here and swallow
                Assert.AreEqual("Invalid scorer.", e.Message);
            }
        }
    }
}
