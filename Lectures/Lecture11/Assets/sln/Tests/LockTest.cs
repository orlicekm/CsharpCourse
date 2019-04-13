using System.Threading.Tasks;
using Xunit;

namespace Tests
{
    public class LockTest
    {
        private readonly object thisLock = new object();

        private int increment;
        private void CriticalSection()
        {
            lock (thisLock)
            {
                Task.Delay(16);
                increment++;
            }
        }

        [Fact]
        private void Test()
        {
            const int attempts = 1_000_000;
            for (var i = 0; i < attempts; i++)
            {
                Task.Run(() => CriticalSection()).ConfigureAwait(false);
            }

            Assert.True(increment < attempts);
        }
    }
}