using System;
using System.Collections.Generic;
using System.Text;

namespace Kata.BankOCR.Models
{
    public class AccountNumber : ICloneable
    {
        public List<int> Number { get; set; }
        public bool IsValid { get; set; } = false;

        public object Clone()
        {
            return new AccountNumber()
            {
                Number = new List<int>(this.Number),
                IsValid = this.IsValid
            };
        }
    }
}
