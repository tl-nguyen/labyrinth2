using System;
using Labyrinth.LabyrinthHandler;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Labyrinth.Tests
{
    [TestClass]
    public class LabyrinthFactoryTest
    {
        [TestMethod]
        public void TestCellInstance()
        {
            int row = 3;
            int col = 3;
            ICell testCell = new Cell(row, col, Commons.CellState.Empty);
            var factCell = LabyrinthFactory.GetCellInstance(row, col, Commons.CellState.Empty);

            Object.Equals(testCell, factCell);
        }

        [TestMethod]
        public void TestUserInputOutputInstance()
        {
            UserInputAndOutput userIO = new UserInputAndOutput();
            var factUser = LabyrinthFactory.GetUserInputInstance();

            Object.Equals(userIO, factUser);
        }

        [TestMethod]
        public void TestLabyrinthInstance()
        {
            LabyrinthHandler.Labyrinth testLab = new LabyrinthHandler.Labyrinth();
            var factLabyrinth = LabyrinthFactory.GetLabyrinthInstance();

            Object.Equals(testLab, factLabyrinth);
        }

        [TestMethod]
        public void TestPlayerInstance()
        {
           LabyrinthHandler.Labyrinth testLab = new LabyrinthHandler.Labyrinth();
           Player testPlayer = new Player(testLab);
           var factPlayer = LabyrinthFactory.GetPlayerInstance(testLab);

           Object.Equals(testLab, factPlayer);
        }

        [TestMethod]
        public void TestCellMatrixInstance()
        {
            int size = 4;
            ICell[,] testMatrix = new Cell[size, size];

            var factMatrix = LabyrinthFactory.GetICellMatrixInstance(size);

            Object.Equals(testMatrix, factMatrix);
        }

        [TestMethod]
        public void TestCellMatrixRows()
        {
            int size = 4;
            ICell[,] testMatrix = new Cell[size, size];

            var factMatrix = LabyrinthFactory.GetICellMatrixInstance(size);

            Assert.AreEqual(testMatrix.GetLength(0), factMatrix.GetLength(0));
        }

        [TestMethod]
        public void TestCellMatrixCols()
        {
            int size = 4;
            ICell[,] testMatrix = new Cell[size, size];

            var factMatrix = LabyrinthFactory.GetICellMatrixInstance(size);

            Assert.AreEqual(testMatrix.GetLength(1), factMatrix.GetLength(1));
        }

    }
}
