namespace UsingExample
{
    class Using
    {
        static void Main()
        {
            using (var streamReader = new StreamReader("c:\\file.txt"))
            {
                Console.Write(streamReader.ReadToEnd());
            }
        }
    }
}