using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROG7312_POE_PART1.Classes
{
    internal class callNumberObject
    {
        private List<string> deweyDecimals = new List<string>();

        public List<string> DeweyDecimals { get => deweyDecimals; set => deweyDecimals = value; }
    }
}
