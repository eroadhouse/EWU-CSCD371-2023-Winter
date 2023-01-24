using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

namespace Logger.Tests
{
    [TestClass]
    public class FileLoggerTests
    {
        [TestMethod]
        public void Log_GivenLog_Success()
        {
            LogFactory testFactory = new();
            testFactory.ConfigureFileLogger("test.txt");
            FileLogger testFileLogger = (FileLogger)testFactory.CreateLogger(nameof(FileLoggerTests));
            testFileLogger.Information("Test message {0} {1}", "test1", "test2");

            string[] fileText = File.ReadAllLines(testFileLogger.FilePath);

            Assert.AreEqual(string.Format($"{DateTime.Now} {testFileLogger.ClassName} {LogLevel.Information}: Test message test1 test2"), fileText[^1]);
        }
    }
}
