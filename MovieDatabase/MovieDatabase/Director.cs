using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieDatabase
{
    public class Director : CrewMember
    {
        public int DirectorId { get; set; }
        public List<Media> Directed {  get; set; }

        public Director(string firstName, string secondName, List<Review> reviews, int directorId, List<Media> directed) : base(firstName, secondName, reviews)
        {
            Directed = directed;
            DirectorId = directorId;
        }
    }
}
