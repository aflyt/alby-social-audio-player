using System;
using System.IO;
using System.Windows.Forms;
using NAudio;
using NAudio.Wave;

namespace Alby
{
    class Song
    {
        public String filename;
        public IWavePlayer soundOut;
        public WaveStream mp3Reader;
        WaveChannel32 mainSoundOut;
        WaveChannel32 volume;


        public void Open()
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

                Form1.ActiveForm.Text = Path.GetFileName(filename);
                Play();
            }
            else
            {
                MessageBox.Show("Couldn't play file!");
            }
        }

        public void Play()
        {
            if (soundOut == null)
            {
                MessageBox.Show("You haven't loaded a file yet!");
            }
            else if (soundOut.PlaybackState == PlaybackState.Playing)
            {
                soundOut.Pause();
            }
            else
            {
                soundOut.Play();
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
        
        public int returnSongLength()
        {
            return (int)mp3Reader.TotalTime.TotalSeconds;
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
    }
}
