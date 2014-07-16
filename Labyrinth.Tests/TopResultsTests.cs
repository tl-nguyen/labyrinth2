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
            var expected =
                "|----------------------------------|" +
                Environment.NewLine +
                "|         Top Results Table        |" +
                Environment.NewLine +
                "|----------------------------------|" +
                Environment.NewLine +
                "|     The scoreboard is empty.     |" +
                Environment.NewLine +
                "|----------------------------------|";

            Assert.AreEqual(table.ToString(), expected);
        }

        [TestMethod]
        public void TestTopResultAddResult()
        {
            var table = new TopResults();
            table.Add(new SimpleResult(5, "somePlayer", new PlainResultFormatter()));
            var expected = 
                "|----------------------------------|" +
                Environment.NewLine +
                "|         Top Results Table        |" +
                Environment.NewLine +
                "|----------------------------------|" +
                Environment.NewLine +
                "| 1. somePlayer --> 5 moves |" +
                Environment.NewLine +
                "|----------------------------------|";
            Assert.AreEqual(table.ToString(), expected);
        }

        [TestMethod]
        public void TestTopResultAddTwoResults()
        {
            var table = new TopResults();
            table.Add(new SimpleResult(5, "somePlayer", new PlainResultFormatter()));
            table.Add(new SimpleResult(7, "otherPlayer", new PlainResultFormatter()));
            var expected =
                "|----------------------------------|" +
                Environment.NewLine +
                "|         Top Results Table        |" +
                Environment.NewLine +
                "|----------------------------------|" +
                Environment.NewLine +
                "| 1. somePlayer --> 5 moves |" +
                Environment.NewLine +
                "| 2. otherPlayer --> 7 moves |" +
                Environment.NewLine +
                "|----------------------------------|";
            Assert.AreEqual(table.ToString(), expected);
        }

        [TestMethod]
        public void TestTopResultIsTopResultEmptyTable()
        {
            var table = new TopResults();
            var current = new SimpleResult(1, "otherPlayer", new PlainResultFormatter());
            Assert.IsTrue(table.IsTopResult(current.MovesCount));
        }


        [TestMethod]
        public void TestTopResultIsTopResultTrueFullTable()
        {
            var table = new TopResults();
            table.Add(new SimpleResult(1, "Player1", new PlainResultFormatter()));
            table.Add(new SimpleResult(2, "Player2", new PlainResultFormatter()));
            table.Add(new SimpleResult(3, "Player3", new PlainResultFormatter()));
            table.Add(new SimpleResult(4, "Player4", new PlainResultFormatter()));
            table.Add(new SimpleResult(5, "Player5", new PlainResultFormatter()));
            table.Add(new SimpleResult(6, "Player6", new PlainResultFormatter()));
            var current = new SimpleResult(2, "otherPlayer", new PlainResultFormatter());
            Assert.IsTrue(table.IsTopResult(current.MovesCount));
        }

        [TestMethod]
        public void TestTopResultIsSortedTable()
        {
            var table = new TopResults();
            table.Add(new SimpleResult(6, "Player6", new PlainResultFormatter()));
            table.Add(new SimpleResult(3, "Player3", new PlainResultFormatter()));
            table.Add(new SimpleResult(4, "Player4", new PlainResultFormatter()));
            table.Add(new SimpleResult(1, "Player1", new PlainResultFormatter()));
            table.Add(new SimpleResult(5, "Player5", new PlainResultFormatter()));
            table.Add(new SimpleResult(2, "Player2", new PlainResultFormatter()));
            var expected =
                "|----------------------------------|" +
                Environment.NewLine +
                "|         Top Results Table        |" +
                Environment.NewLine +
                "|----------------------------------|" +
                Environment.NewLine +
                "| 1. Player1 --> 1 moves |" +
                Environment.NewLine +
                "| 2. Player2 --> 2 moves |" +
                Environment.NewLine +
                "| 3. Player3 --> 3 moves |" +
                Environment.NewLine +
                "| 4. Player4 --> 4 moves |" +
                Environment.NewLine +
                "| 5. Player5 --> 5 moves |" +
                Environment.NewLine +
                "|----------------------------------|";
            Assert.AreEqual(table.ToString(), expected);
        }

        [TestMethod]
        public void TestTopResultIsTopResultFalseFullTable()
        {
            var table = new TopResults();
            table.Add(new SimpleResult(1, "Player1", new PlainResultFormatter()));
            table.Add(new SimpleResult(2, "Player2", new PlainResultFormatter()));
            table.Add(new SimpleResult(3, "Player3", new PlainResultFormatter()));
            table.Add(new SimpleResult(4, "Player4", new PlainResultFormatter()));
            table.Add(new SimpleResult(5, "Player5", new PlainResultFormatter()));
            table.Add(new SimpleResult(6, "Player6", new PlainResultFormatter()));
            var current = new SimpleResult(7, "otherPlayer", new PlainResultFormatter());
            Assert.IsFalse(table.IsTopResult(current.MovesCount));
        }

        [TestMethod]
        public void TestTopResultOnChangeEvent()
        {
            var table = new TopResults();
            var eventRaised = false;
            table.Changed += (object sender, EventArgs e) => { eventRaised = true; };
            table.Add(new SimpleResult(1, "Player1", new PlainResultFormatter()));
            Assert.IsTrue(eventRaised);
        }
    }
}
