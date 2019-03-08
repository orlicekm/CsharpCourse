namespace ShopSample6.AccountDiscountCalculator
{
    public class NotRegisteredDiscountCalculator : IAccountDiscountCalculator
    {
        public decimal ApplyDiscount(decimal price)
        {
            return price;
        }
    }
}