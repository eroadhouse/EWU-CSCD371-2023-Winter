using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

namespace Logger.Tests
{
    [TestClass]
    public class LogFactoryTests
    {
        [TestMethod]
        public void CreateLogger_GivenFileLogger_ReturnFileLogger()
        {
            LogFactory testFactory = new();
            testFactory.ConfigureFileLogger(filePath: "testPath");
            FileLogger testFileLogger = (FileLogger)testFactory.CreateLogger(nameof(LogFactoryTests));
            Assert.AreEqual("FileLogger", testFileLogger.ClassName);
        }

        [TestMethod]
        public void CreateLogger_GivenNoConfigure_ReturnNull()
        {
            LogFactory testFactory = new();
            FileLogger testFileLogger = (FileLogger)testFactory.CreateLogger("FileLogger");
            Assert.IsNull(testFileLogger);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CreateLogger_GivenInvalidLogger_ThrowArgumentException()
        {
            LogFactory testFactory = new();
            testFactory.ConfigureFileLogger(filePath: "testPath");
            FileLogger testFileLogger = (FileLogger)testFactory.CreateLogger("NotALogger");
        }

        [TestMethod]
        public void ConfigureFileLogger_GivenFilePath_Success()
        {
            LogFactory testFactory = new();
            testFactory.ConfigureFileLogger(filePath: "testPath");
            Assert.AreEqual("testPath", testFactory.FileLoggerPath);
        }
    }
}
