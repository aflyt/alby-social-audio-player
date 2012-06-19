using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using TagLib.Mpeg;

namespace Alby
{
    class Library
    {
        protected Dictionary<String, String[,,]> libraryIndex = new Dictionary<String, String[,,]>();
        
        protected String artist;
        protected String songTitle;
        protected String albumTitle;
        protected String filename;

        public Library()
        {

        }

        public void AddToLibrary(String fileToAdd)
        {
  
        }

        public void IndexFolder()
        {
            String indexLocation = Environment.GetFolderPath(Environment.SpecialFolder.MyMusic);

            String[] files = Directory.GetFiles(indexLocation);

            foreach (String file in files)
            {
                TagLib.File tempTag = TagLib.File.Create(file);
                artist = tempTag.Tag.FirstPerformer;
                songTitle = tempTag.Tag.Title;
                albumTitle = tempTag.Tag.Album;
                filename = file;

                if (libraryIndex.ContainsKey(artist))
                {
                    //libraryIndex[artist] = [albumTitle,songTitle,filename];
                }
            }
        }
    }
}
