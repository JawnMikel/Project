using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieDatabase
{
    public class Movie
    {
        public int MovieId { get; set; }
        public int Duration { get; set; }

        public Movie(int movieId, int duration)
        {
            MovieId = movieId;
            Duration = duration;
        }
    }
}
