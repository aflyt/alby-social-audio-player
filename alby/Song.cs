using System;
using System.IO;
using System.Windows.Forms;
using NAudio;
using NAudio.Wave;
using IdSharp.AudioInfo;
using IdSharp.Common;
using IdSharp.Tagging.ID3v2;
using IdSharp.Tagging.ID3v1;

namespace Alby
{
    class Song : Album
    {
        protected String filename;
        protected Boolean muted;
        public IWavePlayer soundOut;
        public WaveStream mp3Reader;
        public WaveChannel32 mainSoundOut;
        
        public void Open(int currentVolume)
        {
            OpenFileDialog input = new OpenFileDialog();
            input.Filter = ".mp3 files (*.mp3)|*.mp3|.ogg files (*.ogg)|*.ogg|All files (*.*)|*.*";

            input.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyMusic);

            if (input.ShowDialog() == DialogResult.OK)
            {
                if (soundOut != null)
                {
                    Stop();
                    CloseSong();
                }

                filename = input.FileName;

                soundOut = new WaveOut();
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
                }
        }

        public PlaybackState ReturnPlaybackState()
        {
            if (soundOut != null)
            {
                if (soundOut.PlaybackState == PlaybackState.Playing)
                {
                    return PlaybackState.Playing;
                }
                else if (soundOut.PlaybackState == PlaybackState.Paused)
                {
                    return PlaybackState.Paused;
                }
                else
                {
                    return PlaybackState.Stopped;
                }
            }
            return 0;
        }

        public void Stop()
        {
            if (soundOut != null)
            {
                soundOut.Stop();
                SetSongPosition(0);
            }
        }

        public void UpdateVolume(int newVolume)
        {
            if (soundOut != null)
            {
                mainSoundOut.Volume = (float)newVolume / 100;
            }
        }

        public float ReturnVolume()
        {
            return mainSoundOut.Volume;
        }

        public void Mute(int currentVolume)
        {
            if (IsMuted() == false)
            {
                muted = true;
                mainSoundOut.Volume = 0;
            }
            else
            {
                muted = false;
                UpdateVolume(currentVolume);
            }
        }

        public bool IsMuted()
        {
            if (muted == false)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public int ReturnSongLength()
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

        public void SetSongPosition(int trackbarValue)
        {
            if (mp3Reader != null)
            {
                mp3Reader.CurrentTime = TimeSpan.FromSeconds(trackbarValue);
            }
        }

        public int ReturnSongPosition()
        {
            return (int)mp3Reader.CurrentTime.TotalSeconds;
        }

        public void CloseSong()
        {
                mainSoundOut.Dispose();
                soundOut.Dispose();
                mp3Reader.Dispose();
        }
    }
}
