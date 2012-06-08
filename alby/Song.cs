﻿using System;
using System.IO;
using System.Windows.Forms;
using NAudio;
using NAudio.Wave;

namespace Alby
{
    class Song : Album
    {
        public String filename;
        public IWavePlayer soundOut;
        public WaveStream mp3Reader;
        WaveChannel32 mainSoundOut;
        WaveChannel32 volume;

        public void Open(int currentVolume)
        {
            soundOut = new WaveOut();

            volume = mainSoundOut;

            OpenFileDialog input = new OpenFileDialog();
            input.Filter = ".mp3 files (*.mp3)|*.mp3|.ogg files (*.ogg)|*.ogg|All files (*.*)|*.*";

            input.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyMusic);

            if (input.ShowDialog() == DialogResult.OK)
            {
                if (soundOut != null && soundOut.PlaybackState == PlaybackState.Playing)
                {
                    Stop();
                }

                filename = input.FileName;
                mp3Reader = new Mp3FileReader(filename);
                mainSoundOut = new WaveChannel32(mp3Reader);
                soundOut.Init(mainSoundOut);

                mainWindow.ActiveForm.Text = Path.GetFileName(filename);
                Play(currentVolume);
            }
        }

        public void Play(int currentVolume)
        {
            if (soundOut != null)
                if (soundOut.PlaybackState == PlaybackState.Playing)
                {
                    soundOut.Pause();
                }
                else
                {
                    UpdateVolume(currentVolume);
                    soundOut.Play();
                    Id3v2Tag tag = Id3v2Tag.ReadTag(mp3Reader);
                }
        }

        public void Stop()
        {
            if (soundOut != null)
            {
                soundOut.Stop();
                setSongPosition(0);
            }
        }

        public void UpdateVolume(int newVolume)
        {
            if (soundOut != null)
            {
                mainSoundOut.Volume = (float)newVolume / 100;
            }
            
        }
        
        public int returnSongLength()
        {
            if (mp3Reader == null)
            {
                return 0;
            }
            else
            {
                return (int)mp3Reader.TotalTime.TotalSeconds;
            }
        }

        public void setSongPosition(int trackbarValue)
        {
            if (mp3Reader != null)
            {
                mp3Reader.CurrentTime = TimeSpan.FromSeconds(trackbarValue);
            }
        }

        public int returnSongPosition()
        {
            return (int)mp3Reader.CurrentTime.TotalSeconds;
        }

        public float returnVolume()
        {
            return mainSoundOut.Volume;
        }
    }
}
