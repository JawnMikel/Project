using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieDatabase.Model
{
    /// <summary>
    /// TVShow class is used to represent a tv show.
    /// </summary>
    public class TVShow : Media
    {
        public List<Episode> Episodes { get; set; }

        /// <summary>
        /// All argument constructor for a new tv show
        /// </summary>
        /// <param name="title">The title of the tv show.</param>
        /// <param name="releaseDate">The release date of the tv show.</param>
        /// <param name="sysnopsis">The synopsis of the tv show.</param>
        public TVShow(string title, DateTime releaseDate, string sysnopsis, string imageLink) : base(title, releaseDate, sysnopsis, imageLink)
        {
            Episodes = new List<Episode>();
        }

        /// <summary>
        /// Get the number of seasons in the tv show.
        /// </summary>
        /// <returns>The number of seasons in the tv show.</returns>
        public int GetNumberOfSeasons()
        {
            return Episodes.Select(e => e.SeasonNumber).Max(); ;
        }

        /// <summary>
        /// Get the total number of episodes.
        /// </summary>
        /// <returns></returns>
        public int GetNumberOfEpisodes()
        {
            return Episodes.Count;
        }

        /// <summary>
        /// Get the number of episodes in a season.
        /// </summary>
        /// <param name="seasonNumber">The season to filter by.</param>
        /// <returns>The number of episodes in the season specified.</returns>
        public int GetNumberOfEpisodes(int seasonNumber)
        {
            if (seasonNumber < 1 || seasonNumber > GetNumberOfSeasons())
            {
                throw new ArgumentException("The seasonNumber argument must be between 1 and the total number of seasons.");
            }
            return Episodes.Where(e => e.SeasonNumber == seasonNumber).Count();
        }

        /// <summary>
        /// Get the episode designated by seasonNumber and episodeNumber
        /// </summary>
        /// <param name="seasonNumber">The season number.</param>
        /// <param name="episodeNumber">The episode number.</param>
        /// <returns>The episode designated by seasonNumber and episodeNumber.</returns>
        public Episode GetEpisode(int seasonNumber, int episodeNumber)
        {
            if (seasonNumber < 1 || seasonNumber > GetNumberOfSeasons())
            {
                throw new ArgumentException("The seasonNumber argument must be between 1 and the total number of seasons.");
            }
            if (episodeNumber < 1 || episodeNumber > GetNumberOfEpisodes(seasonNumber))
            {
                throw new ArgumentException("The episodeNumber must be between 1 and the total number of episodes in the season.");
            }
            return Episodes.Where(e => e.SeasonNumber == seasonNumber && e.EpisodeNumber == episodeNumber).First();
        }

        /// <summary>
        /// Add an episode to the list of episodes.
        /// </summary>
        /// <param name="episode">The episode to add.</param>
        /// <exception cref="ArgumentNullException">Exception thrown when the episode argument is null.</exception>
        public void AddEpisode(Episode episode)
        {
            if (episode == null)
            {
                throw new ArgumentNullException("The episode argument cannot be null.");
            }
            // Only add if not already present
            if (!Episodes.Contains(episode))
            {
                episode.TVShowId = MediaId; // Link the episode to this tv show
                Episodes.Add(episode);
            }
        }

        /// <summary>
        /// Remove an episode from the list of episodes.
        /// </summary>
        /// <param name="episode">The episode to remove.</param>
        /// <exception cref="ArgumentNullException">Exception thrown when the episode argument is null.</exception>
        public void RemoveEpisode(Episode episode)
        {
            if (episode == null)
            {
                throw new ArgumentNullException("The episode argument cannot be null.");
            }
            Episodes.Remove(episode);
        }

        /// <summary>
        /// Checks whether an object is equal to this tv show.
        /// </summary>
        /// <param name="obj">The object to compare.</param>
        /// <returns>A boolean indicating whether the object provided is equal to this tv show.</returns>
        public override bool Equals(object? obj)
        {
            return obj is TVShow show &&
                   base.Equals(obj) &&
                   EqualityComparer<List<Episode>>.Default.Equals(Episodes, show.Episodes);
        }

        /// <summary>
        /// Generates a hashcode for this tv show.
        /// </summary>
        /// <returns>The hashcode of this tv show.</returns>
        public override int GetHashCode()
        {
            return HashCode.Combine(base.GetHashCode(), Episodes);
        }

        /// <summary>
        /// Generate a string representation of this tv show.
        /// </summary>
        /// <returns>A string representation of this tv show.</returns>
        public override string? ToString()
        {
            return $"TVShow{{{base.ToString()}, Episodes: {string.Join(", ", Episodes)}}}";
        }
    }
}
