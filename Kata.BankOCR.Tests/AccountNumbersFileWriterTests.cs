using Kata.BankOCR.Infrastructure;
using Kata.BankOCR.Models;
using System.Collections.Generic;
using System.IO;
using Xunit;

namespace Kata.BankOCR.Tests
{
    public class AccountNumbersFileWriterTests
    {

        [Fact]
        public void WriteNumbers_ValidNumbers_CreatesFileWithCorrectOutput()
        {
            FaxInputParser parser = new FaxInputParser();
            IList<AccountNumber> numbers = parser.ConvertInputToAccountNumbers();

            AccountNumbersFileWriter.WriteNumbers(numbers);        

            Assert.True(File.Exists(Configuration.FaxWriterPath));
            Assert.True(File.ReadAllLines(Configuration.FaxWriterPath).Length == numbers.Count);
        }
    }
}
