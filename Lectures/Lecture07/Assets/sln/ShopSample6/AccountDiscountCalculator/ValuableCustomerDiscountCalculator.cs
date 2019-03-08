namespace ShopSample6.AccountDiscountCalculator
{
    public class ValuableCustomerDiscountCalculator : IAccountDiscountCalculator
    {
        public decimal ApplyDiscount(decimal price)
        {
            return price - DiscountConstants.DiscountForValuableCustomers * price;
        }
    }
}