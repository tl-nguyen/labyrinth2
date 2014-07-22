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
            var result = new RatedResult(2, "player", LabyrinthFactory.GetResultFormatterInstance());
            Assert.IsInstanceOfType(result, typeof(RatedResult));
        }

        [TestMethod]
        public void TestResultPropertyPlayerName()
        {
            var result = new RatedResult(2, "player", LabyrinthFactory.GetResultFormatterInstance());
            Assert.AreEqual(result.PlayerName, "player");
        }

        [TestMethod]
        public void TestResultPropertyMovesCount()
        {
            var result = new RatedResult(2, "player", LabyrinthFactory.GetResultFormatterInstance());
            Assert.AreEqual(result.MovesCount, 2);
        }

        [TestMethod]
        public void TestResultPropertyRatingMaster()
        {
            var result = new RatedResult(4, "player", LabyrinthFactory.GetResultFormatterInstance());
            Assert.AreEqual(result.Rating, PlayerRating.Master);
        }

        [TestMethod]
        public void TestResultPropertyRatingPlayer()
        {
            var result = new RatedResult(6, "player", LabyrinthFactory.GetResultFormatterInstance());
            Assert.AreEqual(result.Rating, PlayerRating.Player);
        }

        [TestMethod]
        public void TestResultPropertyRatingBeginner()
        {
            var result = new RatedResult(7, "player", LabyrinthFactory.GetResultFormatterInstance());
            Assert.AreEqual(result.Rating, PlayerRating.Beginner);
        }

        [TestMethod]
        public void TestResultCompareToEqualResults()
        {
            var firstResult = new RatedResult(2, "player1", LabyrinthFactory.GetResultFormatterInstance());
            var secondResult = new RatedResult(2, "player2", LabyrinthFactory.GetResultFormatterInstance());
            Assert.AreEqual(firstResult.CompareTo(secondResult), 0);
        }

        [TestMethod]
        public void TestResultCompareToFisrtBeforeSecond()
        {
            var firstResult = new RatedResult(1, "player1", LabyrinthFactory.GetResultFormatterInstance());
            var secondResult = new RatedResult(2, "player2", LabyrinthFactory.GetResultFormatterInstance());
            Assert.AreEqual(firstResult.CompareTo(secondResult), -1);
        }

        [TestMethod]
        public void TestResultCompareToSecondBeforeFirst()
        {
            var firstResult = new RatedResult(3, "player1", LabyrinthFactory.GetResultFormatterInstance());
            var secondResult = new RatedResult(2, "player2", LabyrinthFactory.GetResultFormatterInstance());
            Assert.AreEqual(firstResult.CompareTo(secondResult), 1);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestResultCompareToWithNull()
        {
            var firstResult = new RatedResult(3, "player1", LabyrinthFactory.GetResultFormatterInstance());
            Result secondResult = null;
            firstResult.CompareTo(secondResult);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestResultCompareToDifferentObject()
        {
            var firstResult = new RatedResult(3, "player1", LabyrinthFactory.GetResultFormatterInstance());
            var secondResult = new object();
            firstResult.CompareTo(secondResult);
        }
    }
}
