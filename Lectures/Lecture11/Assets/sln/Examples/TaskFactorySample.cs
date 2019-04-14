using System;
using System.Threading.Tasks;

namespace Examples
{
    public class TaskFactorySample
    {
        public static void Main()
        {
            var taskFactory = new TaskFactory(TaskCreationOptions.AttachedToParent,
                TaskContinuationOptions.ExecuteSynchronously);

            var parent = Task.Run(() =>
            {
                var results = new int[3];
                taskFactory.StartNew(() => results[0] = 0);
                taskFactory.StartNew(() => results[1] = 1);
                taskFactory.StartNew(() => results[2] = 2);
                return results;
            });

            var finalTask = parent.ContinueWith(
                parentTask =>
                {
                    foreach (var i in parentTask.Result)
                        Console.WriteLine(i);
                });

            finalTask.Wait();
        }
    }
}