using BenchmarkDotNet.Running;

namespace DataLocalityBenchmark
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            BenchmarkRunner.Run<DataLocality>();
        }
    }
}