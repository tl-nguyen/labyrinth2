namespace Labyrinth
{
    using Loggers;
    using System.Runtime.Serialization.Formatters.Binary;

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
            return new Labyrinth();
        }

        public static IPlayer GetPlayerInstance(ILabyrinthMoveHandler labyrinth)
        {
            return new Player(labyrinth);
        }

        public static ICell[,] GetICellMatrixInstance(int size)
        {
            return new Cell[size, size];
        }

        public static IResult GetResultInstance(int movesCount, string playerName)
        {
            return new Result(movesCount, playerName);
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
