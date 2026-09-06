namespace ConsoleApp13
{
    internal class Playlist
    {
        public Playlist (string name)
        {
            Name = name;
        }
        List<Music> Music { get; set; } = new List<Music> ();

        string Name { get; set; }
    }
}
