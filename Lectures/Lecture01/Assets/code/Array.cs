namespace ArrayExample
{
    class Array
    {
        static void Main()
        {
            //declaration
            char[] characters = new char[5];
            char[] characters1 = new char[] { 'a', 'b', 'c' };
            char[] characters2 = { 'a', 'b', 'c' };

            //access
            characters[0] = 'a';
            characters[1] = 'b';
            for (int I = 0; I < characters.Length; i++)
            {
                Console.WriteLine(characters[i]);
            }
            foreach (var character in characters)
            {
                Console.WriteLine(character);
            }
        }
    }
}