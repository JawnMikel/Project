using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieDatabase.Utils;

namespace MovieDatabase
{
    /// <summary>
    /// Movie class is used to represent a movie.
    /// </summary>
    public class Movie : Media
    {
        public int Duration { get; set; }

        /// <summary>
        /// All argument constructor for a new movie.
        /// </summary>
        /// <param name="title">The title of the movie.</param>
        /// <param name="releaseDate">The release date of the movie.</param>
        /// <param name="sysnopsis">The synopsis of the movie.</param>
        /// <param name="duration">The duration of the movie in minutes.</param>
        /// <param name="imageLink">The link of the thumbnail of the movie.</param>
        /// <exception cref="ArgumentException">Exception thrown when the duration is invalid.</exception>
        public Movie(string title, DateTime releaseDate, string sysnopsis, int duration, string imageLink) : base(title, releaseDate, sysnopsis, imageLink)
        {
            if (!Util.ValidateMediaDuration(duration))
            {
                throw new ArgumentException("The duration argument must be greater than zero.");
            }
            Duration = duration;
        }

        /// <summary>
        /// Checks whether an object is equal to this movie.
        /// </summary>
        /// <param name="obj">The object to compare.</param>
        /// <returns>A boolean indicating whether the object provided is equal to this movie.</returns>
        public override bool Equals(object? obj)
        {
            return obj is Movie movie &&
                   base.Equals(obj) &&
                   Duration == movie.Duration;
        }

        /// <summary>
        /// Generates a hashcode for this movie.
        /// </summary>
        /// <returns>The hashcode of this movie.</returns>
        public override int GetHashCode()
        {
            return HashCode.Combine(base.GetHashCode(), Duration);
        }

        /// <summary>
        /// Generate a string representation of this movie.
        /// </summary>
        /// <returns>A string representation of this movie.</returns>
        public override string? ToString()
        {
            return $"Movie{{{base.ToString()}, Duration: {Duration}}}";
        }
    }
}
