using System;
using System.Threading.Tasks;

namespace Examples
{
    public class TaskSample
    {
        public void Main()
        {
            var t = Task.Run(() =>
            {
                for (var x = 0; x < 50; x++)
                    Console.Write("Hi ");
            });
            t.Wait();
        }
    }
}