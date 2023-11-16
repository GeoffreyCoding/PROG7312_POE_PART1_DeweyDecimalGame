using DocumentFormat.OpenXml.EMMA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PROG7312_POE_PART1.Classes
{
    internal class findingCallNumberClass
    {
        /// <summary>
        /// singleton instance of the matchingGameClass
        /// </summary>
        private static readonly Lazy<findingCallNumberClass> _Instance = new Lazy<findingCallNumberClass>(() => new findingCallNumberClass());
        public static findingCallNumberClass Instance
        {
            get { return _Instance.Value; }
        }

       
    }

}

