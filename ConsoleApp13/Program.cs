using System.Reflection.Metadata;

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
                            Console.WriteLine("Success");
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
                else if (userInput == 2)
                {
                    Console.WriteLine("Please input name of playlist");

                    string nameOfPlaylist = Console.ReadLine();

                    if (!string.IsNullOrEmpty(nameOfPlaylist))
                    {
                        Playlist playlist = new Playlist(nameOfPlaylist);
                        playlists.Add(playlist);
                        Console.WriteLine("Success");
                    }
                    else
                    {
                        Console.WriteLine("Empty input");
                    }
                }
                else if (userInput == 3)
                {
                    if (musics.Count > 0 && playlists.Count > 0)
                    {
                        Console.WriteLine("Please input name of playlist");
                        string nameOfPlaylist = Console.ReadLine();

                        Playlist findedPlaylist = null; 

                        if (!string.IsNullOrEmpty(nameOfPlaylist))
                        {
                            foreach (Playlist playlist in playlists)
                            {
                                if (playlist.Name == nameOfPlaylist)
                                {
                                    findedPlaylist = playlist;
                                }
                            }
                            if (findedPlaylist != null)
                            {
                                Music findedMusic = null;

                                Console.WriteLine("Please input name of music");
                                string nameOfMusic = Console.ReadLine();

                                if (!string.IsNullOrEmpty(nameOfMusic))
                                {
                                    foreach (Music music in musics)
                                    {
                                        if (nameOfMusic == music.Name)
                                        {
                                            findedMusic = music;
                                        }
                                    }
                                    if (findedMusic != null)
                                    {
                                        findedPlaylist.Musics.Add(findedMusic);
                                        Console.WriteLine("Success");
                                    }
                                    else
                                    {
                                        Console.WriteLine($"Music with name \"{nameOfMusic}\" is not exist yet");
                                    }
                                }
                            }
                            else
                            {
                                Console.WriteLine($"Playlist with name \"{nameOfPlaylist}\" is not exist yet");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Empty input");
                        }
                    }
                    else if (musics.Count == 0)
                    {
                        Console.WriteLine("There is no musics yet");
                    }
                    else if (playlists.Count == 0)
                    {
                        Console.WriteLine("There is no playlists yet");
                    }
                }
            }
        }
        static void PrintInfo()
        {
            Console.WriteLine("Enter 1 to add new music");
            Console.WriteLine("Enter 2 to add new playlist");
            Console.WriteLine("Enter 3 to add music to playlist");
        }
    }
}
