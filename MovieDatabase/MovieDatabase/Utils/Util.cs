using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieDatabase.Utils
{
    public class Util
    {

        /// <summary>
        /// Validates the card information (Card#, cvv, expiry date)
        /// </summary>
        /// <param name="creditCardNumber">Card number</param>
        /// <param name="cvv">CVV</param>
        /// <param name="expiryDate">ExpiryDate</param>
        /// <returns>true if they are formatted properly</returns>
        private bool ValidateCreditCard(string creditCardNumber, int cvv, DateTime expiryDate)
        {
            if (creditCardNumber.Length != 12 || !creditCardNumber.All(char.IsDigit))
            {
                MessageBox.Show("Invalid credit card number. Must be exactly 12 digits.", "Payment Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (cvv < 100 || cvv > 999)
            {
                MessageBox.Show("Invalid CVV. Must be exactly 3 digits.", "Payment Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (expiryDate.Month < 1 || expiryDate.Month > 12)
            {
                MessageBox.Show("Invalid expiry month. Must be between 1 and 12.", "Payment Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (expiryDate.Year < 2024)
            {
                MessageBox.Show("Invalid expiry year. Must be greater than or equal to 2024.", "Payment Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (expiryDate < DateTime.Now)
            {
                MessageBox.Show("The card has expired.", "Payment Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }
    }
}
