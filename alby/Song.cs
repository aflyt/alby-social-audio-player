using System;
using System.IO;
using System.Windows.Forms;
using NAudio;
using NAudio.Wave;
using TagLib.Mpeg;

namespace Alby
{
    class Song
    {
        //Initialise local variables
        private String artistName;
        private String songTitle;
        private String albumTitle;


        public float volume;
        private Boolean isMuted = false;

        //Create NAudio specific variables
        private IWavePlayer soundOut;
        private WaveStream mp3Reader;
        private WaveChannel32 soundStream;

        public void Play(String filename)
        {
            //Create Waveout instance
            soundOut = new WaveOut();
            //Create Mp3FileReader instance to read mp3 file
            mp3Reader = new Mp3FileReader(filename);
            //Create soundchannel from mp3Reader instance
            soundStream = new WaveChannel32(mp3Reader);

            //Init soundOut using soundStream to prepare to play
            soundOut.Init(soundStream);

            //Call Set SongInfo to retrieve song tag information
            SetSongInfo(filename);

            //If Song is playing call pause method, if song is paused Update song volume and call play method
            if (soundOut.PlaybackState == PlaybackState.Playing)
            {
               soundOut.Pause();
            }
            else
            {
                UpdateVolume(ReturnVolume());
                soundOut.Play();
            }
        }

        public PlaybackState ReturnPlaybackState()
        {
            //if song is loaded return the playback state of soundout
            if (ReturnSongLoaded() == true)
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
            //If song is loaded call soundouts stop method and set the song position to 0
            if (ReturnSongLoaded() == true)
            {
                soundOut.Stop();
                SetSongPosition(0);
            }
        }

        public void UpdateVolume(float volume)
        {
            //If song is loaded set the soundStream volume to passed in volume
            if (ReturnSongLoaded() == true)
            {
                soundStream.Volume = (float)volume / 100;
            }
        }

        public float ReturnVolume()
        {
            //If song is muted return 0 else return the current volume of the song
            if (isMuted == true)
            {
                return 0;
            }
            else
            {
                return volume;
            }
        }

        public void Mute()
        {
            /* Change isMuted and set relevant volume setting */
            if (isMuted == false)
            {
                isMuted = true;
                UpdateVolume(0);
            }
            else
            {
                isMuted = false;
                UpdateVolume(volume);
            }
        }

        public bool ReturnIsMuted()
        {
            //Return if song is muted 
            if (isMuted == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //Set song info variables using TagLib library
        public void SetSongInfo(String filename)
        {
            TagLib.File getInfo = TagLib.File.Create(filename);
            artistName = getInfo.Tag.FirstPerformer;
            songTitle = getInfo.Tag.Title;
            albumTitle = getInfo.Tag.Album;
        }

        //if song is loaded return the length of the song
        public int ReturnSongLength()
        {
            if (ReturnSongLoaded() == false)
            {
                return 0;
            }
            else
            {
                return (int)mp3Reader.TotalTime.TotalSeconds;
            }
        }

        //Set the position of the song via passed in trackbar value
        public void SetSongPosition(int trackbarValue)
        {
            if (ReturnSongLoaded() == true)
            {
                mp3Reader.CurrentTime = TimeSpan.FromSeconds(trackbarValue);
            }
        }

        //Return the position of the song
        public int ReturnSongPosition()
        {
            return (int)mp3Reader.CurrentTime.TotalSeconds;
        }

        //Return if the song is loaded or not
        public bool ReturnSongLoaded()
        {
            if (soundOut == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        //Return artist name
        public String ReturnArtist()
        {
            return artistName;
        }

        //Return song title
        public String ReturnSongTitle()
        {
            return songTitle;
        }

        //If song is loaded, clean up 
        public void CloseSong()
        {
            if (ReturnSongLoaded() == true)
            {
                soundStream.Dispose();
                soundOut.Dispose();
                mp3Reader.Dispose();
            }
        }
    }
}