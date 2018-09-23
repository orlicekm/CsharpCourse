namespace DefaultValueExample
{
    class DefaultValue
    {
        static int y;
        static void Main()
        {
            int x;
            Console.WriteLine(x);        // Compile-time error
            int[] ints = new int[2];
            Console.WriteLine(ints[0]);  // 0
            Console.WriteLine(y);        // 0
        }
    }
}