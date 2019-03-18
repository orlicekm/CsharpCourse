using Sample;
using Xunit;

namespace XUnit.Tests
{
    public class NumberValidatorTests
    {
        private readonly NumberValidator numberValidatorSUT = new NumberValidator();

        [Theory]
        [InlineData(3)]
        [InlineData(5)]
        [InlineData(6)]
        public void MyFirstTheory(int value)
        {
            Assert.True(numberValidatorSUT.IsOdd(value));
        }
    }
}