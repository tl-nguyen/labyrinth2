namespace Labyrinth.Tests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class ResultTests
    {
        [TestMethod]
        public void TestResultConstructorCreateResult()
        {
            var result = new Result(2, "player");
            Assert.IsInstanceOfType(result, typeof(Result));
        }

        [TestMethod]
        public void TestResultPropertyPlayerName()
        {
            var result = new Result(2, "player");
            Assert.AreEqual(result.PlayerName, "player");
        }


        [TestMethod]
        public void TestResultPropertyMovesCount()
        {
            var result = new Result(2, "player");
            Assert.AreEqual(result.MovesCount, 2);
        }

        [TestMethod]
        public void TestResultCompareToEqualResults()
        {
            var firstResult = new Result(2, "player1");
            var secondResult = new Result(2, "player2");
            Assert.AreEqual(firstResult.CompareTo(secondResult), 0);
        }

        [TestMethod]
        public void TestResultCompareToFisrtBeforeSecond()
        {
            var firstResult = new Result(1, "player1");
            var secondResult = new Result(2, "player2");
            Assert.AreEqual(firstResult.CompareTo(secondResult), -1);
        }

        [TestMethod]
        public void TestResultCompareToSecondBeforeFirst()
        {
            var firstResult = new Result(3, "player1");
            var secondResult = new Result(2, "player2");
            Assert.AreEqual(firstResult.CompareTo(secondResult), 1);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestResultCompareToWithNull()
        {
            var firstResult = new Result(3, "player1");
            Result secondResult = null;
            firstResult.CompareTo(secondResult);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestResultCompareToDifferentObject()
        {
            var firstResult = new Result(3, "player1");
            var secondResult = new Object();
            firstResult.CompareTo(secondResult);
        }
    }
}
