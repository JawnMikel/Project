using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieDatabase
{
    public class TVShow
    {
        public List<Episode> Episodes;

        public TVShow(List<Episode> episodes)
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
