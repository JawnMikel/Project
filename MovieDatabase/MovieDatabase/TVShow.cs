using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieDatabase
{
    public class TVShow : Media
    {
        public List<Episode> Episodes;

        public TVShow(int mediaId, string title, DateTime releaseDate, List<Director> directors, List<Actor> actors, Genre genres, List<Review> reviews, string sysnopsis, List<Episode> episodes) : base(mediaId, title, releaseDate, directors, actors, genres, reviews, sysnopsis)
        {
            Episodes = episodes;
        }

        public int getNumberOfSeasons()
        {
            return 0;
        }

        public int getNumberOfEpisodes()
        {
            return 0;
        }

        public int getNumberOfEpisodes(int season)
        {
            return 0;
        }

        public Episode getEpisode(int season,int episode)
        {
            return null;
        }

        public void addEpisode(int season,Episode episode)
        {

        }
    }
}
