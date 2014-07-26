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
    using Labyrinth.Loggers.Contracts;
    using Labyrinth.Loggers;

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
            var factCell = this.testFactory.GetICellInstance(row, col, Commons.CellState.Empty);

            Assert.AreEqual(testCell.CellValue, factCell.CellValue);
            Assert.AreEqual(testCell.Row, factCell.Row);
            Assert.AreEqual(testCell.Col, factCell.Col);
        }

        [TestMethod]
        public void TestGetUserInputInstanceCorrectInstance()
        {
            var actual = this.testFactory.GetIUserInputInstance();

            Assert.IsInstanceOfType(actual, typeof(UserInputConsole));
        }

        [TestMethod]
        public void TestLabyrinthInstanceGetsCorrectInstance()
        {
            var actual = this.testFactory.GetILabyrinthPlayFieldInstance(this.testFactory, this.testFactory.GetIMoveHandlerInstance());

            Assert.IsInstanceOfType(actual, typeof(LabyrinthPlayField));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestLabyrinthInstanceNullFactory()
        {
            var testHandler = new Mock<IMoveHandler>();
            var actual = this.testFactory.GetILabyrinthPlayFieldInstance(null, testHandler.Object);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestLabyrinthInstanceNullMoveHandler()
        {
            var testHandler = new Mock<IMoveHandler>();
            var actual = this.testFactory.GetILabyrinthPlayFieldInstance(this.testFactory, null);
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
            var actual = this.testFactory.GetIConsoleGraphicFactoryInstance();

            Assert.IsInstanceOfType(actual, typeof(ConsoleGraphicFactory));
        }

        [TestMethod]
        public void TestGetConsoleSceneGetsCorrectInstance()
        {
            var renderer = new Mock<IConsoleRenderer>();
            var actual = this.testFactory.GetISceneInstance(renderer.Object);

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
            var actual = this.testFactory.GetIGameLogicInstance(playField.Object, gameConsole.Object, resultTable.Object, userInput.Object, factory.Object);

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
            var actual = this.testFactory.GetIGameLogicInstance(null, gameConsole.Object, resultTable.Object, userInput.Object, factory.Object);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestGetGameLogicWithNullIGameConsole()
        {
            var playField = new Mock<ILabyrinthPlayField>();
            var resultTable = new Mock<IResultsTable>();
            var userInput = new Mock<IUserInput>();
            var factory = new Mock<IResultFactory>();
            var actual = this.testFactory.GetIGameLogicInstance(playField.Object, null, resultTable.Object, userInput.Object, factory.Object);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestGetGameLogicWithNullIResultsTable()
        {
            var playField = new Mock<ILabyrinthPlayField>();
            var gameConsole = new Mock<IGameConsole>();
            var userInput = new Mock<IUserInput>();
            var factory = new Mock<IResultFactory>();
            var actual = this.testFactory.GetIGameLogicInstance(playField.Object, gameConsole.Object, null, userInput.Object, factory.Object);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestGetGameLogicWithNullIUserInput()
        {
            var playField = new Mock<ILabyrinthPlayField>();
            var gameConsole = new Mock<IGameConsole>();
            var resultTable = new Mock<IResultsTable>();
            var factory = new Mock<IResultFactory>();
            var actual = this.testFactory.GetIGameLogicInstance(playField.Object, gameConsole.Object, resultTable.Object, null, factory.Object);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestGetGameLogicWithNullIResultFactory()
        {
            var playField = new Mock<ILabyrinthPlayField>();
            var gameConsole = new Mock<IGameConsole>();
            var resultTable = new Mock<IResultsTable>();
            var userInput = new Mock<IUserInput>();
            var actual = this.testFactory.GetIGameLogicInstance(playField.Object, gameConsole.Object, resultTable.Object, userInput.Object, null);
        }

        [TestMethod]
        public void TestGetILanguageStringsCorrectInstance()
        {
            var actual = this.testFactory.GetILanguageStringsInstance();

            Assert.IsInstanceOfType(actual, typeof(LanguageStrings));
        }

        [TestMethod]
        public void TestGetMoveHandlerCorrectInstance()
        {
            var actual = this.testFactory.GetIMoveHandlerInstance();

            Assert.IsInstanceOfType(actual, typeof(MoveHandler));
        }

        [TestMethod]
        public void TestGetRendererInstanceCorrectInstance()
        {
            var langStrings = new Mock<ILanguageStrings>();
            var actual = this.testFactory.GetIRendererInstance(langStrings.Object);

            Assert.IsInstanceOfType(actual, typeof(ConsoleRenderer));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestGetRendererInstanceWithNull()
        {
            var actual = this.testFactory.GetIRendererInstance(null);
        }

        [TestMethod]
        public void TestGetResultFormatterInstanceCorrectInstance()
        {
            var actual = this.testFactory.GetIResultFormatterInstance();

            Assert.IsInstanceOfType(actual, typeof(SeparatorResultFormatter));
        }

        [TestMethod]
        public void TestGetResultInstanceCorrectInstance()
        {
            var actual = this.testFactory.GetIResultInstance(1, "sa");

            Assert.IsInstanceOfType(actual, typeof(RatedResult));
        }

        [TestMethod]
        public void TestGetSerializationManagerInstanceCorrectInstance()
        {
            var actual = this.testFactory.GetFileSerializationManagerInstance();

            Assert.IsInstanceOfType(actual, typeof(FileSerializationManager));
        }

        [TestMethod]
        public void TestGetTopResultsTableInstanceCorrectInstance()
        {
            var actual = this.testFactory.GetIResultsTableInstance();

            Assert.IsInstanceOfType(actual, typeof(ResultsTable));
        }

        [TestMethod]
        public void TestGetSimpleLoggerCorrectInstance()
        {
            var appender = new Mock<IAppender>();
            var actual = this.testFactory.GetSimpleILoggerInstance(appender.Object);

            Assert.IsInstanceOfType(actual, typeof(SimpleLogger));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestGetSimpleLoggerWithNull()
        {
            var actual = this.testFactory.GetSimpleILoggerInstance(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestGetIGameConsoleWithNull()
        {
            var actual = this.testFactory.GetIGameConsoleInstance(null);
        }

        [TestMethod]
        public void TestGetIGameConsoleCorrectInstance()
        {
            var languageStrings = new Mock<ILanguageStrings>();
            var actual = this.testFactory.GetIGameConsoleInstance(languageStrings.Object);

            Assert.IsInstanceOfType(actual, typeof(GameConsole));
        }
    }
}
