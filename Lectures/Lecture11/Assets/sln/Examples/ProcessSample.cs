using System.Diagnostics;
using System.Runtime.InteropServices.ComTypes;

namespace Examples
{
    public class ProcessSample
    {
        public Process OpenApplication(string name)
        {
            return Process.Start(name);
        }

        public Process OpenApplicationWithArguments(string name, string arg)
        {
            return Process.Start(name, arg);
        }

        public Process OpeApplicationWithStartInfo(string name, string arg)
        {
            var startInfo = new ProcessStartInfo(name)
            {
                WindowStyle = ProcessWindowStyle.Minimized,
                Arguments = arg
            };

            return Process.Start(startInfo);
        }
    }
}