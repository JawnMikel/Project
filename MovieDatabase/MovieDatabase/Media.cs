using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace MovieDatabase
{
    public abstract class Media
    {
        public int MediaId { get; set; }
        public string Title { get; set; }
        public DateTime ReleaseDate { get; set; }
        public List<Director> Directors { get; set; }
        public List<Actor> Actors { get; set; }
        public Genre Genres { get; set; }
        public List<Review> Reviews { get; set; }
        public string Sysnopsis { get; set; }

        protected Media(int mediaId, string title, DateTime releaseDate, List<Director> directors, List<Actor> actors, Genre genres, List<Review> reviews, string sysnopsis)
        {
            MediaId = mediaId;
            Title = title;
            ReleaseDate = releaseDate;
            Directors = directors;
            Actors = actors;
            Genres = genres;
            Reviews = reviews;
            Sysnopsis = sysnopsis;
        }

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
        /// Adds a review to the list of reviews
        /// </summary>
        /// <param name="review">review</param>
        public void addReview(Review review)
        {
            Reviews.Add(review);
        }
        /// <summary>
        /// Calculates the media rating by taking the average of all the reviews
        /// </summary>
        /// <returns>the average rating</returns>
        public double getMediaRating()
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

    }
}
