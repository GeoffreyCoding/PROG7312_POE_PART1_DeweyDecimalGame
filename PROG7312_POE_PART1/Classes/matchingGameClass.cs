using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROG7312_POE_PART1.Classes
{
    internal class matchingGameClass
    {
        /// <summary>
        /// singleton instance of the matchingGameClass
        /// </summary>
        private static readonly Lazy<matchingGameClass> _Instance = new Lazy<matchingGameClass>(() => new matchingGameClass());
        public static matchingGameClass Instance
        {
            get { return _Instance.Value; }
        }
        /// <summary>
        /// fills the dictionary with the questions and answers that are used in the matching game
        /// this includes the incorrect questions and answers
        /// </summary>
        /// <returns></returns>
        public void fillDeweyCategories()
        {
            var deweyCategory = new Dictionary<String, String>();
            deweyCategory.Add("000", "Generalities");
            deweyCategory.Add("100", "Philosophy");
            deweyCategory.Add("200", "Religion");
            deweyCategory.Add("300", "Social Sciences");
            deweyCategory.Add("400", "Language");
            deweyCategory.Add("500", "Natural Sciences/Math");
            deweyCategory.Add("600", "Technology");
            deweyCategory.Add("700", "Arts/Recreation");
            deweyCategory.Add("800", "Literature");
            deweyCategory.Add("900", "History/Geography");
            matchingGameObject.Instance.DeweyCategory = deweyCategory;
            deweyCategory = null;
        }
        /// <summary>
        /// gets a ramly ordered list of numbers from 0-7
        /// </summary>
        /// <returns></returns>
        public List<int> getRandomNumberList()
        {
            var random = new Random();
            List<int> randomNumberList = Enumerable.Range(0, 7).ToList();
            // Shuffle the list
            randomNumberList = randomNumberList.OrderBy(n => random.Next()).ToList();

            return randomNumberList;

        }
        
        /// <summary>
        /// gets a random set of questions and answers from the dewey decimal system
        /// </summary>
        public Dictionary<string, string> getRandomQuestionsAndAnswers(int qustionsAmount)
        {
            //getting the categories for the dewey decimal system
            var originalCategories = matchingGameObject.Instance.DeweyCategory;
            var randomCategories = new Dictionary<string, string>();
            var random = new Random();
            try
            {
                while (randomCategories.Count < qustionsAmount && randomCategories.Count < originalCategories.Count)
                {
                    
                    int randomIndex = random.Next(0, originalCategories.Count);
                    //getting random category and number
                    KeyValuePair<string, string> randomItem = originalCategories.ElementAt(randomIndex);
                    //checking if the random category and number is already in the dictionary
                    if (!randomCategories.ContainsKey(randomItem.Key))
                    {
                        //adding the random category and number to the dictionary
                        randomCategories.Add(randomItem.Key, randomItem.Value);
                    }
                }

                return randomCategories;
            }
            catch (Exception e)
            {
                return null;
            }
        }


        /// <summary>
        /// checks if the answer is correct
        /// </summary>
        public bool checkCorrectAnswer(KeyValuePair<string, string> questions)
        {
            //LinQ gettinng a matching question and category
            var answer = matchingGameObject.Instance.DeweyCategory.Where(x => x.Key == questions.Key && x.Value == questions.Value).FirstOrDefault();
            //checking if the answer is correct
            if (answer.Value == questions.Value)
            {
                //correct
                return true;
            }
            else
            {
                //wrong answer
                return false;
            }
        }
    }
}
