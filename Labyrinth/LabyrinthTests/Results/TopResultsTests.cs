namespace Labyrinth.Tests.Results
{
    using System;
    using System.Linq;
    using Labyrinth.Results;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class TopResultsTests
    {
        private TopResults table;

        [TestInitialize]
        public void InitializeTopResultsInstance()
        {
            this.table = new TopResults();
        }

        [TestMethod]
        public void TestTopResultsConstructor()
        {
            Assert.IsInstanceOfType(this.table, typeof(TopResults));
        }

        [TestMethod]
        public void TestGetTopResultsStringsEmptyList()
        {
            var expected = new string[0];
            var actual = this.table.GetTopResultsStrings();
            Assert.IsTrue(actual.SequenceEqual<string>(expected));
        }

        [TestMethod]
        public void TestTopResultAddResult()
        {
            var result = new SimpleResult(5, "somePlayer", new PlainResultFormatter());
            this.table.Add(result);
            var expected = new string[] { result.ToString() };
            var actual = this.table.GetTopResultsStrings();
            Assert.IsTrue(actual.SequenceEqual<string>(expected));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestTopResultAddNullResult()
        {
            this.table.Add(null);
        }

        [TestMethod]
        public void TestTopResultAddTwoResults()
        {
            var first = new SimpleResult(5, "somePlayer", new PlainResultFormatter());
            var second = new SimpleResult(7, "otherPlayer", new PlainResultFormatter());
            this.table.Add(first);
            this.table.Add(second);
            var expected = new string[] { first.ToString(), second.ToString() };
            var actual = this.table.GetTopResultsStrings();
            Assert.IsTrue(actual.SequenceEqual<string>(expected));
        }

        [TestMethod]
        public void TestTopResultIsTopResultEmptyTable()
        {
            var current = new SimpleResult(1, "otherPlayer", new PlainResultFormatter());
            Assert.IsTrue(this.table.IsTopResult(current.MovesCount));
        }

        [TestMethod]
        public void TestTopResultIsTopResultTrueFullTable()
        {
            this.table.Add(new SimpleResult(1, "Player1", new PlainResultFormatter()));
            this.table.Add(new SimpleResult(2, "Player2", new PlainResultFormatter()));
            this.table.Add(new SimpleResult(3, "Player3", new PlainResultFormatter()));
            this.table.Add(new SimpleResult(4, "Player4", new PlainResultFormatter()));
            this.table.Add(new SimpleResult(5, "Player5", new PlainResultFormatter()));
            this.table.Add(new SimpleResult(6, "Player6", new PlainResultFormatter()));
            var current = new SimpleResult(2, "otherPlayer", new PlainResultFormatter());
            Assert.IsTrue(this.table.IsTopResult(current.MovesCount));
        }

        [TestMethod]
        public void TestTopResultIsSortedTable()
        {
            var results = new Result[6] 
            {
            new SimpleResult(6, "Player6", new PlainResultFormatter()),
            new SimpleResult(3, "Player3", new PlainResultFormatter()),
            new SimpleResult(4, "Player4", new PlainResultFormatter()),
            new SimpleResult(1, "Player1", new PlainResultFormatter()),
            new SimpleResult(5, "Player5", new PlainResultFormatter()),
            new SimpleResult(2, "Player2", new PlainResultFormatter())
            };
            for (int i = 0; i < results.Length; i++)
            {
                this.table.Add(results[i]);
            }

            var actual = this.table.GetTopResultsStrings();
            var expected = new string[] 
            { 
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
            this.table.Add(new SimpleResult(1, "Player1", new PlainResultFormatter()));
            this.table.Add(new SimpleResult(2, "Player2", new PlainResultFormatter()));
            this.table.Add(new SimpleResult(3, "Player3", new PlainResultFormatter()));
            this.table.Add(new SimpleResult(4, "Player4", new PlainResultFormatter()));
            this.table.Add(new SimpleResult(5, "Player5", new PlainResultFormatter()));
            this.table.Add(new SimpleResult(6, "Player6", new PlainResultFormatter()));
            var current = new SimpleResult(7, "otherPlayer", new PlainResultFormatter());
            Assert.IsFalse(this.table.IsTopResult(current.MovesCount));
        }

        [TestMethod]
        public void TestTopResultOnChangeEvent()
        {
            var eventRaised = false;
            this.table.Changed += (object sender, EventArgs e) => { eventRaised = true; };
            this.table.Add(new SimpleResult(1, "Player1", new PlainResultFormatter()));
            Assert.IsTrue(eventRaised);
        }
    }
}
