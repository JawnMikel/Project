using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieDatabase.Utils;

namespace MovieDatabase
{
    public class Payment
    {
        public string CardHolderName { get; set; }
        public string CVV { get; set; }
        public string CreditCardNum { get; set; }
        public string ExpiryDate { get; set; }
        public DateTime Date { get; private set; }
        
		public Payment(string cardName, string cardNum, string expiryDate, string cvv)
        { 
            if (!Util.ValidateCreditCard(cardNum,cvv,expiryDate))
            {
                throw new ArgumentException("Invalid format for the card");
            }

            CardHolderName = cardName;
            CreditCardNum = cardNum;
            ExpiryDate = expiryDate;
            CVV = cvv;
            Date = DateTime.Now;

        }
    }
}