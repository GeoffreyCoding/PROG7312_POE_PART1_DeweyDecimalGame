using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROG7312_POE_PART1.Classes
{
    internal class deweyDataModel
    {
        private string deweyNumber;
        private string deweyDescription;

        public string DeweyNumber { get => deweyNumber; set => deweyNumber = value; }
        public string DeweyDescription { get => deweyDescription; set => deweyDescription = value; }

        public deweyDataModel(string deweyNumber, string deweyDescription)
        {
            this.deweyNumber = deweyNumber;
            this.deweyDescription = deweyDescription;
        }
    }
}
