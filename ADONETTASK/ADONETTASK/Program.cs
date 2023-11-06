using ADONETTASK.Models;
using ADONETTASK.Serivce;
using System.Reflection;
using System.Xml.Linq;

namespace ADONETTASK
{
    internal class Program
    {
        static void Main(string[] args)
        {

            ArtistService artistService = new ArtistService();
            MusicService musicService = new MusicService();

            Artist artist = new Artist();
            {
                Name = "Sirac";
                Surname = "Abbasov";
                Gender = "Female";
                Age = 20;
            }
            artistService.CreateArtist(artist);

            Music music = new Music();
            {
                Name = "Hoscakal";
                Duration = 220;
                CategoryId = 1;
                ArtistId = 2;
            };

            musicService.CreateMusic(music);

            List<Artist> artists = artistService.GetAllArtists();
            foreach (Artist item in artists)
            {
                Console.WriteLine($"{item.Name} {item.Surname}");
            }

            List<Music> musics = musicService.GetAllMusics();
            foreach (Music item in musics)
            {
                Console.WriteLine($"{item.Name}");
            }

            Artist artistid = artistService.GetByIdArtistId(1);
            Console.WriteLine($"{artistid.Name} {artistid.Surname}");

            Music musicid = musicService.GetByIdMusic(2);
            Console.WriteLine(musicid.Name);



        }
    }
}