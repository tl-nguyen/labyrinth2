namespace Labyrinth
{
    using Loggers;
    using System.Runtime.Serialization.Formatters.Binary;
    using LabyrinthHandler;
    using LabyrinthHandler.Contracts;
    using Results;
    using Results.Contracts;
    using Loggers.Contracts;
    using Renderer;
    using Renderer.Contracts;
    using Commons;


    /// <summary>
    /// Returns instances of all classes for the project
    /// </summary>
    public class LabyrinthFactory
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
        public static ICell GetCellInstance(int row, int col, CellState value)
        {
            return new Cell(row, col, value);
        }

        public static IRenderer GetRendererInstance(ILanguageStrings dialogList)
        {
            return new ConsoleRenderer(dialogList);
        }

        public static IUserInput GetUserInputInstance()
        {
            return new UserInputAndOutput();
        }

        public static ILabyrinthMoveHandler GetLabyrinthInstance()
        {
            return new LabyrinthHandler.Labyrinth();
        }

        public static IPlayer GetPlayerInstance(ILabyrinthMoveHandler labyrinth)
        {
            return new Player(labyrinth);
        }

        public static ICell[,] GetICellMatrixInstance(int size)
        {
            return new Cell[size, size];
        }

        /// <summary>
        /// Gets the correct instance of the class implementing <see cref="IResult"/> interface.
        /// </summary>
        /// <returns>The correct instance of the class implementing <see cref="IResult"/> interface</returns>
        public static IResult GetResultInstance(int movesCount, string playerName)
        {
            // return new SimpleResult(
            //    movesCount, 
            //    playerName, 
            //    LabyrinthFactory.GetResultFormatterInstance());
            return new RatedResult(
                movesCount,
                playerName,
                LabyrinthFactory.GetResultFormatterInstance());
        }

        /// <summary>
        /// Gets the correct instance of the class implementing <see cref="IResultFormatter"/> interface.
        /// </summary>
        /// <returns>The correct instance of the class implementing <see cref="IResultFormatter"/> interface</returns>
        public static IResultFormatter GetResultFormatterInstance()
        {
            // return new PlainResultFormatter();
             return new SeparatorResultFormatter("|");
        }

        /// <summary>
        /// Gets the correct instance of the <see cref="TopResults"/> class.
        /// </summary>
        /// <returns><see cref="TopResults"/> class instance</returns>
        public static ITable GetTopResultsInstance()
        {
            try
            {
                return (TopResults)LabyrinthFactory.GetSerializationManagerInstance().Deserialize();
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
        public static FileSerializationManager GetSerializationManagerInstance()
        {
            return new FileSerializationManager(new BinaryFormatter(), LabyrinthFactory.TableFileName);
        }

        public static ILanguageStrings GetLanguageStringsInstance()
        {
            return new LanguageStrings();
        }

        public static IAppender GetFileAppender(string fileName)
        {
            return new FileAppender(fileName);
        }

        public static IAppender GetMemoryAppender()
        {
            return MemoryAppender.GetInstance();
        }

        public static ILogger GetSimpleLogger(IAppender appender)
        {
            return new SimpleLogger(appender);
        }
    }
}
