﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieDatabase
{
    public class Episode
    {
        public int Duration { get; set; }
        public int SeasonNumber { get; set; }
        public int EpisodeNumber { get; set; }

        public Episode(int duration, int seasonNumber, int episodeNumber)
        {
            Duration = duration;
            SeasonNumber = seasonNumber;
            EpisodeNumber = episodeNumber;
        }
    }
}
