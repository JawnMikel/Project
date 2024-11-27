using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieDatabase.Utils
{
    public class Util
    {

        public static CultureInfo cultureEn = new CultureInfo("en-CA");
        public static CultureInfo cultureFr = new CultureInfo("en-CA");

        /// <summary>
        /// Validateps the card information (Card#, cvv, expiry date)
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
        /// Returns the first letter to uppercase and the rest to lowercase.
        /// </summary>
        /// <param name="str">name</param>
        /// <returns>The first letter uppercase and all the rest to lowercase</returns>
        public static string ToPascaleCase(string str)
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
    }
}
