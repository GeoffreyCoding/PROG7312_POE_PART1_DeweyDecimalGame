using ClosedXML.Excel;
using PROG7312_POE_PART1.Classes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

internal class fileReader
{
    /// <summary>
    /// 
    /// </summary>
    private readonly string exeLocation = AppDomain.CurrentDomain.BaseDirectory;
    /// <summary>
    /// 
    /// </summary>
    public void getDeweyDecimalDataFromFile()
    {
        try
        {
            string fullPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "dewey.csv");

            /*string fileName = "dewey.csv";
            string projectRoot = Directory.GetParent(exeLocation).Parent.Parent.FullName;
            string soundAffectsPath = Path.Combine(projectRoot, "Resources", fileName);
            string fullPath = Path.GetFullPath(soundAffectsPath);*/

            // Get the tree helper from the singleton instance
            var treeHelper = findingCallNumberObject.Instance.TreeHelper;

            // Read the CSV file line by line
            var lines = File.ReadAllLines(fullPath);

            // Skip the header if it exists, adjust the value of 'i' accordingly
            for (int i = 1; i < lines.Length; i++)
            {
                var cells = lines[i].Split(';'); // Split the line into cells (assuming comma is the separator)
                if (cells.Length >= 3) // Ensure there are at least three columns
                {
                    if (int.TryParse(cells[0].Trim(), out int code) &&
                        int.TryParse(cells[2].Trim(), out int level))
                    {
                        string description = cells[1].Trim();
                        // Insert the data into the tree with level
                        treeHelper.Insert(code, description, level);
                    }
                    else
                    {
                        // Handle the case where the code or level is not a valid integer
                        Console.WriteLine("Warning: Invalid data format on line " + (i + 1));
                    }
                }
            }
        }
        catch(Exception ex)
        {
            MessageBox.Show("Error, while accessing or reading the dewey.csv file, please ensure it is in the bin/debug folder and is not currently in use " +
                "by any other application and then restart the application! " + ex.Message);
            System.Environment.Exit(1);
        }
       
    }
}


