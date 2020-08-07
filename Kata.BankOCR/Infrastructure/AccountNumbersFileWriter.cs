using Kata.BankOCR.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Kata.BankOCR.Infrastructure
{
    public static class AccountNumbersFileWriter
    {
        public static void WriteNumbers(IList<AccountNumber> accountNumbers)
        {
            if (File.Exists(Configuration.FaxWriterPath) == false)
                File.Create(Configuration.FaxWriterPath);

            var numbers = accountNumbers.Select(x => 
            {
                {
                    var number = string.Join("", x.Number);
                    if(!x.IsValid)
                    {
                        number = number + " ERR";
                    }
                    return number;
                }                
            }).ToList();
            File.WriteAllLines(Configuration.FaxWriterPath, numbers);
        }
    }
}
