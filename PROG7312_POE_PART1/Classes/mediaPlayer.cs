using System.IO;
using System.Media;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PROG7312_POE_PART1.Classes
{
    internal class mediaPlayer
    {
        //Private static instance of the class
        private static readonly mediaPlayer instance = new mediaPlayer();
        public static mediaPlayer Instance => instance;
        /// <summary>
        /// These variables hold the sound player instances for each .wav file, this prevents
        /// the code from having to constance initialzie a new instance of the SoundPlayer
        /// overall it ensures  efficient use of resources and memroy management
        /// </summary>
        private SoundPlayer buttonHoverSoundPlayer;
        private SoundPlayer buttonClickSoundPlayer;
        private SoundPlayer gameClickSoundPlayer;
        private SoundPlayer errorSoundPlayer;
        private SoundPlayer wongameSoundPlayer;
        /// <summary>
        /// Private constructor to ensure that no other instances can be created
        /// </summary>
        private mediaPlayer()
        {
            buttonHoverSoundPlayer = InitializeSoundPlayer("buttonHover.wav");
            buttonClickSoundPlayer = InitializeSoundPlayer("buttonClick.wav");
            gameClickSoundPlayer = InitializeSoundPlayer("orderGameClick.wav");
            errorSoundPlayer = InitializeSoundPlayer("error_soundaffect.wav");
            wongameSoundPlayer = InitializeSoundPlayer("wongame_soundaffect.wav");
        }
        /// <summary>
        /// This code only runs once when the mediaPlayer is first initialized, it prevents the absolute paths to the 
        /// .wav files from repeatedly being search for.
        /// </summary>
        private SoundPlayer InitializeSoundPlayer(string fileName)
        {
            string appPath = Path.GetDirectoryName(Application.ExecutablePath);
            string relativePath = Path.Combine(appPath, "..", "..", "SoundAffects", fileName);
            string absolutePath = Path.GetFullPath(relativePath);
            return new SoundPlayer(absolutePath);
        }
        /// <summary>
        /// Task.Run() this peice of code was gotten from ChatGPT
        /// The methods simply plays the sound by using the already initiazied variables
        /// </summary>
        public void buttonHoverSoundAffect()
        {
            Task.Run(() => buttonHoverSoundPlayer.Play());
        }
        /// <summary>
        /// Task.Run() this peice of code was gotten from ChatGPT
        /// The methods simply plays the sound by using the already initiazied variables
        /// </summary>
        public void buttonClickSoundAffect()
        {
            Task.Run(() => buttonClickSoundPlayer.Play());
        }
        /// <summary>
        /// Task.Run() this peice of code was gotten from ChatGPT
        /// The methods simply plays the sound by using the already initiazied variables
        /// </summary>
        public void gameClickSoundAffect()
        {
            Task.Run(() => gameClickSoundPlayer.Play());
        }
        /// <summary>
        /// 
        /// </summary>
        public void errorSoundAffect()
        {
            Task.Run(() => errorSoundPlayer.Play());
        }
        /// <summary>
        /// 
        /// </summary>
        public void wongameSoundAffect()
        {
            Task.Run(() => wongameSoundPlayer.Play());
        }
    }
}
