namespace SwitchExample
{
    class Switch
    {
        static void Main()
        {
            int cardNumber = 12;

            switch (cardNumber)
            {
                case 10:
                case 13:
                    Console.WriteLine("King");
                    break;
                case 12:
                    Console.WriteLine("Queen");
                    break;
                case 11:
                    Console.WriteLine("Jack");
                    break;
                case -1:                          // Joker is −1
                    goto case 12;                 // In this game joker counts as queen
                default:                          // Executes for any other cardNumber
                    Console.WriteLine(cardNumber);
                    break;
            }
        }
    }
}