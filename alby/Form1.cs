using System;
using System.Windows.Forms;
using System.IO;
using NAudio;
using NAudio.Wave;

namespace Alby
{
    public partial class Form1 : Form
    {
        Song song = new Song();

        public Form1()
        {
            InitializeComponent();
        }

        private void onClickOpen(object sender, EventArgs e)
        {
            song.Open();
            positionTrackbar.Maximum = song.returnSongLength();
            Update_Trackbar();
        }

        private void Play_Click(object sender, EventArgs e)
        {
            song.Play();
            Update_Trackbar();
        }

        private void Stop_Click(object sender, EventArgs e)
        {
            song.Stop();
            positionTrackbar.Value = 0;
        }

        private void Scroll_PositionTrackbar(object sender, EventArgs e)
        {
            song.setSongPosition(positionTrackbar.Value);
        }

        private void Update_Trackbar()
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

        private void songTime_Tick(object sender, EventArgs e)
        {
            positionTrackbar.Value = song.returnSongPosition();
            TimeSpan currentTime = TimeSpan.FromSeconds(song.mp3Reader.CurrentTime.TotalSeconds);

            timeDisplay.Text = String.Format("{0:D2}:{1:D2}:{2:D2}", currentTime.Hours, currentTime.Minutes, currentTime.Seconds);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            song.soundOut.Dispose();
            song.mp3Reader.Close();
            song.mp3Reader.Dispose();
            Application.Exit();
        }
    }
}
