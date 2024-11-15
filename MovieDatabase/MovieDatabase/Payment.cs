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
        public string CreditCardNum { get; set; }
        //public DateTime CardExpirationDate { get; set; }
        public int CVV {  get; set; }

        public Payment(string cardHolderName, string creditCardNum, int cVV)
        {
            CardHolderName = cardHolderName;
            CreditCardNum = creditCardNum;
            CVV = cVV;
        }

        public bool validateCard(string creditCardNumber)
        {
            return false;
        }
    }
}
