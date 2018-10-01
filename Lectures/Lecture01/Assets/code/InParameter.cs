namespace InParameterExample
{
    class InParameter
    {
        private static void Foo(in int p)
        {
            // Uncomment the following line to see error 
            //p = 19;
        }

        static void Main()
        {
            int x = 8;
            Foo(ref x);           
            Console.WriteLine(x); // x is still 8
        }
    }
}