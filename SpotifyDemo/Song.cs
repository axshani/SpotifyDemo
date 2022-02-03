namespace SpotifyDemo
{
    class Song
    {
        private string name;
        private string author;
        private double length;
        private string category;
        private string album;

        public Song(string name, string author, double length, string category, string album = "")
        {
            this.name = name;
            this.author = author;
            this.length = length;
            this.category = category;
            this.album = album;
        }

        public string getName()
        {
            return this.name;
        }

        public string getCategory()
        {
            return this.category;
        }

        public string getAuthor()
        {
            return this.author;
        }

        public string getAlbum()
        {
            return this.album;
        }
    }
}
