using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieDatabase.Model
{
    /// <summary>
    /// Director class is used to represent a director.
    /// </summary>
    public class Director : CrewMember
    {
        public List<int> DirectedMovies { get; set; }
        public List<int> DirectedTVShows { get; set; }
        public List<int> DirectedEpisodes { get; set; }

        /// <summary>
        /// All argument constructor for a new director.
        /// </summary>
        /// <param name="firstName">The first name of the director.</param>
        /// <param name="lastName">The last name of the director.</param>
        /// <param name="imageLink">The link of the picture of the director.</param>
        public Director(string firstName, string lastName, string imageLink) : base(firstName, lastName, imageLink)
        {
            DirectedMovies = new List<int>();
            DirectedTVShows = new List<int>();
            DirectedEpisodes = new List<int>();
        }

        /// <summary>
        /// Checks whether an object is equal to this director.
        /// </summary>
        /// <param name="obj">The object to compare.</param>
        /// <returns>A boolean indicating whether the object provided equals this director.</returns>
        public override bool Equals(object? obj)
        {
            return obj is Director director &&
                   base.Equals(obj) &&
                   EqualityComparer<List<int>>.Default.Equals(DirectedMovies, director.DirectedMovies) &&
                   EqualityComparer<List<int>>.Default.Equals(DirectedTVShows, director.DirectedTVShows) &&
                   EqualityComparer<List<int>>.Default.Equals(DirectedEpisodes, director.DirectedEpisodes);
        }

        /// <summary>
        /// Generate a hashcode for this actor.
        /// </summary>
        /// <returns>The hashcode of this actor.</returns>
        public override int GetHashCode()
        {
            return HashCode.Combine(base.GetHashCode(), DirectedMovies, DirectedTVShows, DirectedEpisodes);
        }

        /// <summary>
        /// Generate a string representation of this actor.
        /// </summary>
        /// <returns>A string representation of this actor.</returns>
        public override string? ToString()
        {
            return $"Director{{Id: {Id}, FirstName: {FirstName}, LastName: {LastName}, ImageLink: {ImageLink}, " +
               $"Reviews: {string.Join(",", Reviews)}}}";
        }
    }
}
