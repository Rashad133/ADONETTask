using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADONETTASK.Models
{
    internal class Music
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Duration { get; set; }
        public int CategoryId { get; set; }
        public int ArtistId { get; set; }

        internal void Add(object music)
        {
            throw new NotImplementedException();
        }
    }
}
