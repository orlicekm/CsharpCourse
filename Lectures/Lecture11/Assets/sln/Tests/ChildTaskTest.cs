using System.Threading.Tasks;
using Xunit;

namespace Tests
{
    public class ChildTaskTest
    {
        [Fact]
        public void Test()
        {
            var parent = Task.Run(() =>
            {
                var results = new int[3];
                new Task(() => results[0] = 0,
                    TaskCreationOptions.AttachedToParent).Start();
                new Task(() => results[1] = 1,
                    TaskCreationOptions.AttachedToParent).Start();
                new Task(() => results[2] = 2,
                    TaskCreationOptions.AttachedToParent).Start();
                return results;
            });

            var result = new int[3];
            var finalTask = parent.ContinueWith(
                parentTask => { result = parentTask.Result; });
            finalTask.Wait();

            Assert.Equal(result, new[] {0, 1, 2});
        }
    }
}