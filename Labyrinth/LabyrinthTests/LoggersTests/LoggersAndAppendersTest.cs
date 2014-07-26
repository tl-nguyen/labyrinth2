namespace Labyrinth.Tests.LoggersTests
{
    using Labyrinth.Loggers.Contracts;
    using Loggers;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
    using System.IO;

    /// <summary>
    /// Summary Here are the tests for loggers and appenders
    /// </summary>
    [TestClass]
    public class LoggersAndAppendersTest
    {
        private const string FileName = "TestLog.txt";
        private const string TestMessage = "Loggers Test";
        private const ulong DefaultCount = 0;

        private IAppender fileAppender;
        private IAppender memoryAppender;
        private ILogger simpleLoggerFileAppender;
        private ILogger simpleLoggerMemoryAppender;

        [TestInitialize()]
        public void TestInitializeInstances()
        {
            this.fileAppender = LabyrinthFactory.GetFileAppender(FileName);
            this.memoryAppender = LabyrinthFactory.GetMemoryAppender();
            this.simpleLoggerFileAppender = LabyrinthFactory.GetSimpleLogger(this.fileAppender);
            this.simpleLoggerMemoryAppender = LabyrinthFactory.GetSimpleLogger(this.memoryAppender);
        }

        [TestMethod]
        public void TestFileAppender()
        {
            this.simpleLoggerFileAppender.Log(TestMessage);
            Assert.AreEqual(DefaultCount + 1, this.fileAppender.MessageCount, "Logged messages are not count correctly!");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestFileAppenderNullCreation()
        {
            var fileAppender = LabyrinthFactory.GetFileAppender(string.Empty);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestSimpleLoggerWithFileAppenderNullCreation()
        {
            var simpleLogger = LabyrinthFactory.GetSimpleLogger(null);
        }

        [TestMethod]
        public void TestSimpleLoggerWithFileAppenderLog()
        {
            File.Delete(FileName);
            this.simpleLoggerFileAppender.Log(TestMessage);
            var stream = new StreamReader(FileName);
            var readedMessage = stream.ReadLine();
            var result = readedMessage.Contains(TestMessage);
            Assert.AreEqual(true, result, "The SimpleLoggerWithFileAppender does not write correctly in the file!");
        }
    }
}