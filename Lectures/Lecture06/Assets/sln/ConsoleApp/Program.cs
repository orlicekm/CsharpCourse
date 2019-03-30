using System;
using Samples.Behavioral;
using Samples.Creational;
using Samples.Structural;

namespace ConsoleApp
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            WriteChoices();
            var input = Console.ReadLine();
            if (int.TryParse(input, out var number) && (number > 0 && number <= 23))
                RunChoice(number);
            else
                Console.WriteLine("Wrong input!");
            Console.Read();
        }

        private static void WriteChoices()
        {
            Console.WriteLine("Select sample for run:");
            Console.WriteLine("1.  Abstract Factory");
            Console.WriteLine("2.  Builder");
            Console.WriteLine("3.  Factory Method");
            Console.WriteLine("4.  Prototype");
            Console.WriteLine("5.  Singleton");

            Console.WriteLine("6.  Adapter");
            Console.WriteLine("7.  Bridge");
            Console.WriteLine("8.  Composite");
            Console.WriteLine("9.  Decorator");
            Console.WriteLine("10. Facade");
            Console.WriteLine("11. Flyweight");
            Console.WriteLine("12. Proxy");

            Console.WriteLine("13. Chain of Responsibility");
            Console.WriteLine("14. Command");
            Console.WriteLine("15. Interpreter");
            Console.WriteLine("16. Iterator");
            Console.WriteLine("17. Mediator");
            Console.WriteLine("18. Memento");
            Console.WriteLine("19. Observer");
            Console.WriteLine("20. State");
            Console.WriteLine("21. Strategy");
            Console.WriteLine("22. Template Method");
            Console.WriteLine("23. Visitor");

            Console.WriteLine("Enter choice: ");
        }

        private static void RunChoice(int number)
        {
            switch (number)
            {
                case 1:
                    AbstractFactorySample.Main();
                    break;
                case 2:
                    BuilderSample.Main();
                    break;
                case 3:
                    FactoryMethodSample.Main();
                    break;
                case 4:
                    PrototypeSample.Main();
                    break;
                case 5:
                    SingletonSample.Main();
                    break;
                case 6:
                    AdapterSample.Main();
                    break;
                case 7:
                    BridgeSample.Main();
                    break;
                case 8:
                    CompositeSample.Main();
                    break;
                case 9:
                    DecoratorSample.Main();
                    break;
                case 10:
                    FacadeSample.Main();
                    break;
                case 11:
                    FlyweightSample.Main();
                    break;
                case 12:
                    ProxySample.Main();
                    break;
                case 13:
                    ChainOfResponsibilitySample.Main();
                    break;
                case 14:
                    CommandSample.Main();
                    break;
                case 15:
                    InterpreterSample.Main();
                    break;
                case 16:
                    IteratorSample.Main();
                    break;
                case 17:
                    MediatorSample.Main();
                    break;
                case 18:
                    MementoSample.Main();
                    break;
                case 19:
                    ObserverSample.Main();
                    break;
                case 20:
                    StateSample.Main();
                    break;
                case 21:
                    StrategySample.Main();
                    break;
                case 22:
                    TemplateMethodSample.Main();
                    break;
                case 23:
                    VisitorSample.Main();
                    break;
                default:
                    break;
            }
        }
    }
}