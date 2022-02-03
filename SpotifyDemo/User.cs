using System;
using System.Collections.Generic;
using System.Text;

namespace SpotifyDemo
{
    enum UserType { Regular , Premium , Admin }
    class User
    {
        private string name;
        private MusicPlayer mp;
        private List<Song> likedSongs;
        private List<Song> history;
        private List<Album> likedAlbums;
        private UserType type;
        private string password;
        private string email;
        private List<string> authors;
        private List<int> authorsCounters;
        private List<string> categories;
        private List<int> categoriesCounters;
        
        public User(string name, UserType type, string password = "", string email = "")
        {
            this.name = name;
            this.mp = new MusicPlayer();
            this.likedSongs = new List<Song>();
            this.history = new List<Song>();
            this.likedAlbums = new List<Album>();
            this.type = type;
            this.password = password;
            this.email = email;
            this.authors = new List<string>();
            this.authorsCounters = new List<int>();
            this.categories = new List<string>();
            this.categoriesCounters = new List<int>();
        }

        public void Play(Song s = null)
        {
            mp.Play(s);
        }

        public void Stop()
        {
            mp.Stop();
        }

        public void Next()
        {
            Song s = mp.Next();
            if(s == null)
            {
                return;
            }

            this.history.Add(s);

            string author = s.getAuthor();
            if (this.authors.Contains(author))
            {
                int index = this.authors.IndexOf(author);
                this.authorsCounters[index]++;
            } else {
                this.authors.Add(author);
                this.authorsCounters.Add(1);
            }

            string category = s.getCategory();
            if (this.categories.Contains(category))
            {
                int index = this.categories.IndexOf(category);
                this.categoriesCounters[index]++;
            }
            else
            {
                this.categories.Add(category);
                this.categoriesCounters.Add(1);
            }
        }

        public void Like(Song s)
        {
            if (this.likedSongs.Count > 10 && this.type == UserType.Regular)
                Console.WriteLine("Regular user can like only up to 10 songs");

            if (this.likedSongs.Contains(s))
                Console.WriteLine("You already liked this song");

            this.likedSongs.Add(s);
        }

        public Song[] getHistory()
        {
            return this.history.ToArray();
        }

        public Song[] getPlaylist()
        {
            return mp.getPlaylist();
        }

        public string getName()
        {
            return this.name;
        }

        public void Add(Song s)
        {
            this.mp.Add(s);
        }

        public List<string> getTopAuthors()
        {
            return this.authors;
        }

        public List<string> getTopCategories()
        {
            return this.categories;
        }
    }
}
