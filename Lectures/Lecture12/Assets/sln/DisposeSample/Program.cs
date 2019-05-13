using System;

namespace DisposeSample
{
    public class DisposableClass : IDisposable
    {
        private bool disposed;

        ~DisposableClass()
        {
            //while (true);
            Dispose(false);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void Test()
        {
            Console.WriteLine(disposed ? "I died!" : "I live!");
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    // cleanup of managed resources
                }

                disposed = true;
            }
        }
    }

    internal class Program
    {
        private static void Main(string[] args)
        {
            DisposableClass disposableClass;
            using (disposableClass = new DisposableClass())
            {
                disposableClass.Test();
            }
        }
    }
}
