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
        private String artistName;
        private String songTitle;
        private String albumTitle;

        public float volume;
        private Boolean isMuted = false;

        private IWavePlayer soundOut;
        private WaveStream mp3Reader;
        private WaveChannel32 mainSoundOut;

        public void Play(String filename)
        {
            if (filename != null)
            {
                if (ReturnSongLoaded() == false)
                {
                    soundOut = new WaveOut();
                    mp3Reader = new Mp3FileReader(filename);
                    mainSoundOut = new WaveChannel32(mp3Reader);
                    soundOut.Init(mainSoundOut);
                    SetSongInfo(filename);
                }

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
        }

        public PlaybackState ReturnPlaybackState()
        {
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
            if (ReturnSongLoaded() == true)
            {
                soundOut.Stop();
                SetSongPosition(0);
            }
        }

        public void UpdateVolume(float volume)
        {
            if (ReturnSongLoaded() == true)
            {
                mainSoundOut.Volume = (float)volume / 100;
            }
        }

        public float ReturnVolume()
        {
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
            if (isMuted == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void SetSongInfo(String filename)
        {
            TagLib.File getInfo = TagLib.File.Create(filename);
            artistName = getInfo.Tag.FirstPerformer;
            songTitle = getInfo.Tag.Title;
            albumTitle = getInfo.Tag.Album;
        }

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

        public void SetSongPosition(int trackbarValue)
        {
            if (ReturnSongLoaded() == true)
            {
                mp3Reader.CurrentTime = TimeSpan.FromSeconds(trackbarValue);
            }
        }

        public int ReturnSongPosition()
        {
            return (int)mp3Reader.CurrentTime.TotalSeconds;
        }

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

        public String ReturnArtist()
        {
            return artistName;
        }

        public String ReturnSongTitle()
        {
            return songTitle;
        }

        public void CloseSong()
        {
            if (ReturnSongLoaded() == true)
            {
                mainSoundOut.Dispose();
                soundOut.Dispose();
                mp3Reader.Dispose();
            }
        }
    }
}