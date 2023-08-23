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
    public partial class Leaderboard : UserControl
    {
        public Leaderboard()
        {
            InitializeComponent();
        }

        private void btn_BackToMenu_Click(object sender, EventArgs e)
        {
            mediaPlayer.Instance.buttonClickSoundAffect();
            Toolbox.Instance.ParentForm.loadMainMenu();
        }

        private void btn_BackToMenu_MouseEnter(object sender, EventArgs e)
        {
            mediaPlayer.Instance.buttonHoverSoundAffect();
        }
    }
}
