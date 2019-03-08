namespace ShopSample5
{
    public static class DiscountPriceExtensions
    {
        public static decimal ApplyDiscountForAccountStatus(this decimal price, decimal discountSize)
        {
            return price - discountSize * price;
        }

        public static decimal ApplyDiscountForTimeOfHavingAccount(this decimal price, int timeOfHavingAccountInYears)
        {
            var constants = new DiscountConstants();
            var discountForLoyaltyInPercentage = timeOfHavingAccountInYears > constants.MaximumDiscountForLoyalty
                ? (decimal) constants.MaximumDiscountForLoyalty / 100
                : (decimal) timeOfHavingAccountInYears / 100;

            return price - discountForLoyaltyInPercentage * price;
        }
    }
}