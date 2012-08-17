using System;
using System.Windows.Forms;
using System.IO;
using NAudio;
using NAudio.Wave;

namespace Alby
{
    public partial class mainWindow : Form
    {
        //Create new song instance
        Song song = new Song();
        
        //Initialise global variables
        String filename;
        Boolean muted;

        //Load main window
        public mainWindow()
        {
            InitializeComponent();
        }

        private void Open_Click(object sender, EventArgs e)
        {
            //Create File Dialog instance
            OpenFileDialog input = new OpenFileDialog();

            //Create File Dialog Filter
            input.Filter = ".mp3 files (*.mp3)|*.mp3|.ogg files (*.ogg)|*.ogg|All files (*.*)|*.*";

            //Set Initial File Dialog Location
            input.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyMusic);

            //If Dialog action is successful 
            if (input.ShowDialog() == DialogResult.OK)
            {
                //If a song is already loaded stop, cleanup and reinitialise instance of song
                if (song.ReturnSongLoaded() == true)
                {
                    song.Stop();
                    song.Close();

                    song = new Song();
                }

                //Set volumne of song to the volume trackbar value
                song.volume = volumeTrackBar.Value;

                //Set the song file to the dialog action filename
                filename = input.FileName;   

                //Change play button text to pause
                Play.Text = "Pause";
                
                //Run song objects play method
                song.Play(filename);
                
                //Check if song is muted. If muted set song objects volume method to 0. If not Set song volume to volumetrackbar's value
                if (muted == true)
                {
                    song.UpdateVolume(0);
                }
                else
                {
                    song.UpdateVolume(volumeTrackBar.Value);
                }

                //Set the initial position of the positioning trackbar to the length of the song and enable it
                positionTrackbar.Maximum = song.ReturnSongLength();
                positionTrackbar.Enabled = true;
                
                //Set the window titlebar to the artist name followed by the song title
                mainWindow.ActiveForm.Text = song.ReturnArtist() + " - " + song.ReturnSongTitle();
                
                //Call the update trackbar method to refresh the positioning trackbars position with the song
                Update_Trackbar();
            }
        }

        private void Play_Click(object sender, EventArgs e)
        {
            //If song is loaded enable the position trackbar
            if (song.ReturnSongLoaded() == true)
            {
                positionTrackbar.Enabled = true;
            }

            //if song is playing set the Play button text to Pause
            if (song.ReturnPlaybackState() == PlaybackState.Paused)
            {
                Play.Text = "Pause";
            }
            
            //if song is paused set the Play button text to Play
            if (song.ReturnPlaybackState() == PlaybackState.Playing)
            {
                Play.Text = "Play";
            }

            //Play the song based upon the filename loaded in the open method
            song.Play(filename);

            //Update the trackbar as the song is playing
            Update_Trackbar();
        }

        private void Stop_Click(object sender, EventArgs e)
        {
            /* call the song instance Stop method, Disable the positioning trackbar 
            and set it's value to 0, reset the timeDisplay and change the Play buttons text to Play */
            song.Stop();
            positionTrackbar.Enabled = false;
            positionTrackbar.Value = 0;
            timeDisplay.Text = "00:00:00";
            Play.Text = "Play";
        }

        private void Scroll_PositionTrackbar(object sender, EventArgs e)
        {
            //If song is loaded set song position to position trackbar value
            if (song.ReturnSongLoaded() == true)
            {
                song.SetSongPosition(positionTrackbar.Value);
            }
        }

        private void VolumeTrackBar_Scroll(object sender, EventArgs e)
        {
            //Update song volume to volume trackbar value
            song.UpdateVolume(volumeTrackBar.Value);
            
            //Check if song is muted. If muted call Song mute method and Update the mute buttons appearance
            if (song.ReturnIsMuted() == true)
            {
                song.Mute();
                UpdateMute();
            }
        }

        private void Update_Trackbar()
        {
            //If song is loaded run timerTrackbar method to update position trackbar based on songs PlaybackState
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
            //Update position trackbar based on song position
            positionTrackbar.Value = song.ReturnSongPosition();
            //Get the songs current time
            TimeSpan currentTime = TimeSpan.FromSeconds(song.ReturnSongPosition());

            //set timeDisplay textbox to the formatted current time
            timeDisplay.Text = String.Format("{0:D2}:{1:D2}:{2:D2}", currentTime.Hours, currentTime.Minutes, currentTime.Seconds);
        }

        private void VolumeMute_Click(object sender, EventArgs e)
        {
            //If song is loaded Update the mute button appearance and run the songs mute method to mute or unmute
            if (song.ReturnSongLoaded() == true)
            {
                UpdateMute();
                song.Mute();
            }
            else
            {
                //If song isn't loaded run the update mute method
                UpdateMute();
            }
        }

        private void UpdateMute()
        {
            /* if mute button is set to false, change local mute variable to true and change forecolor to red.
            If mute button is set to true, change local mute variable to false and change forecolour to white */
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
            //Run song's close method and quit application
            song.Close();
            Application.Exit();
        }

        private void content_Click(object sender, EventArgs e)
        {
            Content mainContent = new Content();
            mainContent.Show();
        }
    }
}