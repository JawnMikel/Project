using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieDatabase
{
    /// <summary>
    /// Director class is used to represent a director.
    /// </summary>
    public class Director : CrewMember
    {
        public List<Media> Directed { get; set; }

        /// <summary>
        /// All argument constructor for a new director.
        /// </summary>
        /// <param name="firstName">The first name of the director.</param>
        /// <param name="secondName">The last name of the director.</param>
        /// <param name="imageLink">The link of the picture of the director.</param>
        public Director(string firstName, string secondName, string imageLink) : base(firstName, secondName, imageLink)
        {
            Directed = new List<Media>();
        }

        /// <summary>
        /// Add a media to the directed list of this director.
        /// </summary>
        /// <param name="media">The media to add.</param>
        /// <exception cref="ArgumentNullException">Exception thrown when the media argument is null.</exception>
        public void AddMediaToDirected(Media media)
        {
            if (media == null)
            {
                throw new ArgumentNullException("The media argument cannot be null.");
            }
            Directed.Add(media);
        }

        /// <summary>
        /// Remove a media from the directed list of this director.
        /// </summary>
        /// <param name="media">The media to remove.</param>
        /// <exception cref="ArgumentNullException">Exception thrown when the media argument is null.</exception>
        public void RemoveMediaFromDirected(Media media)
        {
            if (media == null)
            {
                throw new ArgumentNullException("The media argument cannot be null.");
            }
            Directed.Remove(media);
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
                   FirstName == director.FirstName &&
                   LastName == director.LastName &&
                   Id == director.Id &&
                   EqualityComparer<List<Review>>.Default.Equals(Reviews, director.Reviews) &&
                   ImageLink == director.ImageLink &&
                   EqualityComparer<List<Media>>.Default.Equals(Directed, director.Directed);
        }

        /// <summary>
        /// Generate a hashcode for this actor.
        /// </summary>
        /// <returns>The hashcode of this actor.</returns>
        public override int GetHashCode()
        {
            return HashCode.Combine(base.GetHashCode(), FirstName, LastName, Id, Reviews, ImageLink, Directed);
        }

        /// <summary>
        /// Generate a string representation of this actor.
        /// </summary>
        /// <returns>A string representation of this actor.</returns>
        public override string? ToString()
        {
            return $"Director{{Id: {Id}, FirstName: {FirstName}, LastName: {LastName}, ImageLink: {ImageLink}, " +
               $"Reviews: {String.Join(",", Reviews)}, Directed: {String.Join(",", Directed)}}}";
        }
    }
}
