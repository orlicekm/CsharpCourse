using System;
using System.Collections.Generic;

namespace Samples.Structural
{
    public class BridgeSample
    {
        public static void Main()
        {
            // Create RefinedAbstraction
            var customers = new Customers("Chicago");

            // Set ConcreteImplementor
            customers.Data = new CustomersData();

            // Exercise the bridge
            customers.Show();
            customers.Next();
            customers.Show();
            customers.Next();
            customers.Show();
            customers.Add("Henry Velasquez");
            customers.ShowAll();
        }
    }

    internal class CustomersBase
    {
        protected string group;

        public CustomersBase(string group)
        {
            this.group = group;
        }

        public DataObject Data { set; get; }

        public virtual void Next()
        {
            Data.NextRecord();
        }

        public virtual void Prior()
        {
            Data.PriorRecord();
        }

        public virtual void Add(string customer)
        {
            Data.AddRecord(customer);
        }

        public virtual void Delete(string customer)
        {
            Data.DeleteRecord(customer);
        }

        public virtual void Show()
        {
            Data.ShowRecord();
        }

        public virtual void ShowAll()
        {
            Console.WriteLine("Customer Group: " + group);
            Data.ShowAllRecords();
        }
    }

    internal class Customers : CustomersBase
    {
        public Customers(string group)
            : base(group)
        {
        }

        public override void ShowAll()
        {
            Console.WriteLine();
            Console.WriteLine("------------------------");
            base.ShowAll();
            Console.WriteLine("------------------------");
        }
    }

    internal abstract class DataObject
    {
        public abstract void NextRecord();
        public abstract void PriorRecord();
        public abstract void AddRecord(string name);
        public abstract void DeleteRecord(string name);
        public abstract void ShowRecord();
        public abstract void ShowAllRecords();
    }

    internal class CustomersData : DataObject
    {
        private readonly List<string> customers = new List<string>();
        private int current;

        public CustomersData()
        {
            // Loaded from a database 
            customers.Add("Jim Jones");
            customers.Add("Samual Jackson");
            customers.Add("Allen Good");
            customers.Add("Ann Stills");
            customers.Add("Lisa Giolani");
        }

        public override void NextRecord()
        {
            if (current <= customers.Count - 1) current++;
        }

        public override void PriorRecord()
        {
            if (current > 0) current--;
        }

        public override void AddRecord(string customer)
        {
            customers.Add(customer);
        }

        public override void DeleteRecord(string customer)
        {
            customers.Remove(customer);
        }

        public override void ShowRecord()
        {
            Console.WriteLine(customers[current]);
        }

        public override void ShowAllRecords()
        {
            foreach (var customer in customers) Console.WriteLine(" " + customer);
        }
    }
}