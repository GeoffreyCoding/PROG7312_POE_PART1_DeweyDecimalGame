using PROG7312_POE_PART1.Classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace PROG7312_POE_PART1.UserControls
{
    public partial class orderingGame : UserControl
    {
        /// <summary>
        /// dictionary which holds the original locations of all the panels with the "draggable" tag allocated to them
        /// This was found on stack overflow
        /// </summary>
        private Dictionary<Panel, Point> originalLocations = new Dictionary<Panel, Point>();
        private bool isDragging = false;
        private Panel activePanel = null;
        /// <summary>
        /// Simple list that holds the data of all the panels with the "target" tags allocated with them
        /// This was given by ChatGPT
        /// </summary>
        private List<Panel> targetPanels;
        private int elapsedTimeInSeconds = 0;

        public orderingGame()
        {
            InitializeComponent();
            InitializeTimer();
            this.Load += orderingGame_Load;
        }
        /// <summary>
        /// 
        /// </summary>
        private void orderingGame_Load(object sender, EventArgs e)
        {
            //finds all the panels with the "target" tag using a LinQ operation and puts in a list
            targetPanels = this.Controls.OfType<Panel>().Where(p => p.Tag != null && p.Tag.ToString() == "target").ToList();
            foreach (Panel panel in this.Controls.OfType<Panel>().Where(p => p.Tag != null && p.Tag.ToString() == "draggable"))
            {
                originalLocations[panel] = panel.Location;
                panel.MouseDown += GenericPanel_MouseDown;
                panel.MouseMove += GenericPanel_MouseMove;
                panel.MouseUp += GenericPanel_MouseUp;
            }
        }
        /// <summary>
        /// activates when a specific panel is chosen and then allows it to be moved
        /// </summary>
        private void GenericPanel_MouseDown(object sender, MouseEventArgs e)
        {
            mediaPlayer.Instance.gameClickSoundAffect();
            activePanel = sender as Panel;
            isDragging = true;
        }
        /// <summary>
        /// control the movement of the panel being dragged
        /// I did get help with this from a post on StackOverflow
        /// </summary>
        private void GenericPanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDragging && activePanel != null)
            {
                activePanel.Left = e.X + activePanel.Left - originalLocations[activePanel].X;
                activePanel.Top = e.Y + activePanel.Top - originalLocations[activePanel].Y;
            }
        }
        /// <summary>
        /// when the use lets go of the left-click button, it changes the image and text of the targetted panel
        /// </summary>
        private void GenericPanel_MouseUp(object sender, MouseEventArgs e)
        {
            isDragging = false;
            mediaPlayer.Instance.gameClickSoundAffect();
            foreach (Panel targetPanel in targetPanels)
            {
                if (activePanel.Bounds.IntersectsWith(targetPanel.Bounds))
                {
                    targetPanel.BackgroundImage = activePanel.BackgroundImage;
                    // Find the labels on bottom panels
                    Label draggedPanelLabel = activePanel.Controls.OfType<Label>().FirstOrDefault();
                    // Find the labeels on the top panels
                    Label targetPanelLabel = targetPanel.Controls.OfType<Label>().FirstOrDefault();
                    // Update the text on the target panel's label
                    if (draggedPanelLabel != null && targetPanelLabel != null)
                    {
                        targetPanelLabel.Text = draggedPanelLabel.Text;
                    }
                    break;
                }
            }
            // Return to the original fixed position
            activePanel.Location = originalLocations[activePanel];
            activePanel = null;
        }
        /// <summary>
        /// when the users mouse hovers over any button, the method from mediaPlayer class is called and the 
        /// </summary>
        private void btn_OrderGame_MouseHover(object sender, EventArgs e)
        {
            mediaPlayer.Instance.buttonHoverSoundAffect();
        }
        /// <summary>
        /// 
        /// </summary>
        private void btn_OrderGame_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            mediaPlayer.Instance.buttonClickSoundAffect();
            Toolbox.Instance.ParentForm.loadMainMenu();
        }
        /// <summary>
        /// 
        /// </summary>
        private void btn_StartGame_Click(object sender, EventArgs e)
        {
            mediaPlayer.Instance.buttonClickSoundAffect();
            elapsedTimeInSeconds = 0; // Reset the elapsed time
            timer1.Start(); // Start the timer
        }
        /// <summary>
        /// 
        /// </summary>
        private void Timer1_Tick(object sender, EventArgs e)
        {
            elapsedTimeInSeconds++;
            TimeSpan time = TimeSpan.FromSeconds(elapsedTimeInSeconds);
            lb_GameTime.Text = time.ToString(@"hh\:mm\:ss"); // Format it as hh:mm:ss
        }
        /// <summary>
        /// 
        /// </summary>
        private void InitializeTimer()
        {
            timer1.Interval = 1000; // Set the interval to 1 second
            timer1.Tick += Timer1_Tick; // Subscribe to the Tick event
        }
    }
}
