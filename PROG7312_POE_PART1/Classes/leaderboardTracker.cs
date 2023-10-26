using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
 * ST10081932
 * Geoffrey Huth
 * PROG7312 Part 1
 */
namespace PROG7312_POE_PART1.Classes
{
    internal class leaderboardTracker
    {
        /// <summary>
        /// holds the singleton instance of the leaderboardTracker Class
        /// </summary>
        private static readonly leaderboardTracker instance = new leaderboardTracker();
        /// <summary>
        /// getting the instance of the leaderboardTracker class
        /// </summary>
        public static leaderboardTracker Instance => instance;
        private string matchingGameHighestScore;
        public string MatchingGameHighestScore
        {
            get => matchingGameHighestScore;
            set => matchingGameHighestScore = value;
        }
        /// <summary>
        /// holds the users highest score that they ever achieved in the ordering game
        /// </summary>
        private string orderingGameHighestScore;

        /// <summary>
        /// holds the top 5 scores that the user has ever been able to Achieve
        /// </summary>
        private string[] orderingGameScoresArray = new string[5];
        /// <summary>
        /// getter and setter for the lowest score. This format was recommended by ReSharpe
        /// </summary>
        public string HighestScore
        {
            get => orderingGameHighestScore;
            set => orderingGameHighestScore = value;
        }
        /// <summary>
        /// setter for the scores array
        /// </summary>
        public string[] ScoresArray => orderingGameScoresArray;

        #region Holds methods to add a users score to the scores array and replace their highest score
        /// <summary>
        /// finds the lowest score in the scores array and replaces that score with the new score the user has achieved if the new score
        /// is higher than the old score
        /// </summary>
        /// <param name="score"></param>
        public void AddToScoresArray(string score)
        {
            var temp = Array.IndexOf(orderingGameScoresArray, null);
            if (orderingGameScoresArray[0] == null) 
                orderingGameScoresArray[0] = score;
            else if (temp != -1)
            {
                orderingGameScoresArray[temp] = score;
            }
            else orderingGameScoresArray[Array.IndexOf(orderingGameScoresArray, orderingGameScoresArray.Max())] = score;
        }
        /// <summary>
        /// simple checks if the new score is higher than the currently stored highest score
        /// </summary>
        /// <param name="score"></param>
        /// <returns></returns>
        public bool replaceOrderingGameHighestScore(string score)
        {
            //if the user has already played the game
            if (orderingGameHighestScore == null)
            {
                orderingGameHighestScore = score;
                return true;
            }
            //checking if the old score is higher than the new score
            else if (int.Parse(orderingGameHighestScore) > int.Parse(score))
            {
                orderingGameHighestScore = score;
                return true;
            }
            return false;
        }

        public bool replaceMatchingGameHighestScore(string score)
        {
            //if the user has already played the game
            if (MatchingGameHighestScore == null)
            {
                MatchingGameHighestScore = score;
                return true;
            }
            //checking if the old score is higher than the new score
            else if (int.Parse(MatchingGameHighestScore) > int.Parse(score))
            {
                MatchingGameHighestScore = score;
                return true;
            }
            return false;
        }

            /// <summary>
            /// converts the users score back into a time variant "00:00:00"
            /// </summary>
            /// <param name="score"></param>
            /// <returns></returns>
            public string scoreToTime(string score)
        {
            if (score != null)
            {
                TimeSpan timeSpan = TimeSpan.ParseExact(score, "hhmmss", CultureInfo.InvariantCulture);
                string formattedTime = timeSpan.ToString(@"hh\:mm\:ss");
                return formattedTime;
            }

            return "";
        }
        /// <summary>
        /// controller method that gets sent the current score of the user when they win the game. It wil then convert the score
        /// into a 000000 format and send it to the addscore method and replacehighest score method respectively.
        /// </summary>
        /// <param name="currentScore"></param>
        public void setScoreForLeaderboard(string currentScore)
        {
            string[] trueScore = currentScore.Split(':');
            currentScore = trueScore[0] + trueScore[1] + trueScore[2];
            leaderboardTracker.Instance.AddToScoresArray(currentScore);
            leaderboardTracker.Instance.replaceOrderingGameHighestScore(currentScore);

        }
        #endregion
    }
}
