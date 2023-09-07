using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROG7312_POE_PART1.Classes
{
    internal class leaderboardTracker
    {
        private static readonly leaderboardTracker instance = new leaderboardTracker();
        public static leaderboardTracker Instance => instance;

        private int highestScore;
        private int currentScore;
        private List<int> scoresList;
    }
}
