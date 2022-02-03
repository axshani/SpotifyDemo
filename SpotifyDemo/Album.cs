using System;
using System.Collections.Generic;
using System.Text;

namespace SpotifyDemo
{
    class Album
    {
        private string name;
        private List<Song> songs;

        public Album(string name, List<Song> songs)
        {
            this.name = name;
            this.songs = songs;
        }

        public List<Song> getSongs()
        {
            return this.songs;
        }

        public List<Song> searchSongs(string name)
        {
            List<Song> res = new List<Song>();
            for(int i = 0; i < this.songs.Count; i++)
            {
                if (this.songs[i].getName().Contains(name))
                    res.Add(this.songs[i]);
            }

            return res;
        }

        public string getCategory()
        {
            return this.songs[0].getCategory();
        }

        public int numberOfSongs()
        {
            return this.songs.Count;
        }
    }
}
