using System;

namespace ShopSample4
{
    public class DiscountManager
    {
        private readonly DiscountConstants constants = new DiscountConstants();

        public decimal ApplyDiscount(decimal price, AccountStatus accountStatus, int timeOfHavingAccountInYears)
        {
            decimal priceAfterDiscount;
            decimal discountForLoyaltyInPercentage = (timeOfHavingAccountInYears > constants.MaximumDiscountForLoyalty) ? (decimal)constants.MaximumDiscountForLoyalty / 100 : (decimal)timeOfHavingAccountInYears / 100;
            switch (accountStatus)
            {
                case AccountStatus.NotRegistered:
                    priceAfterDiscount = price;
                    break;
                case AccountStatus.SimpleCustomer:
                    priceAfterDiscount = (price - (constants.DiscountForSimpleCustomers * price));
                    priceAfterDiscount = priceAfterDiscount - (discountForLoyaltyInPercentage * priceAfterDiscount);
                    break;
                case AccountStatus.ValuableCustomer:
                    priceAfterDiscount = (price - (constants.DiscountForValuableCustomers * price));
                    priceAfterDiscount = priceAfterDiscount - (discountForLoyaltyInPercentage * priceAfterDiscount);
                    break;
                case AccountStatus.MostValuableCustomer:
                    priceAfterDiscount = (price - (constants.DiscountForMostValuableCustomers * price));
                    priceAfterDiscount = priceAfterDiscount - (discountForLoyaltyInPercentage * priceAfterDiscount);
                    break;
                default:
                    throw new NotImplementedException();
            }
            return priceAfterDiscount;
        }
    }
}
