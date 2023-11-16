// Removed using DocumentFormat.OpenXml.EMMA; to avoid confusion
using DocumentFormat.OpenXml.EMMA;
using System;
using System.Collections.Generic;

namespace PROG7312_POE_PART1.Classes
{
    internal class findingCallNumberObject
    {
        private static readonly findingCallNumberObject instance = new findingCallNumberObject();
        public findingCallNumberTreeHelper TreeHelper { get; private set; }

        private List<findingCallNumberTreeHelper.Node> correctAnswersList = new List<findingCallNumberTreeHelper.Node>(); 

        private findingCallNumberObject()
        {
            TreeHelper = new findingCallNumberTreeHelper();
        }

        public static findingCallNumberObject Instance
        {
            get { return instance; }
        }
        public List<findingCallNumberTreeHelper.Node> CorrectAnswersList { get => correctAnswersList; set => correctAnswersList = value; }
    }
}
