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
        }

        public void loadMainMenu()
        {
            orderingGame1.Visible = false;
            leaderboard1.Visible = false;
            achievementPage1.Visible = false;
            mainMenu1.Visible = true;
        }

        public void loadOrderingGame()
        {
            mainMenu1.Visible=false;
            leaderboard1.Visible = false;
            achievementPage1.Visible = false;
            orderingGame1.Visible = true;
        }

        public void loadLeaderboard()
        {
            mainMenu1.Visible = false;
            orderingGame1.Visible = false;
            achievementPage1.Visible = false;
            leaderboard1.Visible = true;
        }

        public void loadAcheivementsPage()
        {
            mainMenu1.Visible = false;
            orderingGame1.Visible = false;
            leaderboard1.Visible = false;
            achievementPage1.Visible = true;
        }
    }
}
