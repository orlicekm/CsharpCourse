using System;
using System.Collections.Generic;

namespace Samples.Behavioral
{
    internal class VisitorSample
    {
        private static void Main()
        {
            // Setup employee collection
            var e = new Employees();
            e.Attach(new Clerk());
            e.Attach(new MainDirector());
            e.Attach(new CEO());

            // Employees are 'visited'
            e.Accept(new IncomeVisitor());
            e.Accept(new VacationVisitor());
        }
    }

    internal interface IVisitor
    {
        void Visit(Element element);
    }

    internal class IncomeVisitor : IVisitor
    {
        public void Visit(Element element)
        {
            var employee = element as Employee;

            // Provide 10% pay raise
            employee.Income *= 1.10;
            Console.WriteLine($"{employee.GetType().Name} {employee.Name}'s new income: {employee.Income:C}");
        }
    }

    internal class VacationVisitor : IVisitor
    {
        public void Visit(Element element)
        {
            var employee = element as Employee;

            // Provide 3 extra vacation days
            employee.VacationDays += 3;
            Console.WriteLine(
                $"{employee.GetType().Name} {employee.Name}'s new vacation days: {employee.VacationDays}");
        }
    }

    internal abstract class Element
    {
        public abstract void Accept(IVisitor visitor);
    }

    internal class Employee : Element
    {
        public Employee(string name, double income,
            int vacationDays)
        {
            Name = name;
            Income = income;
            VacationDays = vacationDays;
        }

        public string Name { get; set; }
        public double Income { get; set; }
        public int VacationDays { get; set; }

        public override void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }
    }

    internal class Employees
    {
        private readonly List<Employee> employees = new List<Employee>();

        public void Attach(Employee employee)
        {
            employees.Add(employee);
        }

        public void Detach(Employee employee)
        {
            employees.Remove(employee);
        }

        public void Accept(IVisitor visitor)
        {
            foreach (var e in employees) e.Accept(visitor);
            Console.WriteLine();
        }
    }

    internal class Clerk : Employee
    {
        public Clerk()
            : base("Hank", 25000.0, 14)
        {
        }
    }

    internal class MainDirector : Employee
    {
        public MainDirector()
            : base("Elly", 35000.0, 16)
        {
        }
    }

    internal class CEO : Employee
    {
        public CEO()
            : base("Mike", 45000.0, 21)
        {
        }
    }
}