using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace MovieDatabase
{
    /// <summary>
    /// Media class is used to represent all forms of media: TVShow, Episode, or Movie.
    /// </summary>
    public abstract class Media
    {
        public int MediaId { get; set; }
        public string Title { get; }
        public DateTime ReleaseDate { get; }
        public List<Director> Directors { get; set; }
        public List<Actor> Actors { get; set;  }
        public List<Genre> Genres { get; set; }
        public List<Review> Reviews { get; set; }
        public string Synopsis { get; }
        public string ImageLink { get; }

        /// <summary>
        /// Genre enum is used to represent all of the available genres.
        /// </summary>
        public enum Genre
        {
            ACTION,
            COMEDY,
            MYSTERY,
            HORROR,
            SCI_FI,
            ROMANCE,
            THRILLER,
            DRAMA,
            MUSICAL,
            WAR,
            SUPERHERO,
            ANIMATION,
            DOCUMENTARY,
            CRIME,
            FANTASY
        }

        /// <summary>
        /// All argument constructor for a new media.
        /// </summary>
        /// <param name="title">The title of the media.</param>
        /// <param name="releaseDate">The release date of the media.</param>
        /// <param name="synopsis">The synopsis of the media.</param>
        /// <exception cref="ArgumentException">
        /// Exception thrown when the title or synopsis arguments 
        /// are null or contain only whitespaces.
        /// </exception>
        public Media(string title, DateTime releaseDate, string synopsis, string imageLink)
        {
            if (String.IsNullOrWhiteSpace(title) || String.IsNullOrWhiteSpace(synopsis))
            {
                throw new ArgumentException("The title and synopsis arguments cannot be null nor contain only whitespaces.");
            }
            MediaId = -1;
            Title = title;
            ReleaseDate = releaseDate;
            Directors = new List<Director>();
            Actors = new List<Actor>();
            Genres = new List<Genre>();
            Reviews = new List<Review>();
            Synopsis = synopsis;
            ImageLink = imageLink;
        }
        /// <summary>
        /// Adds a review to the list of reviews
        /// </summary>
        /// <param name="review">The review to add.</param>
        /// <exception cref="ArgumentNullException">Exception thrown when the review argument is null.</exception>
        public void AddReview(Review review)
        {
            if (review == null)
            {
                throw new ArgumentNullException("The review argument cannot be null.");
            }
            Reviews.Add(review);
        }

        /// <summary>
        /// Remove a review from the list of reviews.
        /// </summary>
        /// <param name="review">The review to remove.</param>
        /// <exception cref="ArgumentNullException">Exception thrown when the review argument is null.</exception>
        public void RemoveReview(Review review)
        {
            if (review == null)
            {
                throw new ArgumentNullException("The review argument cannot be null.");
            }
            Reviews.Remove(review);
        }

        /// <summary>
        /// Adds a director to the list of directors.
        /// </summary>
        /// <param name="director">The director to add.</param>
        /// <exception cref="ArgumentNullException">Exception thrown when the director argument is null.</exception>
        public void AddDirector(Director director)
        {
            if (director == null)
            {
                throw new ArgumentNullException("The director argument cannot be null.");
            }
            Directors.Add(director);
        }

        /// <summary>
        /// Remove a director from the list of directors.
        /// </summary>
        /// <param name="director">The director to remove.</param>
        /// <exception cref="ArgumentNullException">Exception thrown when the director argument is null.</exception>
        public void RemoveDirector(Director director)
        {
            if (director == null)
            {
                throw new ArgumentNullException("The director argument cannot be null.");
            }
            Directors.Remove(director);
        }

        /// <summary>
        /// Adds an actor to the list of actors.
        /// </summary>
        /// <param name="actor">The actor to add.</param>
        /// <exception cref="ArgumentNullException">Exception thrown when the actor argument is null.</exception>
        public void AddActor(Actor actor)
        {
            if (actor == null)
            {
                throw new ArgumentNullException("The actor argument cannot be null.");
            }
            Actors.Add(actor);
        }

        /// <summary>
        /// Remove a director from the list of directors.
        /// </summary>
        /// <param name="actor">The director to remove.</param>
        /// <exception cref="ArgumentNullException">Exception thrown when the director argument is null.</exception>
        public void RemoveActor(Actor actor)
        {
            if (actor == null)
            {
                throw new ArgumentNullException("The actor argument cannot be null.");
            }
            Actors.Remove(actor);
        }

        /// <summary>
        /// Adds a genre to the list of genres.
        /// </summary>
        /// <param name="genre">The genre to add.</param>
        public void AddGenre(Genre genre)
        {
            Genres.Add(genre);
        }

        /// <summary>
        /// Removes a genre from the list of genres.
        /// </summary>
        /// <param name="genre">The genre to remove.</param>
        public void RemoveGenre(Genre genre)
        {
            Genres.Remove(genre);
        }

        /// <summary>
        /// Calculates the media rating by taking the average of all the reviews.
        /// </summary>
        /// <returns>The average rating of the media.</returns>
        public double GetMediaRating()
        {
            if ( Reviews == null || Reviews.Count == 0)
            {
                return 0.0;
            }

            double total = 0.0;
            foreach (var review in Reviews)
            {
                total += review.Rating;
            }

            return total / Reviews.Count;
        }

        /// <summary>
        /// Checks whether an object is equal to this media.
        /// </summary>
        /// <param name="obj">The object to compare.</param>
        /// <returns>A boolean indicating whether the object provided is equal to this media.</returns>
        public override bool Equals(object? obj)
        {
            return obj is Media media &&
                   MediaId == media.MediaId &&
                   Title == media.Title &&
                   ReleaseDate == media.ReleaseDate &&
                   EqualityComparer<List<Director>>.Default.Equals(Directors, media.Directors) &&
                   EqualityComparer<List<Actor>>.Default.Equals(Actors, media.Actors) &&
                   EqualityComparer<List<Genre>>.Default.Equals(Genres, media.Genres) &&
                   EqualityComparer<List<Review>>.Default.Equals(Reviews, media.Reviews) &&
                   Synopsis == media.Synopsis &&
                   ImageLink == media.ImageLink;
        }

        /// <summary>
        /// Generates a hashcode for this media.
        /// </summary>
        /// <returns>The hashcode of this media.</returns>
        public override int GetHashCode()
        {
            HashCode hash = new HashCode();
            hash.Add(MediaId);
            hash.Add(Title);
            hash.Add(ReleaseDate);
            hash.Add(Directors);
            hash.Add(Actors);
            hash.Add(Genres);
            hash.Add(Reviews);
            hash.Add(Synopsis);
            hash.Add(ImageLink);
            return hash.ToHashCode();
        }

        /// <summary>
        /// Generate a partial string representation of this media.
        /// </summary>
        /// <returns>A partial string representation of this media.</returns>
        public override string? ToString()
        {
            return $"MediaId: {MediaId}, Title: {Title}, ReleaseDate: {ReleaseDate}, " +
                $"Directors: {String.Join(", ", Directors)}, Actors: {String.Join(", ", Actors)}, " +
                $"Genres: {String.Join(", ", Genres)}, Reviews: {String.Join(", ", Reviews)}, " +
                $"Synopsis: {Synopsis}, ImageLink: {ImageLink}";
        }
    }
}
