namespace ShopSample6.AccountDiscountCalculator
{
    public class SimpleCustomerDiscountCalculator : IAccountDiscountCalculator
    {
        public decimal ApplyDiscount(decimal price)
        {
            return price - DiscountConstants.DiscountForSimpleCustomers * price;
        }
    }
}