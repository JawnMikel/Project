using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieDatabase.Utils;

namespace MovieDatabase
{
    /// <summary>
    /// Payment class is used to represent payments made by users for their memberships.
    /// </summary>
    public class Payment
    {
        public string CardHolderName { get; }
        public string Cvv { get; }
        public string CreditCardNum { get; }
        public DateTime ExpiryDate { get; }
        public DateTime PaymentDate { get; set; }
        
        /// <summary>
        /// All argument constructor for a new payment.
        /// </summary>
        /// <param name="cardHolderName">The card holder name.</param>
        /// <param name="cardNum">The card number.</param>
        /// <param name="expiryDate">The card's expiry date</param>
        /// <param name="cvv"></param>
        /// <exception cref="ArgumentException">Exception thrown when the arguments passed are of invalid format.</exception>
		public Payment(string cardHolderName, string cardNum, string cvv, string expiryDate)
        {
            if (!Util.ValidateNameFormat(cardHolderName))
            {
                throw new ArgumentException("The card holder's name format is invalid.");
            }
            if (!Util.ValidateCreditCard(cardNum, cvv, expiryDate))
            {
                throw new ArgumentException("Invalid format for the card information.");
            }
            CardHolderName = cardHolderName;
            CreditCardNum = cardNum;
            ExpiryDate = FormatExpiryDate(expiryDate);
            Cvv = cvv;
            PaymentDate = DateTime.MinValue; // The payment date must be set by the database
        }

        /// <summary>
        /// Convert a string expiration date of format "MM/yy" into a DateTime value.
        /// </summary>
        /// <param name="expiryDate">The string expiration date.</param>
        /// <returns>The DateTime value corresponding to the expiration date.</returns>
        private DateTime FormatExpiryDate(string expiryDate)
        {
            DateTime date = DateTime.ParseExact(expiryDate, "MM/yy", null);
            return date;
        }

        /// <summary>
        /// Check whether an object is equal to this payment.
        /// </summary>
        /// <param name="obj">The object to compare.</param>
        /// <returns>A boolean indicating whether the object is equal to this payment.</returns>
        public override bool Equals(object? obj)
        {
            return obj is Payment payment &&
                   CardHolderName == payment.CardHolderName &&
                   Cvv == payment.Cvv &&
                   CreditCardNum == payment.CreditCardNum &&
                   ExpiryDate == payment.ExpiryDate &&
                   PaymentDate == payment.PaymentDate;
        }

        /// <summary>
        /// Generate a hashcode for this payment.
        /// </summary>
        /// <returns>The hashcode of this payment.</returns>
        public override int GetHashCode()
        {
            return HashCode.Combine(CardHolderName, Cvv, CreditCardNum, ExpiryDate, PaymentDate);
        }

        /// <summary>
        /// Generate a string representation of this payment.
        /// </summary>
        /// <returns>A string representation of this payment.</returns>
        public override string? ToString()
        {
            return $"Payment{{CardHolderName: {CardHolderName}, PaymentDate: {PaymentDate}}}";
        }
    }
}