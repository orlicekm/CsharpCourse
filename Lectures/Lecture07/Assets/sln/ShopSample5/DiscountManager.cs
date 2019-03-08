using System;

namespace ShopSample5
{
    public class DiscountManager
    {
        private readonly DiscountConstants constants = new DiscountConstants();
        public decimal ApplyDiscount(decimal price, AccountStatus accountStatus, int timeOfHavingAccountInYears)
        {
            decimal priceAfterDiscount;
            switch (accountStatus)
            {
                case AccountStatus.NotRegistered:
                    priceAfterDiscount = price;
                    break;
                case AccountStatus.SimpleCustomer:
                    priceAfterDiscount = price.ApplyDiscountForAccountStatus(constants.DiscountForSimpleCustomers);
                    break;
                case AccountStatus.ValuableCustomer:
                    priceAfterDiscount = price.ApplyDiscountForAccountStatus(constants.DiscountForValuableCustomers);
                    break;
                case AccountStatus.MostValuableCustomer:
                    priceAfterDiscount = price.ApplyDiscountForAccountStatus(constants.DiscountForMostValuableCustomers);
                    break;
                default:
                    throw new NotImplementedException();
            }
            if(accountStatus != AccountStatus.NotRegistered)
                priceAfterDiscount = priceAfterDiscount.ApplyDiscountForTimeOfHavingAccount(timeOfHavingAccountInYears);
            return priceAfterDiscount;
        }
    }
}