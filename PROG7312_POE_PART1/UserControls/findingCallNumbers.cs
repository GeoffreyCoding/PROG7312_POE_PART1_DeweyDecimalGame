using PROG7312_POE_PART1.Classes;
using System;
using System.Collections.Generic;
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
        //top panels
        private readonly List<Panel> targetPanels = new List<Panel>();
        public findingCallNumbers()
        {
            this.DoubleBuffered = true;
            InitializeComponent();
            loadBottomPanelLocation();
            initializeDeweyTreeDataStructure();
            FillTargetPanels();
            resetGame();
        }

        private void loadBottomPanelLocation()
        {
            int x = bottomPanel1.Location.X;
            int y = bottomPanel1.Location.Y;
            bottomPanelLocation = new Point(x, y);
        }

        private void initializeDeweyTreeDataStructure()
        {
            fileReader reader = new fileReader();
            reader.getDeweyDecimalDataFromFile();
            reader = null;
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

        private void resetLabel()
        {
            lb_TopPanel1.Text = "";
            lb_TopPanel2.Text = "";
            lb_TopPanel3.Text = "";
            lbTopPanel4.Text = "";

        }

        private void loadDataIntoPanels()
        {
            resetLabel();
            findingCallNumberObject.Instance.CorrectAnswersList.Clear();
            //-----------------------Filling top panels with correct answer-----------------------
            //initializing the tree helper
            findingCallNumberTreeHelper treeHelper = findingCallNumberObject.Instance.TreeHelper;
            //getting the correct answer
            var correctAnswer = treeHelper.GetRandomEntriesByLevel(3, 1).FirstOrDefault();
            //filling the bottom panel with the correct answer
            bottomPanel1.Controls.OfType<Label>().FirstOrDefault().Text = correctAnswer.description;
            //filling the correct answers list
            var correctAnswerlist = treeHelper.GetAllParents(correctAnswer);
            //setting the correct answers list
            findingCallNumberObject.Instance.CorrectAnswersList = correctAnswerlist;
            //getting a random panel to fill with the correct answer
            Random rand = new Random();
            var randomPanel = targetPanels[rand.Next(0, 3)];
            randomPanel.Controls.OfType<Label>().FirstOrDefault().Text = correctAnswerlist[currentLevel - 1].description;
            //-----------------------Filling top panels with incorrect answers-----------------------
            //getting incorrect answers
            var incorrectAnswers = treeHelper.GetRandomEntriesByLevel(currentLevel, 3);
            //used to cycle through each target panel
            var index = 0;
            //filling the target panels with the incorrect answers
            foreach (var panel in targetPanels)
            {
                var label = panel.Controls.OfType<Label>().FirstOrDefault();

                if (label.Text == correctAnswerlist[currentLevel - 1].description)
                {

                }
                else
                {
                    label.Text = incorrectAnswers[index].description;
                    index++;
                }
            }
        }

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

        private void onQuestionComplete()
        {
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
                    leaderboardTracker.Instance.FindingNumberGameHighestScore = correctQuestions.ToString() + ";" + incorrectQuestions.ToString();
                    gameFinish();
                }

            }
        }

        private void gameFinish()
        {
            //won the game
            if (incorrectQuestions > correctQuestions)
            {
                mediaPlayer.Instance.WinGameSoundEffect();
                Toolbox.Instance.ParentForm.VisibleConfetti();
            }
            //lost the game
            Toolbox.Instance.ParentForm.VisibleLostGame();
            mediaPlayer.Instance.loseGameSoundAffect();
            //reset the game to play again
            resetGame();
        }

        private void checkCorrectAnswer(string description)
        {
            
            var correctAnswerList = findingCallNumberObject.Instance.CorrectAnswersList;
            var correctDescription = correctAnswerList[currentLevel - 1].description;

            if (correctDescription == description)
            {
                //correct
                correctQuestions++;
            }
            else
            {
                //incorrect
                incorrectQuestions++;
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

        private void btn_StartGame_Click(object sender, EventArgs e)
        {
            resetGame();
            gameStart = true;
        }

        private void btn_OrderGame_Click(object sender, EventArgs e)
        {
            resetGame();
            Toolbox.Instance.ParentForm.LoadMainMenu();
        }

        private void resetGame()
        {
            setHighestScore();
            currentLevel = 1;
            incorrectQuestions = 0;
            correctQuestions = 0;
            loadDataIntoPanels();
            gameStart = false;
            updateScore();
        }

        private void setHighestScore()
        {
            var temp = leaderboardTracker.Instance.FindingNumberGameHighestScore;
            if (temp != null)
            {
                var splitTemp = temp.Split(';');
                lbl_RWScoreToBeat.Text = "Score to beat || Right : " + temp[0] + "| Wrong : " + temp[1];
            }
        }

        private void updateScore()
        {
            lbCurrentScore.Text = "Score || Right : " + correctQuestions + "| Wrong : " + incorrectQuestions;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
