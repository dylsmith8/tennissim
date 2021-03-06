﻿using System;
using TennisSimulator.Enums;

namespace TennisSimulator
{
    public class Score
    {
        public static PlayerScore Player1Score { get; private set; }
        public static PlayerScore Player2Score { get; private set; }

        public Score()
        {
            ResetScores();
        }

        public GameOutcome UpdateScore(int scorer)
        {
            if (scorer == 1)
                Player1Score = UpdateScore(Player1Score);
            else
                Player2Score = UpdateScore(Player2Score);

            Tuple<Enums.GameOutcome, int> roundResult = DetermineGameOutcome();

            GameOutcome outcome = null;
            if (roundResult != null && roundResult.Item1 == Enums.GameOutcome.Win)
            {
                outcome = new GameOutcome(roundResult.Item2);
                ResetScores();
            }

            return outcome;
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
                case PlayerScore.Adv:
                    playerScore = PlayerScore.Winner;
                    break;
            }

            return playerScore;
        }

        private Tuple<Enums.GameOutcome, int> DetermineGameOutcome()
        {
            if (Player1Score == PlayerScore.Forty && Player2Score == PlayerScore.Forty)
                return Tuple.Create(Enums.GameOutcome.Deuce, 0);

            // reset if both get advantage
            if (Player1Score == PlayerScore.Adv && Player2Score == PlayerScore.Adv)
            {
                Player1Score = PlayerScore.Forty; Player2Score = PlayerScore.Forty;
                return Tuple.Create(Enums.GameOutcome.Deuce, 0);
            }

            // handle case where a player has gone on to win the current game after having the advantage
            if (Player1Score == PlayerScore.Winner && Player2Score == PlayerScore.Forty)
                return Tuple.Create(Enums.GameOutcome.Win, 1);
            else if (Player2Score == PlayerScore.Winner && Player1Score == PlayerScore.Forty)
                return Tuple.Create(Enums.GameOutcome.Win, 1);

            if (Player1Score == PlayerScore.Adv || Player2Score == PlayerScore.Adv)
            {
                if (Math.Abs(Player1Score - Player2Score) >= 2)
                {
                    if (Player1Score > Player2Score)
                        return Tuple.Create(Enums.GameOutcome.Win, 1);
                    else
                        return Tuple.Create(Enums.GameOutcome.Win, 2);
                }
                else
                {
                    if (Player1Score > Player2Score)
                        return Tuple.Create(Enums.GameOutcome.Advantage, 1);
                    else
                        return Tuple.Create(Enums.GameOutcome.Advantage, 2);
                }
            }

            return Tuple.Create(Enums.GameOutcome.None, 0);
        }

        private void ResetScores()
        {
            Player1Score = PlayerScore.Love;
            Player2Score = PlayerScore.Love;
        }
    }
}
