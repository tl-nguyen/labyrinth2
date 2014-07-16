namespace Labyrinth.Tests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class TopResultsTests
    {
        [TestMethod]
        public void TestTopResultConstructor()
        {
            var table = new TopResults();
            Assert.IsInstanceOfType(table, typeof(TopResults));
        }

        [TestMethod]
        public void TestTopResultEmptyListResultsToString()
        {
            var table = new TopResults();
            Assert.AreEqual(table.ToString(), "The scoreboard is empty.");
        }

        [TestMethod]
        public void TestTopResultAddResult()
        {
            var table = new TopResults();
            table.Add(new Result(5, "somePlayer"));
            Assert.AreEqual(table.ToString(), "1. somePlayer --> 5 moves");
        }

        [TestMethod]
        public void TestTopResultAddTwoResults()
        {
            var table = new TopResults();
            table.Add(new Result(5, "somePlayer"));
            table.Add(new Result(7, "otherPlayer"));
            Assert.AreEqual(table.ToString(), "1. somePlayer --> 5 moves" + Environment.NewLine + "2. otherPlayer --> 7 moves");
        }

        [TestMethod]
        public void TestTopResultIsTopResultEmptyTable()
        {
            var table = new TopResults();
            var current = new Result(1, "otherPlayer");
            Assert.IsTrue(table.IsTopResult(current.MovesCount));
        }


        [TestMethod]
        public void TestTopResultIsTopResultTrueFullTable()
        {
            var table = new TopResults();
            table.Add(new Result(1, "Player1"));
            table.Add(new Result(2, "Player2"));
            table.Add(new Result(3, "Player3"));
            table.Add(new Result(4, "Player4"));
            table.Add(new Result(5, "Player5"));
            table.Add(new Result(6, "Player6"));
            var current = new Result(2, "otherPlayer");
            Assert.IsTrue(table.IsTopResult(current.MovesCount));
        }

        [TestMethod]
        public void TestTopResultIsSortedTable()
        {
            var table = new TopResults();
            table.Add(new Result(6, "Player6"));
            table.Add(new Result(3, "Player3"));
            table.Add(new Result(4, "Player4"));
            table.Add(new Result(1, "Player1"));
            table.Add(new Result(5, "Player5"));
            table.Add(new Result(2, "Player2"));
            Assert.AreEqual(
                table.ToString(),
                "1. Player1 --> 1 moves" +
                Environment.NewLine +
                "2. Player2 --> 2 moves" +
                Environment.NewLine +
                "3. Player3 --> 3 moves" +
                Environment.NewLine +
                "4. Player4 --> 4 moves" +
                Environment.NewLine +
                "5. Player5 --> 5 moves");
        }

        [TestMethod]
        public void TestTopResultIsTopResultFalseFullTable()
        {
            var table = new TopResults();
            table.Add(new Result(1, "Player1"));
            table.Add(new Result(2, "Player2"));
            table.Add(new Result(3, "Player3"));
            table.Add(new Result(4, "Player4"));
            table.Add(new Result(5, "Player5"));
            table.Add(new Result(6, "Player6"));
            var current = new Result(7, "otherPlayer");
            Assert.IsFalse(table.IsTopResult(current.MovesCount));
        }

        [TestMethod]
        public void TestTopResultOnChangeEvent()
        {
            var table = new TopResults();
            var eventRaised = false;
            table.Changed += (object sender, EventArgs e) => { eventRaised = true; };
            table.Add(new Result(1, "Player1"));
            Assert.IsTrue(eventRaised);
        }
    }
}
