namespace ConsoleApp13
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Music> musics = new List<Music>();
            List<Playlist> playlists = new List<Playlist>();

            bool go = true;
            while (go)
            {
                PrintInfo();
                int.TryParse(Console.ReadLine(), out int userInput);

                if (userInput == 1)
                {
                    Console.WriteLine("Please input name of music");
                    string nameOfMusic = Console.ReadLine();

                    if (!string.IsNullOrEmpty(nameOfMusic))
                    {
                        Console.WriteLine("Please input duration of music");
                        bool isParseSucces = int.TryParse(Console.ReadLine(), out int duration);
                        if (isParseSucces)
                        {
                            Music music = new Music(nameOfMusic, duration);
                            musics.Add(music);
                        }
                        else
                        {
                            Console.WriteLine("Duration must to be a number");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Empty input");
                    }
                }
            }
        }
        static void PrintInfo()
        {
            Console.WriteLine("Enter 1 to add new music");
        }
    }
}
