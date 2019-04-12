using System.Diagnostics;

namespace Examples
{
    public class ProcessSample
    {
        public void OpenApplication()
        {
            Process.Start("IExplore.exe");
        }

        public void OpenApplicationWithArguments()
        {
            Process.Start("IExplore.exe", @"C:\TestFile.html");
        }

        public void OpeApplicationWithStartInfo()
        {
            var startInfo = new ProcessStartInfo("IExplore.exe")
            {
                WindowStyle = ProcessWindowStyle.Minimized,
                Arguments = @"C:\TestFile.html"
            };

            Process.Start(startInfo);
        }
    }
}