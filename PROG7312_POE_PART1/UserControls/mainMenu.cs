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
            mediaPlayer.Instance.buttonHoverSoundAffect();
        }

        private void btn_OrderGame_Click(object sender, EventArgs e)
        {
            mediaPlayer.Instance.buttonClickSoundAffect();
            Toolbox.Instance.ParentForm.loadOrderingGame();
        }

        private void btn_MatchColumns_Click(object sender, EventArgs e)
        {
            mediaPlayer.Instance.buttonClickSoundAffect();
        }

        private void btn_FindCallNumbers_Click(object sender, EventArgs e)
        {
            mediaPlayer.Instance.buttonClickSoundAffect();
        }

        private void btn_Leaderboard_Click(object sender, EventArgs e)
        {
            mediaPlayer.Instance.buttonClickSoundAffect();
            Toolbox.Instance.ParentForm.loadLeaderboard();
        }
    }
}
