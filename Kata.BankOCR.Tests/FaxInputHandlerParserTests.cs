using Kata.BankOCR.Models;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Kata.BankOCR.Tests
{
    public class FaxInputHandlerParserTests
    {


        [Theory]
        [InlineData((new object[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 }), 0)]
        [InlineData((new object[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 }), 1)]
        [InlineData((new object[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 }), 2)]
        [InlineData((new object[] { 5, 5, 5, 5, 5, 5, 5, 5, 5 }), 3)]
        public void ConvertInputToNumbers_CorrectInput_NumbersConvertedCorrectly(object[] array, int index)
        {
            FaxInputParser parser = new FaxInputParser();
            IList<AccountNumber> numbersActual = parser.ConvertInputToAccountNumbers();

            var numbersExpected = array.Cast<int>().ToList();

            for(int i = 0; i < numbersExpected.Count; i++)
            {
                Assert.Equal(numbersExpected[i], numbersActual[index].Number[i]);
            }            
        }

        //[Theory]
        //[InlineData("     |  |   ", 0)]
        //[InlineData(" _  _||_    ", 1)]
        //[InlineData(" _  _| _|   ", 2)]
        //[InlineData("   |_|  |   ", 3)]
        //[InlineData(" _ |_  _|   ", 4)]
        //[InlineData(" _ |_ |_|   ", 5)]
        //[InlineData(" _   |  |   ", 6)]
        //[InlineData(" _ |_||_|   ", 7)]
        //[InlineData(" _ |_| _|   ", 8)]
        //public void ParseInput_CorrectInput_ReadsInputCorrectly(string expected, int index)
        //{
        //    FaxInputParser parser = new FaxInputParser();

        //    IList<List<char>> numbersStrings = parser.ParseInput();

        //    var myString = new string(numbersStrings[index].ToArray());

        //    Assert.Equal(expected, myString);
        //}
    }
}
