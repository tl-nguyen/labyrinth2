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
            Assert.AreEqual(CellState.Wall, cell.CellValue);
        }

        [TestMethod]
        public void TestChangeCellValue()
        {
            Cell cell = new Cell(3, 5, CellState.Wall);
            cell.CellValue = CellState.Player;
            Assert.AreEqual(CellState.Player, cell.CellValue);
        }

        [TestMethod]
        public void TestClone()
        {
            Cell cell = new Cell(3, 5, CellState.Wall);
            Cell copy = (Cell)cell.Clone();
            Assert.AreEqual(cell.CellValue, copy.CellValue);
            Assert.AreEqual(cell.Col, copy.Col);
            Assert.AreEqual(cell.Row, copy.Row);
        }
    }
}
