using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PROG7312_POE_PART1.Classes
{
    internal class Toolbox
    {
        private static readonly Toolbox instance = new Toolbox(); // Single instance
        //holds the instance of form1
        private Form1 parentForm;

        // Private constructor ensures that no other instances can be created
        private Toolbox() { }

        // Public static property to get the instance
        public static Toolbox Instance
        {
            get { return instance; }
        }

        public Form1 ParentForm { get => parentForm; set => parentForm = value; }
    }
}
