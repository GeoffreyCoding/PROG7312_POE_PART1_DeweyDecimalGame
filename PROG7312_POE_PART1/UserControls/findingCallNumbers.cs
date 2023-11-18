using PROG7312_POE_PART1.Classes;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace PROG7312_POE_PART1.UserControls
{

    public partial class findingCallNumbers : UserControl
    {
        //panel being dragged
        private Panel activePanel;
        private bool isDragging = false;
        private Point mouseOffset;
        private bool gameStart = false;
        private Point bottomPanelLocation;
        private int currentLevel = 1;
        private int correctQuestions = 0;
        private int incorrectQuestions = 0;
        private Stopwatch stopwatch = new Stopwatch();
        //top panels
        private readonly List<Panel> targetPanels = new List<Panel>();

        #region game initialization
        public findingCallNumbers()
        {
            //double bufferent to improve drag and drop feature
            this.DoubleBuffered = true;
            //initialize components
            InitializeComponent();
            //initializing the timer
            InitializeTimer();
            //loading the bottom panel location
            loadBottomPanelLocation();
            //initializing the data structure
            initializeDeweyTreeDataStructure();
            //filling the target panels
            FillTargetPanels();
            //loading the data into the panels
            resetGame();


        }

        /// <summary>
        /// loading the location of the bottom panel
        /// </summary>
        private void loadBottomPanelLocation()
        {
            int x = bottomPanel1.Location.X;
            int y = bottomPanel1.Location.Y;
            bottomPanelLocation = new Point(x, y);
        }
        /// <summary>
        /// starts the process of reading from the .csv file and then filling the AVL Black-Red tree
        /// </summary>
        private void initializeDeweyTreeDataStructure()
        {
            try
            {
                fileReader reader = new fileReader();
                reader.getDeweyDecimalDataFromFile();
                reader = null;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// fills the target panel array in re-sharpe/co-pilot format
        /// </summary>
        private void FillTargetPanels()
        {
            var targetPanelArray = new[]
            {
                topPanel1, topPanel2, topPanel3,topPanel4
            };

            targetPanels.AddRange(targetPanelArray);
            activePanel = bottomPanel1;
            targetPanelArray = null;
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
        /// changes the time tracker label
        /// </summary>
        private void Timer1_Tick(object sender, EventArgs e)
        {
            //tracks the time of the current game session
            lb_GameTime.Text = stopwatch.Elapsed.ToString(@"hh\:mm\:ss");
        }
        #endregion
        /// <summary>
        /// reset the labels in the top panels
        /// </summary>
        private void resetLabel()
        {
            lb_TopPanel1.Text = "";
            lb_TopPanel2.Text = "";
            lb_TopPanel3.Text = "";
            lbTopPanel4.Text = "";

        }


        /// <summary>
        /// loads the data from the tree, back into the panels
        /// </summary>
        private void loadDataIntoPanels()
        {
            try
            {
                resetLabel();
                //findingCallNumberObject.Instance.CorrectAnswersList.Clear();
                //-----------------------Filling top panels with correct answer-----------------------
                //initializing the tree helper
                findingCallNumberTreeHelper treeHelper = findingCallNumberObject.Instance.TreeHelper;
                //getting the correct answer
                var correctAnswer = findingCallNumberObject.Instance.CorrectAnswer;
                //filling the correct answers list
                var correctAnswerlist = findingCallNumberObject.Instance.CorrectAnswersList;
                //filling the bottom panel with the correct answer
                bottomPanel1.Controls.OfType<Label>().FirstOrDefault().Text = correctAnswer.description;
                //setting the correct answers list
                findingCallNumberObject.Instance.CorrectAnswersList = correctAnswerlist;
                //-----------------------Filling top panels with incorrect answers-----------------------
                //getting incorrect answers
                var incorrectAnswers = treeHelper.GetIncorrectEntriesByLevel(currentLevel, 3);
                incorrectAnswers.Add(correctAnswerlist[currentLevel - 1]);
                incorrectAnswers.Sort((x, y) => x.data.CompareTo(y.data));
                //used to cycle through each target panel
                var index = 0;
                //filling the target panels with the incorrect answers
                foreach (var panel in targetPanels)
                {
                    var label = panel.Controls.OfType<Label>().FirstOrDefault();
                    label.Text = incorrectAnswers[index].data.ToString() + " : " + incorrectAnswers[index].description;
                    index++;

                }
            }
            catch (Exception ex){ MessageBox.Show(ex.Message); }
        }
        #region drag-and-drop mouse events
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
            if (matchedTargetPanel != null)
            {
                var targetPanelDescription = matchedTargetPanel.Controls.OfType<Label>().FirstOrDefault().Text;
                var temp = targetPanelDescription.ToString().Split(':');
                targetPanelDescription = temp[1].Trim();
                //checking for the correct answer
                checkCorrectAnswer(targetPanelDescription);
                //handling if user answer is correct/false
                onQuestionComplete();
            }
            //sending the dragged panel back to its original positions
            activePanel.Location = bottomPanelLocation;
            //resuming the layout now that the operation is complete
            this.ResumeLayout();
        }
        #endregion

        /// <summary>
        /// handles the logic for when a user completes a questions
        /// </summary>
        private void onQuestionComplete()
        {
            //upating the score
            updateScore();
            if (currentLevel != 3)
            {
                currentLevel++;
                loadDataIntoPanels();
            }
            else
            {
                //checking if the game is finished
                if (incorrectQuestions + correctQuestions == 3)
                {
                    //formatting/storing their highest score
                    leaderboardTracker.Instance.FindingNumberGameHighestScore = correctQuestions.ToString() + ";" + incorrectQuestions.ToString();
                    gameFinish();
                }

            }
        }
        /// <summary>
        /// Handles the game logic for when the game is finished
        /// </summary>
        private void gameFinish()
        {
            //won the game
            if (correctQuestions > incorrectQuestions)
            {
                mediaPlayer.Instance.WinGameSoundEffect();
                Toolbox.Instance.ParentForm.VisibleConfetti();
            }
            else
            {

            }
            var temp = lb_GameTime.Text.Trim().Split(':');
            var score = temp[0] + temp[1] + temp[2];
            leaderboardTracker.Instance.replaceFindingCallNumberBestTime(score);
            //reset the game to play again
            resetGame();
        }
        /// <summary>
        /// checks the description of the target panel against the correct answer
        /// </summary>
        /// <param name="description"></param>
        private void checkCorrectAnswer(string description)
        {

            var correctAnswerList = findingCallNumberObject.Instance.CorrectAnswersList;
            var correctDescription = correctAnswerList[currentLevel - 1].description;

            if (correctDescription == description)
            {
                //correct
                correctQuestions++;
                pb_GameProgression.Value += 33;
            }
            else
            {
                resetGame();
                //lost the game
                Toolbox.Instance.ParentForm.VisibleLostGame();
                mediaPlayer.Instance.loseGameSoundAffect();

            }
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
        #region Button Clicks
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_StartGame_Click(object sender, EventArgs e)
        {
            resetGame();
            gameStart = true;
            startTimer();
            
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_OrderGame_Click(object sender, EventArgs e)
        {
            Toolbox.Instance.ParentForm.LoadMainMenu();
            resetGame();
            
        }
        #endregion
        /// <summary>
        /// resets the entire game
        /// </summary>
        private void resetGame()
        {
            setHighestScore();
            currentLevel = 1;
            incorrectQuestions = 0;
            correctQuestions = 0;
            findingCallNumberClass.Instance.loadAnswers();
            loadDataIntoPanels();
            gameStart = false;
            stopTime();
            updateScore();
            lb_GameTime.Text = "00:00:00";
            pb_GameProgression.Value = 0;
            updateBestTime();
        }
        #region timer and score
        /// <summary>
        /// start the game timer
        /// </summary>
        private void startTimer()
        {
            timer1.Enabled = true;
            timer1.Start();
            stopwatch.Start();
        }
        /// <summary>
        /// stop the game timer
        /// </summary>
        private void stopTime()
        {
            timer1.Stop();
            timer1.Enabled = false;
            stopwatch.Reset();
        }
        private void updateBestTime()
        {
            var bestTime = leaderboardTracker.Instance.FindingNumberGameBestTime;
            if (bestTime != null)
            {
                lb_FastestTime.Text = leaderboardTracker.Instance.FindingNumberGameBestTime;

            }

        }
        /// <summary>
        /// updates teh users score on the label
        /// </summary>
        private void setHighestScore()
        {
            var temp = leaderboardTracker.Instance.FindingNumberGameHighestScore;
            if (temp != null)
            {
                var splitTemp = temp.Split(';');
                lbl_RWScoreToBeat.Text = "Score to beat || Right : " + temp[0].ToString() + "| Wrong : " + temp[1].ToString();
            }
        }
       
        /// <summary>
        /// updates the users score
        /// </summary>
        private void updateScore()
        {
            lbCurrentScore.Text = "Score || Right : " + correctQuestions.ToString() + "| Wrong : " + incorrectQuestions.ToString() ;
        }
        #endregion
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void lb_ScoreToBeat_Click(object sender, EventArgs e)
        {

        }
    }
}
