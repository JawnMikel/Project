﻿using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieDatabase.Utils;

namespace MovieDatabase
{
    /// <summary>
    /// Review class is used to represent reviews written by users.
    /// </summary>
    public class Review
    {
        public int ReviewId { get; set; }
        public int AuthorId { get; }
        public string Comment { get; private set; }
        public double Rating { get; private set; }

        /// <summary>
        /// All argument constructor for a new review.
        /// </summary>
        /// <param name="author">The author of the review.</param>
        /// <param name="comment">The comment of the review.</param>
        /// <param name="rating">The rating of the review.</param>
        /// <exception cref="ArgumentNullException">Exception thrown when the arguments are null or empty.</exception>
        /// <exception cref="ArgumentException">Exception thrown when the rating provided is invalid.</exception>
        public Review(int authorId, string comment, double rating)
        {
            // Validate the parameters
            if (String.IsNullOrEmpty(comment))
            {
                throw new ArgumentNullException("The author or comment arguments cannot be null.");
            }
            // Round the rating to one decimal point
            rating = Math.Round(rating, 1, MidpointRounding.AwayFromZero);
            if (!Util.ValidateRatingRange(rating))
            {
                throw new ArgumentException("The rating must be in the range defined by Util.LOWEST_RATING and UTIL.HIGHEST_RATING.");
            }
            ReviewId = -1; // The ID is set to -1 because its ID can only be generated by the database
            AuthorId = authorId;
            Comment = comment;
            Rating = rating;
        }

        /// <summary>
        /// Edit a review's comment.
        /// </summary>
        /// <param name="comment">The new comment of the review.</param>
        /// <exception cref="ArgumentNullException">Exception thrown when the comment argument is null or empty.</exception>
        public void EditReviewComment(string comment)
        {
            if (String.IsNullOrEmpty(Comment))
            {
                throw new ArgumentNullException("The edited comment cannot be null.");
            }
            Comment = comment;
        }

        /// <summary>
        /// Edit a review's rating.
        /// </summary>
        /// <param name="rating">The new rating of the review.</param>
        /// <exception cref="ArgumentException">Exception thrown when the rating argument is invalid.</exception>
        public void EditReviewRating(double rating)
        {
            // Round the rating to one decimal point
            rating = Math.Round(rating, 1, MidpointRounding.AwayFromZero);
            if (!Util.ValidateRatingRange(rating))
            {
                throw new ArgumentException("The rating must be in the range defined by Util.LOWEST_RATING and UTIL.HIGHEST_RATING.");
            }
            Rating = rating;
        }

        /// <summary>
        /// Check whether an object is equal to this review.
        /// </summary>
        /// <param name="obj">The object to compare.</param>
        /// <returns>A boolean indicating whether the object provided is equal to this review.</returns>
        public override bool Equals(object? obj)
        {
            return obj is Review review &&
                   ReviewId == review.ReviewId &&
                   AuthorId == review.AuthorId &&
                   Comment == review.Comment &&
                   Rating == review.Rating;
        }

        /// <summary>
        /// Generate a hashcode for this review.
        /// </summary>
        /// <returns>The hashcode of this review.</returns>
        public override int GetHashCode()
        {
            return HashCode.Combine(ReviewId, AuthorId, Comment, Rating);
        }

        /// <summary>
        /// Generate a string representation of this review.
        /// </summary>
        /// <returns>A string representation of this review.</returns>
        public override string? ToString()
        {
            return $"""
                    By: {AuthorId}
                    Rating: {Rating}
                    Comment: {Comment}
                    
                    """;
        }
    }
}
