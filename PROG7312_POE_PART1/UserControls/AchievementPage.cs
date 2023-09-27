using PROG7312_POE_PART1.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PROG7312_POE_PART1.UserControls
{
    public partial class AchievementPage : UserControl
    {
        public AchievementPage()
        {
            InitializeComponent();
        }
        /// <summary>
        /// makes the mainmenu user control visible
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        #region Button event handlers
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
        /// uses the users current score which is stored in the leaderboardTracker to reveal different achievements
        /// </summary>
        public void LoadAchievments()
        {
            try
            {
                var currentScore = int.Parse(leaderboardTracker.Instance.HighestScore);
                if (currentScore > 0)
                {
                    if (currentScore >= 61)
                    {
                        pb_Achievement4.Visible = true;
                    }

                    if (currentScore >= 41)
                    { 
                        pb_Achievement3.Visible = true;
                    }
                        

                    if (currentScore >= 21)
                    {
                        pb_Achievement2.Visible = true;
                    }

                    if (currentScore < 20)
                    {
                        pb_Achievement1.Visible = true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }
    }
}
