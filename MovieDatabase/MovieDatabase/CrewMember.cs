using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieDatabase
{
    public abstract class CrewMember : Person
    {
        private static int _counter = 1;
        public int Id { get; set; }
        public string ImageLink { get; set; }
        public List<Review> Reviews { get; set; }
        public CrewMember(string firstName, string secondName,List<Review> reviews) : base(firstName, secondName)
        {
            Id = _counter++;
            Reviews = reviews;
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
        public double getCrewMemberRating()
        {
            if (Reviews == null || Reviews.Count == 0)
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
