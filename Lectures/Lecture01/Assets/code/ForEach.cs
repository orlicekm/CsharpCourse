namespace ForeachExample
{
    class Foreach
    {
        static void Main()
        {
            foreach (char c in "beer") // c is the iteration variable
            {
                Console.WriteLine(c);
            }
        }
    }
}