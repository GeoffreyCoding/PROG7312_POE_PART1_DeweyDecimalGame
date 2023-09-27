using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        /// <summary>
        /// holds the users highest score that they ever achieved in the ordering game
        /// </summary>
        private string highestScore;
        /// <summary>
        /// holds the top 5 scores that the user has ever been able to Achieve
        /// </summary>
        private string[] scoresArray = new string[5];
        /// <summary>
        /// getter and setter for the lowest score. This format was recommended by ReSharpe
        /// </summary>
        public string HighestScore
        {
            get => highestScore;
            set => highestScore = value;
        }
        /// <summary>
        /// setter for the scores array
        /// </summary>
        public string[] ScoresArray => scoresArray;

        #region Holds methods to add a users score to the scores array and replace their highest score
        /// <summary>
        /// finds the lowest score in the scores array and replaces that score with the new score the user has achieved if the new score
        /// is higher than the old score
        /// </summary>
        /// <param name="score"></param>
        public void AddToScoresArray(string score)
        {
            var temp = Array.IndexOf(scoresArray, null);
            if (scoresArray[0] == null) 
                scoresArray[0] = score;
            else if (temp != -1)
            {
                scoresArray[temp] = score;
            }
            else scoresArray[Array.IndexOf(scoresArray, scoresArray.Max())] = score;
        }
        /// <summary>
        /// simple checks if the new score is higher than the currently stored highest score
        /// </summary>
        /// <param name="score"></param>
        /// <returns></returns>
        public bool replaceHighestScore(string score)
        {
            //if the user has already played the game
            if (highestScore == null)
            {
                highestScore = score;
                return true;
            }
            //checking if the old score is higher than the new score
            else if (int.Parse(highestScore) > int.Parse(score))
            {
                highestScore = score;
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
            leaderboardTracker.Instance.replaceHighestScore(currentScore);

        }
        #endregion
    }
}
