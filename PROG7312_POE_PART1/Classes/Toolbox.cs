using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PROG7312_POE_PART1.Classes
{
    internal class Toolbox
    {
        private static Toolbox instance = new Toolbox(); // Single instance
        //holds the instance of form1
        private Form1 parentForm;
        // Set to hold the generated numbers to ensure uniqueness for the Dewey Decimal System
        private HashSet<string> generatedNumbers = new HashSet<string>();
        private Random random = new Random();

        // Private constructor ensures that no other instances can be created
        private Toolbox() { }

        // Public static property to get the instance
        public static Toolbox Instance
        {
            get { return instance; }
        }

        public Form1 ParentForm { get => parentForm; set => parentForm = value; }
        /// <summary>
        /// asynchronous method which generates 10  dewey decimal classifications and then places them in a list, this list is then returned
        /// The hash map is only in place to prevent duplicate values as it matches values to keys and every key must be unique
        /// </summary>
        public async Task<string[]> GenerateUniqueDeweyDecimal()
        {
            string[] deweyDecimals = new string[10];

            for (int i = 0; i < 10; i++)
            {
                string deweyDecimal;

                // Keep generating numbers until a unique one is found
                do
                {
                    int mainClass = random.Next(0, 1000); // Main class (000-999)
                    int division = random.Next(0, 10);    // Division (0-9)
                    int section = random.Next(0, 10);     // Section (0-9)

                    deweyDecimal = $"{mainClass:D3}.{division:D1}{section:D1}"; // Format as "000.00"

                } while (generatedNumbers.Contains(deweyDecimal)); // Check if the number has been generated before

                // Add the unique number to the set
                generatedNumbers.Add(deweyDecimal);
                deweyDecimals[i] = deweyDecimal;
            }

            return await Task.FromResult(deweyDecimals);
        }
        /// <summary>
        /// checks that the panels with the "target" tag are in the correct order according to a pre-sorted array that already has the 
        /// correct order of the dewey decimal classifications.
        /// </summary>
        /// <param name="targetPanels"></param>
        /// <param name="correctOrder"></param>
        /// <returns></returns>
        public bool CheckPanelOrder(List<Panel> targetPanels, Panel panel, string[] correctOrder, Label draggedPanelLabel)
        {
            try
            {
                Label label = panel.Controls.OfType<Label>().FirstOrDefault();
                if (label != null && !string.IsNullOrEmpty(label.Text) && !label.Text.Equals("000.000"))
                {
                    string panelValue = draggedPanelLabel.Text;

                    // Find index of panel in targetPanels.
                    int panelIndex = targetPanels.IndexOf(panel);

                    // If the panel index is out of bounds for correctOrder, it's not in the correct position.
                    if (panelIndex >= correctOrder.Length) return false;

                    // Check if the panel's value matches what is in correctOrder.
                    return panelValue == correctOrder[panelIndex];
                }
                return false;
            }
            catch(Exception ex) { return false; }
            
        }

    }
}
