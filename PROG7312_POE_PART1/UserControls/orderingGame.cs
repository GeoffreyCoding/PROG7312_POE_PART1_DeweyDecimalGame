using PROG7312_POE_PART1.Classes;
using System;
using System.Collections.Generic;
using System.Diagnostics;  // Added for Stopwatch
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
        private readonly Dictionary<Panel, Point> originalLocations = new Dictionary<Panel, Point>();  // Made readonly
        private bool isDragging = false;
        private Panel activePanel = null;
        /// <summary>
        /// Simple list that holds the data of all the panels with the "target" tags allocated with them
        /// This was given by ChatGPT
        /// </summary>
        private readonly List<Panel> targetPanels;
        private readonly List<Panel> draggablePanels;
        private readonly Stopwatch stopwatch = new Stopwatch();
        /// <summary>
        /// variable controlling wether the game has been started or not
        /// </summary>
        private bool gameStart = false;
        private Point lastUpdatePoint = Point.Empty;
        private string[] callNumbers;
        private List<Panel> alreadyOrderedBooks = new List<Panel>();
        private Point mouseOffset; // Add this as a class-level variable
        /// <summary>
        /// 
        /// </summary>
        public orderingGame()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            // Stored the LINQ query results into a List to prevent redundancy
            targetPanels = this.Controls.OfType<Panel>().Where(p => p.Tag?.ToString() == "target").OrderBy(p => p.Name).ToList();
            draggablePanels = this.Controls.OfType<Panel>().Where(p => p.Tag?.ToString() == "draggable").OrderBy(p => p.Name).ToList();
            InitializeTimer();
            this.Load += orderingGame_Load;
            loadCallNumbers();
            callNumbers = callNumberObject.Instance.DeweyDecimals;
            Array.Sort(callNumbers);
        }
        /// <summary>
        /// 
        /// </summary>
        private async void loadCallNumbers()
        {
            var callNumbers = await Toolbox.Instance.GenerateUniqueDeweyDecimal();
            callNumberObject.Instance.DeweyDecimals = callNumbers;
            for (int i = 0; i < draggablePanels.Count; i++)
            {
                if (draggablePanels[i].Controls.OfType<Label>().FirstOrDefault() is Label label)
                {
                    label.Text = callNumbers[i].ToString();
                }
            }
        }
        /// <summary>
        /// 
        /// </summary>
        private void orderingGame_Load(object sender, EventArgs e)
        {
            foreach (var panel in draggablePanels)
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
            if (gameStart == true)
            {
                mediaPlayer.Instance.gameClickSoundAffect();
                activePanel = sender as Panel;
                isDragging = true;
                // Capture the mouse position at the time of the mouse down event
                mouseOffset = new Point(e.X, e.Y);
            }
            else
            {
                mediaPlayer.Instance.errorSoundAffect();
                MessageBox.Show(@"Please press start game to begin! ");
            }
        }
        /// <summary>
        /// control the movement of the panel being dragged
        /// I did get help with this from a post on StackOverflow
        /// </summary>
        private void GenericPanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDragging && activePanel != null && gameStart == true)
            {
                this.SuspendLayout();  // Temporarily pause layout logic

                // Calculate the new position based on the mouse's current position minus the offset
                int x = e.X + activePanel.Left - mouseOffset.X;
                int y = e.Y + activePanel.Top - mouseOffset.Y;

                // Update the panel's position
                activePanel.Location = new Point(x, y);
                activePanel.Invalidate();  // Force a repaint of the panel
                this.ResumeLayout();  // Resume layout logic
            }
       }
        /// <summary>
        /// when the use lets go of the left-click button, it changes the image and text of the targetted panel
        /// </summary>
        private void GenericPanel_MouseUp(object sender, MouseEventArgs e)
        {
            try{
                this.SuspendLayout();
                isDragging = false;
                Label draggedPanelLabel = null;
                Label targetPanelLabel = null;
                // Store repeated calls in local variables
                mediaPlayer.Instance.gameClickSoundAffect();
                Rectangle activePanelBounds = activePanel.Bounds;
                Point originalLocation = originalLocations[activePanel];
                Panel matchedTargetPanel = null;
                foreach (var targetPanel in targetPanels)
                {
                    if (activePanelBounds.IntersectsWith(targetPanel.Bounds))
                    {
                        // Store label of active panel and target panel in local variables
                        draggedPanelLabel = activePanel.Controls.OfType<Label>().FirstOrDefault();
                        targetPanelLabel = targetPanel.Controls.OfType<Label>().FirstOrDefault();

                        if (draggedPanelLabel != null && targetPanelLabel != null && !alreadyOrderedBooks.Contains(targetPanel))
                        {
                            targetPanel.BackgroundImage = activePanel.BackgroundImage;
                            targetPanelLabel.Text = draggedPanelLabel.Text;
                        }

                        matchedTargetPanel = targetPanel;
                        break;
                    }
                }
                if (matchedTargetPanel != null)
                {
                    var isCorrect = Toolbox.Instance.CheckPanelOrder(targetPanels, matchedTargetPanel, callNumbers,draggedPanelLabel);
                    // Do something with isCorrect if needed.
                    if (isCorrect == true)
                    {
                        pb_GameProgression.Value += 10;
                        activePanel.Visible = false;
                        alreadyOrderedBooks.Add(matchedTargetPanel);
                    }
                }
                activePanel.Location = originalLocation;
                activePanel = null;
                this.ResumeLayout();
            }
            catch(Exception ex)
            {
                mediaPlayer.Instance.errorSoundAffect();
                MessageBox.Show(ex.Message);
            }
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
            gameStart = true;
            mediaPlayer.Instance.buttonClickSoundAffect();
            stopwatch.Restart();
            timer1.Start();
        }
        /// <summary>
        /// 
        /// </summary>
        private void Timer1_Tick(object sender, EventArgs e)
        {
            lb_GameTime.Text = stopwatch.Elapsed.ToString(@"hh\:mm\:ss");
        }
        /// <summary>
        /// 
        /// </summary>
        private void InitializeTimer()
        {
            timer1.Interval = 1000;
            timer1.Tick += Timer1_Tick;
        }
    }
}
