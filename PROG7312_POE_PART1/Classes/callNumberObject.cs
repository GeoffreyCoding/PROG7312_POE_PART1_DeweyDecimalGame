using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROG7312_POE_PART1.Classes
{
    internal class callNumberObject
    {
        //Private static instance of the class
        private static readonly callNumberObject instance = new callNumberObject();
        private string[] deweyDecimals;
        public static callNumberObject Instance
        {
            get { return instance; }
        }
        public string[] DeweyDecimals { get => deweyDecimals; set => deweyDecimals = value; }
  
    }
}
