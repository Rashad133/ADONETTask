using ADONETTASK.Data;
using ADONETTASK.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADONETTASK.Serivce
{
    internal class MusicService
    {
        private Sql _database = new Sql();

        public void Add(Music music)
        {

            string cmd = $"INSERT INTO Musics('{music.Name}',{music.Duration},{music.CategoryId},{music.ArtistId})";
            int result = _database.ExecuteCommand(cmd);

            if (result > 0)
            {
                Console.WriteLine("Command successfully completed");
            }
            else
            {
                Console.WriteLine("Error occured");
            }

        }

        public List<Music> GetAllMusics()
        {
            string query = $"SELECT * FROM Musics";
            DataTable table = _database.ExecuteQuery(query);

            List<Music> musics = new List<Music>();

            foreach (DataRow row in table.Rows)
            {
                Music musics = new Music
                {
                    Id = (int)row["id"],
                    Name = row["name"].ToString(),
                    Duration = (int)row["duration"],
                    CategoryId = (int)row["categoryId"],
                    ArtistId = (int)row["artistId"],

                };
                musics.Add(musics);

            }
            return musics;


        }


        public void GetByIdMusic(int id)
        {
            string query = $"SELECT * FROM Musics WHERE Id={id}";
            DataTable table = _database.ExecuteQuery(query);

            if (table.Rows.Count > 0)
            {
                Music music = new Music
                {
                    Id = (int)table.Rows[0]["id"],
                    Name = table.Rows[0]["name"].ToString(),
                    Duration = (int)table.Rows[0]["duration"],
                    CategoryId = (int)table.Rows[0]["categoryId"],
                    ArtistId = (int)table.Rows[0]["artistId"]
                };

            }

            else
            {
                Console.WriteLine("Music not found");
            }

        }


        public void Delete(int id)
        {
            string cmd = $"DELETE FROM Musics WHERE Id={id}";
            _database.ExecuteCommand(cmd);
        }
    }
}
