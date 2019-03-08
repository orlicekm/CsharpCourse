using Xunit;

namespace ClassLibrary2.Tests
{
    public class Class1Tests
    {
        private readonly Class1 class1SUT = new Class1();

        [Fact]
        public void CalculateFirstTypeTest()
        {
            var amount = -5;
            var type = 1;
            var years = 4;

            var result = class1SUT.Calculate(amount, type, years);

            Assert.Equal(amount, result);
        }

        [Fact]
        public void CalculateFourthTypeTest()
        {
            var amount = 1200;
            var type = 4;
            var years = 2;

            var disc = years > 5 ? (decimal) 5 / 100 : (decimal) years / 100;
            var expectedResult = amount - 0.5m * amount - disc * (amount - 0.5m * amount);

            var result = class1SUT.Calculate(amount, type, years);

            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void CalculateMaxTypeTest()
        {
            var amount = 4;
            var type = int.MaxValue;
            var years = 10;

            var result = class1SUT.Calculate(amount, type, years);

            Assert.Equal(0, result);
        }

        [Fact]
        public void CalculateMinTypeTest()
        {
            var amount = 0;
            var type = int.MinValue;
            var years = 42;

            var result = class1SUT.Calculate(amount, type, years);

            Assert.Equal(0, result);
        }

        [Fact]
        public void CalculateSecondTypeTest()
        {
            var amount = 10;
            var type = 2;
            var years = 4;

            var disc = years > 5 ? (decimal) 5 / 100 : (decimal) years / 100;
            var expectedResult = amount - 0.1m * amount - disc * (amount - 0.1m * amount);

            var result = class1SUT.Calculate(amount, type, years);

            Assert.Equal(expectedResult, result);
        }


        [Fact]
        public void CalculateThirdTypeTest()
        {
            var amount = 80;
            var type = 3;
            var years = 4;

            var disc = years > 5 ? (decimal) 5 / 100 : (decimal) years / 100;
            var expectedResult = 0.7m * amount - disc * 0.7m * amount;

            var result = class1SUT.Calculate(amount, type, years);

            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void CalculateZeroTypeTest()
        {
            var amount = 10;
            var type = 0;
            var years = 4;

            var result = class1SUT.Calculate(amount, type, years);

            Assert.Equal(0, result);
        }
    }
}