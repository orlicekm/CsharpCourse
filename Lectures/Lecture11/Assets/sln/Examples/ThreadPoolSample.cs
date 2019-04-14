using System;
using System.Diagnostics;
using System.Threading;

namespace Examples
{
    public class ThreadPoolSample
    {
        public void Main()
        {
            var stopwatch = new Stopwatch();

            Console.WriteLine("Thread Pool Execution");
            stopwatch.Start();
            ProcessWithThreadPoolMethod();
            stopwatch.Stop();
            Console.WriteLine($"Time consumed by ProcessWithThreadPoolMethod is : {stopwatch.ElapsedTicks}");

            stopwatch.Reset();

            Console.WriteLine("Thread Execution");
            stopwatch.Start();
            ProcessWithThreadMethod();
            stopwatch.Stop();
            Console.WriteLine($"Time consumed by ProcessWithThreadMethod is : {stopwatch.ElapsedTicks}");
        }

        private void ProcessWithThreadPoolMethod()
        {
            for (var i = 0; i <= 10; i++) ThreadPool.QueueUserWorkItem(Process);
        }

        private void ProcessWithThreadMethod()
        {
            for (var i = 0; i <= 10; i++) new Thread(Process).Start();
        }

        private void Process(object callback)
        {
        }
    }
}