﻿namespace Labyrinth.Tests.Results
{
    using System;
    using Labyrinth.Results;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class SeparatorResultFormatterTests
    {
        [TestMethod]
        public void TestSeparatorResultFormatterConstructorCreateInstance()
        {
            var formatter = new SeparatorResultFormatter("|");
            Assert.IsInstanceOfType(formatter, typeof(SeparatorResultFormatter));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestSeparatorResultFormatterConstructorCreateInstanceNullSeparator()
        {
            var formatter = new SeparatorResultFormatter(null);
        }

        [TestMethod]
        public void TestSeparatorResultFormatterFormat()
        {
            var formatter = new SeparatorResultFormatter("|");
            var actual = formatter.Format("player", "2");
            var expected = "player            |   2 moves |";
            Assert.AreEqual(actual, expected);
        }
    }
}
