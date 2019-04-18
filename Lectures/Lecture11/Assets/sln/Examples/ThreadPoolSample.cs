using System;
using System.Diagnostics;
using System.Threading;
using BenchmarkDotNet.Attributes;

namespace Examples
{
    //Run as BenchmarkRunner.Run<ThreadPoolSample>();
    public class ThreadPoolSample
    {
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

        [Benchmark]
        public void ThreadPoolBenchmark() => ProcessWithThreadPoolMethod();

        [Benchmark]
        public void ThreadBenchmark() => ProcessWithThreadMethod();
    }


}