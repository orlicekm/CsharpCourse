using System;

namespace Samples.Structural
{
    public class FacadeSample
    {
        public static void Main()
        {
            var mortgage = new Mortgage();

            // Evaluate mortgage eligibility for customer
            var customer = new Customer("Ann McKinsey");
            var eligible = mortgage.IsEligible(customer, 125000);

            Console.WriteLine("\n" + customer.Name +
                              " has been " + (eligible ? "Approved" : "Rejected"));
        }
    }

    internal class Bank
    {
        public bool HasSufficientSavings(Customer c, int amount)
        {
            Console.WriteLine("Check bank for " + c.Name);
            return true;
        }
    }

    internal class Credit
    {
        public bool HasGoodCredit(Customer c)
        {
            Console.WriteLine("Check credit for " + c.Name);
            return true;
        }
    }

    internal class Loan
    {
        public bool HasNoBadLoans(Customer c)
        {
            Console.WriteLine("Check loans for " + c.Name);
            return true;
        }
    }

    internal class Customer
    {
        public Customer(string name)
        {
            Name = name;
        }

        public string Name { get; }
    }

    internal class Mortgage
    {
        private readonly Bank bank = new Bank();
        private readonly Credit credit = new Credit();
        private readonly Loan loan = new Loan();

        public bool IsEligible(Customer customer, int amount)
        {
            Console.WriteLine($"{customer.Name} applies for {amount:C} loan\n");

            var eligible = true;

            // Check creditworthyness of applicant
            if (!bank.HasSufficientSavings(customer, amount))
                eligible = false;
            else if (!loan.HasNoBadLoans(customer))
                eligible = false;
            else if (!credit.HasGoodCredit(customer)) eligible = false;

            return eligible;
        }
    }
}