using Sample;
using Xunit;

namespace XUnit.Tests
{
    public class CalculatorTests
    {
        [Fact]
        public void Adding10To15Returns25()
        {
            // Arrange
            var calculator = new Calculator();

            // Act
            var result = calculator.Add(10, 15);

            //Assert
            Assert.Equal(25, result);
        }
    }
}