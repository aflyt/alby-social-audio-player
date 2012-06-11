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

        private void Open_Click(object sender, EventArgs e)
        {
            song.Open(volumeTrackBar.Value);

            if (song.soundOut != null)
            {
                if (song.IsMuted() == true)
                {
                    song.UpdateVolume(0);
                }

                positionTrackbar.Maximum = song.ReturnSongLength();
                positionTrackbar.Enabled = true;
                Play.Text = "Pause";
                Update_Trackbar();
            }
        }

        private void Play_Click(object sender, EventArgs e)
        {
            if (song.ReturnPlaybackState() == PlaybackState.Paused)
            {
                Play.Text = "Pause";
            }
            if (song.ReturnPlaybackState() == PlaybackState.Playing)
            {
                Play.Text = "Play";
            }

            if (song.IsMuted() == true)
            {
                song.Play(0);
            }
            else
            {
                if (song.soundOut != null)
                {
                    song.Play(volumeTrackBar.Value);
                    Update_Trackbar();
                }
            }
            positionTrackbar.Enabled = true;
        }

        private void Stop_Click(object sender, EventArgs e)
        {
            song.Stop();
            positionTrackbar.Enabled = false;
            positionTrackbar.Value = 0;
            timeDisplay.Text = "00:00:00";

            if (song.IsMuted() == true)
            {
                song.Mute(volumeTrackBar.Value);
                UpdateMute_Colour();
            }
        }

        private void Scroll_PositionTrackbar(object sender, EventArgs e)
        {
            if (song.soundOut != null)
            {
                song.SetSongPosition(positionTrackbar.Value);
            }
            else
            {
                positionTrackbar.Enabled = false;
            }
        }

        private void VolumeTrackBar_Scroll(object sender, EventArgs e)
        {
            song.UpdateVolume(volumeTrackBar.Value);
            
            if (song.IsMuted() == true)
            {
                song.Mute(volumeTrackBar.Value);
                UpdateMute_Colour();
            }
        }

        private void Update_Trackbar()
        {
            if (song.soundOut != null)
            {
                if (song.ReturnPlaybackState() == PlaybackState.Playing)
                {
                    timerTrackbar.Start();
                }
                if (song.ReturnPlaybackState() == PlaybackState.Paused)
                {
                    timerTrackbar.Stop();
                }
                if (song.ReturnPlaybackState() == PlaybackState.Stopped)
                {
                    timerTrackbar.Stop();
                }
            }
        }

        private void SongTime_Tick(object sender, EventArgs e)
        {
            positionTrackbar.Value = song.ReturnSongPosition();
            TimeSpan currentTime = TimeSpan.FromSeconds(song.mp3Reader.CurrentTime.TotalSeconds);

            timeDisplay.Text = String.Format("{0:D2}:{1:D2}:{2:D2}", currentTime.Hours, currentTime.Minutes, currentTime.Seconds);
        }

        private void VolumeMute_Click(object sender, EventArgs e)
        {
            if (song.soundOut != null)
            {
                song.Mute(volumeTrackBar.Value);
                UpdateMute_Colour();
            }
        }

        private void UpdateMute_Colour()
        {
            if (song.IsMuted() == true)
            {
                volumeMute.ForeColor = System.Drawing.Color.Red;
            }
            else
            {
                volumeMute.ForeColor = System.Drawing.Color.White;
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            song.CloseSong();
            Application.Exit();
        }
    }
}