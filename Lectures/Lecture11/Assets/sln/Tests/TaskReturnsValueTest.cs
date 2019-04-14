using System.Threading.Tasks;
using Xunit;

namespace Tests
{
    public class TaskReturnsValueTest
    {
        private readonly Task<int> task = Task.Run(() => { return 100; });
        private readonly Task<int> lambdaTask = Task.Run(() => 100);

        [Fact]
        public void Test()
        {
            Assert.Equal(100, task.Result);
            Assert.Equal(100, lambdaTask.Result);
        }
    }
}