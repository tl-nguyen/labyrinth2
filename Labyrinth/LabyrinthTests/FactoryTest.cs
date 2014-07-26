namespace Labyrinth.Tests
{
    using System;
    using Labyrinth.LabyrinthHandler;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Labyrinth.UI;
    using Moq;
    using Labyrinth.Renderer.Contracts;
    using Labyrinth.Entities.Contracts;
    using Labyrinth.Renderer;
    using Labyrinth.Results;
    using Labyrinth.Entities;
    using Labyrinth.LabyrinthHandler.Contracts;

    [TestClass]
    public class FactoryTest
    {
        private Factory testFactory = new Factory();

        [TestMethod]
        public void TestCellInstance()
        {
            int row = 3;
            int col = 3;
            ICell testCell = new Cell(row, col, Commons.CellState.Empty);
            var factCell = this.testFactory.GetCellInstance(row, col, Commons.CellState.Empty);

            Assert.AreEqual(testCell.CellValue, factCell.CellValue);
            Assert.AreEqual(testCell.Row, factCell.Row);
            Assert.AreEqual(testCell.Col, factCell.Col);
        }

        [TestMethod]
        public void TestGetUserInputInstanceCorrectInstance()
        {
            var actual = this.testFactory.GetUserInputInstance();

            Assert.IsInstanceOfType(actual, typeof(UserInputConsole));
        }

        [TestMethod]
        public void TestLabyrinthInstanceGetsCorrectInstance()
        {
            var actual = this.testFactory.GetLabyrinthInstance(this.testFactory, this.testFactory.GetMoveHandlerInstance());

            Assert.IsInstanceOfType(actual, typeof(LabyrinthPlayField));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestLabyrinthInstanceNullFactory()
        {
            var testHandler = new Mock<IMoveHandler>();
            var actual = this.testFactory.GetLabyrinthInstance(null, testHandler.Object);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestLabyrinthInstanceNullMoveHandler()
        {
            var testHandler = new Mock<IMoveHandler>();
            var actual = this.testFactory.GetLabyrinthInstance(this.testFactory, null);
        }

        [TestMethod]
        public void TestCellMatrixInstanceGetsCorrectInstance()
        {
            int size = 4;
            var actual = this.testFactory.GetICellMatrixInstance(size);

            Assert.IsInstanceOfType(actual, typeof(Cell[,]));

        }

        [TestMethod]
        public void TestCellMatrixRows()
        {
            int size = 4;
            ICell[,] testMatrix = new Cell[size, size];
            
            var factMatrix = this.testFactory.GetICellMatrixInstance(size);

            Assert.AreEqual(testMatrix.GetLength(0), factMatrix.GetLength(0));
        }

        [TestMethod]
        public void TestCellMatrixCols()
        {
            int size = 4;
            ICell[,] testMatrix = new Cell[size, size];

            var factMatrix = this.testFactory.GetICellMatrixInstance(size);

            Assert.AreEqual(testMatrix.GetLength(1), factMatrix.GetLength(1));
        }

        [TestMethod]
        public void TestGetConsoleGraphicFactoryGetsCorrectInstance()
        {
            var actual = this.testFactory.GetConsoleGraphicFactory();

            Assert.IsInstanceOfType(actual, typeof(ConsoleGraphicFactory));
        }

        [TestMethod]
        public void TestGetConsoleSceneGetsCorrectInstance()
        {
            var renderer = new Mock<IConsoleRenderer>();
            var actual = this.testFactory.GetConsoleScene(renderer.Object);

            Assert.IsInstanceOfType(actual, typeof(ConsoleScene));
        }

        [TestMethod]
        public void TestGetGameLogicGetsCorrectInstance()
        {
            var playField = new Mock<ILabyrinthPlayField>();
            var gameConsole = new Mock<IGameConsole>();
            var resultTable = new Mock<IResultsTable>();
            var userInput = new Mock<IUserInput>();
            var factory = new Mock<IResultFactory>();
            var actual = this.testFactory.GetGameLogic(playField.Object, gameConsole.Object, resultTable.Object, userInput.Object, factory.Object);

            Assert.IsInstanceOfType(actual, typeof(GameLogic));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestGetGameLogicWithNullILabyrinthPlayField()
        {
            var gameConsole = new Mock<IGameConsole>();
            var resultTable = new Mock<IResultsTable>();
            var userInput = new Mock<IUserInput>();
            var factory = new Mock<IResultFactory>();
            var actual = this.testFactory.GetGameLogic(null, gameConsole.Object, resultTable.Object, userInput.Object, factory.Object);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestGetGameLogicWithNullIGameConsole()
        {
            var playField = new Mock<ILabyrinthPlayField>();
            var resultTable = new Mock<IResultsTable>();
            var userInput = new Mock<IUserInput>();
            var factory = new Mock<IResultFactory>();
            var actual = this.testFactory.GetGameLogic(playField.Object, null, resultTable.Object, userInput.Object, factory.Object);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestGetGameLogicWithNullIResultsTable()
        {
            var playField = new Mock<ILabyrinthPlayField>();
            var gameConsole = new Mock<IGameConsole>();
            var userInput = new Mock<IUserInput>();
            var factory = new Mock<IResultFactory>();
            var actual = this.testFactory.GetGameLogic(playField.Object, gameConsole.Object, null, userInput.Object, factory.Object);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestGetGameLogicWithNullIUserInput()
        {
            var playField = new Mock<ILabyrinthPlayField>();
            var gameConsole = new Mock<IGameConsole>();
            var resultTable = new Mock<IResultsTable>();
            var factory = new Mock<IResultFactory>();
            var actual = this.testFactory.GetGameLogic(playField.Object, gameConsole.Object, resultTable.Object, null, factory.Object);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestGetGameLogicWithNullIResultFactory()
        {
            var playField = new Mock<ILabyrinthPlayField>();
            var gameConsole = new Mock<IGameConsole>();
            var resultTable = new Mock<IResultsTable>();
            var userInput = new Mock<IUserInput>();
            var actual = this.testFactory.GetGameLogic(playField.Object, gameConsole.Object, resultTable.Object, userInput.Object, null);
        }

        [TestMethod]
        public void TestGetILanguageStringsCorrectInstance()
        {
            var actual = this.testFactory.GetLanguageStringsInstance();

            Assert.IsInstanceOfType(actual, typeof(LanguageStrings));
        }

        [TestMethod]
        public void TestGetMoveHandlerCorrectInstance()
        {
            var actual = this.testFactory.GetMoveHandlerInstance();

            Assert.IsInstanceOfType(actual, typeof(MoveHandler));
        }

        [TestMethod]
        public void TestGetRendererInstanceCorrectInstance()
        {
            var langStrings = new Mock<ILanguageStrings>();
            var actual = this.testFactory.GetRendererInstance(langStrings.Object);

            Assert.IsInstanceOfType(actual, typeof(ConsoleRenderer));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestGetRendererInstanceWithNull()
        {
            var actual = this.testFactory.GetRendererInstance(null);
        }

        [TestMethod]
        public void TestGetResultFormatterInstanceCorrectInstance()
        {
            var actual = this.testFactory.GetResultFormatterInstance();

            Assert.IsInstanceOfType(actual, typeof(SeparatorResultFormatter));
        }

        [TestMethod]
        public void TestGetResultInstanceCorrectInstance()
        {
            var actual = this.testFactory.GetResultInstance(1, "sa");

            Assert.IsInstanceOfType(actual, typeof(RatedResult));
        }

        [TestMethod]
        public void TestGetSerializationManagerInstanceCorrectInstance()
        {
            var actual = this.testFactory.GetSerializationManagerInstance();

            Assert.IsInstanceOfType(actual, typeof(FileSerializationManager));
        }

        [TestMethod]
        public void TestGetTopResultsTableInstanceCorrectInstance()
        {
            var actual = this.testFactory.GetTopResultsTableInstance();

            Assert.IsInstanceOfType(actual, typeof(ResultsTable));
        }
    }
}
