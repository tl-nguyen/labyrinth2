namespace Labyrinth.Tests
{
    using System;
    using System.Text;
    using System.Collections.Generic;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Loggers;
    using Loggers.Contracts;

    /// <summary>
    /// Summary description for FileAppenderTest
    /// </summary>
    [TestClass]
    public class LoggersAndAppendersTest
    {
        private const string FileName = "TestLog.txt";
        private const string TestMessage = "Loggers Test";

        private IAppender fileAppender;
        private IAppender memoryAppender;
        private ILogger simpleLoggerFileAppender;
        private ILogger simpleLoggerMemoryAppender;

        [TestInitialize()]
        public void TestInitializeInstances()
        {
            this.fileAppender = new FileAppender(FileName);
            this.memoryAppender = MemoryAppender.GetInstance();
            this.simpleLoggerFileAppender = new SimpleLogger(this.fileAppender);
            this.simpleLoggerMemoryAppender = new SimpleLogger(this.memoryAppender);
        }

        [TestMethod]
        public void TestMethod1()
        {

        }
    }
}
