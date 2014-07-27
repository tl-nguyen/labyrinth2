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
        /// Gets the correct instance of <see cref="ICell"/> interface
        /// </summary>
        /// <param name="row">Sets the Row of the <see cref="ICell"/> that will be returned</param>
        /// <param name="col">Sets the Col of the <see cref="ICell"/> that will be returned</param>
        /// <param name="value">Sets the <see cref="CellState"/> of the <see cref="ICell"/> that will be returned</param>
        /// <returns>The correct instance of the class implementing <see cref="ICell"/> interface</returns>
        public ICell GetICellInstance(int row, int col, CellState value)
        {
            return new Cell(row, col, value);
        }

        /// <summary>
        /// Gets the correct instance of the class implementing <see cref="IRenderer"/> interface.
        /// </summary>
        /// <returns>The correct instance of the class implementing <see cref="IRenderer"/> interface</returns>
        /// <param name="dialogList">Non null value of <see cref="ILanguageStrings"/></param>
        public IRenderer GetIRendererInstance(ILanguageStrings dialogList)
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
        public IUserInput GetIUserInputInstance()
        {
            return new UserInputConsole();
        }

        /// <summary>
        /// Gets the correct instance of the class implementing <see cref="ILabyrinthPlayField"/> interface.
        /// </summary>
        /// <returns>The correct instance of the class implementing <see cref="ILabyrinthPlayField"/> interface</returns>
        /// <param name="factory">A non null value of <see cref="IFactory"/></param>
        /// <param name="moveHandler">A non null value of <see cref="IMoveHandler"/></param>
        public ILabyrinthPlayField GetILabyrinthPlayFieldInstance(IFactory factory, IMoveHandler moveHandler)
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
        /// <param name="size">Sets the size of the matrix</param>
        public ICell[,] GetICellMatrixInstance(int size)
        {
            return new Cell[size, size];
        }

        /// <summary>
        /// Gets the correct instance of the class implementing <see cref="IResult"/> interface.
        /// </summary>
        /// <returns>The correct instance of the class implementing <see cref="IResult"/> interface</returns>
        /// <param name="movesCount">Integer with the moves made</param>
        /// <param name="playerName">String with the player name</param>
        public IResult GetIResultInstance(int movesCount, string playerName)
        {
            // return new SimpleResult(
            //    movesCount,
            //    playerName,
            //    LabyrinthFactory.GetResultFormatterInstance());
            return new RatedResult(
                movesCount,
                playerName,
                this.GetIResultFormatterInstance());
        }

        /// <summary>
        /// Gets the correct instance of the class implementing <see cref="IResultFormatter"/> interface.
        /// </summary>
        /// <returns>The correct instance of the class implementing <see cref="IResultFormatter"/> interface</returns>
        public IResultFormatter GetIResultFormatterInstance()
        {
            // return new PlainResultFormatter();
            return new SeparatorResultFormatter("|");
        }

        /// <summary>
        /// Gets the correct instance of the <see cref="ResultsTable"/> class.
        /// </summary>
        /// <returns><see cref="ResultsTable"/> class instance</returns>
        public IResultsTable GetIResultsTableInstance()
        {
            ITable table = this.GetTopResultsInstance();
            return new ResultsTable(table);
        }

        /// <summary>
        /// Gets the correct instance of the <see cref="FileSerializationManager"/> class.
        /// </summary>
        /// <returns><see cref="FileSerializationManager"/> class instance</returns>
        public FileSerializationManager GetFileSerializationManagerInstance()
        {
            return new FileSerializationManager(new BinaryFormatter(), TableFileName);
        }

        /// <summary>
        /// Gets the correct instance of the class implementing <see cref="ILanguageStrings"/> interface.
        /// </summary>
        /// <returns>The correct instance of the class implementing <see cref="ILanguageStrings"/> interface</returns>
        public ILanguageStrings GetILanguageStringsInstance()
        {
            return new LanguageStrings();
        }

        /// <summary>
        /// Gets the correct instance of the file class implementing <see cref="IAppender"/> interface.
        /// </summary>
        /// <returns>The correct instance of the file class implementing <see cref="IAppender"/> interface</returns>
        /// <param name="fileName">The file name as string</param>
        public IAppender GetFileIAppenderInstance(string fileName)
        {
            return new FileAppender(fileName);
        }

        /// <summary>
        /// Gets the correct instance of the memory class implementing <see cref="IAppender"/> interface.
        /// </summary>
        /// <returns>The correct instance of the memory class implementing <see cref="IAppender"/> interface</returns>
        public IAppender GetMemoryIAppenderInstance()
        {
            return MemoryAppender.GetInstance();
        }

        /// <summary>
        /// Gets the correct instance of the class implementing <see cref="ILogger"/> interface.
        /// </summary>
        /// <returns>The correct instance of the class implementing <see cref="ILogger"/> interface</returns>
        /// <param name="appender">A non null <see cref="IAppender"/></param>
        public ILogger GetSimpleILoggerInstance(IAppender appender)
        {
            if (appender == null)
            {
                throw new ArgumentNullException();
            }

            return new SimpleLogger(appender);
        }

        /// <summary>
        /// Gets the correct instance of the class implementing <see cref="IScene"/> interface.
        /// </summary>
        /// <returns>The correct instance of the class implementing <see cref="IScene"/> interface</returns>
        /// <param name="renderer">A non null value of <see cref="IConsoleRenderer"/></param>
        public IScene GetISceneInstance(IConsoleRenderer renderer)
        {
            if (renderer == null)
            {
                throw new ArgumentNullException(); 
            }

            return new ConsoleScene(renderer);
        }

        /// <summary>
        /// Gets the correct instance of the class implementing <see cref="IConsoleGraphicFactory"/> interface.
        /// </summary>
        /// <returns>The correct instance of the class implementing ConsoleGraphicFactory</returns>
        public IConsoleGraphicFactory GetIConsoleGraphicFactoryInstance()
        {
            return new ConsoleGraphicFactory();
        }

        /// <summary>
        /// Gets the correct instance of the class implementing <see cref="IGameLogic"/> interface.
        /// </summary>
        /// <returns>The correct instance of the class implementing <see cref="IGameLogic"/> interface</returns>
        /// <param name="labyrinth">A non null value of <see cref="ILabyrinthPlayField"/></param>
        /// <param name="gameConsole">A non null value of <see cref="IGameConsole"/></param>
        /// <param name="resultsTable">A non null value of <see cref="IResultsTable"/></param>
        /// <param name="input">A non null value of <see cref="IUserInput"/></param>
        /// <param name="factory">A non null value of <see cref="IResultFactory"/></param>
        public IGameLogic GetIGameLogicInstance(ILabyrinthPlayField labyrinth, IGameConsole gameConsole, IResultsTable resultsTable, IUserInput input, IResultFactory factory)
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
        public IMoveHandler GetIMoveHandlerInstance()
        {
            return new MoveHandler();
        }

        /// <summary>
        /// Gets the correct instance of the class implementing <see cref="IGameConsole"/> interface.
        /// </summary>
        /// <param name="languageStrings">A non null value of <see cref="ILanguageStrings"/></param>
        /// <returns>The correct instance of the class implementing <see cref="IGameConsole"/> interface</returns>
        public IGameConsole GetIGameConsoleInstance(ILanguageStrings languageStrings)
        {
            if (languageStrings == null)
            {
                throw new ArgumentNullException();
            }

            return new GameConsole(languageStrings);
        }

        /// <summary>
        /// Private method
        /// </summary>
        /// <returns>Returns the correct <see cref="ITable"/> instance</returns>
        private ITable GetTopResultsInstance()
        {
            try
            {
                return (TopResults)this.GetFileSerializationManagerInstance().Deserialize();
            }
            catch (System.IO.FileNotFoundException)
            {
                return new TopResults();
            }
        }
    }
}