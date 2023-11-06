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
    internal class ArtistService
    {
        private Sql _database = new Sql();
        public void CreateArtist(Artist artist)
        {

            string cmd = $"INSERT INTO Artists('{artist.Name}','{artist.Surname}',{artist.Age},'{artist.Gender}')";
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

        public List<Artist> GetAllArtists()
        {
            string query = $"SELECT * FROM Artists";
            DataTable table = _database.ExecuteQuery(query);

            List<Artist> artists = new List<Artist>();

            foreach (DataRow row in table.Rows)
            {
                Artist artist = new Artist
                {
                    Id = (int)row["id"],
                    Name = row["name"].ToString(),
                    Surname = row["surname"].ToString(),
                    Age = Convert.ToInt32(row["age"]),
                    Gender = row["gender"].ToString(),
                };
                artists.Add(artist);

            }
            return artists;
        }

        public void GetByIdArtist(int id)
        {
            string query = $"SELECT * FROM Artists WHERE Id={id}";
            DataTable table = _database.ExecuteQuery(query);

            if (table.Rows.Count > 0)
            {
                Artist artist = new Artist
                {
                    Id = (int)table.Rows[0]["id"],
                    Name = table.Rows[0]["name"].ToString(),
                    Surname = table.Rows[0]["surname"].ToString(),
                    Age = Convert.ToInt32(table.Rows[0]["age"]),
                    Gender = table.Rows[0]["gender"].ToString(),
                };

            }
            else
            {
                Console.WriteLine("Artist not found");
            }

        }

        public void Delete(int id)
        {
            string cmd = $"DELETE FROM Artists WHERE Id={id}";
            _database.ExecuteCommand(cmd);
        }


    }
}
