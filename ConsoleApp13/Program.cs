using System.ComponentModel.Design;
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
                else if (userInput == 4)
                {
                    Console.WriteLine("Enter name of music");
                    string nameOfMusic = Console.ReadLine();

                    Music findedMusic = null;

                    if (!string.IsNullOrEmpty (nameOfMusic))
                    {
                        foreach (Music music in musics)
                        {
                            if (music.Name == nameOfMusic)
                            {
                                findedMusic = music;
                            }
                        }
                        if (findedMusic != null)
                        {
                            Console.WriteLine($"Name of music: {findedMusic.Name}");
                            Console.WriteLine($"Duration of music: {findedMusic.Duration}");
                        }
                        else
                        {
                            Console.WriteLine("This music is no exists");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Empty input");
                    }
                }
                else if (userInput == 5)
                {
                    if (playlists.Count > 0)
                    {
                        Console.WriteLine("Please input name of playlist");
                        string nameOfPlaylist = Console.ReadLine();

                        Playlist findedPlaylist = null;
                        Music findedMusic = null;

                        foreach (Playlist playlist in playlists)
                        {
                            if (playlist.Name == nameOfPlaylist)
                            {
                                findedPlaylist = playlist;
                            }
                        }
                        if (findedPlaylist != null)
                        {
                            foreach (Music music in findedPlaylist.Musics)
                            {
                                if (music.IsPlaying == true)
                                {
                                    findedMusic = music;
                                }
                            }
                            if (findedMusic != null)
                            {
                                int indexOfPlayingMusic = findedPlaylist.Musics.IndexOf(findedMusic);
                                int indexOfNextMusic = indexOfPlayingMusic + 1;

                                int indexOfLastItemInPlaylist = findedPlaylist.Musics.Count - 1;

                                if (indexOfNextMusic <= indexOfLastItemInPlaylist)
                                {
                                    findedPlaylist.Musics[indexOfPlayingMusic].IsPlaying = false;
                                    findedPlaylist.Musics[indexOfNextMusic].IsPlaying = true;

                                    Console.WriteLine("Success");
                                }
                                else
                                {
                                    Console.WriteLine($"There is no more music's in this playlists. \"{findedMusic.Name}\" is still playing");
                                }
                            }
                            else
                            {
                                Console.WriteLine("There is no playing music's in playlist");
                            }
                        }
                        else
                        {
                            Console.WriteLine($"\"{nameOfPlaylist}\" is not exists");
                        }
                    }
                    else
                    {
                        Console.WriteLine("There is no playlists yet");
                    }
                }
                else if (userInput == 6)
                {
                    if (playlists.Count > 0)
                    {
                        Console.WriteLine("Please input name of playlist");
                        string nameOfPlaylist = Console.ReadLine();

                        Playlist findedPlaylist = null;
                        Music findedMusic = null;

                        foreach (Playlist playlist in playlists)
                        {
                            if (playlist.Name == nameOfPlaylist)
                            {
                                findedPlaylist = playlist;
                            }
                        }
                        if (findedPlaylist != null)
                        {
                            foreach (Music music in findedPlaylist.Musics)
                            {
                                if (music.IsPlaying == true)
                                {
                                    findedMusic = music;
                                }
                            }
                            if (findedMusic != null)
                            {
                                int indexOfPlayingMusic = findedPlaylist.Musics.IndexOf(findedMusic);
                                int indexOfPreviousMusic = indexOfPlayingMusic - 1;

                                if (indexOfPreviousMusic >= 0)
                                {
                                    findedPlaylist.Musics[indexOfPlayingMusic].IsPlaying = false;
                                    findedPlaylist.Musics[indexOfPreviousMusic].IsPlaying = true;

                                    Console.WriteLine("Success");
                                }
                                else
                                {
                                    Console.WriteLine($"There is no more music's in this playlists. \"{findedMusic.Name}\" is still playing");
                                }
                            }
                            else
                            {
                                Console.WriteLine("There is no playing music's in playlist");
                            }
                        }
                        else
                        {
                            Console.WriteLine($"\"{nameOfPlaylist}\" is not exists");
                        }
                    }
                    else
                    {
                        Console.WriteLine("There is no playlists yet");
                    }
                }
                else if (userInput == 7)
                {
                    if (playlists.Count > 0)
                    {
                        Console.WriteLine("Enter name of playlist");
                        string nameOfPlaylist = Console.ReadLine();

                        Playlist findedPlaylist = null;

                        foreach (Playlist playlist in playlists)
                        {
                            if (playlist.Name == nameOfPlaylist)
                            {
                                findedPlaylist = playlist;
                            }
                        }
                        if (findedPlaylist != null && findedPlaylist.Musics.Count > 0)
                        {
                            int totalDuration = 0;

                            for (int i = 0; i < findedPlaylist.Musics.Count; i++)
                            {
                                totalDuration += findedPlaylist.Musics[i].Duration;
                            }
                            Console.WriteLine($"Total duration of playlist \"{findedPlaylist.Name}\" is {totalDuration}");
                        }
                        else if (findedPlaylist == null)
                        {
                            Console.WriteLine($"Playlist \"{nameOfPlaylist}\" is not exists");
                        }
                        else if (findedPlaylist.Musics.Count == 0)
                        {
                            Console.WriteLine("This playlist is empty right now");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Playlist is empty");
                    }
                }
                else if (userInput == 8)
                {
                    if (playlists.Count > 0)
                    {
                        Console.WriteLine("Enter name of playlist");
                        string nameOfPlaylist = Console.ReadLine();

                        Playlist findedPlaylist = null;

                        foreach (Playlist playlist in playlists)
                        {
                            if (playlist.Name == nameOfPlaylist)
                            {
                                findedPlaylist = playlist;
                            }
                        }
                        if (findedPlaylist != null)
                        {
                            Music longestMusicInPlaylist = null;
                            int longestTime = 0;

                            if (findedPlaylist.Musics.Count > 0)
                            {
                                for (int i = 0; i < findedPlaylist.Musics.Count; i++)
                                {
                                    if (findedPlaylist.Musics[i].Duration > longestTime)
                                    {
                                        longestMusicInPlaylist = findedPlaylist.Musics[i];
                                        longestTime = findedPlaylist.Musics[i].Duration;
                                    }
                                }
                                if (longestMusicInPlaylist != null)
                                {
                                    Console.WriteLine($"The name of longest music is {longestMusicInPlaylist.Name}");
                                    Console.WriteLine($"The duration of longest music is {longestMusicInPlaylist.Duration}");
                                }
                            }
                            else
                            {
                                Console.WriteLine("There is no music's in this playlist yet");
                            }
                        }
                        else
                        {
                            Console.WriteLine($"Playlist \"{nameOfPlaylist}\" is not exists");
                        }
                    }
                    else
                    {
                        Console.WriteLine("There is no playlsits yet");
                    }
                }
                else if (userInput == 9)
                {
                    if (musics.Count > 0)
                    {
                        Console.WriteLine("Enter name of music");
                        string nameOfMusic = Console.ReadLine();

                        Music findedMusic = null;

                        foreach (Music music in musics)
                        {
                            if (nameOfMusic == music.Name)
                            {
                                findedMusic = music;
                            }
                        }
                        if (findedMusic != null)
                        {
                            findedMusic.IsPlaying = true;
                        }
                    }
                    else
                    {
                        Console.WriteLine("There is no music's yet");
                    }
                }
            }
        }
        static void PrintInfo()
        {
            Console.WriteLine("Enter 1 to add new music");
            Console.WriteLine("Enter 2 to add new playlist");
            Console.WriteLine("Enter 3 to add music to playlist");
            Console.WriteLine("Enter 4 to find music by name");
            Console.WriteLine("Enter 5 to play next music");
            Console.WriteLine("Enter 6 to play previous music");
            Console.WriteLine("Enter 7 to see total duration of playlist");
            Console.WriteLine("Enter 8 to see longest music");
            Console.WriteLine("Enter 9 to mark music as playing");
        }
    }
}
