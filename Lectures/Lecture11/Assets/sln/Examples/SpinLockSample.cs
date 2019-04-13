using System;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Examples
{
    public class SpinLockSample
    {
        public void Main()
        {
            var spinLock = new SpinLock();
            var stringBuilder = new StringBuilder();

            // Action taken by each parallel job
            // Append to the StringBuilder 10000 times
            // Protecting access to sb with a SpinLock
            Action action = () =>
            {
                for (var i = 0; i < 10000; i++)
                {
                    var gotLock = false;
                    try
                    {
                        spinLock.Enter(ref gotLock);
                        stringBuilder.Append((i % 10).ToString());
                    }
                    finally
                    {
                        // Only give up the lock if you actually acquired it
                        if (gotLock) spinLock.Exit();
                    }
                }
            };

            // Invoke 3 concurrent instances of the action above
            Parallel.Invoke(action, action, action);

            Console.WriteLine($"sb.Length = {stringBuilder.Length} (should be 30000)");
            Console.WriteLine(
                $"number of occurrences of '5' in sb: {stringBuilder.ToString().Count(c => c == '5')} (should be 3000)");
        }
    }
}