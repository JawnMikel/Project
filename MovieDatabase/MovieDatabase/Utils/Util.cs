using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace MovieDatabase.Utils
{
    public class Util
    {

        public static CultureInfo cultureEn = new CultureInfo("en-CA");
        public static CultureInfo cultureFr = new CultureInfo("en-CA");
        public const int LOWEST_RATING = 0;
        public const int HIGHEST_RATING = 5;

        /// <summary>
        /// Validates the card information (Card#, cvv, expiry date)
        /// </summary>
        /// <param name="creditCardNumber">Card number</param>
        /// <param name="cvv">CVV</param>
        /// <param name="expiryDate">ExpiryDate</param>
        /// <returns>true if they are formatted properly</returns>
        public static bool ValidateCreditCard(string creditCardNumber, string cvv, string expiryDate)
        {
            if (creditCardNumber.Length != 12 || !creditCardNumber.All(char.IsDigit))
            {
                return false;
            }

            if (cvv.Length != 3 && !cvv.All(char.IsDigit))
            {
                return false;
            }

            if (!DateTime.TryParseExact(expiryDate, "MM/yy", null, System.Globalization.DateTimeStyles.None, out DateTime parsedExpiryDate))
            {
                return false;
            }

            if (parsedExpiryDate < DateTime.Now)
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// Validate the format of a name.
        /// The accepted characters any letter from any alphabet and spaces.
        /// </summary>
        /// <param name="name">The name to validate.</param>
        /// <returns>A boolean indicating whether the name is valid.</returns>
        public static bool ValidateNameFormat(string name)
        {
            if (String.IsNullOrEmpty(name))
            {
                return false;
            }
            // Match any letter and space.
            // No two consecutive spaces are allowed
            const string regex = @"^([\p{L}]+ ?)+$";

            return Regex.IsMatch(name, regex);
        }

        /// <summary>
        /// Returns the first letter to uppercase and the rest to lowercase.
        /// </summary>
        /// <param name="str">name</param>
        /// <returns>The first letter uppercase and all the rest to lowercase</returns>
        public static string ToPascalCase(string str)
        {
            if (string.IsNullOrWhiteSpace(str))
                return str;

            return char.ToUpper(str[0]) + str.Substring(1).ToLower();        
        }

        /// <summary>
        /// Changes the language between English and French.
        /// </summary>
        public static void language()
        {
            if (Thread.CurrentThread.CurrentCulture.Equals(cultureEn))
            {
                Thread.CurrentThread.CurrentCulture = cultureFr;
                Thread.CurrentThread.CurrentUICulture = cultureFr;
            } 
            else
            {
                Thread.CurrentThread.CurrentCulture = cultureEn;
                Thread.CurrentThread.CurrentUICulture = cultureEn;
            }
        }

        /// <summary>
        /// Takes the DataTime from and calculates its age by subtracting from todays date.
        /// </summary>
        /// <param name="dob">Birthday</param>
        /// <returns>Returns true if the user is 18 years and older. Returns false if the user is under 18 years old. </returns>
        public static bool ValidateAge(DateTime dob)
        {
            int age = DateTime.Now.Year - dob.Year;
            if (dob > DateTime.Now.AddYears(-age)) 
                age--;
            return age >= 18;
        }

        /// <summary>
        /// Validates the rating range.
        /// The rating must be between the LOWEST_RATING and HIGHEST_RATING constants (both are inclusive).
        /// </summary>
        /// <param name="rating">The rating.</param>
        /// <returns>A boolean indicating whether the rating is valid.</returns>
        public static bool ValidateRatingRange(double rating)
        {
            return rating >= LOWEST_RATING && rating <= HIGHEST_RATING;
        }
    }
}
