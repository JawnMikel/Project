using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieDatabase.Utils;

namespace MovieDatabase.Model
{
    /// <summary>
    /// Episode class is used to represent an episode.
    /// </summary>
    public class Episode : Media
    {
        public int TVShowId { get; set; }
        public int Duration { get; }
        public int SeasonNumber { get; }
        public int EpisodeNumber { get; }

        /// <summary>
        /// All argument constructor for a new episode.
        /// </summary>
        /// <param name="title">The title of the episode.</param>
        /// <param name="releaseDate">The release date of the episode.</param>
        /// <param name="sysnopsis">The synopsis of the episode.</param>
        /// <param name="imageLink">The link of the thumbnail of the episode.</param>
        /// <param name="duration">The duration of the episode in minutes.</param>
        /// <param name="seasonNumber">The season number.</param>
        /// <param name="episodeNumber">The episode number.</param>
        /// <exception cref="ArgumentException">Exception thrown when the duration argument is invalid.</exception>
        public Episode(string title, DateTime releaseDate, string sysnopsis, string imageLink, int duration, int seasonNumber, int episodeNumber) : base(title, releaseDate, sysnopsis, imageLink)
        {
            if (!Util.ValidateMediaDuration(duration))
            {
                throw new ArgumentException("The duration must be greater than zero.");
            }
            Duration = duration;
            SeasonNumber = seasonNumber;
            EpisodeNumber = episodeNumber;
            TVShowId = -1;
        }

        /// <summary>
        /// Checks whether an object is equal to this episode.
        /// </summary>
        /// <param name="obj">The object to compare.</param>
        /// <returns>A boolean indicating whether the object provided is equal to this episode.</returns>
        public override bool Equals(object? obj)
        {
            return obj is Episode episode &&
                   base.Equals(obj) &&
                   TVShowId == episode.TVShowId &&
                   Duration == episode.Duration &&
                   SeasonNumber == episode.SeasonNumber &&
                   EpisodeNumber == episode.EpisodeNumber;
        }

        /// <summary>
        /// Generates a hashcode for this episode.
        /// </summary>
        /// <returns>The hashcode of this episode.</returns>
        public override int GetHashCode()
        {
            return HashCode.Combine(base.GetHashCode(), TVShowId, Duration, SeasonNumber, EpisodeNumber);
        }

        /// <summary>
        /// Generate a string representation of this episode.
        /// </summary>
        /// <returns>A string representation of this episode.</returns>
        public override string? ToString()
        {
            return $"Episode{{{base.ToString()}, TVShowId: {TVShowId}, Duration: {Duration}, " +
                $"EpisodeNumber: {EpisodeNumber}, SeasonNumber: {SeasonNumber}}}";
        }
    }
}
