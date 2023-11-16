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
    public void getDeweyDecimalDataFromFile()
    {
        string filePath = @"C:\Users\Geoffrey\source\repos\PROG7312_POE_PART1\PROG7312_POE_PART1\SpeadsheetData\dewey.csv";

        // Get the tree helper from the singleton instance
        var treeHelper = findingCallNumberObject.Instance.TreeHelper;

        // Read the CSV file line by line
        var lines = File.ReadAllLines(filePath);

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
}


