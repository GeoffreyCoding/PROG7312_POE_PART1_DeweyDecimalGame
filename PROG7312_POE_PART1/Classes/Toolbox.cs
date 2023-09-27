using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
/*
 * ST10081932
 * Geoffrey Huth
 * PROG7312 Part 1
 */
namespace PROG7312_POE_PART1.Classes
{
    internal class Toolbox
    {
        // Toolbox Class
        private static readonly Lazy<Toolbox> _Instance = new Lazy<Toolbox>(() => new Toolbox());
        //holds the instance of form1
        private Form1 parentForm;
        // Private constructor ensures that no other instances can be created
        private Toolbox() { }

        // Public static property to get the instance
        public static Toolbox Instance
        {
            get { return _Instance.Value; }
        }
        //getter and setter for the parent form
        public Form1 ParentForm { get => parentForm; set => parentForm = value; }

       

    }
}
