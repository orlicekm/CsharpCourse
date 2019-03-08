namespace ShopSample6
{
    public interface ILoyaltyDiscountCalculator
    {
        decimal ApplyDiscount(decimal price, AccountStatus accountStatus, int timeOfHavingAccountInYears);
    }
}