//  Date: 11-1-19
//  C# Mini Project - Wheel of Fortune
//  Class: Sound
//  Purpose: Plays audio files in project and disposes of resources when complete.
using NAudio.Wave;
using System.Threading;

namespace WheelOfFortune
{
    public static class Sound
    {
        //  **************************************
        //  variables
        //  ************************************** 
        internal static AudioFileReader audioFile;
        internal static WaveOutEvent outputDevice;

        //  **************************************
        //  methods
        //  ************************************** 
        // plays the specified sound file. If a milliSecond is also provided, that is used in the Thread.Sleep()
        internal static void PlaySound(string musicFile, int milliSeconds = 0)
        {
            // initialize audio device
            audioFile = new AudioFileReader(musicFile);
            outputDevice = new WaveOutEvent();
            outputDevice.Init(audioFile);

            // play and sleep after if requested
            outputDevice.Play();
            Thread.Sleep(milliSeconds);
        }

        // dispose of unmanaged audio resources
        internal static void DisposeAudio()
        {
            audioFile.Dispose();
            outputDevice.Dispose();
        }
    }
}
