namespace ConsoleApp13
{
    internal class Playlist
    {
        public Playlist (string name)
        {
            Name = name;
        }
        public List<Music> Musics { get; set; } = new List<Music> ();

        public string Name { get; set; }
    }
}
