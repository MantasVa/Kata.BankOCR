using Kata.BankOCR.Infrastructure.Extensions;
using Xunit;

namespace Kata.BankOCR.Tests
{
    public class FaxInputValidatorTests
    {
        [Fact]
        public void ValidateFaxInput_FirstThreeValidNumbers_NumbersAreValid()
        {
            FaxInputParser faxInputParser = new FaxInputParser();
            var numbers =  faxInputParser.ConvertInputToAccountNumbers();

            numbers.ValidateFaxInput();

            for(int i = 0; i < 3; i++)
            {
                Assert.True(numbers[i].IsValid);
            }           
        }

        [Fact]
        public void ValidateFaxInput_FifthValidNumbers_NumberIsNotValid()
        {
            FaxInputParser faxInputParser = new FaxInputParser();
            var numbers = faxInputParser.ConvertInputToAccountNumbers();

            numbers.ValidateFaxInput();
                       
            Assert.False(numbers[3].IsValid);            
        }
    }    
}
