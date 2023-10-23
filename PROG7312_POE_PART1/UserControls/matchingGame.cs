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
using System.Windows.Forms;

namespace PROG7312_POE_PART1.UserControls
{
    public partial class matchingGame : UserControl
    {
        private List<(Point, Point)> drawnLines = new List<(Point, Point)>();
        private bool isDragging;
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
        /// <summary>
        /// initializes the gmae
        /// </summary>
        private void initializeGame()
        {
            FillTargetPanels();
            FillDescriptionPanels();
            matchingGameClass matchingGameClass = new matchingGameClass();
            matchingGameClass.fillDeweyCategories();
            matchingGameClass = null;
            fillTextBoxes();
            InitializeTimer();
        }
        /// <summary>
        /// fills the target panel array
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
        /// fills the description panel array
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
        private void fillTextBoxes()
        {
            matchingGameClass matchingGameClass = new matchingGameClass();            
            Dictionary<string,string> gameQuestions = matchingGameClass.getRandomQuestionsAndAnswers(7);
            Label txtLabels = null;
            List<int> randomNumberList = new List<int>();

            if (gameQuestions.Count >= 4)
            {
                for (int questions = 0; questions < 4; questions++)
                {
                    var txtQuestions = gameQuestions.ElementAt(questions);
                    txtLabels = targetPanels[questions].Controls.OfType<Label>().FirstOrDefault();
                    txtLabels.Text = txtQuestions.Key;
                    matchingGameObject.Instance.CorrectQuestions.Add(txtQuestions.Key, txtQuestions.Value);
                }
            }

            if (gameQuestions.Count >= 7)
            {
                randomNumberList = matchingGameClass.getRandomNumberList();
                for (int questions = 0; questions < 7; questions++)
                {
                    var txtQuestions = gameQuestions.ElementAt(randomNumberList[questions]);
                    txtLabels = descriptionPanels[questions].Controls.OfType<Label>().FirstOrDefault();
                    txtLabels.Text = txtQuestions.Value;
                }
            }
            randomNumberList = null;
            gameQuestions = null;
            txtLabels = null;
            matchingGameClass = null;
        }

        
        /// <summary>
        /// ALternates the questions to having the numbers as descriptions and the categories as the questions
        /// </summary>
        private void alternateQuestions()
        {
            matchingGameClass matchingGameClass = new matchingGameClass();
            Dictionary<string, string> gameQuestions = matchingGameClass.getRandomQuestionsAndAnswers(7);
            Label txtLabels = null;
            List<int> randomNumberList = new List<int>();
            if (gameQuestions.Count >= 4)
            {
                for (int questions = 0; questions < 4; questions++)
                {
                    var txtQuestions = gameQuestions.ElementAt(questions);
                    txtLabels = targetPanels[questions].Controls.OfType<Label>().FirstOrDefault();
                    txtLabels.Text = txtQuestions.Value;
                    matchingGameObject.Instance.CorrectQuestions.Add(txtQuestions.Key, txtQuestions.Value);
                }
            }

            if (gameQuestions.Count >= 7)
            {
                randomNumberList = matchingGameClass.getRandomNumberList();
                for (int questions = 0; questions < 7; questions++)
                {
                    var txtQuestions = gameQuestions.ElementAt(randomNumberList[questions]);
                    txtLabels = descriptionPanels[questions].Controls.OfType<Label>().FirstOrDefault();
                    txtLabels.Text = txtQuestions.Key;
                }
            }
            randomNumberList = null;
            gameQuestions = null;
            txtLabels = null;
            matchingGameClass = null;
        }
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
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
                //getting panel label
                Label label = intersectedPanel.Controls.OfType<Label>().FirstOrDefault();
                string leftSideQuestion = label.Text;
                label = activePanel.Controls.OfType<Label>().FirstOrDefault();
                string rigthSideQuestion = label.Text;
                KeyValuePair<string, string> question = new KeyValuePair<string, string>(leftSideQuestion, rigthSideQuestion);  
                var isCorrect = checkAnswer(question);
                if(isCorrect)
                {
                    // Set endPoint to the center of the intersectedPanel
                    endPoint = intersectedPanel.PointToScreen(new Point(intersectedPanel.Width / 2, intersectedPanel.Height / 2));
                    drawnLines.Add((startPoint, endPoint)); // Store the permanent line
                    this.Invalidate(); // Draw the permanent line
                    if(pb_GameProgression.Value == 48)
                    {
                        matchingGameObject.Instance.AlreadyAnsweredQuestions.Clear();
                        matchingGameObject.Instance.CorrectQuestions.Clear();
                        ResetLines();
                        alternateQuestions();
                    }
                    else if(pb_GameProgression.Value == 96)
                    {
                        stopGame();
                        Toolbox.Instance.ParentForm.VisibleConfetti();
                        mediaPlayer.Instance.WinGameSoundEffect();
                        var tempArray = lb_GameTime.Text.Split(':');
                        var gameScore = tempArray[1] + tempArray[2] + tempArray[3];
                        leaderboardTracker.Instance.replaceMatchingGameHighestScore(gameScore);
                        tempArray = null;
                        gameScore = null;
                    }
                }
                
            }

            this.Invalidate(); // Redraw the line
            intersectedPanel = null;
        }
        /// <summary>
        /// checks the users answer and if it is correct it will increase the alue of the progress bar
        /// </summary>
        /// <param name="answer"></param>
        /// <returns></returns>
        private bool checkAnswer(KeyValuePair<string, string> answer) {
            var correctQuestions = matchingGameObject.Instance.CorrectQuestions;
            KeyValuePair<string, string> swapped = new KeyValuePair<string, string>(answer.Value, answer.Key);
            if (correctQuestions.Contains(answer) || correctQuestions.Contains(swapped))
            {
                if (!matchingGameObject.Instance.AlreadyAnsweredQuestions.Contains(answer) && !matchingGameObject.Instance.AlreadyAnsweredQuestions.Contains(swapped))
                {
                    matchingGameObject.Instance.AlreadyAnsweredQuestions.Add(answer.Key, answer.Value);
                    pb_GameProgression.Value += 12;
                    swapped.Equals(null);
                    correctQuestions = null;
                    return true;
                }
                else
                {
                    swapped.Equals(null);
                    correctQuestions = null;
                    return false;
                }
            }
            else
            {
                swapped.Equals(null);
                correctQuestions = null;
                return false;
            }
        }
        /// <summary>
        /// on paint event that draws the lines
        /// </summary>
        /// <param name="e"></param>
        protected override void OnPaint(PaintEventArgs e)
        {
            var rand = new Random();
            base.OnPaint(e);
            using (Pen pen = new Pen(Color.FromArgb(rand.Next(256), rand.Next(256), rand.Next(256)), 5))
            {
                foreach (var line in drawnLines)
                {
                    e.Graphics.DrawLine(pen, this.PointToClient(line.Item1), this.PointToClient(line.Item2));
                }

                if (isDragging)
                {
                    e.Graphics.DrawLine(pen, this.PointToClient(startPoint), this.PointToClient(endPoint));
                }
            }
            rand = null;
        }
        /// <summary>
        /// starts the game and resets the game
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_StartGame_Click(object sender, EventArgs e)
        {
            gameStart = true;
            resetGame();
            startGame();

        }
        /// <summary>
        /// takes the user back to the main menu and resets the game
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_OrderGame_Click(object sender, EventArgs e)
        {
            mediaPlayer.Instance.ButtonClickSoundEffect();
            stopGame();
            Toolbox.Instance.ParentForm.LoadMainMenu();
        }
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
            resetGame();   
        }
        /// <summary>
        /// plays sound when you hover your mouse over a button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_MatchingGame_MouseHover(object sender, EventArgs e)
        {
            mediaPlayer.Instance.ButtonHoverSoundEffect();
        }
        /// <summary>
        /// Resets the game
        /// </summary>
        private void resetGame()
        {
            lb_FastestTime.Text = leaderboardTracker.Instance.scoreToTime(leaderboardTracker.Instance.MatchingGameHighestScore);
            pb_GameProgression.Value = 0;
            matchingGameObject.Instance.AlreadyAnsweredQuestions.Clear();
            matchingGameObject.Instance.CorrectQuestions.Clear();
            ResetLines();
            fillTextBoxes();
            lb_GameTime.Text = "00:00:00";
        }
    }
}
