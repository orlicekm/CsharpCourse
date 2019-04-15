using System;
using System.Threading.Tasks;

namespace Examples
{
    public class AsyncAwaitSample
    {
        public void Main()
        {
            var totalAfterTax = CalculateTotalAfterTaxAsync(70);
            DoSomethingSynchronous();

            totalAfterTax.Wait();
            Console.ReadLine();
        }

        private void DoSomethingSynchronous()
        {
            Console.WriteLine("Doing some synchronous work");
        }

        private async Task<float> CalculateTotalAfterTaxAsync(float value)
        {
            Console.WriteLine("Started CPU Bound asynchronous task on a background thread");
            var result = await Task.Run(() => value * 1.2f);
            Console.WriteLine($"Finished Task. Total of ${value} after tax of 20% is ${result} ");
            return result;
        }
    }
}