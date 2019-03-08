namespace ShopSample6.LoyaltyDiscountCalculator
{
    public class DefaultLoyaltyDiscountCalculator : ILoyaltyDiscountCalculator
    {
        public decimal ApplyDiscount(decimal price, AccountStatus accountStatus, int timeOfHavingAccountInYears)
        {
            if (accountStatus == AccountStatus.NotRegistered) return price;

            var discountForLoyaltyInPercentage =
                timeOfHavingAccountInYears > DiscountConstants.MaximumDiscountForLoyalty
                    ? (decimal) DiscountConstants.MaximumDiscountForLoyalty / 100
                    : (decimal) timeOfHavingAccountInYears / 100;
            return price - discountForLoyaltyInPercentage * price;
        }
    }
}