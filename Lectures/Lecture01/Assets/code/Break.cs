namespace BreakExample
{
    class Break
    {
        static void Main()
        {
            int x = 0;
            while (true)
            {
                if (x++ > 5)
                {
                    break; // break from the loop
                }
            }
            // execution continues here after break
        }
    }
}