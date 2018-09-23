namespace ContinueExample
{
    class Continue
    {
        static void Main()
        {
            for (int i = 0; i < 10; i++)
            {
                if ((i % 2) == 0) // If i is even,
                {
                    continue; // continue with next iteration
                }
                Console.Write(i + " ");
            }
        }
    }
}