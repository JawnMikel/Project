using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieDatabase
{
    public class Movie : Media
    {
        public int Duration { get; set; }

        public Movie(int mediaId, string title, DateTime releaseDate, List<Director> directors, List<Actor> actors, Genre genres, List<Review> reviews, string sysnopsis, int duration) : base(mediaId, title, releaseDate, directors, actors, genres, reviews, sysnopsis)
        {
            Duration = duration;
        }
    }
}
