using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PROG7312_POE_PART1.Classes
{
    internal class mediaPlayer
    {
        // Private static instance of the class
        private static readonly mediaPlayer instance = new mediaPlayer();

        // Public static method to return the instance
        public static mediaPlayer Instance => instance;

        // Private constructor to ensure that no other instances can be created
        private mediaPlayer() { }

        public void buttonHoverSoundAffect()
        {
            string appPath = Path.GetDirectoryName(Application.ExecutablePath);
            string relativePath = Path.Combine(appPath, "..", "..", "SoundAffects", "buttonHover.wav");
            string absolutePath = Path.GetFullPath(relativePath);
            SoundPlayer soundPlayer = new SoundPlayer(absolutePath);
            soundPlayer.Play();
        }

        public void buttonClickSoundAffect()
        {
            string appPath = Path.GetDirectoryName(Application.ExecutablePath);
            string relativePath = Path.Combine(appPath, "..", "..", "SoundAffects", "buttonClick.wav");
            string absolutePath = Path.GetFullPath(relativePath);
            SoundPlayer soundPlayer = new SoundPlayer(absolutePath);
            soundPlayer.Play();
        }
    }
}
