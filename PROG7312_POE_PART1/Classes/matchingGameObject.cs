using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
 * ST10081932
 * Geoffrey Huth
 * PROG7312 Part 1
 */
namespace PROG7312_POE_PART1.Classes
{
    internal class matchingGameObject
    {
        //Private static instance of the class to implement a singleton design pattern
        private static matchingGameObject instance = new matchingGameObject();
        //List holding all the generated dewey decimal numbers
        public static matchingGameObject Instance
        {
            get { return instance; }
        }
        /// <summary>
        /// holds all the dewey decimal categories || Key is value and value is the name of the category
        /// </summary>
        public Dictionary<string, string> DeweyCategory { get => deweyCategory; set => deweyCategory = value; }
        /// <summary>
        /// tracks which questions in the game have already been answered
        /// </summary>
        public Dictionary<string, string> AlreadyAnsweredQuestions { get => alreadyAnsweredQuestions; set => alreadyAnsweredQuestions = value; }
        /// <summary>
        /// tracks which questions are correct
        /// </summary>
        public Dictionary<string, string> CorrectQuestions { get => correctQuestions; set => correctQuestions = value; }

        //holds the original locations of all the bottom panels so that they can be reset. The key value is the panel while the x,y co-ordinates of the panel are the value
        private Dictionary<String, String> deweyCategory = new Dictionary<String, String>();

        private Dictionary<string, string> alreadyAnsweredQuestions = new Dictionary<string, string>();

        private Dictionary<string, string> correctQuestions = new Dictionary<string, string>();

    }
}
