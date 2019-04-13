using System;
using System.Threading;

namespace Examples
{
    public class SemaphoreSample
    {
        private int padding; // A padding interval to make the output more orderly
        private Semaphore semaphore;

        public void Main()
        {
            // Create a semaphore that can satisfy up to three concurrent requests
            // Use an initial count of zero, so that the entire semaphore count
            // is initially owned by the main program thread
            semaphore = new Semaphore(0, 3);

            // Create and start five numbered threads
            for (var i = 1; i <= 5; i++)
            {
                var t = new Thread(Worker);
                t.Start(i);
            }

            // Wait for half a second, to allow all the
            // Threads to start and to block on the semaphore
            Thread.Sleep(500);

            // The main thread starts out holding the entire semaphore count
            // Calling Release(3) brings the semaphore count back to its maximum value,
            // and allows the waiting threads to enter the semaphore, up to three at a time
            Console.WriteLine("Main thread calls Release.");
            semaphore.Release(3);

            Console.WriteLine("Main thread exits.");
        }

        private void Worker(object num)
        {
            // Each worker thread begins by requesting the semaphore
            Console.WriteLine($"Thread {num} begins " + "and waits for the semaphore.");
            semaphore.WaitOne();

            // A padding interval to make the output more orderly
            var padding = Interlocked.Add(ref this.padding, 100);

            Console.WriteLine($"Thread {num} enters the semaphore.");

            // The thread's "work" consists of sleeping for about a second
            // Each thread "works" a little longer, just to make the output more orderly
            Thread.Sleep(1000 + padding);

            Console.WriteLine($"Thread {num} releases the semaphore.");
            Console.WriteLine($"Thread {num} previous semaphore count: {semaphore.Release()}");
        }
    }
}