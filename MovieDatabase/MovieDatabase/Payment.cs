using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MovieDatabase
{
    public class Payment
    {
        public string CardHolderName { get; set; }
        public string CardNumber { get; set; }
        public int CVV { get; set; }
        public string ExpiryDate { get; set; }
        public decimal Amount { get; private set; }
        public DateTime Date { get; private set; }
        public static decimal TotalRevenue { get; private set; }
        public Payment(string cardName, string cardNum, string expiryDate, int cvv, decimal amount)
        {
            CardHolderName = cardName;
            CardNumber = cardNum;
            ExpiryDate = expiryDate;
            CVV = cvv;
            Amount = amount;
            Date = DateTime.Now;
        }

        /// <summary>
        /// Validates the card information (Card#, cvv, expiry date) if its valid then it will pay for the membership 
        /// </summary>
        /// <param name="creditCardNumber">Card number</param>
        /// <param name="cvv">CVV</param>
        /// <param name="expiryDate">ExpiryDate</param>
        /// <returns>true if all the information is formatted properly or else if it is not, it will return false</returns>
        public bool Process(string creditCardNumber, int cvv, DateTime expiryDate)
        {
            if (!Util.ValidateCreditCard(creditCardNumber, cvv, expiryDate))
            {
                return false;
            }
            TotalRevenue += Amount;
            return true; 
        }
    }
}

