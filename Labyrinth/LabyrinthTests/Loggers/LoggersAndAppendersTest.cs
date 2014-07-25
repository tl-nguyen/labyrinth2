namespace Labyrinth.Tests.LoggersTests
{
    using Labyrinth.Loggers.Contracts;
    using Loggers;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
    using System.Collections.Generic;
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

        private Factory factory;
        private IAppender fileAppender;
        private IAppender memoryAppender;
        private ILogger simpleLoggerFileAppender;
        private ILogger simpleLoggerMemoryAppender;

        [TestInitialize()]
        public void TestInitializeInstances()
        {
            this.factory = new Factory();
            this.fileAppender = factory.GetFileAppender(FileName);
            this.memoryAppender = factory.GetMemoryAppender();
            this.simpleLoggerFileAppender = factory.GetSimpleLogger(this.fileAppender);
            this.simpleLoggerMemoryAppender = factory.GetSimpleLogger(this.memoryAppender);
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
            var fileAppender = factory.GetFileAppender(string.Empty);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestSimpleLoggerWithFileAppenderNullCreation()
        {
            var simpleLogger = factory.GetSimpleLogger(null);
        }

        [TestMethod]
        public void TestSimpleLoggerWithFileAppenderLog()
        {
            this.simpleLoggerFileAppender.Log(TestMessage);
            var stream = new StreamReader(FileName);
            var readedMessage = stream.ReadLine();
            stream.Close();
            var result = readedMessage.Contains(TestMessage);
            Assert.AreEqual(true, result, "The SimpleLoggerWithFileAppender does not write correctly in the file!");
        }

        [TestMethod]
        public void TestSimpleLoggerWithMemoryAppenderLog()
        {
            this.simpleLoggerMemoryAppender.Log(TestMessage);
            var messages = MemoryAppender.GetMessages(memoryAppender, (x => x == x));
            var result = messages[0].Contains(TestMessage);
            Assert.AreEqual(true, result, "The SimpleLoggerWithMemoryAppender does not write correctly!");
        }

        [TestMethod]
        public void TestSimpleLoggerWithMemoryAppenderMessageCount()
        {
            this.simpleLoggerMemoryAppender.Log(TestMessage);
            var result = memoryAppender.MessageCount;
            Assert.AreEqual(2u, result, "The SimpleLoggerWithMemoryAppender does not count messages correctly!");
        }
    }
}