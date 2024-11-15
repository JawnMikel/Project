using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieDatabase
{
    public class Director
    {
        public int DirectorId { get; set; }
        public List<Media> Directed {  get; set; }

        public Director(int directorId, List<Media> directed)
        {
            DirectorId = directorId;
            Directed = directed;
        }
    }
}
