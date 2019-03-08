using ShopSample6.AccountDiscountCalculator;

namespace ShopSample6.AccountDiscountCalculatorFactory
{
    public interface IAccountDiscountCalculatorFactory
    {
        IAccountDiscountCalculator GetAccountDiscountCalculator(AccountStatus accountStatus);
    }
}