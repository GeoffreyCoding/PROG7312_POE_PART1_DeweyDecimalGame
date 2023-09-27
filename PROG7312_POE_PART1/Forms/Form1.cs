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
        }

        public void VisibleConfetti()
        {
            confetti1.BringToFront();
            confetti1.Visible = true;
        }

        public void LoadOrderingGame()
        {
            mainMenu1.Visible = false;
            leaderboard1.Visible = false;
            achievementPage1.Visible = false;
            loadingScreen1.Dispose();
            orderingGame1.Visible = true;
        }

        public void LoadLeaderboard()
        {
            mainMenu1.Visible = false;
            orderingGame1.Visible = false;
            achievementPage1.Visible = false;
            leaderboard1.Visible = true;
        }

        public void LoadAcheivementsPage()
        {
            mainMenu1.Visible = false;
            orderingGame1.Visible = false;
            leaderboard1.Visible = false;
            achievementPage1.Visible = true;
            achievementPage1.LoadAchievments();
        }

        #endregion

        /// <summary>
        /// ensures that all the user-controls are garbage collected to avoid memory leaks
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            orderingGame1.Dispose();
            achievementPage1.Dispose();
            mainMenu1.Dispose();
            leaderboard1.Dispose();
        }
    }
}
