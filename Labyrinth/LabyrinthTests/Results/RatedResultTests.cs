namespace Labyrinth.Tests.Results
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Labyrinth.Results;

    [TestClass]
    public class RatedResultTests
    {
        private static Factory LabyrinthFactory = new Factory();
        [TestMethod]
        public void TestRatedResultConstructorCreateResult()
        {
            var result = new RatedResult(2, "player", new SeparatorResultFormatter("|"));
            Assert.IsInstanceOfType(result, typeof(RatedResult));
        }

        [TestMethod]
        public void TestRatedResultPropertyPlayerName()
        {
            var result = new RatedResult(2, "player", new SeparatorResultFormatter("|"));
            Assert.AreEqual(result.PlayerName, "player");
        }

        [TestMethod]
        public void TestRatedResultPropertyMovesCount()
        {
            var result = new RatedResult(2, "player", new SeparatorResultFormatter("|"));
            Assert.AreEqual(result.MovesCount, 2);
        }

        [TestMethod]
        public void TestRatedResultPropertyRatingMaster()
        {
            var result = new RatedResult(4, "player", new SeparatorResultFormatter("|"));
            Assert.AreEqual(result.Rating, PlayerRating.Master);
        }

        [TestMethod]
        public void TestRatedResultPropertyRatingPlayer()
        {
            var result = new RatedResult(6, "player", new SeparatorResultFormatter("|"));
            Assert.AreEqual(result.Rating, PlayerRating.Player);
        }

        [TestMethod]
        public void TestRatedResultPropertyRatingBeginner()
        {
            var result = new RatedResult(7, "player", new SeparatorResultFormatter("|"));
            Assert.AreEqual(result.Rating, PlayerRating.Beginner);
        }

        [TestMethod]
        public void TestRatedResultCompareToEqualResults()
        {
            var firstResult = new RatedResult(2, "player1", new SeparatorResultFormatter("|"));
            var secondResult = new RatedResult(2, "player2", new SeparatorResultFormatter("|"));
            Assert.AreEqual(firstResult.CompareTo(secondResult), 0);
        }

        [TestMethod]
        public void TestRatedResultCompareToFisrtBeforeSecond()
        {
            var firstResult = new RatedResult(1, "player1", new SeparatorResultFormatter("|"));
            var secondResult = new RatedResult(2, "player2", new SeparatorResultFormatter("|"));
            Assert.AreEqual(firstResult.CompareTo(secondResult), -1);
        }

        [TestMethod]
        public void TestRatedResultCompareToSecondBeforeFirst()
        {
            var firstResult = new RatedResult(3, "player1", new SeparatorResultFormatter("|"));
            var secondResult = new RatedResult(2, "player2", new SeparatorResultFormatter("|"));
            Assert.AreEqual(firstResult.CompareTo(secondResult), 1);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestRatedResultCompareToWithNull()
        {
            var firstResult = new RatedResult(3, "player1", new SeparatorResultFormatter("|"));
            Result secondResult = null;
            firstResult.CompareTo(secondResult);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestRatedResultCompareToDifferentObject()
        {
            var firstResult = new RatedResult(3, "player1", new SeparatorResultFormatter("|"));
            var secondResult = new object();
            firstResult.CompareTo(secondResult);
        }

        [TestMethod]
        public void TestRatedResultToString()
        {
            var result = new RatedResult(3, "player1", new SeparatorResultFormatter("|"));
            var expected = "player (Master)   |   3 moves |";
            var actual = result.ToString();
            Assert.AreEqual(actual, expected);
        }
    }
}
