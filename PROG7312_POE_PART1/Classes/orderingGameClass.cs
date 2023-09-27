using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PROG7312_POE_PART1.Classes
{
    internal class orderingGameClass
    {
        private static readonly Lazy<orderingGameClass> _Instance = new Lazy<orderingGameClass>(() => new orderingGameClass());
        public static orderingGameClass Instance
        {
            get { return _Instance.Value; }
        }

        // Set to hold the generated numbers to ensure uniqueness for the Dewey Decimal System
        private readonly HashSet<string> generatedNumbers = new HashSet<string>();
        private readonly Random random = new Random();

        #region Generates the letters and numbers for the Dewey Decimal System
        /// <summary>
        /// generates 10 random combinations of 2 capital letters which act as the authors initials for the dewey decimal numbers
        /// This is done using the random char operand
        /// </summary>
        /// <returns></returns>
        public string[] GenerateRandomLetters()
        {
            string[] deweyLetters = new string[10];

            for (int I = 0; I < 10; I++)
            {
                char letter1 = (char)random.Next('A', 'Z' + 1);
                char letter2 = (char)random.Next('A', 'Z' + 1);
                deweyLetters[I] = string.Concat(letter1, letter2);
            }

            return deweyLetters;
        }
        /// <summary>
        /// asynchronous method which generates 10  dewey decimal classifications and then places them in a list, this list is then returned
        /// The hash map is only in place to prevent duplicate values as it matches values to keys and every key must be unique
        /// The code for the divisions was found on stack overflow. This allows for a truly random dewey decimal classification
        /// </summary>
        public void GenerateUniqueDeweyDecimal()
        {
            string[] deweyDecimals = new string[10];

            Parallel.For(0, 10, i =>
            {
                string deweyDecimal;
                do
                {
                    int mainClass = random.Next(0, 1000);
                    int division = random.Next(0, 10);
                    int section = random.Next(0, 10);

                    deweyDecimal = $"{mainClass:D3}.{division:D1}{section:D1}";
                } while (generatedNumbers.Contains(deweyDecimal));

                generatedNumbers.Add(deweyDecimal);
                deweyDecimals[i] = deweyDecimal;
            });

            callNumberObject.Instance.DeweyDecimals = deweyDecimals.ToList();
        }
        #endregion

        /// <summary>
        /// checks that the panels with the "target" tag are in the correct order according to a pre-sorted array that already has the 
        /// correct order of the dewey decimal classifications.
        /// </summary>
        /// <param name="targetPanels"></param>
        /// <param name="correctOrder"></param>
        /// <returns></returns>
        public bool CheckPanelOrder(List<Panel> targetPanels, Panel panel, List<string> correctOrder, Label draggedPanelLabel)
        {
            try
            {
                //finds the label that is on the targeted panel
                Label label = panel.Controls.OfType<Label>().FirstOrDefault();
                if (label != null && !string.IsNullOrEmpty(label.Text) && !label.Text.Equals("000.000"))
                {
                    var temp = draggedPanelLabel.Text.Split(' ');
                    string panelValue = temp[0];

                    // Find index of panel in targetPanels.
                    int panelIndex = targetPanels.IndexOf(panel);

                    // If the panel index is out of bounds for correctOrder, it's not in the correct position.
                    if (panelIndex >= correctOrder.Count) return false;

                    // Check if the panel's value matches what is in correctOrder.
                    return panelValue == correctOrder[panelIndex];
                }
                return false;
            }
            catch (Exception ex) { return false; }

        }
    }
}
