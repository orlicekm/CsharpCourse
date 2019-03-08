namespace ShopSample6.AccountDiscountCalculator
{
    public class MostValuableCustomerDiscountCalculator : IAccountDiscountCalculator
    {
        public decimal ApplyDiscount(decimal price)
        {
            return price - DiscountConstants.DiscountForMostValuableCustomers * price;
        }
    }
}