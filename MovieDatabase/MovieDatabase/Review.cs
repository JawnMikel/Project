using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieDatabase
{
    public class Review
    {
        private static int _nextInt = 1;
        public int ReviewId { get; set; }
        public User Author { get; set; }
        public string Comment { get; set; }
        public double Rating { get; set; }

        public Review(User author, string comment, double rating)
        {
            ReviewId = _nextInt++;
            Author = author;
            Comment = comment;
            Rating = rating;
        }

        public void editReviewComment(string comment)
        {

        }

        public void editReviewRating(double rating)
        {

        }

        public override string? ToString()
        {
            return $"""
                    By: {Author.Username}
                    Rating: {Rating}
                    Comment: {Comment}
                    
                    """;
        }
    }
}
