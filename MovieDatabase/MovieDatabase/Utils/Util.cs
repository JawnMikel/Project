using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieDatabase.Utils
{
    public static class Util
    {

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
    }
}
