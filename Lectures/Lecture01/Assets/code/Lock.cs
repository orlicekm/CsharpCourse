namespace LockExample
{
    class Lock
    {
        private Object thisLock = new Object();

        static void Main()
        {
            int i = 0;
            lock (thisLock)
            {
                i = i++;
            }
        }
    }
}