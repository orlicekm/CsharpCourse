using System;
using System.Text;

namespace WeakReferenceSample
{
    internal class Program
    {
        private static WeakReference weak;

        private static void Main()
        {
            weak = new WeakReference(new StringBuilder("Hello word!"));

            TryWeakReference();

            MakeGarbage();

            TryWeakReference();
        }

        private static void TryWeakReference()
        {
            if (weak.IsAlive)
            {
                //MakeGarbage();
                Console.WriteLine("Object lives {0}.", (weak.Target as StringBuilder));
            }
            else
            {
                Console.WriteLine("Object is not in memory anymore.");
            }
        }

        private static void MakeGarbage()
        {
            //GC.Collect();
            for (int i = 0; i < 1000000; i++)
            {
                var newStringBuilder = new StringBuilder();
                newStringBuilder.Append("Some text");
            }
        }
    }
}