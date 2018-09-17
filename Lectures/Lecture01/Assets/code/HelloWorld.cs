using System;                                            // Importing namespace

namespace HelloWorld                                     // Namespace declaration
{
    class Hello                                          // Class declaration
    {
        private static void Main(string[] args)          // Method declaration
        {
            Console.WriteLine("Hello World!");           // Statement 1

            Console.WriteLine("Press any key to exit."); // Statement 2
            Console.ReadKey();                           // Statement 3
        }                                                // End of method
    }
}