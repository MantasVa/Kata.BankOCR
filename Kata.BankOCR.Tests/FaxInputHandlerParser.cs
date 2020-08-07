using System;
using System.Collections.Generic;
using Xunit;

namespace Kata.BankOCR.Tests
{
    public class FaxInputHandlerParser
    {
        [Theory]
        [InlineData("     |  |   ", 0)]
        [InlineData(" _  _||_    ", 1)]
        [InlineData(" _  _| _|   ", 2)]
        [InlineData("   |_|  |   ", 3)]
        [InlineData(" _ |_  _|   ", 4)]
        [InlineData(" _ |_ |_|   ", 5)]
        [InlineData(" _   |  |   ", 6)]
        [InlineData(" _ |_||_|   ", 7)]
        [InlineData(" _ |_| _|   ", 8)]
        public void ParseInput_CorrectInput_ReadsInputCorrectly(string expected, int index)
        {
            FaxInputParser parser = new FaxInputParser();

            IList<List<char>> numbersStrings = parser.ParseInput();

            var myString = new string(numbersStrings[index].ToArray());
            Assert.Equal(expected, myString);
        }

        [Fact]
        public void ConvertInputToNumbers_CorrectInput_NumbersConvertedCorrectly()
        {
            FaxInputParser parser = new FaxInputParser();
            var numbers = parser.ConvertInputToNumbers();

            for (short i = 1; i < 10; i++)
            {
                Assert.Equal(i, numbers[i - 1]);
            }
        }
    }
}
