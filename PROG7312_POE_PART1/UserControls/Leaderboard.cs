﻿using PROG7312_POE_PART1.Classes;
using System;
using System.Linq;
using System.Windows.Forms;
/*
 * ST10081932
 * Geoffrey Huth
 * PROG7312 Part 1
 */
namespace PROG7312_POE_PART1.UserControls
{
    public partial class Leaderboard : UserControl
    {
        /// <summary>
        /// array holding the labels that show the users score
        /// </summary>
        private Label[] scoreLabels = new Label[5];
        /// <summary>
        /// parallel array holding the labels that show the users time associated to each score
        /// </summary>
        private Label[] timeLabels = new Label[5];
        public Leaderboard()
        {
            InitializeComponent();
        }

        #region Button Clicks
        private void btn_BackToMenu_Click(object sender, EventArgs e)
        {
            mediaPlayer.Instance.ButtonClickSoundEffect();
            Toolbox.Instance.ParentForm.LoadMainMenu();
        }

        private void btn_BackToMenu_MouseEnter(object sender, EventArgs e)
        {
            mediaPlayer.Instance.ButtonHoverSoundEffect();
        }

        #endregion

        /// <summary>
        /// loads all the score and time labels into parralel arrays
        /// </summary>
        public void loadLabels()
        {
            //score labels
            scoreLabels[0] = lb_Score1;
            scoreLabels[1] = lb_Score2;
            scoreLabels[2] = lb_Score3;
            scoreLabels[3] = lb_Score4;
            scoreLabels[4] = lb_Score6;
            //time labels
            timeLabels[0] = lb_Time1;
            timeLabels[1] = lb_Time2;
            timeLabels[2] = lb_Time3;
            timeLabels[3] = lb_Time4;
            timeLabels[4] = lb_Time5;
        }
        /// <summary>
        /// loads all the currently stored top 5 scores and times on the labels 
        /// </summary>
        public void loadLeaderboard()
        {
            string[] ScoreArray = leaderboardTracker.Instance.ScoresArray;
            if (ScoreArray != null && ScoreArray.Count() > 0)
            {
                int counter = 0;
                foreach (Label label in scoreLabels)
                {
                    label.Text = ScoreArray[counter];
                    counter++;
                }
                counter = 0;
                foreach (Label label in timeLabels)
                {
                    var temp = ScoreArray[counter];
                    temp = leaderboardTracker.Instance.scoreToTime(temp);
                    label.Text = temp;
                    counter++;
                }
            }
        }
        /// <summary>
        /// detects when the visibility of the user-control changes and then updates the labels
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Leaderboard_VisibleChanged(object sender, EventArgs e)
        {
            loadLabels();
            loadLeaderboard();
        }
    }
}
