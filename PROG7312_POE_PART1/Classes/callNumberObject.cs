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
    internal class callNumberObject
    {
        //Private static instance of the class to implement a singleton design pattern
        private static readonly callNumberObject instance = new callNumberObject();
        //List holding all the generated dewey decimal numbers
        private List<string> deweyDecimals;
        //constructor returning the singleton instance of the callNumberObject class
        public static callNumberObject Instance
        {
            get { return instance; }
        }
        //getter and setter for the Dewey Decimal list
        public List<string> DeweyDecimals { get => deweyDecimals; set => deweyDecimals = value; }
  
    }
}
