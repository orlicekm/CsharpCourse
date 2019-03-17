using NUnit.Framework;
using Sample;

namespace NUnit.Tests
{
    public class CalculatorTests
    {
        [Test]
        public void Adding10To15Returns25()
        {
            // Arrange
            var calculator = new Calculator();

            // Act
            var result = calculator.Add(10, 15);

            //Assert
            Assert.AreEqual(25, result);
        }
    }
}