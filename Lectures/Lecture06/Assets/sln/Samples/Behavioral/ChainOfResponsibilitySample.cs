using System;

namespace Samples.Behavioral
{
    public class ChainOfResponsibilitySample
    {
        public static void Main()
        {
            // Setup Chain of Responsibility
            Approver larry = new Director();
            Approver sam = new VicePresident();
            Approver tammy = new President();

            larry.SetSuccessor(sam);
            sam.SetSuccessor(tammy);

            // Generate and process purchase requests
            var p = new Purchase(2034, 350.00, "Assets");
            larry.ProcessRequest(p);

            p = new Purchase(2035, 32590.10, "Project X");
            larry.ProcessRequest(p);

            p = new Purchase(2036, 122100.00, "Project Y");
            larry.ProcessRequest(p);
        }
    }
    
    internal abstract class Approver
    {
        protected Approver successor;

        public void SetSuccessor(Approver successor)
        {
            this.successor = successor;
        }

        public abstract void ProcessRequest(Purchase purchase);
    }

    internal class Director : Approver
    {
        public override void ProcessRequest(Purchase purchase)
        {
            if (purchase.Amount < 10000.0)
                Console.WriteLine("{0} approved request# {1}",
                    GetType().Name, purchase.Number);
            else
                successor?.ProcessRequest(purchase);
        }
    }
    
    internal class VicePresident : Approver
    {
        public override void ProcessRequest(Purchase purchase)
        {
            if (purchase.Amount < 25000.0)
                Console.WriteLine("{0} approved request# {1}",
                    GetType().Name, purchase.Number);
            else
                successor?.ProcessRequest(purchase);
        }
    }
    
    internal class President : Approver
    {
        public override void ProcessRequest(Purchase purchase)
        {
            if (purchase.Amount < 100000.0)
                Console.WriteLine("{0} approved request# {1}",
                    GetType().Name, purchase.Number);
            else
                Console.WriteLine(
                    "Request# {0} requires an executive meeting!",
                    purchase.Number);
        }
    }
    
    internal class Purchase
    {
        public Purchase(int number, double amount, string purpose)
        {
            Number = number;
            Amount = amount;
            Purpose = purpose;
        }
        
        public int Number { get; set; }
        public double Amount { get; set; }
        public string Purpose { get; set; }
    }
}