using System;
using System.Threading;

namespace Examples
{
    public class MutexSample
    {
        private readonly Mutex mutex = new Mutex();

        public void Main()
        {
            // Create 3 threads
            for (var i = 0; i < 3; i++)
            {
                var newThread = new Thread(ThreadProc)
                {
                    Name = $"Thread{i + 1}"
                };
                newThread.Start();
            }
        }

        private void ThreadProc()
        {
            // Use resource 3 times
            for (var i = 0; i < 3; i++) UseResource();
        }

        private void UseResource()
        {
            mutex.WaitOne();
            Console.WriteLine($"{Thread.CurrentThread.Name} has entered the protected area");
            Thread.Sleep(500); // Simulate some work
            Console.WriteLine($"{Thread.CurrentThread.Name} is leaving the protected area");
            mutex.ReleaseMutex();
        }
    }
}