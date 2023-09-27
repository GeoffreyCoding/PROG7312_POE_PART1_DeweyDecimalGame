using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace PROG7312_POE_PART1.UserControls
{
    public partial class Confetti : UserControl
    {
        private SolidBrush brush;
        private Bitmap confettiBitmap;
        private Graphics confettiGraphics;
        private List<Rectangle> confettiRects;
        private Timer confettiTimer;
        private Random random;

        public Confetti()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            this.BackColor = Color.Transparent;
        }

        private void initializeConfetti()
        {
            confettiBitmap = new Bitmap(pb_Confetti.Width, pb_Confetti.Height);
            confettiGraphics = Graphics.FromImage(confettiBitmap);
            brush = new SolidBrush(Color.Black);
            confettiTimer = new Timer();
            confettiTimer.Interval = 50;
            confettiTimer.Tick += ConfettiTimer_Tick;
            confettiTimer.Start();
        }

        private void fillConfettiList()
        {
            random = new Random();
            confettiRects = new List<Rectangle>();
            for (var i = 0; i < 100; i++) // 100 pieces of confetti, change the number as you like
            {
                var x = random.Next(Width);
                var y = random.Next(Height);
                confettiRects.Add(new Rectangle(x, y, 5, 5));
            }
        }

        private void ConfettiTimer_Tick(object sender, EventArgs e)
        {
            // Clear the graphics object for each frame
            confettiGraphics.Clear(Color.Transparent);
            for (var i = 0; i < confettiRects.Count; i++)
            {
                confettiRects[i] = new Rectangle(confettiRects[i].X, confettiRects[i].Y + 5, 5, 5);
                if (confettiRects[i].Y > Height) confettiRects[i] = new Rectangle(random.Next(Width), -5, 5, 5);
                // Change the brush color and draw the rectangle
                brush.Color = Color.FromArgb(random.Next(256), random.Next(256), random.Next(256));
                confettiGraphics.FillRectangle(brush, confettiRects[i]);
                bt_Close.BackColor = brush.Color;
                lb_YouWin.ForeColor = brush.Color;
            }

            if (confettiBitmap != null && pb_Confetti != null)
            {
                pb_Confetti.Image = confettiBitmap;
                // Force the PictureBox to repaint
                pb_Confetti.Invalidate();
            }
        }

        private void clearConfetti()
        {
            confettiTimer.Stop();
            confettiTimer = null;
            pb_Confetti.Invalidate();
        }

        private void Confetti_VisibleChanged(object sender, EventArgs e)
        {
            if (Visible)
            {
                fillConfettiList();
                initializeConfetti();
            }
            else if (confettiTimer != null)
            {
                if (confettiTimer.Enabled) clearConfetti();
            }
        }

        private void bt_Close_Click(object sender, EventArgs e)
        {
            clearConfetti();
            this.Visible = false;
        }
    }
}