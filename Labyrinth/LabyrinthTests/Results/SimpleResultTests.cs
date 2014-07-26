namespace Labyrinth.Tests.Results
{
    using System;
    using Labyrinth.Results;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class SimpleResultTests
    {
        [TestMethod]
        public void TestSimpleResultConstructorCreateResult()
        {
            var result = new SimpleResult(2, "player", new PlainResultFormatter());
            Assert.IsInstanceOfType(result, typeof(SimpleResult));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestSimpleResultConstructorCreateResultZeroCount()
        {
            var result = new SimpleResult(0, "player", new PlainResultFormatter());
        }

        [TestMethod]
        public void TestSimpleResultConstructorCreateResultEmptyName()
        {
            var result = new SimpleResult(5, string.Empty, new PlainResultFormatter());
            var expected = "Anonymous";
            Assert.AreEqual(result.PlayerName, expected);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestSimpleResultConstructorCreateResultNullFormatter()
        {
            var result = new SimpleResult(7, "player", null);
        }

        [TestMethod]
        public void TestResultPropertyPlayerName()
        {
            var result = new SimpleResult(2, "player", new PlainResultFormatter());
            Assert.AreEqual(result.PlayerName, "player");
        }

        [TestMethod]
        public void TestResultPropertyMovesCount()
        {
            var result = new SimpleResult(2, "player", new PlainResultFormatter());
            Assert.AreEqual(result.MovesCount, 2);
        }

        [TestMethod]
        public void TestResultPropertyFormatter()
        {
            var result = new SimpleResult(2, "player", new PlainResultFormatter());
            Assert.IsInstanceOfType(result.Formatter, typeof(PlainResultFormatter));
        }

        [TestMethod]
        public void TestResultCompareToEqualResults()
        {
            var firstResult = new SimpleResult(2, "player1", new PlainResultFormatter());
            var secondResult = new SimpleResult(2, "player2", new PlainResultFormatter());
            Assert.AreEqual(firstResult.CompareTo(secondResult), 0);
        }

        [TestMethod]
        public void TestResultCompareToFisrtBeforeSecond()
        {
            var firstResult = new SimpleResult(1, "player1", new PlainResultFormatter());
            var secondResult = new SimpleResult(2, "player2", new PlainResultFormatter());
            Assert.AreEqual(firstResult.CompareTo(secondResult), -1);
        }

        [TestMethod]
        public void TestResultCompareToSecondBeforeFirst()
        {
            var firstResult = new SimpleResult(3, "player1", new PlainResultFormatter());
            var secondResult = new SimpleResult(2, "player2", new PlainResultFormatter());
            Assert.AreEqual(firstResult.CompareTo(secondResult), 1);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestResultCompareToWithNull()
        {
            var firstResult = new SimpleResult(3, "player1", new PlainResultFormatter());
            Result secondResult = null;
            firstResult.CompareTo(secondResult);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestResultCompareToDifferentObject()
        {
            var firstResult = new SimpleResult(3, "player1", new PlainResultFormatter());
            var secondResult = new object();
            firstResult.CompareTo(secondResult);
        }
    }
}
