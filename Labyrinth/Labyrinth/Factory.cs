namespace Labyrinth
{
    using System;
    using System.Runtime.Serialization.Formatters.Binary;
    using Commons;
    using Entities;
    using Entities.Contracts;
    using LabyrinthHandler;
    using LabyrinthHandler.Contracts;
    using Loggers;
    using Loggers.Contracts;
    using Renderer;
    using Renderer.Contracts;
    using Results;
    using Results.Contracts;
    using UI;
    using UI.Contracts;

    /// <summary>
    /// Returns instances of all classes for the project
    /// </summary>
    public class Factory : IFactory, IResultFactory
    {
        /// <summary>
        /// Name of the file for serialization of the top results table.
        /// </summary>
        private const string TableFileName = "table.bin";

        // TODO: Refactor other classes, and make instances be returned only here.

        /// <summary>
        /// Gets the correct instance of the ICell interface
        /// </summary>
        /// <returns>ICell instance</returns>
        public ICell GetCellInstance(int row, int col, CellState value)
        {
            return new Cell(row, col, value);
        }

        /// <summary>
        /// Gets the correct instance of the class implementing <see cref="IRenderer"/> interface.
        /// </summary>
        /// <returns>The correct instance of the class implementing <see cref="IRenderer"/> interface</returns>
        public IRenderer GetRendererInstance(ILanguageStrings dialogList)
        {
            if (dialogList == null)
            {
                throw new ArgumentNullException("GetRendererInstance has a null argument");
            }

            return new ConsoleRenderer();
        }

        /// <summary>
        /// Gets the correct instance of the class implementing <see cref="IUserInput"/> interface.
        /// </summary>
        /// <returns>The correct instance of the class implementing <see cref="IUserInput"/> interface</returns>
        public IUserInput GetUserInputInstance()
        {
            return new UserInputConsole();
        }

        /// <summary>
        /// Gets the correct instance of the class implementing <see cref="ILabyrinthPlayField"/> interface.
        /// </summary>
        /// <returns>The correct instance of the class implementing <see cref="ILabyrinthPlayField"/> interface</returns>
        public ILabyrinthPlayField GetLabyrinthInstance(IFactory factory, IMoveHandler moveHandler)
        {
            if (factory == null || moveHandler == null)
            {
                throw new ArgumentNullException("GetLabyrinthInstance has a null argument");
            }

            return new LabyrinthPlayField(factory, moveHandler);
        }

        /// <summary>
        /// Gets the correct matrix instance of the class implementing <see cref="ICell"/> interface.
        /// </summary>
        /// <returns>The correct matrix instance of the class implementing <see cref="ICell"/> interface</returns>
        public ICell[,] GetICellMatrixInstance(int size)
        {
            return new Cell[size, size];
        }

        /// <summary>
        /// Gets the correct instance of the class implementing <see cref="IResult"/> interface.
        /// </summary>
        /// <returns>The correct instance of the class implementing <see cref="IResult"/> interface</returns>
        public IResult GetResultInstance(int movesCount, string playerName)
        {
            // return new SimpleResult(
            //    movesCount,
            //    playerName,
            //    LabyrinthFactory.GetResultFormatterInstance());
            return new RatedResult(
                movesCount,
                playerName,
                this.GetResultFormatterInstance());
        }

        /// <summary>
        /// Gets the correct instance of the class implementing <see cref="IResultFormatter"/> interface.
        /// </summary>
        /// <returns>The correct instance of the class implementing <see cref="IResultFormatter"/> interface</returns>
        public IResultFormatter GetResultFormatterInstance()
        {
            // return new PlainResultFormatter();
            return new SeparatorResultFormatter("|");
        }

        /// <summary>
        /// Gets the correct instance of the <see cref="ResultsTable"/> class.
        /// </summary>
        /// <returns><see cref="ResultsTable"/> class instance</returns>
        public IResultsTable GetTopResultsTableInstance()
        {
            ITable table = this.GetTopResultsInstance();
            return new ResultsTable(table);
        }

        /// <summary>
        /// Gets the correct instance of the <see cref="FileSerializationManager"/> class.
        /// </summary>
        /// <returns><see cref="FileSerializationManager"/> class instance</returns>
        public FileSerializationManager GetSerializationManagerInstance()
        {
            return new FileSerializationManager(new BinaryFormatter(), TableFileName);
        }

        /// <summary>
        /// Gets the correct instance of the class implementing <see cref="ILanguageStrings"/> interface.
        /// </summary>
        /// <returns>The correct instance of the class implementing <see cref="ILanguageStrings"/> interface</returns>
        public ILanguageStrings GetLanguageStringsInstance()
        {
            return new LanguageStrings();
        }

        /// <summary>
        /// Gets the correct instance of the file class implementing <see cref="IAppender"/> interface.
        /// </summary>
        /// <returns>The correct instance of the file class implementing <see cref="IAppender"/> interface</returns>
        public IAppender GetFileAppender(string fileName)
        {
            return new FileAppender(fileName);
        }

        /// <summary>
        /// Gets the correct instance of the memory class implementing <see cref="IAppender"/> interface.
        /// </summary>
        /// <returns>The correct instance of the memory class implementing <see cref="IAppender"/> interface</returns>
        public IAppender GetMemoryAppender()
        {
            return MemoryAppender.GetInstance();
        }

        /// <summary>
        /// Gets the correct instance of the class implementing <see cref="ILogger"/> interface.
        /// </summary>
        /// <returns>The correct instance of the class implementing <see cref="ILogger"/> interface</returns>
        public ILogger GetSimpleLogger(IAppender appender)
        {
            return new SimpleLogger(appender);
        }

        /// <summary>
        /// Gets the correct instance of the class implementing <see cref="IScene"/> interface.
        /// </summary>
        /// <returns>The correct instance of the class implementing <see cref="IScene"/> interface</returns>
        public IScene GetConsoleScene(IConsoleRenderer renderer)
        {
            return new ConsoleScene(renderer);
        }

        /// <summary>
        /// Gets the correct instance of the class implementing <see cref="IConsoleGraphicFactory"/> interface.
        /// </summary>
        /// <returns>The correct instance of the class implementing ConsoleGraphicFactory</returns>
        public IConsoleGraphicFactory GetConsoleGraphicFactory()
        {
            return new ConsoleGraphicFactory();
        }

        /// <summary>
        /// Gets the correct instance of the class implementing <see cref="IGameLogic"/> interface.
        /// </summary>
        /// <returns>The correct instance of the class implementing <see cref="IGameLogic"/> interface</returns>
        public IGameLogic GetGameLogic(ILabyrinthPlayField labyrinth, IGameConsole gameConsole, IResultsTable resultsTable, IUserInput input, IResultFactory factory)
        {
            if (labyrinth == null || gameConsole == null || resultsTable == null || input == null || factory == null)
            {
                throw new ArgumentNullException("GetGameLogic class in IFactory has some null arguments");
            }

            return new GameLogic(labyrinth, gameConsole, resultsTable, input, factory);
        }

        /// <summary>
        /// Gets the correct instance of the class implementing <see cref="IMoveHandler"/> interface.
        /// </summary>
        /// <returns>The correct instance of the class implementing <see cref="IRenderer"/> interface</returns>
        public IMoveHandler GetMoveHandlerInstance()
        {
            return new MoveHandler();
        }
        /// <summary>
        /// Private method
        /// </summary>
        private ITable GetTopResultsInstance()
        {
            try
            {
                return (TopResults)this.GetSerializationManagerInstance().Deserialize();
            }
            catch (System.IO.FileNotFoundException)
            {
                return new TopResults();
            }
        }
    }
}