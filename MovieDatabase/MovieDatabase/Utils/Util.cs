using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace MovieDatabase.Utils
{
    /// <summary>
    /// Util class is used to provide util methods globally (mostly input validation).
    /// </summary>
    public class Util
    {
        public static CultureInfo cultureEn = new CultureInfo("en-Us");
        public static CultureInfo cultureFr = new CultureInfo("fr-FR");
        public const int LOWEST_RATING = 0;
        public const int HIGHEST_RATING = 5;
        public const int MAX_NAME_LENGTH = 100;

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

            if (cvv.Length != 3 || !cvv.All(char.IsDigit))
            {
                return false;
            }

            if (!DateTime.TryParseExact(expiryDate, "MM/yy", null, DateTimeStyles.None, out DateTime parsedExpiryDate))
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
        /// The accepted characters are any letter from any alphabet and spaces.
        /// The name must start and end with a letter.
        /// The name's length must be less than or equal to the MAX_NAME_LENGTH.
        /// </summary>
        /// <param name="name">The name to validate.</param>
        /// <returns>A boolean indicating whether the name is valid.</returns>
        public static bool ValidateNameFormat(string name)
        {
            if (String.IsNullOrEmpty(name))
            {
                return false;
            }
            if (name.Length > MAX_NAME_LENGTH)
            {
                return false;
            }
            // Match any letter and space
            // No two consecutive spaces are allowed
            const string regex = @"^([\p{L}]+ ?)+\p{L}$";

            return Regex.IsMatch(name, regex);
        }

        /// <summary>
        /// Validate the format of a username.
        /// The accepted characters are any letter from any alphabet and spaces.
        /// The username must start and end with a letter or digit.
        /// The username's length must be less than or equal to MAX_NAME_LENGTH.
        /// </summary>
        /// <param name="username"></param>
        /// <returns>A boolean indicating whether the username's format is valid.</returns>
        public static bool ValidateUsernameFormat(string username)
        {
            if (String.IsNullOrEmpty(username))
            {
                return false;
            }
            if (username.Length > MAX_NAME_LENGTH)
            {
                return false;
            }
            // Match any combination of letters, spaces, and digits
            // The match must start and end with a letter or digit
            const string regex = @"^[\p{L}0-9][\p{L}0-9 ]+[\p{L}0-9]$";

            return Regex.IsMatch(username, regex);
        }

        /// <summary>
        /// Validate the format of a password.
        /// The accepted characters are any letter, digit, and the following special characters:
        /// ! @ # $ % ^ & * ( )
        /// No spaces are allowed.
        /// The password's length must be between 8 and 50 characters inclusively.
        /// </summary>
        /// <param name="password">The password to validate.</param>
        /// <returns></returns>
        public static bool ValidatePasswordFormat(string password)
        {
            if (String.IsNullOrEmpty(password))
            {
                return false;
            }
            // Match between 8 and 50 letters, digits, and special characters.
            const string regex = @"^[\p{L}\d!@#$%^&*()]{8,50}$";

            return Regex.IsMatch(password, regex);
        }

        /// <summary>
        /// Returns the first letter to uppercase and the rest to lowercase.
        /// </summary>
        /// <param name="str">name</param>
        /// <returns>The first letter uppercase and all the rest to lowercase</returns>
        public static string? ToPascalCase(string str)
        {
            if (string.IsNullOrWhiteSpace(str))
            {
                return str;
            }
            return char.ToUpper(str[0]) + str.Substring(1).ToLower();        
        }

        /// <summary>
        /// Changes the language between English and French.
        /// </summary>
        public static void Language()
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
        public static bool ValidateUserAge(DateTime dob)
        {
            int age = DateTime.Now.Year - dob.Year;
            if (dob > DateTime.Now.AddYears(-age))
            {
                age--;
            }
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

        /// <summary>
        /// Cheecks if the comment has response
        /// </summary>
        /// <param name="comment">comment</param>
        /// <returns>returns false if the user leaves the comment empty</returns>
        public static bool ValidateComment(string comment)
        {
            if (string.IsNullOrWhiteSpace(comment))
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// Validates the duration of a media.
        /// The duration must be greater than 0.
        /// </summary>
        /// <param name="duration">The duration to validate.</param>
        /// <returns>A boolean indicating whether the duration is valid.</returns>
        public static bool ValidateMediaDuration(int duration)
        {
            if (duration <= 0)
            {
                return false;
            }
            return true;
        }
    }
}
