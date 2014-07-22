namespace Labyrinth.Tests.Results
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Labyrinth.Results;

    [TestClass]
    public class PlainResultFormatterTests
    {
        [TestMethod]
        public void TestPlainResultFormatterConstructorCreateInstance()
        {
            var formatter = new PlainResultFormatter();
            Assert.IsInstanceOfType(formatter, typeof(PlainResultFormatter));
        }

        [TestMethod]
        public void TestPlainResultFormatterFormat()
        {
            var formatter = new PlainResultFormatter();
            var actual = formatter.Format("player", "2");
            var expected = "player --> 2 moves";
            Assert.AreEqual(actual, expected);
        }
    }
}
