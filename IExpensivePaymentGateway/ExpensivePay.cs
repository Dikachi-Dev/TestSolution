using Microsoft.AspNetCore.Mvc;
using Profile;
using System;
using System.Linq;


namespace IExpensivePaymentGateway
{
    public class ExpensivePay
    {
        public IActionResult ChPay([FromBody] Request request)
        {
            try
            {

                if (request == null)
                {
                    return new BadRequestResult();
                }
                if (!IsCCNValid(request.CreditCardNumber))
                {
                    return new StatusCodeResult(400);
                }
                if (!IsDateExpire(request.ExpirationDate))
                {
                    return new StatusCodeResult(400);
                }
                return new OkResult();
            }
            catch(Exception )
            {
                return new StatusCodeResult(500);
            }

        }
        private bool IsCCNValid(string CreditCardNumber)
        {
            if (CreditCardNumber == null)
            {
                return true;
            }

            string ccValue = CreditCardNumber as string;
            if (ccValue == null)
            {
                return false;
            }
            ccValue = ccValue.Replace("-", "");
            ccValue = ccValue.Replace(" ", "");

            int checksum = 0;
            bool evenDigit = false;

            // http://www.beachnet.com/~hstiles/cardtype.html
            foreach (char digit in ccValue.Reverse())
            {
                if (digit < '0' || digit > '9')
                {
                    return false;
                }

                int digitValue = (digit - '0') * (evenDigit ? 2 : 1);
                evenDigit = !evenDigit;

                while (digitValue > 0)
                {
                    checksum += digitValue % 10;
                    digitValue /= 10;
                }
            }

            return true;
        }
        private bool IsDateExpire(DateTime ExpirationDate)
        {

            DateTime pDate = DateTime.Now;
            if (pDate <= ExpirationDate)
            {
                //Invalid date
                //log , show error
                return false;
            }
            return true;
        }

    }
}
