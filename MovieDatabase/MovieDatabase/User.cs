﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieDatabase.Utils;

namespace MovieDatabase
{
    /// <summary>
    /// User class is used to represent a user of the application.
    /// </summary>
    public class User
    {
        private const int MAX_REVIEWS_REGULAR = 5;
        private string _userName;
        private string _password;
        private string _firstName;
        private string _lastName;
        private DateTime _dob;

        public int Id { get; set; }
        public string Username
        {
            get => _userName;
            set
            {
                if (!Util.ValidateUsernameFormat(value))
                {
                    throw new ArgumentException("The username's format is invalid.");
                }
                _userName = value;
            }
        }
        public string Password
        {
            get => _password;
            set
            {
                if (!Util.ValidatePasswordFormat(value))
                {
                    throw new ArgumentException("The password's format is invalid.");
                }
                _password = value;
            }
        }
        public string FirstName
        {
            get => _firstName;
            set
            {
                if (!Util.ValidateNameFormat(value))
                {
                    throw new ArgumentException("The firstname's format is invalid.");
                }
                _firstName = value;
            }
        }
        public string LastName
        {
            get => _lastName;
            set
            {
                if (!Util.ValidateNameFormat(value))
                {
                    throw new ArgumentException("The lastname's format is invalid.");
                }
                _lastName = value;
            }
        }
        public DateTime Dob
        {
            get => _dob;
            set
            {
                if (!Util.ValidateUserAge(value))
                {
                    throw new ArgumentException("The lastname's format is invalid."); 
                }
                _dob = value;
            }
        }
        public List<Review> WrittenReviews { get; }
        public List<Media> WatchList { get; }
        public Payment? MembershipPayment { get; private set; }
        public Memberships Membership { get; set; } // TODO: make setter private

        /// <summary>
        /// Memberships enum used to represent the two available membership types.
        /// </summary>
        public enum Memberships
        {
            REGULAR,
            PREMIUM
        }

        /// <summary>
        /// All argument constructor for a new user.
        /// </summary>
        /// <param name="username">The username of the user.</param>
        /// <param name="password">The password of the user.</param>
        /// <param name="firstName">The first name of the user.</param>
        /// <param name="lastName">The last name of the user.</param>
        /// <param name="dob">The date of birth of the user.</param>
        /// <param name="membership">The membership of the user.</param>
        /// <exception cref="ArgumentException">Exception thrown when the arguments are not of the correct format.</exception>
        public User(string username, string password, string firstName, string lastName, DateTime dob, Memberships membership)
        {
            Id = -1; // Set the -1 since the ID can only be generated by the database
            Username = username;
            Password = password;
            FirstName = Util.ToPascalCase(firstName);
            LastName = Util.ToPascalCase(lastName);
            Dob = dob;
            Membership = membership;
            WrittenReviews = new List<Review>();
            WatchList = new List<Media>();
        }

        // TODO: REMOVE -----------
        /// <summary>
        /// Passes a username and password and checks if they match with the fields of the user
        /// </summary>
        /// <param name="username">username</param>
        /// <param name="password">password</param>
        /// <returns>True if the credentials match or returns false if the credentials do not match</returns
        public bool Login(string username, string password)
        {
            return Username == username && Password == password;
        }

        /// <summary>
        /// Add a media to the watch list.
        /// </summary>
        /// <param name="media">The media to add.</param>
        /// <exception cref="ArgumentNullException">Exception thrown when the media argument is null.</exception>
        public void AddMediaToWatchList(Media media)
        {
            if (media == null)
            {
                throw new ArgumentNullException("The media argument cannot be null.");
            }
            WatchList.Add(media);
        }

        /// <summary>
        /// Remove a media from the watch list.
        /// </summary>
        /// <param name="media">The media to remove.</param>
        /// <exception cref="ArgumentNullException">Exception thrown when the media argument is null.</exception>
        public void RemoveMediaFromWatchList(Media media)
        {
            if (media == null)
            {
                throw new ArgumentNullException("The media argument cannot be null.");
            }
            WatchList.Remove(media);
        }

        /// <summary>
        /// Write a new review.
        /// </summary>
        /// <param name="comment">The comment of the review.</param>
        /// <param name="rating">The rating associated with the review.</param>
        /// <returns>
        /// The review written. Null if the user has a regular membership
        /// and already wrote the MAX_REVIEWS_REGULAR number of reviews.
        /// </returns>
        public Review? WriteReview(string comment, double rating)
        {
            if (Membership == Memberships.REGULAR && WatchList.Count >= MAX_REVIEWS_REGULAR)
            {
                throw new InvalidOperationException("The user already reached the maximum number of reviews for his regular membership.");
            }
            Review review = new Review(this, comment, rating);
            WrittenReviews.Add(review);
            return review;
        }

        /// <summary>
        /// Upgrade the user's membership.
        /// </summary>
        /// <param name="cardHolderName">The card holder name.</param>
        /// <param name="cardNum">The card number.</param>
        /// <param name="cvv">The card's security code.</param>
        /// <param name="expiryDate">The card's expiration date.</param>
        /// <returns>The Payment made by the user.</returns>
        /// <exception cref="InvalidOperationException">Exception thrown when the user already has a premium membership.</exception>
        public Payment UpgradeMembership(string cardHolderName, string cardNum, string cvv, string expiryDate)
        {
            if (MembershipPayment != null)
            {
                throw new InvalidOperationException("The user already has a premium membership.");
            }
            Payment payment = new Payment(cardHolderName, cardNum, cvv, expiryDate);
            MembershipPayment = payment;
            return payment;
        }

        /// <summary>
        /// Check whether an object is equal to this user.
        /// </summary>
        /// <param name="obj">The object to compare.</param>
        /// <returns>A boolean indicating whether the object and this user are equal.</returns>
        public override bool Equals(object? obj)
        {
            return obj is User user &&
                   Id == user.Id &&
                   Username == user.Username &&
                   Password == user.Password &&
                   FirstName == user.FirstName &&
                   LastName == user.LastName &&
                   Dob == user.Dob &&
                   EqualityComparer<List<Review>>.Default.Equals(WrittenReviews, user.WrittenReviews) &&
                   EqualityComparer<List<Media>>.Default.Equals(WatchList, user.WatchList) &&
                   Membership == user.Membership;
        }

        /// <summary>
        /// Generate a hashcode for this user.
        /// </summary>
        /// <returns>The hashcode for this user.</returns>
        public override int GetHashCode()
        {
            HashCode hash = new HashCode();
            hash.Add(Id);
            hash.Add(Username);
            hash.Add(Password);
            hash.Add(FirstName);
            hash.Add(LastName);
            hash.Add(Dob);
            hash.Add(WrittenReviews);
            hash.Add(WatchList);
            hash.Add(Membership);
            return hash.ToHashCode();
        }

        /// <summary>
        /// Generate a string representation of this user.
        /// </summary>
        /// <returns>A string representation of this user.</returns>
        public override string? ToString()
        {
            return $"User{{ID: {Id}, Username: {Username}}}";
        }
    }
}
