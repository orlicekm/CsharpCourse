using ShopSample6.AccountDiscountCalculatorFactory;
using ShopSample6.LoyaltyDiscountCalculator;

namespace ShopSample6
{
    public class DiscountManager
    {
        private readonly IAccountDiscountCalculatorFactory factory;
        private readonly ILoyaltyDiscountCalculator loyaltyDiscountCalculator;

        public DiscountManager(IAccountDiscountCalculatorFactory factory,
            ILoyaltyDiscountCalculator loyaltyDiscountCalculator)
        {
            this.factory = factory;
            this.loyaltyDiscountCalculator = loyaltyDiscountCalculator;
        }

        public decimal ApplyDiscount(decimal price, AccountStatus accountStatus, int timeOfHavingAccountInYears)
        {
            var priceAfterDiscount = factory.GetAccountDiscountCalculator(accountStatus).ApplyDiscount(price);
            priceAfterDiscount =
                loyaltyDiscountCalculator.ApplyDiscount(priceAfterDiscount, accountStatus, timeOfHavingAccountInYears);
            return priceAfterDiscount;
        }
    }
}