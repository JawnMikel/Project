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
        public List<Media> Starred { get; }

        /// <summary>
        /// All argument constructor for a new actor.
        /// </summary>
        /// <param name="firstName">The first name of the actor.</param>
        /// <param name="secondName">The last name of the actor.</param>
        /// <param name="imageLink">The image link of the picture of the actor.</param>
        public Actor(string firstName, string secondName, string imageLink) : base(firstName, secondName, imageLink)
        {
            Starred = new List<Media>();
        }

        /// <summary>
        /// Add a media to the starred list of this actor.
        /// </summary>
        /// <param name="media">The media to add.</param>
        /// <exception cref="ArgumentNullException">Exception thrown when the media argument is null.</exception>
        public void AddMediaToStarred(Media media)
        {
            if (media == null)
            {
                throw new ArgumentNullException("The media argument cannot be null.");
            }
            Starred.Add(media);
        }

        /// <summary>
        /// Remove a media from the starred list of this actor.
        /// </summary>
        /// <param name="media">The media to remove.</param>
        /// <exception cref="ArgumentNullException">Exception thrown when the media argument is null.</exception>
        public void RemoveMediaFromStarred(Media media)
        {
            if (media == null)
            {
                throw new ArgumentNullException("The media argument cannot be null.");
            }
            Starred.Remove(media);
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
                   FirstName == actor.FirstName &&
                   LastName == actor.LastName &&
                   Id == actor.Id &&
                   EqualityComparer<List<Review>>.Default.Equals(Reviews, actor.Reviews) &&
                   ImageLink == actor.ImageLink &&
                   EqualityComparer<List<Media>>.Default.Equals(Starred, actor.Starred);
        }

        /// <summary>
        /// Generate a hashcode for this actor.
        /// </summary>
        /// <returns>The hashcode of this actor.</returns>
        public override int GetHashCode()
        {
            return HashCode.Combine(base.GetHashCode(), FirstName, LastName, Id, Reviews, ImageLink, Starred);
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
