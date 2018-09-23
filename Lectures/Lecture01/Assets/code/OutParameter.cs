namespace ValueExample
{
    class DefaultValue
    {
        private static void Split(string name, out string firstNames, out string lastName)
        {
            int i = name.LastIndexOf(' ');
            firstNames = name.Substring(0, i);
            lastName = name.Substring(i + 1);
        }

        static void Main()
        {
            Split("Stevie Ray Vaughan", out var a, out var b);
            Console.WriteLine(a); // Stevie Ray
            Console.WriteLine(b); // Vaughan
        }
    }
}