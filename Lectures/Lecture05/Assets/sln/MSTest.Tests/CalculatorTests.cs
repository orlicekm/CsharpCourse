using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sample;

namespace MSTest.Tests
{
    [TestClass]
    public class CalculatorTests
    {
        [TestMethod]
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