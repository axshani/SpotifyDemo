using System;
using System.Collections.Generic;
using System.Text;

namespace SpotifyDemo
{

    class MusicPlayer
    {
        private Queue<Song> playlist;
        private bool playing;

        public MusicPlayer()
        {
            this.playlist = new Queue<Song>();
            this.playing = false;
        }

        public void Play(Song s)
        {
            if (s != null && this.playlist.Contains(s))
            {
                Queue<Song> temp = new Queue<Song>();
                Queue<Song> newPlaylist = new Queue<Song>();

                while(this.playlist.Peek() != s){
                    temp.Enqueue(this.playlist.Dequeue());
                }

                newPlaylist.Enqueue(this.playlist.Dequeue());

                while (this.playlist.Count != 0){
                    temp.Enqueue(this.playlist.Dequeue());
                }

                while(temp.Count != 0){
                    newPlaylist.Enqueue(temp.Dequeue());
                }
                this.playlist = newPlaylist;
            } else {
                List<Song> l = new List<Song>(new Song[]{ s });
                l.AddRange(this.playlist.ToArray());
                this.playlist = new Queue<Song>(l);
            }

            this.playing = true;
        }

        public void Stop()
        {
            this.playing = false;
        }

        public Song Next()
        {
            if (this.playlist.Count == 0)
            {
                return null;
            }

            if (this.playlist.Count == 1)
            {
                this.playing = false;
            }
                
            return this.playlist.Dequeue();
        }

        public void Add(Song s)
        {
            if (!this.playlist.Contains(s))
                this.playlist.Enqueue(s);
        }
        public Song[] getPlaylist()
        {
            return this.playlist.ToArray();
        }

        public Song currentSong()
        {
            if (this.playing && this.playlist.Count > 0)
                return this.playlist.Peek();
            else
                return null;
        }
    }
}
