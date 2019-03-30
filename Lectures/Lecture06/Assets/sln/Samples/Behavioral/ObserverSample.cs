using System;
using System.Collections.Generic;

namespace Samples.Behavioral
{
    public class ObserverSample
    {
        private static void Main()
        {
            // Create IBM stock and attach investors
            var ibm = new IBM("IBM", 120.00);
            ibm.Attach(new Investor("Sorros"));
            ibm.Attach(new Investor("Berkshire"));

            // Fluctuating prices will notify investors
            ibm.Price = 120.10;
            ibm.Price = 121.00;
            ibm.Price = 120.50;
            ibm.Price = 120.75;
        }
    }

    internal abstract class Stock
    {
        private readonly List<IInvestor> investors = new List<IInvestor>();
        private double price;

        public Stock(string symbol, double price)
        {
            Symbol = symbol;
            this.price = price;
        }

        public double Price
        {
            get => price;
            set
            {
                if (price != value)
                {
                    price = value;
                    Notify();
                }
            }
        }

        public string Symbol { get; }

        public void Attach(IInvestor investor)
        {
            investors.Add(investor);
        }

        public void Detach(IInvestor investor)
        {
            investors.Remove(investor);
        }

        public void Notify()
        {
            foreach (var investor in investors) investor.Update(this);
            Console.WriteLine("");
        }
    }

    internal class IBM : Stock
    {
        public IBM(string symbol, double price)
            : base(symbol, price)
        {
        }
    }

    internal interface IInvestor
    {
        void Update(Stock stock);
    }

    internal class Investor : IInvestor
    {
        private readonly string name;

        public Investor(string name)
        {
            this.name = name;
        }

        public Stock Stock { get; set; }

        public void Update(Stock stock)
        {
            Console.WriteLine($"Notified {name} of {stock.Symbol}'s " + $"change to {stock.Price:C}");
        }
    }
}