using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MovieDatabase.Model
{
    /// <summary>
    /// Actor class is used to represent an Actor.
    /// </summary>
    public class Actor : CrewMember
    {
        public List<int> StarredMovies { get; set; }
        public List<int> StarredTVShows { get; set; }
        public List<int> StarredEpisodes { get; set; }

        /// <summary>
        /// All argument constructor for a new actor.
        /// </summary>
        /// <param name="firstName">The first name of the actor.</param>
        /// <param name="lastName">The last name of the actor.</param>
        /// <param name="imageLink">The image link of the picture of the actor.</param>
        public Actor(string firstName, string lastName, string imageLink) : base(firstName, lastName, imageLink)
        {
            StarredMovies = new List<int>();
            StarredTVShows = new List<int>();
            StarredEpisodes = new List<int>();
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
                $"Reviews: {string.Join(",", Reviews)}}}";
        }
    }
}
