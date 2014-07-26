namespace Labyrinth
{
    using Commons;
    using Entities;
    using Entities.Contracts;
    using LabyrinthHandler.Contracts;
    using Loggers.Contracts;
    using Renderer.Contracts;
    using Results;
    using Results.Contracts;
    using UI.Contracts;

    /// <summary>
    /// IFactory interface provides methods for getting the correct instances of the classes in Labyrinth project.
    /// </summary>
    public interface IFactory : IResultFactory
    {
        /// <summary>
        /// Gets the correct instance of the class implementing <see cref="ICell"/> interface.
        /// </summary>
        /// <returns>The correct instance of the class implementing <see cref="ICell"/> interface</returns>
        ICell GetCellInstance(int row, int col, CellState value);

        /// <summary>
        /// Gets the correct instance of the class implementing <see cref="IRenderer"/> interface.
        /// </summary>
        /// <returns>The correct instance of the class implementing <see cref="IRenderer"/> interface</returns>
        IRenderer GetRendererInstance(ILanguageStrings dialogList);

        /// <summary>
        /// Gets the correct instance of the class implementing <see cref="IMoveHandler"/> interface.
        /// </summary>
        /// <returns>The correct instance of the class implementing <see cref="IRenderer"/> interface</returns>
        IMoveHandler GetMoveHandlerInstance();

        /// <summary>
        /// Gets the correct instance of the class implementing <see cref="IUserInput"/> interface.
        /// </summary>
        /// <returns>The correct instance of the class implementing <see cref="IUserInput"/> interface</returns>
        IUserInput GetUserInputInstance();

        /// <summary>
        /// Gets the correct instance of the class implementing <see cref="ILabyrinthPlayField"/> interface.
        /// </summary>
        /// <returns>The correct instance of the class implementing <see cref="ILabyrinthPlayField"/> interface</returns>
        ILabyrinthPlayField GetLabyrinthInstance(IFactory factory, IMoveHandler moveHandler);

        /// <summary>
        /// Gets the correct matrix instance of the class implementing <see cref="ICell"/> interface.
        /// </summary>
        /// <returns>The correct matrix instance of the class implementing <see cref="ICell"/> interface</returns>
        ICell[,] GetICellMatrixInstance(int size);

        /// <summary>
        /// Gets the correct instance of the class implementing <see cref="IResultFormatter"/> interface.
        /// </summary>
        /// <returns>The correct instance of the class implementing <see cref="IResultFormatter"/> interface</returns>
        IResultFormatter GetResultFormatterInstance();

        /// <summary>
        /// Gets the correct instance of the <see cref="ResultsTable"/> class.
        /// </summary>
        /// <returns><see cref="ResultsTable"/> class instance</returns>
        IResultsTable GetTopResultsTableInstance();

        /// <summary>
        /// Gets the correct instance of the <see cref="FileSerializationManager"/> class.
        /// </summary>
        /// <returns><see cref="FileSerializationManager"/> class instance</returns>
        FileSerializationManager GetSerializationManagerInstance();

        /// <summary>
        /// Gets the correct instance of the class implementing <see cref="ILanguageStrings"/> interface.
        /// </summary>
        /// <returns>The correct instance of the class implementing <see cref="ILanguageStrings"/> interface</returns>
        ILanguageStrings GetLanguageStringsInstance();

        /// <summary>
        /// Gets the correct instance of the file class implementing <see cref="IAppender"/> interface.
        /// </summary>
        /// <returns>The correct instance of the file class implementing <see cref="IAppender"/> interface</returns>
        IAppender GetFileAppender(string fileName);

        /// <summary>
        /// Gets the correct instance of the memory class implementing <see cref="IAppender"/> interface.
        /// </summary>
        /// <returns>The correct instance of the memory class implementing <see cref="IAppender"/> interface</returns>
        IAppender GetMemoryAppender();

        /// <summary>
        /// Gets the correct instance of the class implementing <see cref="ILogger"/> interface.
        /// </summary>
        /// <returns>The correct instance of the class implementing <see cref="ILogger"/> interface</returns>
        ILogger GetSimpleLogger(IAppender appender);

        /// <summary>
        /// Gets the correct instance of the class implementing <see cref="IScene"/> interface.
        /// </summary>
        /// <returns>The correct instance of the class implementing <see cref="IScene"/> interface</returns>
        IScene GetConsoleScene(IConsoleRenderer renderer);

        /// <summary>
        /// Gets the correct instance of the class implementing <see cref="IConsoleGraphicFactory"/> interface.
        /// </summary>
        /// <returns>The correct instance of the class implementing ConsoleGraphicFactory</returns>
        IConsoleGraphicFactory GetConsoleGraphicFactory();

        /// <summary>
        /// Gets the correct instance of the class implementing <see cref="IGameLogic"/> interface.
        /// </summary>
        /// <returns>The correct instance of the class implementing <see cref="IGameLogic"/> interface</returns>
        IGameLogic GetGameLogic(ILabyrinthPlayField labyrinth, IGameConsole gameConsole, IResultsTable resultsTable, IUserInput input, IResultFactory factory);
    }
}