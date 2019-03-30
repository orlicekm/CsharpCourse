using System;

namespace Samples.Behavioral
{
    public class MementoSample
    {
        public static void Main()
        {
            var salesProspect = new SalesProspect
            {
                Name = "Noel van Halen",
                Phone = "(412) 256-0990",
                Budget = 25000.0
            };

            // Store internal state
            var prospectMemory = new ProspectMemory
            {
                Memento = salesProspect.SaveMemento()
            };

            // Continue changing originator
            salesProspect.Name = "Leo Welch";
            salesProspect.Phone = "(310) 209-7111";
            salesProspect.Budget = 1000000.0;

            // Restore saved state
            salesProspect.RestoreMemento(prospectMemory.Memento);
        }
    }

    internal class SalesProspect
    {
        private double budget;
        private string name;
        private string phone;

        public string Name
        {
            get => name;
            set
            {
                name = value;
                Console.WriteLine("Name:  " + name);
            }
        }

        public string Phone
        {
            get => phone;
            set
            {
                phone = value;
                Console.WriteLine("Phone: " + phone);
            }
        }

        public double Budget
        {
            get => budget;
            set
            {
                budget = value;
                Console.WriteLine("Budget: " + budget);
            }
        }

        public Memento SaveMemento()
        {
            Console.WriteLine("\nSaving state --\n");
            return new Memento(name, phone, budget);
        }

        public void RestoreMemento(Memento memento)
        {
            Console.WriteLine("\nRestoring state --\n");
            Name = memento.Name;
            Phone = memento.Phone;
            Budget = memento.Budget;
        }
    }

    internal class Memento
    {
        public Memento(string name, string phone, double budget)
        {
            Name = name;
            Phone = phone;
            Budget = budget;
        }

        public string Name { get; set; }
        public string Phone { get; set; }
        public double Budget { get; set; }
    }

    internal class ProspectMemory
    {
        public Memento Memento { set; get; }
    }
}