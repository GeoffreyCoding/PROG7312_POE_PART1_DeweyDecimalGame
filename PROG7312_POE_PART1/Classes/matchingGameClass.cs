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
            deweyCategory.Add("500", "Natural Sciences and Mathematics");
            deweyCategory.Add("600", "Technology");
            deweyCategory.Add("700", "Arts and Recreation");
            deweyCategory.Add("800", "Literature");
            deweyCategory.Add("900", "History and Geography");
            matchingGameObject.Instance.DeweyCategory = deweyCategory;
            deweyCategory = null;
        }

        public List<int> getRandomNumberList()
        {
            var random = new Random();
            List<int> randomNumberList = Enumerable.Range(0, 7).ToList();
            // Shuffle the list
            randomNumberList = randomNumberList.OrderBy(n => random.Next()).ToList();

            return randomNumberList;

        }
        

        public Dictionary<string, string> getRandomQuestionsAndAnswers(int qustionsAmount)
        {
            var originalCategories = matchingGameObject.Instance.DeweyCategory;
            var randomCategories = new Dictionary<string, string>();
            var random = new Random();
            try
            {
                while (randomCategories.Count < qustionsAmount && randomCategories.Count < originalCategories.Count)
                {
                    int randomIndex = random.Next(0, originalCategories.Count);
                    KeyValuePair<string, string> randomItem = originalCategories.ElementAt(randomIndex);

                    if (!randomCategories.ContainsKey(randomItem.Key))
                    {
                        randomCategories.Add(randomItem.Key, randomItem.Value);
                    }
                }

                return randomCategories;
            }
            catch (Exception e)
            {
                // Consider logging the exception here to get more information
                // about the exact nature of the error.
                return null;
            }
        }



        public bool checkCorrectAnswer(KeyValuePair<string, string> questions)
        {
            var answer = matchingGameObject.Instance.DeweyCategory.Where(x => x.Key == questions.Key && x.Value == questions.Value).FirstOrDefault();
            if (answer.Value == questions.Value)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
