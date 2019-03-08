namespace ShopSample6.LoyaltyDiscountCalculator
{
    public interface ILoyaltyDiscountCalculator
    {
        decimal ApplyDiscount(decimal price, AccountStatus accountStatus, int timeOfHavingAccountInYears);
    }
}