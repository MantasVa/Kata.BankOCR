using Kata.BankOCR.Models;
using System.Collections.Generic;

namespace Kata.BankOCR.Infrastructure.Extensions
{
    public static class FaxInputValidator
    {
        public static IList<AccountNumber> ValidateFaxInput(this IList<AccountNumber> accountNumbers)
        {
            foreach(var account in accountNumbers)
            {
                var accNumber = (AccountNumber)account.Clone();
                accNumber.Number.Reverse();
                short validate = 0;
                for (short i = 1; i <= accNumber.Number.Count; i++)
                {
                    validate += (short)(accNumber.Number[i-1] * i);
                }
                if(validate % 11 == 0)
                {
                    account.IsValid = true;
                }            
            }

            return accountNumbers;
        }
    }
}
