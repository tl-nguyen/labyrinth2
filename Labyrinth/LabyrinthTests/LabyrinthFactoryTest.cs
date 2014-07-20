namespace Labyrinth.Tests
{
    using System;
    using Labyrinth.LabyrinthHandler;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class LabyrinthFactoryTest
    {
        Factory testFactory = new Factory();
        [TestMethod]
        public void TestCellInstance()
        {
            int row = 3;
            int col = 3;
            ICell testCell = new Cell(row, col, Commons.CellState.Empty);
            var factCell = testFactory.GetCellInstance(row, col, Commons.CellState.Empty);

            Object.Equals(testCell, factCell);
        }

        [TestMethod]
        public void TestUserInputOutputInstance()
        {
            UserInputAndOutput userIO = new UserInputAndOutput();
            var factUser = testFactory.GetUserInputInstance();

            Object.Equals(userIO, factUser);
        }

        [TestMethod]
        public void TestLabyrinthInstance()
        {
            MoveHandler testHandler = new MoveHandler();
            Entities.Labyrinth testLab = new Entities.Labyrinth(testFactory, testHandler);
            var factLabyrinth = testFactory.GetLabyrinthInstance(testFactory, testHandler);

            Object.Equals(testLab, factLabyrinth);
        }

        [TestMethod]
        public void TestCellMatrixInstance()
        {
            int size = 4;
            ICell[,] testMatrix = new Cell[size, size];

            var factMatrix = testFactory.GetICellMatrixInstance(size);

            Object.Equals(testMatrix, factMatrix);
        }

        [TestMethod]
        public void TestCellMatrixRows()
        {
            int size = 4;
            ICell[,] testMatrix = new Cell[size, size];
            
            var factMatrix = testFactory.GetICellMatrixInstance(size);

            Assert.AreEqual(testMatrix.GetLength(0), factMatrix.GetLength(0));
        }

        [TestMethod]
        public void TestCellMatrixCols()
        {
            int size = 4;
            ICell[,] testMatrix = new Cell[size, size];

            var factMatrix = testFactory.GetICellMatrixInstance(size);

            Assert.AreEqual(testMatrix.GetLength(1), factMatrix.GetLength(1));
        }
    }
}
