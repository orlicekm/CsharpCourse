using Xunit;

namespace ShopSample3.Tests
{
    public class DiscountManagerTests
    {
        private readonly DiscountManager discountManagerSUT = new DiscountManager();

        [Fact]
        public void CalculateFirstTypeTest()
        {
            var price = -5;
            var type = AccountStatus.NotRegistered;
            var timeOfHavingAccountInYears = 4;

            var result = discountManagerSUT.ApplyDiscount(price, type, timeOfHavingAccountInYears);

            Assert.Equal(price, result);
        }

        [Fact]
        public void CalculateFourthTypeTest()
        {
            var price = 1200;
            var type = AccountStatus.MostValuableCustomer;
            var timeOfHavingAccountInYears = 2;

            var disc = timeOfHavingAccountInYears > 5 ? (decimal) 5 / 100 : (decimal) timeOfHavingAccountInYears / 100;
            var expectedResult = price - 0.5m * price - disc * (price - 0.5m * price);

            var result = discountManagerSUT.ApplyDiscount(price, type, timeOfHavingAccountInYears);

            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void CalculateMaxTypeTest()
        {
            var price = 4;
            var type = (AccountStatus) int.MaxValue;
            var timeOfHavingAccountInYears = 10;

            var result = discountManagerSUT.ApplyDiscount(price, type, timeOfHavingAccountInYears);

            Assert.Equal(0, result);
        }

        [Fact]
        public void CalculateMinTypeTest()
        {
            var price = 0;
            var type = (AccountStatus) int.MinValue;
            var timeOfHavingAccountInYears = 42;

            var result = discountManagerSUT.ApplyDiscount(price, type, timeOfHavingAccountInYears);

            Assert.Equal(0, result);
        }

        [Fact]
        public void CalculateSecondTypeTest()
        {
            var price = 10;
            var type = AccountStatus.SimpleCustomer;
            var timeOfHavingAccountInYears = 4;

            var disc = timeOfHavingAccountInYears > 5 ? (decimal) 5 / 100 : (decimal) timeOfHavingAccountInYears / 100;
            var expectedResult = price - 0.1m * price - disc * (price - 0.1m * price);

            var result = discountManagerSUT.ApplyDiscount(price, type, timeOfHavingAccountInYears);

            Assert.Equal(expectedResult, result);
        }


        [Fact]
        public void CalculateThirdTypeTest()
        {
            var price = 80;
            var type = AccountStatus.ValuableCustomer;
            var timeOfHavingAccountInYears = 4;

            var disc = timeOfHavingAccountInYears > 5 ? (decimal) 5 / 100 : (decimal) timeOfHavingAccountInYears / 100;
            var expectedResult = 0.7m * price - disc * 0.7m * price;

            var result = discountManagerSUT.ApplyDiscount(price, type, timeOfHavingAccountInYears);

            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void CalculateZeroTypeTest()
        {
            var price = 10;
            var type = (AccountStatus) 0;
            var timeOfHavingAccountInYears = 4;

            var result = discountManagerSUT.ApplyDiscount(price, type, timeOfHavingAccountInYears);

            Assert.Equal(0, result);
        }
    }
}