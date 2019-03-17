using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sample;

namespace MSTest.Tests
{
    [TestClass]
    public class CalculatorTests
    {
        private readonly Calculator calculatorSUT = new Calculator();

        [TestMethod]
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