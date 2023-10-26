using PROG7312_POE_PART1.Classes;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;

namespace PROG7312_POE_PART1.UserControls
{
    public partial class matchingGame : UserControl
    { 
        private List<(Point, Point)> drawnLines = new List<(Point, Point)>();
        //panel clicked on 
        private bool isDragging;
        //panel being dragged
        private Panel activePanel;
        //top panels
        private readonly List<Panel> targetPanels = new List<Panel>();
        //bottom panels
        private readonly List<Panel> descriptionPanels = new List<Panel>();
        //holds the value ensuring that the user has clicked the start game button
        private bool gameStart;
        private Stopwatch stopwatch = new Stopwatch();
        // Declare two points to store the starting and ending points for the line
        Point startPoint = Point.Empty;
        Point endPoint = Point.Empty;

        public matchingGame()
        {
            InitializeComponent();
            initializeGame();
            this.DoubleBuffered = true; // To make drawing smoother

        }

        #region Initializes the game (Fills panel arrays) and fills the text boxes with the questions and answers
        /// <summary>
        /// initializes the gmae
        /// </summary>
        private void initializeGame()
        {
            //fills the dictionary with the target panels
            FillTargetPanels();
            //fills the dictionary with description panels
            FillDescriptionPanels();
            //fills the dictionairy with the dewey decimal categories and their corresponding numbers
            matchingGameClass.Instance.fillDeweyCategories();
            //fills the labels on the panels with their corresponding categories or numbers
            fillTextBoxes(false);
            //Initializes timer
            InitializeTimer();
        }
        /// <summary>
        /// fills the target panel array in re-sharpe/co-pilot format
        /// </summary>
        private void FillTargetPanels()
        {
            var targetPanelArray = new[]
            {
                pnlQuestion1, pnlQuestion2, pnlQuestion3, pnlQuestion4
            };

            targetPanels.AddRange(targetPanelArray);
            targetPanelArray = null;
        }
        /// <summary>
        /// fills the description panel array in re-sharpe/co-pilot format
        /// </summary>
        private void FillDescriptionPanels()
        {
            var descriptionPanelArray = new[]
            {
                pnlDescription1, pnlDescription2, pnlDescription3, pnlDescription4, pnlDescription5,
                pnlDescription6, pnlDescription7
            };

            descriptionPanels.AddRange(descriptionPanelArray);
            descriptionPanelArray = null;
        }
        /// <summary>
        /// Fills the questions with numbers and the descriptions with the categories
        /// </summary>
        private void fillTextBoxes(bool alternateQuestions)
        {          
            //will store the chosen questions
            Dictionary<string,string> gameQuestions = matchingGameClass.Instance.getRandomQuestionsAndAnswers(7);
            //variable stores the label on the panel
            Label txtLabels = null;
            //contains a random list of numbers tht will 
            List<int> randomNumberList = new List<int>();
            //ensures that game questions has all the questions required
            if (gameQuestions.Count >= 4)
            {
                //iterates through the questions
                for (int questions = 0; questions < 4; questions++)
                {
                    //gets a random element from gameQuestions
                    var txtQuestions = gameQuestions.ElementAt(questions);
                    //grabs a random panel
                    txtLabels = targetPanels[questions].Controls.OfType<Label>().FirstOrDefault();
                    //decides which orientation the questions will be in
                    if (alternateQuestions == false)
                    {
                        txtLabels.Text = txtQuestions.Key;
                    }
                    else
                    {
                        txtLabels.Text = txtQuestions.Value;
                    }
                    //ading the correct questions
                    matchingGameObject.Instance.CorrectQuestions.Add(txtQuestions.Key, txtQuestions.Value);
                }
            }

            if (gameQuestions.Count >= 7)
            {
                //gets the list of random numbers from 0-7
                randomNumberList = matchingGameClass.Instance.getRandomNumberList();
                for (int questions = 0; questions < 7; questions++)
                {
                    //gets a random element
                    var txtQuestions = gameQuestions.ElementAt(randomNumberList[questions]);
                    //gets label of panel
                    txtLabels = descriptionPanels[questions].Controls.OfType<Label>().FirstOrDefault();
                    //controls questions and answer orientation
                    if (alternateQuestions == true)
                    {
                        txtLabels.Text = txtQuestions.Key;
                    }
                    else
                    {
                        txtLabels.Text = txtQuestions.Value;
                    }
                }
            }
            randomNumberList = null;
            gameQuestions = null;
            txtLabels = null;
        }
        #endregion

        #region Controls the dragging of the panels and drawing of lines
        /// <summary>
        /// event detects when the user clicks on a panel
        /// </summary>
        private void descriptionPanel_MouseDown(object sender, MouseEventArgs e)
        {
            if(gameStart == true)
            {
                // Activate dragging and set starting point for line
                isDragging = true;
                activePanel = (Panel)sender;
                startPoint = activePanel.PointToScreen(new Point(e.X, e.Y));
            }
            
        }
        
        /// <summary>
        /// event controls the lines that get painted
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void descriptionPanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDragging)
            {
                // Update the ending point for the line
                endPoint = activePanel.PointToScreen(new Point(e.X, e.Y));
                this.Invalidate(); // Force the control to be redrawn
            }
        }
        /// <summary>
        /// mouse up event that checks if the user has answered the question correctly
        /// </summary>
        private void descriptionPanel_MouseUp(object sender, MouseEventArgs e)
        {
            // Deactivate dragging
            isDragging = false;

            // Calculate the end point based on the mouse position when the mouse is released
            endPoint = this.PointToClient(Cursor.Position);

            Panel intersectedPanel = CheckIntersectsWithTargetPanels(endPoint);

            if (intersectedPanel == null)
            {
                // Invalidate the control to erase the line.
                this.Invalidate();
            }
            else
            {
                //getting target panel label
                Label label = intersectedPanel.Controls.OfType<Label>().FirstOrDefault();
                //assigning qestion
                string leftSideQuestion = label.Text;
                //getting active panel label
                label = activePanel.Controls.OfType<Label>().FirstOrDefault();
                //assigning text
                string rigthSideQuestion = label.Text;
                //creating a key value pair that contains the questions and description pair
                KeyValuePair<string, string> question = new KeyValuePair<string, string>(leftSideQuestion, rigthSideQuestion);
                //checks if the answer is correct
                var isCorrect = checkAnswer(question);
                if (isCorrect)
                {
                    addLine(intersectedPanel);
                    this.Invalidate(); // Draw the permanent line
                    //first question set complete 
                    if (pb_GameProgression.Value == 48)
                    {
                        swapQuestions();
                    }
                    //game finished
                    else if (pb_GameProgression.Value == 96)
                    {
                        onWin();
                    }
                }

            }

            this.Invalidate(); // Redraw the line
            intersectedPanel = null;
        }
        #endregion

        /// <summary>
        /// loads the alternated questions where the descriptions are now the call numbers 
        /// and the questions are now the categories
        /// </summary>
        private void swapQuestions()
        {
            matchingGameObject.Instance.AlreadyAnsweredQuestions.Clear();
            matchingGameObject.Instance.CorrectQuestions.Clear();
            ResetLines();
            fillTextBoxes(true);
        }
        /// <summary>
        /// adds a line to the array, that will get drawn by the onPaint event
        /// </summary>
        /// <param name="intersectedPanel"></param>
        private void addLine(Panel intersectedPanel)
        {
            // Set endPoint to the center of the intersectedPanel
            endPoint = intersectedPanel.PointToScreen(new Point(intersectedPanel.Width / 2, intersectedPanel.Height / 2));
            drawnLines.Add((startPoint, endPoint)); // Store the permanent line
        }
        /// <summary>
        /// loads the winning screen and resets the game
        /// </summary>
        private void onWin()
        {
            var tempArray = lb_GameTime.Text.Split(':');
            var gameScore = tempArray[0] + tempArray[1] + tempArray[2];
            leaderboardTracker.Instance.replaceMatchingGameHighestScore(gameScore);
            stopGame();
            lb_GameTime.Text = "00:00:00";
            tempArray = null;
            gameScore = null;
            Toolbox.Instance.ParentForm.VisibleConfetti();
            mediaPlayer.Instance.WinGameSoundEffect();
        }
        #region Game utilities to check intersection and answer
        /// <summary>
        /// checks if the user has hovered over a target panel
        /// </summary>
        private Panel CheckIntersectsWithTargetPanels(Point mousePosition)
        {
            foreach (var targetPanel in targetPanels)
            {
                if (targetPanel.Bounds.Contains(mousePosition))
                {
                    return targetPanel;
                }
            }
            return null; // return null if the mouse does not intersect with any target panel
        }
                /// <summary>
        /// checks the users answer and if it is correct it will increase the alue of the progress bar
        /// </summary>
        /// <param name="answer"></param>
        private bool checkAnswer(KeyValuePair<string, string> answer) {
            //getting the list of correct questions
            var correctQuestions = matchingGameObject.Instance.CorrectQuestions;
            //key value pair for the question and answer the user has matched
            KeyValuePair<string, string> swapped = new KeyValuePair<string, string>(answer.Value, answer.Key);
            //checking if the user input has been answered already
            if (correctQuestions.Contains(answer) || correctQuestions.Contains(swapped))
            {
                //if its not already answered
                if (!matchingGameObject.Instance.AlreadyAnsweredQuestions.Contains(answer) && !matchingGameObject.Instance.AlreadyAnsweredQuestions.Contains(swapped))
                {
                    //add it to the list of already answered quesions
                    matchingGameObject.Instance.AlreadyAnsweredQuestions.Add(answer.Key, answer.Value);
                    pb_GameProgression.Value += 12;
                    return true;
                }
                //if it is a correct match but has not been answered alreadys
                else
                {
                    return false;
                }
            }
            //is not a correct answer
            else
            {
                return false;
            }
        }
        #endregion
        /// <summary>
        /// on paint event that draws the lines
        /// </summary>
        protected override void OnPaint(PaintEventArgs e)
        {
            var rand = new Random();
            base.OnPaint(e);
            using (Pen pen = new Pen(Color.White, 5))
            {
                foreach (var line in drawnLines)
                {
                    //gets a randoming colour for each line
                    pen.Color = Color.FromArgb(rand.Next(256), rand.Next(256), rand.Next(256));
                    e.Graphics.DrawLine(pen, this.PointToClient(line.Item1), this.PointToClient(line.Item2));
                }

                if (isDragging)
                {
                    //gets a random colour for the line being drawn
                    pen.Color = Color.FromArgb(rand.Next(256), rand.Next(256), rand.Next(256));
                    e.Graphics.DrawLine(pen, this.PointToClient(startPoint), this.PointToClient(endPoint));
                }
            }
            rand = null;
        }

        #region Gmae controls ( Stop,Start,Timer,Reset Lines)
        /// <summary>
        /// clears all the lines between the panels 
        /// </summary>
        public void ResetLines()
        {
            drawnLines.Clear();
            this.Invalidate(); // Redraw the control without the lines
        }
        /// <summary>
        /// changes the time tracker label
        /// </summary>
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
        /// starts the game timers
        /// </summary>
        private void startGame()
        {
            timer1.Enabled = true;
            timer1.Start();
            stopwatch.Start();
        }
        /// <summary>
        /// stops the game entirely and then resets the game
        /// </summary>
        private void stopGame()
        {
            gameStart = false;
            stopwatch.Stop();
            timer1.Stop();
            timer1.Enabled = false;
            resetGame();   
        }
       
        /// <summary>
        /// Resets the game
        /// </summary>
        private void resetGame()
        {
            lb_FastestTime.Text = leaderboardTracker.Instance.MatchingGameHighestScore;
            if(lb_FastestTime.Text == "" || lb_FastestTime.Text == null)
            {
                lb_FastestTime.Text = "000000";           
            }
            //resetting progress bar
            pb_GameProgression.Value = 0;
            //clearing already answered questions
            matchingGameObject.Instance.AlreadyAnsweredQuestions.Clear();
            //clearing all correct questions
            matchingGameObject.Instance.CorrectQuestions.Clear();
            //resetting all drawn lines
            ResetLines();
            //alternating questions
            fillTextBoxes(false);
            lb_GameTime.Text = "00:00:00";
        }
        #endregion
        #region Button Clicks and events
        /// <summary>
        /// plays sound when you hover your mouse over a button
        /// </summary>
        private void btn_MatchingGame_MouseHover(object sender, EventArgs e)
        {
            mediaPlayer.Instance.ButtonHoverSoundEffect();
        }
        /// <summary>
        /// starts the game and resets the game
        /// </summary>
        private void btn_StartGame_Click(object sender, EventArgs e)
        {
            gameStart = true;
            resetGame();
            startGame();

        }
        /// <summary>
        /// takes the user back to the main menu and resets the game
        /// </summary>
        private void btn_OrderGame_Click(object sender, EventArgs e)
        {
            mediaPlayer.Instance.ButtonClickSoundEffect();
            stopGame();
            Toolbox.Instance.ParentForm.LoadMainMenu();
        }
        #endregion
    }
}
