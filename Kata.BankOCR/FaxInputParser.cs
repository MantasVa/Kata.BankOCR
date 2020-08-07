using Kata.BankOCR.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Kata.BankOCR
{
    public class FaxInputParser
    {
        public IList<List<char>> ParseInput()
        {
            string[] input = GetInputText();
            IList<List<char>> insertedFaxTemplates = new List<List<char>>();

            for (short i = 0; i < input.Count(); i++)
            {
                for (short j = 0; j < 27; j++)
                {
                    var floor = (int)Math.Floor((double)j / 3);
                    //if( i % 4 == 0)
                    //{

                    //}
                    int index = (int)Math.Floor((double)j / 3);

                    if (insertedFaxTemplates.ElementAtOrDefault(index) == null)
                        insertedFaxTemplates.Add(new List<char>());

                    insertedFaxTemplates[index].Add(input[i][j]);
                }
            }

            return insertedFaxTemplates;
        }

        public IList<short> ConvertInputToNumbers()
        {
            var convertedNumbers = new List<short>();
            var inputList = ParseInput();
            foreach (var item in inputList)
            {
                short number;
                Configuration.NumberTemplates.TryGetValue(new string(item.ToArray()), out number);
                convertedNumbers.Add(number);
            }
            return convertedNumbers;
        }

        private string[] GetInputText()
        {
            return System.IO.File.ReadAllLines(Configuration.FilePath);
        }
    }
}
