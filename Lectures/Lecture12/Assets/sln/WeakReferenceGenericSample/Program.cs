using System;
using System.Text;

namespace WeakReferenceGenericSample
{
    class Program
    {
        private static WeakReference<StringBuilder> weakReference;

        private static void Main(string[] args)
        {
            SetWeakReference();

            TryWeakReference();

            MakeGarbage();

            TryWeakReference();
        }

        private static void TryWeakReference()
        {
            StringBuilder sb;
            if (weakReference.TryGetTarget(out sb))
            {
                Console.WriteLine("Object lives {0}.", sb);
            }
            else
            {
                Console.WriteLine("Object is not in memory anymore.");
            }
        }

        private static void SetWeakReference()
        {
            var sb = new StringBuilder("Hello word!");
            weakReference = new WeakReference<StringBuilder>(sb);
        }

        private static void MakeGarbage()
        {
            //GC.Collect();
            for (int i = 0; i < 100000; i++)
            {
                var newStringBuilder = new StringBuilder();
                newStringBuilder.Append("Some text");
            }
        }
    }
}