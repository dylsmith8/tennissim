using System;
using TennisSimulator.Enums;

namespace TennisSimulator
{
    public class Score
    {
        public static PlayerScore Player1Score { get; private set; }
        public static PlayerScore Player2Score { get; private set; }

        public Score()
        {
            Player1Score = PlayerScore.Love;
            Player2Score = PlayerScore.Love;
        }

        public Tuple<GameOutcome, Outcome> UpdateScore(int scorer)
        {
            if (scorer == 1)
                Player1Score = UpdateScore(Player1Score);
            else
                Player2Score = UpdateScore(Player2Score);

            Tuple<GameOutcome, int> roundResult = DetermineGameOutcome();

            Outcome outcome = null;
            if (roundResult != null && roundResult.Item1 == GameOutcome.Win)
                outcome = new Outcome(roundResult.Item2, string.Format("Player 1: {0}. Player 2: {1}", Player1Score, Player2Score));

            return Tuple.Create(roundResult.Item1, outcome);
        }

        private PlayerScore UpdateScore(PlayerScore currentScore)
        {
            PlayerScore playerScore = PlayerScore.None;

            switch (currentScore)
            {
                case PlayerScore.Love:
                    playerScore = PlayerScore.Fifteen;
                    break;
                case PlayerScore.Fifteen:
                    playerScore = PlayerScore.Thirty;
                    break;
                case PlayerScore.Thirty:
                    playerScore = PlayerScore.Forty;
                    break;
                case PlayerScore.Forty:
                    playerScore = PlayerScore.Adv;
                    break;
            }

            return playerScore;
        }

        private Tuple<GameOutcome, int> DetermineGameOutcome()
        {
            if (Player1Score == PlayerScore.Forty && Player2Score == PlayerScore.Forty)
                return Tuple.Create(GameOutcome.Deuce, 0);

            if (Player1Score == PlayerScore.Adv || Player2Score == PlayerScore.Adv)
            {
                if (Math.Abs(Player1Score - Player2Score) >= 2)
                {
                    if (Player1Score > Player2Score)
                        return Tuple.Create(GameOutcome.Win, 1);
                    else
                        return Tuple.Create(GameOutcome.Win, 2);
                }
                else
                {
                    if (Player1Score > Player2Score)
                        return Tuple.Create(GameOutcome.Advantage, 1);
                    else
                        return Tuple.Create(GameOutcome.Advantage, 2);
                }
            }

            return Tuple.Create(GameOutcome.None, 0);
        }
    }
}
