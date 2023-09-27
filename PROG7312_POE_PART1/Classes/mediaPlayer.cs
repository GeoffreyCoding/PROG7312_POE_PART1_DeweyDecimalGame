using System;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using NAudio.Wave;
/*
 * ST10081932
 * Geoffrey Huth
 * PROG7312 Part 1
 */
namespace PROG7312_POE_PART1.Classes
{
    internal class mediaPlayer
    {
        /// <summary>
        /// Singleton instance of the media player class
        /// </summary>
        private static readonly mediaPlayer instance = new mediaPlayer();
        /// <summary>
        /// setter for the media file singleton instance
        /// </summary>
        public static mediaPlayer Instance => instance;
        /// <summary>
        /// the output variable that is used to play the sound affect
        /// </summary>
        private readonly WaveOutEvent sharedWaveOut;
        /// <summary>
        /// the file reader that reads the .wav file and then passes it to the output event handler
        /// </summary>
        private AudioFileReader sharedAudioFileReader;
        private readonly string exeLocation = AppDomain.CurrentDomain.BaseDirectory;

        // Private constructor
        private mediaPlayer()
        {
            sharedWaveOut = new WaveOutEvent();
        }

        /// <summary>
        /// Asynchronous file reading
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        private async Task<AudioFileReader> ReadAudioFileAsync(string fileName)
        {
            return await Task.Run(() =>
            {
                string relativePath = Path.Combine(exeLocation, "SoundAffects", fileName);
                string fullPath = Path.GetFullPath(relativePath);
                try
                {
                    return new AudioFileReader(fullPath);
                }
                catch (Exception ex)
                {
                    // Handle the exception here.
                    return null;
                }
            });
        }

        /// <summary>
        /// Asynchronous play sound method that utilizes the NAudio nugget package.
        /// This method calls the ReadAudioFile method and then uses the file reader and the WaveOutput to initiate the sound.
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public async Task PlaySoundAsync(string fileName)
        {
            try
            {
                sharedAudioFileReader?.Dispose();
                //looking for the specific file using the specified filename
                sharedAudioFileReader = await ReadAudioFileAsync(fileName);
        
                if (sharedWaveOut != null && sharedAudioFileReader != null)
                {
                    //stopping the previous sound
                    sharedWaveOut.Stop();
                    //initializing the new sound affect .wav file
                    sharedWaveOut.Init(sharedAudioFileReader);
                    //playing the new sound affect
                    sharedWaveOut.Play();
                }
            }
            catch (Exception ex)
            {
                // Handle the exception
            }
        }

        #region Sends the names of each of the soundaffect.wav files to the play sound 
        public async Task ButtonHoverSoundEffect()
        {
            await PlaySoundAsync("buttonHover.wav");
        }

        public async Task ButtonClickSoundEffect()
        {
            await PlaySoundAsync("buttonClick.wav");
        }

        public async Task GameClickSoundEffect()
        {
            await PlaySoundAsync("orderGameClick.wav");
        }

        public async Task ErrorSoundEffect()
        {
            await PlaySoundAsync("error_soundaffect.wav");
        }

        public async Task WinGameSoundEffect()
        {
            await PlaySoundAsync("wongame_soundaffect.wav");
        }
        #endregion
    }
}
