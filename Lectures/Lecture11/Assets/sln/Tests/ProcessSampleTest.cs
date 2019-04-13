using System.Diagnostics;
using System.Linq;
using Examples;
using Xunit;

namespace Tests
{
    public class ProcessSampleTest
    {
        private readonly ProcessSample processSampleSUT = new ProcessSample();
        private const string processName = "notepad";
        private const string processArg = @"C:\TestFile.txt";

        [Fact]
        public void OpenApplication_Test()
        {
            var createdProcess = processSampleSUT.OpenApplication(processName);
            var processes = Process.GetProcessesByName(processName);

            Assert.True(processes.Any());

            createdProcess.Kill();
        }

        [Fact]
        public void OpenApplicationWithArguments_Test()
        {
            var createdProcess = processSampleSUT.OpenApplicationWithArguments(processName, processArg);
            var processes = Process.GetProcessesByName(processName);

            Assert.True(processes.Any());

            createdProcess.Kill();
        }

        [Fact]
        public void OpeApplicationWithStartInfo_Test()
        {
            var createdProcess = processSampleSUT.OpeApplicationWithStartInfo(processName, processArg);
            var processes = Process.GetProcessesByName(processName);

            Assert.True(processes.Any());

            createdProcess.Kill();
        }
    }
}