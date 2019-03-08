using System;
using Xunit;

namespace ShopSample4.Tests
{
    public class DiscountManagerTests
    {
        private readonly DiscountManager discountManagerSUT = new DiscountManager();
        private readonly DiscountConstants constants = new DiscountConstants();

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

            var discountForLoyaltyInPercentage = timeOfHavingAccountInYears > constants.MaximumDiscountForLoyalty
                ? (decimal) constants.MaximumDiscountForLoyalty / 100
                : (decimal) timeOfHavingAccountInYears / 100;
            var expectedResult = price - constants.DiscountForMostValuableCustomers * price;
            expectedResult = expectedResult - discountForLoyaltyInPercentage * expectedResult;

            var result = discountManagerSUT.ApplyDiscount(price, type, timeOfHavingAccountInYears);

            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void CalculateMaxTypeTest()
        {
            var price = 4;
            var type = (AccountStatus) int.MaxValue;
            var timeOfHavingAccountInYears = 10;

            Assert.Throws<NotImplementedException>(() =>
                discountManagerSUT.ApplyDiscount(price, type, timeOfHavingAccountInYears));
        }

        [Fact]
        public void CalculateMinTypeTest()
        {
            var price = 0;
            var type = (AccountStatus) int.MinValue;
            var timeOfHavingAccountInYears = 42;

            Assert.Throws<NotImplementedException>(() =>
                discountManagerSUT.ApplyDiscount(price, type, timeOfHavingAccountInYears));
        }

        [Fact]
        public void CalculateSecondTypeTest()
        {
            var price = 10;
            var type = AccountStatus.SimpleCustomer;
            var timeOfHavingAccountInYears = 4;

            var discountForLoyaltyInPercentage = timeOfHavingAccountInYears > constants.MaximumDiscountForLoyalty
                ? (decimal) constants.MaximumDiscountForLoyalty / 100
                : (decimal) timeOfHavingAccountInYears / 100;
            var expectedResult = price - constants.DiscountForSimpleCustomers * price;
            expectedResult = expectedResult - discountForLoyaltyInPercentage * expectedResult;

            var result = discountManagerSUT.ApplyDiscount(price, type, timeOfHavingAccountInYears);

            Assert.Equal(expectedResult, result);
        }


        [Fact]
        public void CalculateThirdTypeTest()
        {
            var price = 80;
            var type = AccountStatus.ValuableCustomer;
            var timeOfHavingAccountInYears = 4;

            var discountForLoyaltyInPercentage = timeOfHavingAccountInYears > constants.MaximumDiscountForLoyalty
                ? (decimal) constants.MaximumDiscountForLoyalty / 100
                : (decimal) timeOfHavingAccountInYears / 100;
            var expectedResult = price - constants.DiscountForValuableCustomers * price;
            expectedResult = expectedResult - discountForLoyaltyInPercentage * expectedResult;

            var result = discountManagerSUT.ApplyDiscount(price, type, timeOfHavingAccountInYears);

            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void CalculateZeroTypeTest()
        {
            var price = 10;
            var type = (AccountStatus) 0;
            var timeOfHavingAccountInYears = 4;

            Assert.Throws<NotImplementedException>(() =>
                discountManagerSUT.ApplyDiscount(price, type, timeOfHavingAccountInYears));
        }
    }
}