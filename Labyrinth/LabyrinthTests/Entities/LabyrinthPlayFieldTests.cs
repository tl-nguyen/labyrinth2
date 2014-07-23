namespace Labyrinth.Tests.Entities
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Labyrinth.Entities;
    using Labyrinth.LabyrinthHandler;
    using Labyrinth.Commons;

    [TestClass]
    public class LabyrinthPlayFieldTests
    {
        [TestMethod]
        public void RowsSizeMustBeEqualToColsSize()
        {
            var size = 5;
            var labyrinth = new LabyrinthPlayField(new Factory(), new MoveHandler(), size);

            Assert.IsTrue(labyrinth.Matrix.GetLength(0) == labyrinth.Matrix.GetLength(1));
        }

        [TestMethod]
        public void ProducedMatrixMustHaveCorrectSize()
        {
            var size = 10;
            var labyrinth = new LabyrinthPlayField(new Factory(), new MoveHandler(), size);

            Assert.AreEqual(size, labyrinth.Matrix.GetLength(0));
        }

        [TestMethod]
        public void TheStartingPointMustBeInTheMiddleOfTheField()
        {
            var size = 15;
            var labyrinth = new LabyrinthPlayField(new Factory(), new MoveHandler(), size);

            Assert.IsTrue(labyrinth.CurrentCell.Row == (size / 2) && labyrinth.CurrentCell.Col == (size / 2));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "CurrentCell must be >= 0 and < Labyrinth Size")]
        public void TestInvalidCurrentCellWithNegativeCellRowOrColParams()
        {
            var size = 15;
            var labyrinth = new LabyrinthPlayField(new Factory(), new MoveHandler(), size);

            labyrinth.CurrentCell = new Cell(5, -1, CellState.Empty);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException), "CurrentCell must be >= 0 and < Labyrinth Size")]
        public void TestInvalidCurrentCellWithRowOrColGreaterThanOrEqualTheSize()
        {
            var size = 15;
            var labyrinth = new LabyrinthPlayField(new Factory(), new MoveHandler(), size);

            labyrinth.CurrentCell = new Cell(size, 10, CellState.Empty);
        }

    }
}
