using System;
using System.Windows.Forms;
using System.IO;
using NAudio;
using NAudio.Wave;

namespace Alby
{
    public partial class mainWindow : Form
    {
        Song song = new Song();

        public mainWindow()
        {
            InitializeComponent();
        }

        private void onClickOpen(object sender, EventArgs e)
        {
            song.Open(volumeTrackBar.Value);
            if (song.soundOut != null)
            {
                positionTrackbar.Maximum = song.returnSongLength();
                positionTrackbar.Enabled = true;
                Update_Trackbar();
            }
        }

        private void Play_Click(object sender, EventArgs e)
        {
            song.Play(volumeTrackBar.Value);
            if (song.soundOut != null)
            {
                positionTrackbar.Enabled = true;
                Update_Trackbar();
            }
        }

        private void Stop_Click(object sender, EventArgs e)
        {
            song.Stop();
            positionTrackbar.Enabled = false;
            positionTrackbar.Value = 0;
            timeDisplay.Text = "00:00:00";
        }

        private void Scroll_PositionTrackbar(object sender, EventArgs e)
        {
            if (song.soundOut != null)
            {
                song.setSongPosition(positionTrackbar.Value);
            }
            else
            {
                positionTrackbar.Enabled = false;
            }
        }

        private void volumeTrackBar_Scroll(object sender, EventArgs e)
        {
            song.UpdateVolume(volumeTrackBar.Value);

            if (volumeMute.ForeColor == System.Drawing.Color.Red)
            {
                volumeMute.ForeColor = System.Drawing.Color.White;
            }
        }

        private void Update_Trackbar()
        {
            if (song.soundOut != null)
            {
                if (song.soundOut.PlaybackState == PlaybackState.Playing)
                {
                    timerTrackbar.Start();
                }
                if (song.soundOut.PlaybackState == PlaybackState.Paused)
                {
                    timerTrackbar.Stop();
                }
                if (song.soundOut.PlaybackState == PlaybackState.Stopped)
                {
                    timerTrackbar.Stop();
                }
            }
        }

        private void songTime_Tick(object sender, EventArgs e)
        {
            positionTrackbar.Value = song.returnSongPosition();
            TimeSpan currentTime = TimeSpan.FromSeconds(song.mp3Reader.CurrentTime.TotalSeconds);

            timeDisplay.Text = String.Format("{0:D2}:{1:D2}:{2:D2}", currentTime.Hours, currentTime.Minutes, currentTime.Seconds);
        }

        private void volumeMute_Click(object sender, EventArgs e)
        {
            if (song.soundOut != null)
            {
                if (song.returnVolume() != 0)
                {
                    song.UpdateVolume(0);
                    volumeMute.ForeColor = System.Drawing.Color.Red;
                }
                else
                {
                    song.UpdateVolume(volumeTrackBar.Value);
                    volumeMute.ForeColor = System.Drawing.Color.White;
                }
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (song.soundOut != null)
            {
                song.soundOut.Dispose();
                song.mp3Reader.Close();
                song.mp3Reader.Dispose();
            }
            Application.Exit();
        }
    }
}