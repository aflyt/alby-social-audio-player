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

        String filename;
        Boolean muted;

        public mainWindow()
        {
            InitializeComponent();
        }

        private void Open_Click(object sender, EventArgs e)
        {
            OpenFileDialog input = new OpenFileDialog();

            input.Filter = ".mp3 files (*.mp3)|*.mp3|.ogg files (*.ogg)|*.ogg|All files (*.*)|*.*";

            input.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyMusic);

            if (input.ShowDialog() == DialogResult.OK)
            {
                if (song.ReturnSongLoaded() == true)
                {
                    song.Stop();
                    song.CloseSong();

                    song = new Song();
                }

                song.volume = volumeTrackBar.Value;

                filename = input.FileName;   
                Play.Text = "Pause";
                
                song.Play(filename);
                
                if (muted == true)
                {
                    song.Mute();
                }
                else
                {
                    song.UpdateVolume(volumeTrackBar.Value);
                }
                positionTrackbar.Maximum = song.ReturnSongLength();
                positionTrackbar.Enabled = true;
                
                mainWindow.ActiveForm.Text = song.ReturnArtist() + " - " + song.ReturnSongTitle();
                
                Update_Trackbar();
            }
        }

        private void Play_Click(object sender, EventArgs e)
        {
            if (song.ReturnSongLoaded() == true)
            {
                positionTrackbar.Enabled = true;
            }

            if (song.ReturnPlaybackState() == PlaybackState.Paused)
            {
                Play.Text = "Pause";
                positionTrackbar.Enabled = true;
            }
            
            if (song.ReturnPlaybackState() == PlaybackState.Playing)
            {
                Play.Text = "Play";
                positionTrackbar.Enabled = true;
            }

            song.Play(filename);
            Update_Trackbar();
        }

        private void Stop_Click(object sender, EventArgs e)
        {
            song.Stop();
            positionTrackbar.Enabled = false;
            positionTrackbar.Value = 0;
            timeDisplay.Text = "00:00:00";
            Play.Text = "Play";
        }

        private void Scroll_PositionTrackbar(object sender, EventArgs e)
        {
            if (song.ReturnSongLoaded() == true)
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
            
            if (song.ReturnIsMuted() == true)
            {
                song.Mute();
                UpdateMute();
            }
        }

        private void Update_Trackbar()
        {
            if (song.ReturnSongLoaded() == true)
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
            TimeSpan currentTime = TimeSpan.FromSeconds(song.ReturnSongPosition());

            timeDisplay.Text = String.Format("{0:D2}:{1:D2}:{2:D2}", currentTime.Hours, currentTime.Minutes, currentTime.Seconds);
        }

        private void VolumeMute_Click(object sender, EventArgs e)
        {

            if (song.ReturnSongLoaded() == true)
            {
                UpdateMute();
                song.Mute();
            }
            else
            {
                UpdateMute();
            }
        }

        private void UpdateMute()
        {
            if (volumeMute.ForeColor == System.Drawing.Color.White)
            {
                volumeMute.ForeColor = System.Drawing.Color.Red;
                muted = true;
            }
            else
            {
                volumeMute.ForeColor = System.Drawing.Color.White;
                muted = false;
            }

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            song.CloseSong();
            Application.Exit();
        }
    }
}