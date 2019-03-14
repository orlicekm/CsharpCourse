namespace Samples.Facade
{
    public class MortgageFacade
    {
        private readonly Bank bank = new Bank();
        private readonly Credit credit = new Credit();
        private readonly Loan loan = new Loan();

        public bool IsEligible(Customer cust, int amount)
        {
            var eligible = true;

            if (!bank.HasSufficientSavings(cust, amount))
                eligible = false;
            else if (!loan.HasNoBadLoans(cust))
                eligible = false;
            else if (!credit.HasGoodCredit(cust)) eligible = false;

            return eligible;
        }
    }
}