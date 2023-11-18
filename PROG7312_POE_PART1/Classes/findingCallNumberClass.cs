using DocumentFormat.OpenXml.EMMA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PROG7312_POE_PART1.Classes
{
    internal class findingCallNumberClass
    {
        /// <summary>
        /// singleton instance of the matchingGameClass
        /// </summary>
        private static readonly Lazy<findingCallNumberClass> _Instance = new Lazy<findingCallNumberClass>(() => new findingCallNumberClass());
        public static findingCallNumberClass Instance
        {
            get { return _Instance.Value; }
        }
        /// <summary>
        /// is sent a reference to tree helper and then gets the correct answer for the game from level 3
        /// </summary>
        /// <param name="treeHelper"></param>
        private void getCorrectAnswered(findingCallNumberTreeHelper treeHelper)
        {
            //getting the correct answer
            var correctAnswer = treeHelper.GetRandomEntriesByLevel(3, 1).FirstOrDefault();
            findingCallNumberObject.Instance.CorrectAnswer = correctAnswer;

        }
        /// <summary>
        /// starts the process of getting a list of all the parents of the correct answer
        /// </summary>
        /// <param name="treeHelper"></param>
        /// <returns></returns>
        private bool getCorrectAnswerList(findingCallNumberTreeHelper treeHelper)
        {
            try
            {
                var correctAnswer = findingCallNumberObject.Instance.CorrectAnswer;
                //filling the correct answers list
                var correctAnswerlist = treeHelper.GetAllParents(correctAnswer);
                findingCallNumberObject.Instance.CorrectAnswersList = correctAnswerlist;
                //incase a parent from each level is not found
                if (correctAnswerlist.Count == 3)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
           
        }
        /// <summary>
        /// gets the answer and a list of its parents which is then passed to the object class for later use
        /// </summary>
        public void loadAnswers()
        {
            try
            {
                bool isValid = false;
                while (isValid == false)
                {
                    findingCallNumberTreeHelper treeHelper = findingCallNumberObject.Instance.TreeHelper;
                    //Getting correct answer
                    findingCallNumberClass.Instance.getCorrectAnswered(treeHelper);
                    //getting parents of correct answer
                    findingCallNumberObject.Instance.CorrectAnswersList.Clear();
                    //getting answer list
                    isValid = findingCallNumberClass.Instance.getCorrectAnswerList(treeHelper);
                }
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

    }

}

