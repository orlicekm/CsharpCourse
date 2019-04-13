using System;
using System.Threading;

namespace Examples
{
    class MonitorSample
    {
        private readonly object obj = new object();

        public void Main()
        {
            // Acquires an exclusive lock and the specified object and automatically
            // sets a value that indicates whether the lock was taken
            var lockTaken = false;
            Monitor.Enter(obj, ref lockTaken);

            try
            {
                for (var i = 0; i < 5; i++)
                {
                    Thread.Sleep(100);
                    Console.Write(i + ",");
                }
                Console.WriteLine();
            }
            finally
            {
                if (lockTaken) Monitor.Exit(obj);
            }
        }
    }
}