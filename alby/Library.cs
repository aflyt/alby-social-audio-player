using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using TagLib.Mpeg;

namespace LibraryTest
{
    class Library
    {
        //Intialise Dictionary
        Dictionary<String, String[]> libraryIndex = new Dictionary<String, String[]>();

        //Initialise local variables
        protected String artist;
        protected String songTitle;
        protected String albumTitle;
        protected String filename;
        
        public Library()
        {

        }

        //Method to add a file to the library
        public void AddToLibrary(String fileToAdd)
        {

        }

        //Method to index users music folder
        public void Index()
        {
            String indexLocation = Environment.GetFolderPath(Environment.SpecialFolder.MyMusic);
            String[] directoryList = Directory.GetDirectories(indexLocation);

            foreach (String directory in directoryList)
            {
                String[] fileList = Directory.GetFiles(directory);

                foreach (String file in fileList)
                {
                    FileInfo FileInfo = new FileInfo(file);

                    if (FileInfo.Extension == ".mp3")
                    {
                        TagLib.File tempTag = TagLib.File.Create(file);
                        artist = tempTag.Tag.FirstPerformer;
                        songTitle = tempTag.Tag.Title;
                        albumTitle = tempTag.Tag.Album;
                        filename = file;
                    }

                    String[] tempSongDetails = new String[3] { songTitle, albumTitle, filename };

                    if (artist != null)
                    {
                        if (libraryIndex.ContainsKey(artist))
                        {
                            libraryIndex[artist] = tempSongDetails;
                        }
                        else
                        {
                            libraryIndex.Add(artist, tempSongDetails);
                        }
                    }
                }
            }
        }

        public Dictionary<String, String[]> ReturnIndex()
        {
            return libraryIndex;
        }
    }
}
