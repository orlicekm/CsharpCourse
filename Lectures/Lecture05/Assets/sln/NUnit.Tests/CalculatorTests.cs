using NUnit.Framework;
using Sample;

namespace NUnit.Tests
{
    public class CalculatorTests
    {
        private readonly Calculator calculatorSUT = new Calculator();

        [Test]
        public void Adding10To15Returns25()
        {
            // Arrange
            var x = 10;
            var y = 15;

            // Act
            var result = calculatorSUT.Add(x, y);

            //Assert
            Assert.AreEqual(25, result);
        }
    }
}