namespace ConsoleApp13
{
    internal class Music
    {
        public Music(string name, int duration)
        {
            Name = name;
            Duration = duration;
        }
        public string Name { get; set; }

        public int Duration { get; set; }

        public bool IsPlaying { get; set; } = false;

        public int AmountOfDublicates { get; set; } = 0;
    }
}
