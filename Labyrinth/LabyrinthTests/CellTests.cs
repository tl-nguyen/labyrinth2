namespace Labyrinth.Tests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Commons;
    [TestClass]
    public class CellTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentException),
        "Cell with negative row is not valid!")]
        public void TestCellRow()
        {
            Cell cell = new Cell(-1, 5, CellState.Empty);
            
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException),
        "Cell with negative col is not valid!")]
        public void TestCellCol()
        {
            Cell cell = new Cell(5, -2, CellState.Empty);

        }
    }
}
