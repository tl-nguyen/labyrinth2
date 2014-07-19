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
        public void TestCellRowInvalid()
        {
            Cell cell = new Cell(-1, 5, CellState.Empty);
            
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException),
        "Cell with negative col is not valid!")]
        public void TestCellColInvalid()
        {
            Cell cell = new Cell(5, -1, CellState.Empty);

        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException),
        "Cell with negative col is not valid!")]
        public void TestChangeCellColInvalid()
        {
            Cell cell = new Cell(5, 2, CellState.Empty);
            cell.Col = -2;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException),
        "Cell with negative row is not valid!")]
        public void TestChangeCellRowInvalid()
        {
            Cell cell = new Cell(1, 5, CellState.Empty);
            cell.Row = -1;
        }

        [TestMethod]
        public void TestIsEmptyTrue()
        {
            Cell cell = new Cell(1, 5, CellState.Empty);
            Assert.IsTrue(cell.IsEmpty());
        }

        [TestMethod]
        public void TestIsEmptyWithPlayer()
        {
            Cell cell = new Cell(3, 5, CellState.Player);
            Assert.IsFalse(cell.IsEmpty());
        }

        [TestMethod]
        public void TestIsEmptyWithWall()
        {
            Cell cell = new Cell(3, 5, CellState.Wall);
            Assert.IsFalse(cell.IsEmpty());
        }

        [TestMethod]
        public void TestCellValue()
        {
            Cell cell = new Cell(3, 5, CellState.Wall);
            Assert.Equals(CellState.Wall, cell.CellValue);
        }

        [TestMethod]
        public void TestChangeCellValue()
        {
            Cell cell = new Cell(3, 5, CellState.Wall);
            cell.CellValue = CellState.Player;
            Assert.Equals(CellState.Player, cell.CellValue);
        }
    }
}
