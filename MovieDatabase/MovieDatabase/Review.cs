using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieDatabase
{
    public class Review
    {
        public int ReviewId { get; set; }
        public User Author { get; set; }
        public string Comment { get; set; }
        public double Rating { get; set; }

        public Review(int reviewId, User author, string comment, double rating)
        {
            ReviewId = reviewId;
            Author = author;
            Comment = comment;
            Rating = rating;
        }

        public void EditReviewComment(string comment)
        {

        }

        public void EditReviewRating(double rating)
        {

        }
    }
}
