using System;

namespace CleanCodeSample
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Stuff();
        }

        // Calculating addition operation
        private static void Stuff()
        {
            // First number for addition
            int n1;
            // Second number for addition
            int n2;
            // Answer from the user
            int a;
            // Correct answer
            int r;

            // Asking user to input a number
            Console.Write("Write 1. number for addition: ");

            // Reading number from console
            while (!int.TryParse(Console.ReadLine(), out n1))
            {
            }

            // Asking user to input a number
            Console.Write("Write 2. number for addition: ");

            // Reading number from console
            while (!int.TryParse(Console.ReadLine(), out n2))
            {
            }

            Console.Write("Write your answer: ");

            // Reading number from console
            while (!int.TryParse(Console.ReadLine(), out a))
            {
            }

            // Correct answer
            r = n1 + n2;

            // Checking if the answer from the user was correct
            if (r == a)
            {
                // Setting color to green
                Console.ForegroundColor = ConsoleColor.Green;

                // Printing the result
                Console.Write("Your answer \"");
                Console.Write(a);
                Console.Write("\" is right");
            }
            else
            {
                // Setting color to red
                Console.ForegroundColor = ConsoleColor.Red;

                // Printing the result
                Console.Write("Your answer \"");
                Console.Write(a);
                Console.Write("\" is wrong");
            }

            // Waiting for input from user
            Console.ReadKey();
        }
    }
}