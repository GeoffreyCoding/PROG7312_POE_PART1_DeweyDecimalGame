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
        private List<Panel> alreadyOrderedBooks = new List<Panel>();
        private readonly Stopwatch stopwatch = new Stopwatch();
        /// <summary>
        /// variable controlling wether the game has been started or not
        /// </summary>
        private bool gameStart = false;
        private string[] callNumbers;
        private Point mouseOffset; // Add this as a class-level variable
        private List<PictureBox> confettiList = new List<PictureBox>();
        private Timer confettiTimer = null;
        private PictureBox pb = null;
        /// <summary>
        /// 
        /// </summary>
        public orderingGame()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            // Puts all the panels(top panels) with the target tag into a list using a lINQ query. This prevents having to constantly query for all the panels
            targetPanels = this.Controls.OfType<Panel>().Where(p => p.Tag?.ToString() == "target").OrderBy(p => p.Name).ToList();
            // Puts all the panels(bottom panels) with the draggable tag into a list using a lINQ query. This prevents having to constantly query for all the panels
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
                // Calculate the new position based on the mouse's current position minus the offset
                int x = e.X + activePanel.Left - mouseOffset.X;
                int y = e.Y + activePanel.Top - mouseOffset.Y;
                // Update the panel's position
                activePanel.Location = new Point(x, y);
                activePanel.Refresh(); // Forces the control to redraw itself
            }
        }
        /// <summary>
        /// when the use lets go of the left-click button, it changes the image and text of the targetted panel
        /// </summary>
        private void GenericPanel_MouseUp(object sender, MouseEventArgs e)
        {
            try
            {
                isDragging = false;
                this.SuspendLayout();

                var matchedTargetPanel = FindMatchingTargetPanel();
                UpdateTargetPanel(matchedTargetPanel);

                activePanel.Location = originalLocations[activePanel];
                activePanel = null;

                this.ResumeLayout();
            }
            catch (Exception ex)
            {
                // handle specific exception
            }
        }
        /// <summary>
        /// 
        /// </summary>
        private Panel FindMatchingTargetPanel()
        {
            foreach (var targetPanel in targetPanels)
            {
                if (activePanel.Bounds.IntersectsWith(targetPanel.Bounds))
                {
                    return targetPanel;
                }
            }
            return null;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="matchedTargetPanel"></param>
        private void UpdateTargetPanel(Panel matchedTargetPanel)
        {
            if (matchedTargetPanel != null)
            {
                var draggedPanelLabel = activePanel.Controls.OfType<Label>().FirstOrDefault();
                var targetPanelLabel = matchedTargetPanel.Controls.OfType<Label>().FirstOrDefault();

                if (draggedPanelLabel != null && targetPanelLabel != null && !alreadyOrderedBooks.Contains(matchedTargetPanel))
                {
                    matchedTargetPanel.BackgroundImage = activePanel.BackgroundImage;
                    targetPanelLabel.Text = draggedPanelLabel.Text;

                    // Check if panel is in the correct place and update UI accordingly
                    checkIfPanelInCorrectPlace(matchedTargetPanel, draggedPanelLabel);
                }
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="matchedTargetPanel"></param>
        /// <param name="draggedPanelLabel"></param>
        private void checkIfPanelInCorrectPlace(Panel matchedTargetPanel, Label draggedPanelLabel)
        {
            if (matchedTargetPanel != null)
            {
                bool isCorrect = Toolbox.Instance.CheckPanelOrder(targetPanels, matchedTargetPanel, callNumbers, draggedPanelLabel);

                if (isCorrect)
                {
                    pb_GameProgression.Value += 10;
                    activePanel.Visible = false;
                    alreadyOrderedBooks.Add(matchedTargetPanel);
                    checkIfGameWon();
                }
            }

        }
        /// <summary>
        /// 
        /// </summary>
        private void checkIfGameWon()
        {
            if (pb_GameProgression.Value == 100)
            {
                gameStart = false;
                timer1.Enabled = false;
                OnWin();
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
            resetGame();
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
        /// <summary>
        /// 
        /// </summary>
        private void OnWin()
        {
            GenerateConfetti();
            confettiTimer = new Timer();
            confettiTimer.Interval = 50;
            confettiTimer.Tick += ConfettiTimer_Tick;
            confettiTimer.Start();
            mediaPlayer.Instance.wongameSoundAffect();
            btn_PlayAgain.Visible = true;
        }
        /// <summary>
        /// 
        /// </summary>
        private void GenerateConfetti()
        {
            Random rand = new Random();
            for (int i = 0; i < 50; i++)
            {
                pb = new PictureBox();
                pb.Width = 5;
                pb.Height = 5;
                pb.BackColor = Color.FromArgb(rand.Next(256), rand.Next(256), rand.Next(256));
                pb.Location = new Point(rand.Next(this.Width), rand.Next(this.Height));
                this.Controls.Add(pb);
                confettiList.Add(pb);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        private void ConfettiTimer_Tick(object sender, EventArgs e)
        {
            foreach (PictureBox pb in confettiList)
            {
                pb.Top += 5;
                if (pb.Top > this.Height)
                {
                    pb.Top = -5;
                    pb.Left = new Random().Next(this.Width);
                }
            }
        }
        /// <summary>
        /// resets the game by first loading new call numbers and reseting the game time and progressbar
        /// It then cycles through each top row panel and resets the images and the labels.
        /// The bottom  row panels are then reset by being made visible again
        /// </summary>
        private void resetGame()
        {
            loadCallNumbers();
            gameStart = false;
            lb_GameTime.Text = "00:00:00";
            pb_GameProgression.Value = 0;
            foreach (var targetPanel in targetPanels)
            {
                targetPanel.BackgroundImage = null;
                var targetPanelLabel = targetPanel.Controls.OfType<Label>().FirstOrDefault();
                targetPanelLabel.Text = "000.000";
            }

            foreach (var draggablePanel in draggablePanels)
            {
                draggablePanel.Visible = true;
            }
            btn_PlayAgain.Visible = false;
        }

        private void btn_PlayAgain_Click(object sender, EventArgs e)
        {
            mediaPlayer.Instance.buttonClickSoundAffect();
            // Stop the timer.
            if (confettiTimer != null)
            {
                confettiTimer.Stop();
            }
            // Remove the PictureBox controls from the form and clear the list.
            foreach (var pb in confettiList)
            {
                this.Controls.Remove(pb);
            }
            confettiList.Clear();
            // Rest of your logic.
            resetGame();
        }
    }
}
