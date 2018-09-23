namespace TernaryOperandExample
{
    class TernaryOperand
    {
        static void Main()
        {
            int x = 20, y = 10;
            var result = x > y ? "x is greater than y" : "x is less than or equal to y";
            Console.WriteLine(result);
        }
    }
}