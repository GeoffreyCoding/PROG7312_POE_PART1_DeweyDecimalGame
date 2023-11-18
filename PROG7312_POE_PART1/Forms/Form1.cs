using PROG7312_POE_PART1.Classes;
using PROG7312_POE_PART1.UserControls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PROG7312_POE_PART1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Toolbox.Instance.ParentForm = this.FindForm() as Form1;
            loadingScreen1.Visible = true;
        }

        #region methods that change the visibility of all the user controls
        public void LoadMainMenu()
        {
            orderingGame1.Visible = false;
            leaderboard1.Visible = false;
            achievementPage1.Visible = false;
            mainMenu1.Visible = true;
            findingCallNumbers1.Visible = false;
        }

        public void VisibleConfetti()
        {
            confetti1.BringToFront();
            confetti1.Visible = true;
        }

        public void VisibleLostGame()
        {
            loseGame1.BringToFront();
            loseGame1.Visible = true;
        }

        public void LoadOrderingGame()
        {
            mainMenu1.Visible = false;
            leaderboard1.Visible = false;
            achievementPage1.Visible = false;
            loadingScreen1.Dispose();
            matchingGame2.Visible = true;
            findingCallNumbers1.Visible = false;
        }

        public void LoadLeaderboard()
        {
            mainMenu1.Visible = false;
            orderingGame1.Visible = false;
            achievementPage1.Visible = false;
            leaderboard1.Visible = true;
            findingCallNumbers1.Visible = false;
        }

        public void LoadAcheivementsPage()
        {
            mainMenu1.Visible = false;
            orderingGame1.Visible = false;
            leaderboard1.Visible = false;
            achievementPage1.Visible = true;
            achievementPage1.LoadAchievments();
            findingCallNumbers1.Visible = false;
        }

        public void LoadMatchingGame()
        {
            mainMenu1.Visible = false;
            leaderboard1.Visible = false;
            achievementPage1.Visible = false;
            loadingScreen1.Dispose();
            matchingGame2.Visible = true;
            findingCallNumbers1.Visible = false;
        }

        public void LoadFindingCallNumbers()
        {
            loadingScreen1.Dispose();
            mainMenu1.Visible = false;
            leaderboard1.Visible = false;
            achievementPage1.Visible = false;
            matchingGame2.Visible = false;
            findingCallNumbers1.Visible = true;
        }

        #endregion

        /// <summary>
        /// ensures that all the user-controls are garbage collected to avoid memory leaks
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Dispose();
        }
    }
}
