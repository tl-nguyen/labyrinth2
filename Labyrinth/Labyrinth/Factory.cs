namespace Labyrinth
{
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
    using System.Runtime.Serialization.Formatters.Binary;
    using UI;
    using UI.Contracts;

    /// <summary>
    /// Returns instances of all classes for the project
    /// </summary>
    public class Factory : IFactory
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

        public IRenderer GetRendererInstance(ILanguageStrings dialogList)
        {
            return new ConsoleRenderer();
        }

        public IUserInput GetUserInputInstance()
        {
            return new UserInput();
        }

        public ILabyrinth GetLabyrinthInstance(IFactory factory, IMoveHandler moveHandler)
        {
            return new Entities.Labyrinth(factory, moveHandler); //compiler recognizes just Labyrinth as the namespace and not type, no clue if this is th
        }

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

        /// <summary>
        /// Gets the correct instance of the <see cref="FileSerializationManager"/> class.
        /// </summary>
        /// <returns><see cref="FileSerializationManager"/> class instance</returns>
        public FileSerializationManager GetSerializationManagerInstance()
        {
            return new FileSerializationManager(new BinaryFormatter(), TableFileName);
        }

        public ILanguageStrings GetLanguageStringsInstance()
        {
            return new LanguageStrings();
        }

        public IAppender GetFileAppender(string fileName)
        {
            return new FileAppender(fileName);
        }

        public IAppender GetMemoryAppender()
        {
            return MemoryAppender.GetInstance();
        }

        public ILogger GetSimpleLogger(IAppender appender)
        {
            return new SimpleLogger(appender);
        }

        public IScene GetConsoleScene(IConsoleRenderer renderer)
        {
            return new ConsoleScene(renderer);
        }

        public IConsoleGraphicFactory GetConsoleGraphicFactory()
        {
            return new ConsoleGraphicFactory();
        }

        public IGameLogic GetGameLogic(ILabyrinth labyrinth, IGameConsole gameConsole,
            IResultsTable resultsTable, IUserInput input, IFactory factory)
        {
            return new GameLogic(labyrinth, gameConsole, resultsTable, input, factory);
        }

        public IMoveHandler GetMoveHandlerInstance()
        {
            return new MoveHandler();
        }
    }
}