using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieDatabase
{
    /// <summary>
    /// Actor class is used to represent an Actor.
    /// </summary>
    public class Actor : CrewMember
    {
        public List<int> StarredMovies { get; }
        public List<int> StarredTVShows { get; }
        public List<int> StarredEpisodes { get; }

        /// <summary>
        /// All argument constructor for a new actor.
        /// </summary>
        /// <param name="firstName">The first name of the actor.</param>
        /// <param name="secondName">The last name of the actor.</param>
        /// <param name="imageLink">The image link of the picture of the actor.</param>
        public Actor(string firstName, string secondName, string imageLink) : base(firstName, secondName, imageLink)
        {
            StarredMovies = new List<int>();
            StarredTVShows = new List<int>();
            StarredEpisodes = new List<int>();
        }

        /// <summary>
        /// Add a media to the appropriate starred list of this actor.
        /// </summary>
        /// <param name="media">The media to add.</param>
        /// <exception cref="ArgumentNullException">Exception thrown when the media argument is null.</exception>
        public void AddMediaToStarred(Media media)
        {
            if (media == null)
            {
                throw new ArgumentNullException("The media argument cannot be null.");
            }
            if (media is Movie)
            {
                StarredMovies.Add(media.MediaId);
            }
            else if (media is TVShow)
            {
                StarredTVShows.Add(media.MediaId);
            }
            else
            {
                StarredEpisodes.Add(media.MediaId);
            }
        }

        /// <summary>
        /// Remove a media from the appropriate starred list of this actor.
        /// </summary>
        /// <param name="media">The media to remove.</param>
        /// <exception cref="ArgumentNullException">Exception thrown when the media argument is null.</exception>
        public void RemoveMediaFromStarred(Media media)
        {
            if (media == null)
            {
                throw new ArgumentNullException("The media argument cannot be null.");
            }
            if (media is Movie)
            {
                StarredEpisodes.Remove(media.MediaId);
            }
            else if (media is TVShow)
            {
                StarredTVShows.Remove(media.MediaId);
            }
            else
            {
                StarredEpisodes.Remove(media.MediaId);
            }
        }

        /// <summary>
        /// Checks whether an object is equal to this actor.
        /// </summary>
        /// <param name="obj">The object to compare.</param>
        /// <returns>A boolean indicating whether the object provided equals this actor.</returns>
        public override bool Equals(object? obj)
        {
            return obj is Actor actor &&
                   base.Equals(obj) &&
                   EqualityComparer<List<int>>.Default.Equals(StarredMovies, actor.StarredMovies) &&
                   EqualityComparer<List<int>>.Default.Equals(StarredTVShows, actor.StarredTVShows) &&
                   EqualityComparer<List<int>>.Default.Equals(StarredEpisodes, actor.StarredEpisodes);
        }

        /// <summary>
        /// Generate a hashcode for this actor.
        /// </summary>
        /// <returns>The hashcode of this actor.</returns>
        public override int GetHashCode()
        {
            return HashCode.Combine(base.GetHashCode(), StarredMovies, StarredTVShows, StarredEpisodes);
        }

        /// <summary>
        /// Generate a string representation of this actor.
        /// </summary>
        /// <returns>A string representation of this actor.</returns>
        public override string? ToString()
        {
            return $"Actor{{Id: {Id}, FirstName: {FirstName}, LastName: {LastName}, ImageLink: {ImageLink}, " +
                $"Reviews: {String.Join(",", Reviews)}, Starred: {String.Join(",", Starred)}}}";
        }
    }
}
