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
    public partial class loseGame : UserControl
    {
        private SolidBrush brush;
        private Bitmap ashBitmap;
        private Graphics ashGraphics;
        private List<Rectangle> ashRects;
        private Random random;

        public loseGame()
        {
            InitializeComponent();
        }

        private void InitializeAsh()
        {
            var temp = leaderboardTracker.Instance.FindingNumberGameHighestScore;
            if (temp != null)
            {
                var splitTemp = temp.Split(';');
                lb_Score.Text = "Score to beat || Right : " + temp[0] + "| Wrong : " + temp[1];
            }
            ashBitmap = new Bitmap(pb_LoseGame.Width, pb_LoseGame.Height);
            ashGraphics = Graphics.FromImage(ashBitmap);
            brush = new SolidBrush(System.Drawing.Color.DimGray); // Ash-like color
            ashTimer = new Timer();
            ashTimer.Interval = 50;
            ashTimer.Tick += AshTimer_Tick;
            ashTimer.Start();
        }

        private void FillAshList()
        {
            random = new Random();
            ashRects = new List<Rectangle>();
            for (var i = 0; i < 100; i++)
            {
                var x = random.Next(Width);
                var y = random.Next(Height);
                ashRects.Add(new Rectangle(x, y, 3, 3)); // Smaller particles for ash
            }
        }

        private void AshTimer_Tick(object sender, EventArgs e)
        {
            ashGraphics.Clear(System.Drawing.Color.Transparent);
            for (var i = 0; i < ashRects.Count; i++)
            {
                ashRects[i] = new Rectangle(ashRects[i].X, ashRects[i].Y + 2, 3, 3); // Slower fall for ash
                if (ashRects[i].Y > Height) ashRects[i] = new Rectangle(random.Next(Width), -5, 3, 3);

                ashGraphics.FillRectangle(brush, ashRects[i]);
            }

            if (ashBitmap != null && pb_LoseGame != null)
            {
                pb_LoseGame.Image = ashBitmap;
                pb_LoseGame.Invalidate();
            }
        }

        private void ClearAsh()
        {
            ashTimer.Stop();
            ashTimer = null;
            pb_LoseGame.Invalidate();
        }

        private void AshFall_VisibleChanged(object sender, EventArgs e)
        {
            if (Visible)
            {
                FillAshList();
                InitializeAsh();
            }
            else if (ashTimer != null)
            {
                if (ashTimer.Enabled) ClearAsh();
            }
        }

        private void bt_Close_Click(object sender, EventArgs e)
        {
            ClearAsh();
            this.Visible = false;
        }
    }
}
