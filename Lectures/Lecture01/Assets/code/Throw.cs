namespace ThrowExample
{
    class Throw
    {
        public class NumberGenerator
        {
            int[] numbers = {2, 4, 6, 8, 10, 12, 14, 16, 18, 20};

            public int GetNumber(int index)
            {
                if (index < 0 || index >= numbers.Length)
                {
                    throw new IndexOutOfRangeException();
                }

                return numbers[index];
            }
        }
    }
}