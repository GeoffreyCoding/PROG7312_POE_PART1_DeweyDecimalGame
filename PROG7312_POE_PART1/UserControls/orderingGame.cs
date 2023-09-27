using PROG7312_POE_PART1.Classes;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Diagnostics;  // Added for Stopwatch
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
/*
 * ST10081932 
 * Geoffrey Huth
 * PROG7312 Part 1
 */
namespace PROG7312_POE_PART1.UserControls
{
    public partial class orderingGame : UserControl
    {
        //holds the original locations of all the bottom panels so that they can be reset. The key value is the panel while the x,y co-ordinates of the panel are the value
        private readonly Dictionary<Panel, Point> originalLocations = new Dictionary<Panel, Point>();
        private bool isDragging;
        private Panel activePanel;
        //top panels
        private readonly List<Panel> targetPanels = new List<Panel>();
        //bottom panels
        private readonly List<Panel> draggablePanels = new List<Panel>();
        //already ordered books
        private readonly List<Panel> alreadyOrderedBooks = new List<Panel>();
        private Stopwatch stopwatch = new Stopwatch();
        //holds the value ensuring that the user has clicked the start game button
        private bool gameStart;
        //mouse cursors current position
        private Point mouseOffset;
        /// <summary>
        /// ordering game constructor, the intialize components method is run asynchronously to lower the overall initialization time of the
        /// application
        /// </summary>
        public orderingGame()
        {
            InitializeComponent();
            Task.Run(InitializeComponents);
        }
        /// <summary>
        /// calls the methods that initalize the game, this includes filling the list of panel lists alongside initializing the timer and
        /// storing the original x,y co-ordinates of the bottom panels
        /// </summary>
        private void InitializeComponents()
        {
            InitializeTimer();
            FillDraggablePanels();
            FillTargetPanels();
            StoreOriginalPanelLocations();
        }

        #region Methods only run once during app initialization
        /// <summary>
        /// fills the Target panels array with all the panel ids, This format was recommended by ReSharpe
        /// </summary>
        private void FillTargetPanels()
        {
            var targetPanelArray = new[]
            {
                pn_TopBook1, pn_TopBook2, pn_TopBook3, pn_TopBook4, pn_TopBook5,
                pn_TopBook6, pn_TopBook7, pn_TopBook8, pn_TopBook9, pn_TopBook99
            };

            targetPanels.AddRange(targetPanelArray);
        }
        /// <summary>
        /// fills the draggable panels array with all the panel ids, This format was recommended by ReSharpe
        /// </summary>
        private void FillDraggablePanels()
        {
            var draggablePanelArray = new[]
            {
                pn_BottomBook1, pn_BottomBook2, pn_BottomBook3, pn_BottomBook4, pn_BottomBook5,
                pn_BottomBook6, pn_BottomBook7, pn_BottomBook8, pn_BottomBook9, pn_BottomBook10
            };

            draggablePanels.AddRange(draggablePanelArray);
        }
        /// <summary>
        /// stores the original locations .eg x,y co-ordinates of all the draggable panels
        /// this allows the application to teleport the panels that are not dragged to the correct position, back to their original
        /// location
        /// </summary>
        private void StoreOriginalPanelLocations()
        {
            foreach (var panel in draggablePanels)
            {
                originalLocations[panel] = panel.Location;
            }
        }
        #endregion


        #region Event handlers controlling the drag and drop feature
        /// <summary>
        /// Controls the initial click on a panel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GenericPanel_MouseDown(object sender, MouseEventArgs e)
        {
            if (gameStart)
            {
                mediaPlayer.Instance.GameClickSoundEffect();
                //setting the selected panel
                activePanel = sender as Panel;
                //confirming that dragging is being done
                isDragging = true;
                //setting the original location of the mouse cursor
                mouseOffset = new Point(e.X, e.Y);
            }
            else
            {
                mediaPlayer.Instance.ErrorSoundEffect();
                MessageBox.Show(@"Please press start game to begin! ");
            }
        }
        /// <summary>
        /// While you are dragging the bottom panels, this method runs the calculation that moves the panels in real time. It is
        /// very resource intensive but it looks cool so i kept it.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>    
        private void GenericPanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDragging && activePanel != null && gameStart)
            {
                //using int x and y, the panels new position is changed
                activePanel.Location = new Point(
                    //Takes the initial x-cordinate of the panel being dragged and the mouse and then calculates ts new position
                    e.X + activePanel.Left - mouseOffset.X,
                    //Takes the initial y-cordinate of the panel being dragged and the mouse and then calculate the new position
                    e.Y + activePanel.Top - mouseOffset.Y
                );
            }
        }
        /// <summary>
        /// once the user lets go of hte panel it checks wether you have dragged it on top of one of the top panels.
        /// It will then update the panel you dragged it on.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GenericPanel_MouseUp(object sender, MouseEventArgs e)
        {
            isDragging = false;
            //to increase performance, the layout is suspended until the process between is complete and then it is resumed
            this.SuspendLayout();
            //looking for the target panel that the dragged panel was dropped on
            var matchedTargetPanel = FindMatchingTargetPanel();
            //updating the image and label.text of the targetted panel
            UpdateTargetPanel(matchedTargetPanel);
            //sending the dragged panel back to its original positions
            activePanel.Location = originalLocations[activePanel];
            //garbage collections
            activePanel = null;
            //resuming the layout now that the operation is complete
            this.ResumeLayout();
        }
        #endregion

        #region Main methods for the ordering game 
        /// <summary>
        /// calls the method from the ordering game class to generate the letters and dewey decimal numbers. This method then changes the label
        /// texts of the bottom panels and finally sorts the dewey decimal list after the labels texts have been changed. This prevents
        /// the need for two different lists
        /// </summary>
        private void LoadCallNumbers()
        {
            orderingGameClass.Instance.GenerateUniqueDeweyDecimal();
            List<string> callNumbers = callNumberObject.Instance.DeweyDecimals;
            List<string> callLetters = orderingGameClass.Instance.GenerateRandomLetters().ToList();
            for (int i = 0; i < draggablePanels.Count; i++)
            {
                //gets the label on the specified panel (there is only 1 label per panel making singleOrDefault the best option)
                var label = draggablePanels[i].Controls.OfType<Label>().SingleOrDefault();
                label.Text = $"{callNumbers[i]} {callLetters[i]}";
            }
            //sorting the list of dewey decimals so that the correct order of the panels is solidified
            callNumberObject.Instance.DeweyDecimals.Sort();
            callNumbers = null;
            callLetters = null;
        }
        /// <summary>
        /// Finds the panel that you dragged the bottom panel on top of. It then returns that panel or null if you did not drag it on
        /// top of a target panel.
        /// </summary>
        /// <returns></returns>
        private Panel FindMatchingTargetPanel()
        {
            foreach (var targetPanel in targetPanels)
            {
                //checking if the dragged panels x and y co-ordinates are touching/intersecting with any of the target panels
                if (activePanel.Bounds.IntersectsWith(targetPanel.Bounds))
                {
                    return targetPanel;
                }
            }
            return null;
        }
        /// <summary>
        /// updates the panel that you dragged the bottom panel on top of by changing the image and text of the panel. It will then check if
        /// the panel is in the correct order according to the sorted dewey decimal list in the callNumberObject class.
        /// </summary>
        /// <param name="matchedTargetPanel"></param>
        private void UpdateTargetPanel(Panel matchedTargetPanel)
        {
            if (matchedTargetPanel != null)
            {
                //getting the label of the dragged panel
                var draggedPanelLabel = activePanel.Controls.OfType<Label>().SingleOrDefault();
                //getting the label of the target panel
                var targetPanelLabel = matchedTargetPanel.Controls.OfType<Label>().SingleOrDefault();
                //ensures that a panel that is already ordered cannot be a target
                if (draggedPanelLabel != null && targetPanelLabel != null && !alreadyOrderedBooks.Contains(matchedTargetPanel))
                {
                    //changing the panels background image to the image of the dragged panel
                    matchedTargetPanel.BackgroundImage = activePanel.BackgroundImage;
                    //chaning the text of the target panel
                    targetPanelLabel.Text = draggedPanelLabel.Text;
                    //checking wether the dewey decimal classification is in the correct order
                    checkIfPanelInCorrectPlace(matchedTargetPanel, draggedPanelLabel);
                }
            }
        }
        /// <summary>
        /// checks if the panel you dragged is in the correct order. If it is, it will update the progress bar and adds the panel
        /// to the alreadyOrderedBooks list that ensures that an already ordered book cannot be moved again. Finally it will call the
        /// checkIfGameWon method that checks if you won the game, using the progress bar.
        /// </summary>
        /// <param name="matchedTargetPanel"></param>
        /// <param name="draggedPanelLabel"></param>
        private void checkIfPanelInCorrectPlace(Panel matchedTargetPanel, Label draggedPanelLabel)
        {
            //getting the list of all the dewey decimal numbers ( in sorted order )
            List<string> callNumbers = callNumberObject.Instance.DeweyDecimals;
            //ensuring that a panel is matched
            if (matchedTargetPanel != null)
            {
                //checking the order of the panel
                bool isCorrect = orderingGameClass.Instance.CheckPanelOrder(targetPanels, matchedTargetPanel, callNumbers, draggedPanelLabel);
                //if it is in the correct order
                if (isCorrect)
                {
                    //increase progress bar 
                    pb_GameProgression.Value += 10;
                    //ensuring that the correctly ordered panel at the bottomm is now invisible
                    activePanel.Visible = false;
                    //ensuring that the already ordered panel cannot be changed again
                    alreadyOrderedBooks.Add(matchedTargetPanel);
                    //checking to see if the user has won the game by checking the value of the progress bar
                    checkIfGameWon();
                }
            }
        }
        /// <summary>
        /// Checks if you won the game, this is done using the progress bar and its current value.
        /// </summary>
        private void checkIfGameWon()
        {
            if (pb_GameProgression.Value == 100)
            {
                gameStart = false;
                //stopping the game
                timer1.Enabled = false;
                OnWin();
            }
        }
        #endregion

        #region Button clicks
        /// <summary>
        /// simply calls the startgame button to reset the game and allow the user to play again
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_PlayAgain_Click(object sender, EventArgs e)
        {
            mediaPlayer.Instance.ButtonClickSoundEffect();
            btn_StartGame.PerformClick();
        }
        /// <summary>
        /// plays the hover sound when hovering over any button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_OrderGame_MouseHover(object sender, EventArgs e)
        {
            mediaPlayer.Instance.ButtonHoverSoundEffect();
        }
        /// <summary>
        /// Stops the current games session and takes the user back to the main menu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_OrderGame_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            resetGame();
            Toolbox.Instance.ParentForm.LoadMainMenu();
            mediaPlayer.Instance.ButtonClickSoundEffect();
        }
        /// <summary>
        /// starts a new game session after reseting the entire game.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_StartGame_Click(object sender, EventArgs e)
        {
            resetGame();
            gameStart = true;
            timer1.Start();
            stopwatch.Restart();
        }
        #endregion

        /// <summary>
        /// controls the label that shows the user how much time has passed in the current games session. This later is
        /// converted into a score.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Timer1_Tick(object sender, EventArgs e)
        {
            //tracks the time of the current game session
            lb_GameTime.Text = stopwatch.Elapsed.ToString(@"hh\:mm\:ss");
        }
        /// <summary>
        /// Initializes the timer, this is only run once during the applications initial initialization
        /// </summary>
        private void InitializeTimer()
        {
            timer1.Interval = 1000;
            timer1.Tick += Timer1_Tick;
        }
        /// <summary>
        /// once the user wins the game it will send the users current score to the leaderBoard tracker and show the confetti user control
        /// </summary>
       private void OnWin()
       {
            leaderboardTracker.Instance.setScoreForLeaderboard(lb_GameTime.Text);
            btn_PlayAgain.Visible = true;
            Toolbox.Instance.ParentForm.VisibleConfetti();
            mediaPlayer.Instance.WinGameSoundEffect();
        }

        #region Resets the game and its components
        /// <summary>
        /// resets the game to its original state so that the user can play again.
        /// </summary>
        private void resetGame()
        {
            resetComponents();
            //resetting top panels
            foreach (Panel panel in targetPanels)
            {
                var label = panel.Controls.OfType<Label>().SingleOrDefault();

                label.Text = "000.00";
                panel.BackgroundImage = null;
            }
            //resetting bottom panels
            foreach (Panel panel in draggablePanels)
            {
                panel.Visible = true;
            }
            LoadCallNumbers();
            btn_PlayAgain.Visible = false;
        }
        /// <summary>
        /// resets the labels,progress bar and already ordered list once the user clicks start game or try again button.
        /// </summary>
        private void resetComponents()
        {
            lb_GameTime.Text = "00:00:00";
            var temp = leaderboardTracker.Instance.HighestScore;
            if (temp != null)
            {
                lb_FastestTime.Text = temp;
            }
            alreadyOrderedBooks.Clear();
            pb_GameProgression.Value = 0;
        }


        #endregion
    }
}
