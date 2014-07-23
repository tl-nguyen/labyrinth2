namespace Labyrinth.Tests.Results
{
    using System;
    using System.Linq;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Labyrinth.Results;

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
        public void TestGetTopResultsStringsEmptyList()
        {
            var table = new TopResults();
            var expected = new string[0];
            var actual = table.GetTopResultsStrings();
            Assert.IsTrue(actual.SequenceEqual<string>(expected));
        }

        [TestMethod]
        public void TestTopResultAddResult()
        {
            var table = new TopResults();
            var result = new SimpleResult(5, "somePlayer", new PlainResultFormatter());
            table.Add(result);
            var expected = new string[] { result.ToString() };
            var actual = table.GetTopResultsStrings();
            Assert.IsTrue(actual.SequenceEqual<string>(expected));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestTopResultAddNullResult()
        {
            var table = new TopResults();
            table.Add(null);
        }

        [TestMethod]
        public void TestTopResultAddTwoResults()
        {
            var table = new TopResults();
            var first = new SimpleResult(5, "somePlayer", new PlainResultFormatter());
            var second = new SimpleResult(7, "otherPlayer", new PlainResultFormatter());
            table.Add(first);
            table.Add(second);
            var expected = new string[] { first.ToString(), second.ToString() };
            var actual = table.GetTopResultsStrings();
            Assert.IsTrue(actual.SequenceEqual<string>(expected));
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
            var results = new Result[6] {
            new SimpleResult(6, "Player6", new PlainResultFormatter()),
            new SimpleResult(3, "Player3", new PlainResultFormatter()),
            new SimpleResult(4, "Player4", new PlainResultFormatter()),
            new SimpleResult(1, "Player1", new PlainResultFormatter()),
            new SimpleResult(5, "Player5", new PlainResultFormatter()),
            new SimpleResult(2, "Player2", new PlainResultFormatter())
            };
            for (int i = 0; i < results.Length; i++)
            {
                table.Add(results[i]);
            }

            var actual = table.GetTopResultsStrings();
            var expected = new string[] { 
                results[3].ToString(),
                results[5].ToString(),
                results[1].ToString(),
                results[2].ToString(),
                results[4].ToString()
            };
                
            Assert.IsTrue(actual.SequenceEqual<string>(expected));
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
