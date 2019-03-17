using Sample;
using Xunit;

namespace XUnit.Tests
{
    public class CalculatorTests
    {
        private readonly Calculator calculatorSUT = new Calculator();

        [Fact]
        public void Adding10To15Returns25()
        {
            // Arrange
            var x = 10;
            var y = 15;

            // Act
            var result = calculatorSUT.Add(x, y);

            //Assert
            Assert.Equal(25, result);
        }
    }
}