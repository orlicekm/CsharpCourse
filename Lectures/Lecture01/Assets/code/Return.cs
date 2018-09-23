namespace ReturnExample
{
    class Return
    {
        static double CalculateArea(int r)
        {
            double area = r * r * Math.PI;
            return area;
        }

        static void Main()
        {
            int radius = 5;
            double result = CalculateArea(radius);
            Console.WriteLine($"The area is {result}");
        }
    }
}