namespace GotoExample
{
    class Goto
    {
        static void Main()
        {
            int i = 1;
            startLoop:
            if (i <= 5)
            {
                Console.Write(i + " ");
                i++;
                goto startLoop;
            }
        }
    }
}