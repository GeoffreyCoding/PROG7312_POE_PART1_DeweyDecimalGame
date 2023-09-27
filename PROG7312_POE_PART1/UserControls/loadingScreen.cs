using System;
using System.Drawing;
using System.Windows.Forms;

namespace PROG7312_POE_PART1.UserControls
{
    public partial class loadingScreen : UserControl
    {
        private int angle = 0;
        private Timer timerHideLoading; // New timer

        public loadingScreen()
        {
            InitializeComponent();

            // Initialize the loading animation timer
            timerLoading.Interval = 50;
            timerLoading.Start();

            // Initialize the new timer to hide the loading screen
            timerHideLoading = new Timer();
            timerHideLoading.Interval = 30000; //30 seconds
            timerHideLoading.Tick += new EventHandler(timerHideLoading_Tick);
            timerHideLoading.Start();
        }

        private void timerLoading_Tick(object sender, EventArgs e)
        {
            angle = (angle + 5) % 360;
            pictureBoxLoading.Invalidate();
            lb_Loading.Text += '.';
            if (lb_Loading.Text.Contains("..."))
            {
                lb_Loading.Text =  @"Loading";
            }
        }

        private void pictureBoxLoading_Paint(object sender, PaintEventArgs e)
        {
            int x = pictureBoxLoading.Width / 2;
            int y = pictureBoxLoading.Height / 2;
            int radius = 150;

            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            // Draw a circle
            e.Graphics.DrawEllipse(new Pen(Color.Black, 2), x - radius, y - radius, radius * 2, radius * 2);

            // Draw an arc
            e.Graphics.DrawArc(new Pen(Color.Red, 2), x - radius, y - radius, radius * 2, radius * 2, 0, angle);

            e = null;
        }

        private void timerHideLoading_Tick(object sender, EventArgs e)
        {
            this.Visible = false;  // Hide this control
            timerHideLoading.Stop(); // Stop this timer
            timerHideLoading = null;
        }
    }
}