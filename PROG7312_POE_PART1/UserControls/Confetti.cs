using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
/*
 * ST10081932
 * Geoffrey Huth
 * PROG7312 Part 1
 */
namespace PROG7312_POE_PART1.UserControls
{
    public partial class Confetti : UserControl
    {
        //brush used to apply the colours to the confetti
        private SolidBrush brush;
        //bitmap used to store the confetti
        private Bitmap confettiBitmap;
        //graphics used to generate/fill the picture box with the confetti
        private Graphics confettiGraphics;
        //list that stores all the confetti particles
        private List<Rectangle> confettiRects;
        //timer used to control the confetti
        private Timer confettiTimer;
        //random used to generate the colours of the confetti
        private Random random;
        //constructore
        public Confetti()
        {
            InitializeComponent();
        }

        #region Confetti Main Methods
        /// <summary>
        /// initializes the confetti objects and variables such as the timer and the bitmap/graphics and brush. It will then start the confetti timer
        /// </summary>
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
        /// <summary>
        /// Fills the list with all the confetti rectangles
        /// </summary>
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
        /// <summary>
        /// confetti controller which adds the confetti to the pb adn then moves all the confetti downwards. The colours of the confetti
        /// is already randomly assigned here
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
        /// <summary>
        /// stops the confetti time and get rid of all the confetti on the screen
        /// </summary>
        private void clearConfetti()
        {
            confettiTimer.Stop();
            confettiTimer = null;
            pb_Confetti.Invalidate();
        }
        #endregion
        /// <summary>
        /// detects a changes in the user controls visibility, thus starting the confetti generation
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        #region button clicks
        private void bt_Close_Click(object sender, EventArgs e)
        {
            clearConfetti();
            this.Visible = false;
        }
        #endregion

    }
}