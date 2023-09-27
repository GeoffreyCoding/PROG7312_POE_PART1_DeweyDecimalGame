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

namespace PROG7312_POE_PART1.UserControls
{
    public partial class mainMenu : UserControl
    {
        public mainMenu()
        {
            InitializeComponent();
            
        }
        
        private void btn_OrderGame_MouseEnter(object sender, EventArgs e)
        {
            soundAffectManager(1);
        }

        private void btn_OrderGame_Click(object sender, EventArgs e)
        {
            soundAffectManager(2);
            Toolbox.Instance.ParentForm.LoadOrderingGame();
        }

        private void btn_MatchColumns_Click(object sender, EventArgs e)
        {
            
        }

        private void btn_FindCallNumbers_Click(object sender, EventArgs e)
        {

        }

        private void btn_Leaderboard_Click(object sender, EventArgs e)
        {
            soundAffectManager(2);
            Toolbox.Instance.ParentForm.LoadLeaderboard();
            Leaderboard leaderboard = new Leaderboard();
            leaderboard.loadLabels();
            leaderboard.loadLeaderboard();
        }

        private void btn_Acheivements_Click(object sender, EventArgs e)
        {
            soundAffectManager(2);
            Toolbox.Instance.ParentForm.LoadAcheivementsPage();
        }

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
