using Kata.BankOCR.Infrastructure;
using Kata.BankOCR.Infrastructure.Extensions;
using Kata.BankOCR.Models;
using System.Collections.Generic;
using System.Linq;

namespace Kata.BankOCR
{
    public class FaxInputParser
    {
        public IList<AccountNumber> ConvertInputToAccountNumbers()
        {
            var accountNumber = new List<AccountNumber>();
            var inputList = ParseInput();
            var numbers = new List<int>();
            foreach (var item in inputList)
            {
                short number;
                Configuration.NumberTemplates.TryGetValue(new string(item.ToArray()), out number);
                numbers.Add(number);
                if(numbers.Count == 9)
                {
                    accountNumber.Add(new AccountNumber() { Number = numbers });
                    numbers = new List<int>();
                }
            }
            return accountNumber.ValidateFaxInput();
        }

        private IList<List<char>> ParseInput()
        {
            string[] input = FaxFileReader.GetInputText();
            IList<List<char>> insertedFaxTemplates = new List<List<char>>();

            for (short i = 0; i < input.Count() / 4; i++)
            { 
                short numbers = (short)insertedFaxTemplates.Count;
                for (short j = 0; j < 4; j++)
                {
                    short index = (short)(-1 + numbers);
                    for (short k = 0; k < 27; k++)
                    {
                        if (k % 3 == 0)
                        {
                            index++;
                        }
                        if (insertedFaxTemplates.ElementAtOrDefault(index) == null)
                            insertedFaxTemplates.Add(new List<char>());

                        insertedFaxTemplates[index].Add(input[j][k]);
                    }
                }
                input = input.Skip(4).ToArray();
                i--;
            }
            return insertedFaxTemplates;
        }     
    }
}
