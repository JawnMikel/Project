using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieDatabase
{
    public class Episode : Media
    {
        public int EpisodeId { get; set; }
        public int Duration { get; set; }
        public int SeasonNumber { get; set; }
        public int EpisodeNumber { get; set; }

        public Episode(int mediaId, string title, DateTime releaseDate, List<Director> directors, List<Actor> actors, Genre genres, List<Review> reviews, string sysnopsis, int episodeId, int duration, int seasonNumber, int episodeNumber) : base(mediaId, title, releaseDate, directors, actors, genres, reviews, sysnopsis)
        {
            EpisodeId = episodeId;
            Duration = duration;
            SeasonNumber = seasonNumber;
            EpisodeNumber = episodeNumber;
        }
    }
}
