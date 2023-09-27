using PROG7312_POE_PART1.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
/*
 * ST10081932
 * Geoffrey Huth
 * PROG7312 Part 1
 */
namespace PROG7312_POE_PART1.UserControls
{
    public partial class mainMenu : UserControl
    {
        public mainMenu()
        {
            InitializeComponent();
            
        }
        /// <summary>
        /// sound affect for when the users mouse enters a components
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_OrderGame_MouseEnter(object sender, EventArgs e)
        {
            soundAffectManager(1);
        }

        #region Button Clicks
        /// <summary>
        /// takes user to the ordering game UC
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_OrderGame_Click(object sender, EventArgs e)
        {
            soundAffectManager(2);
            Toolbox.Instance.ParentForm.LoadOrderingGame();
        }
        /// <summary>
        /// Leaderboard UC
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Leaderboard_Click(object sender, EventArgs e)
        {
            soundAffectManager(2);
            Toolbox.Instance.ParentForm.LoadLeaderboard();
            Leaderboard leaderboard = new Leaderboard();
            leaderboard.loadLabels();
            leaderboard.loadLeaderboard();
        }
        //Achievements UC
        private void btn_Acheivements_Click(object sender, EventArgs e)
        {
            soundAffectManager(2);
            Toolbox.Instance.ParentForm.LoadAcheivementsPage();
        }
        #endregion
        /// <summary>
        /// plays different sound affects
        /// </summary>
        /// <param name="code"></param>
        private async void soundAffectManager(int code)
        {
            switch(code)
            {
                case 1:
                    await mediaPlayer.Instance.ButtonHoverSoundEffect();
                    break;
                case 2:
                    await mediaPlayer.Instance.ButtonClickSoundEffect();
                    break;
            }
        }
    }
}
