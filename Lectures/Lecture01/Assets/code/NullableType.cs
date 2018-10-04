namespace NullableTypeExample
{
    class NullableType
    {
        static void Main()
        {
            int? y = 7;
            if (y != null)
            {
                Console.WriteLine($"y is {y.Value}");
            }
            else
            {
                Console.WriteLine("y does not have a value");
            }
        }
    }
}