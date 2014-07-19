namespace Labyrinth
{
    using System.Runtime.Serialization.Formatters.Binary;
    using Commons;
    using Entities;
    using Entities.Contracts;
    using LabyrinthHandler.Contracts;
    using Loggers;
    using Loggers.Contracts;
    using Renderer;
    using Renderer.Contracts;
    using Results;
    using Results.Contracts;

    public interface IFactory
    {
        /// <summary>
        /// Gets the correct instance of the ICell interface
        /// </summary>
        /// <returns>ICell instance</returns>
        ICell GetCellInstance(int row, int col, CellState value);

        IRenderer GetRendererInstance(ILanguageStrings dialogList);

        IUserInput GetUserInputInstance();

        ILabyrinthMoveHandler GetLabyrinthInstance(IFactory factory);

        IPlayer GetPlayerInstance(ILabyrinthMoveHandler labyrinth);

        ICell[,] GetICellMatrixInstance(int size);

        /// <summary>
        /// Gets the correct instance of the class implementing <see cref="IResult"/> interface.
        /// </summary>
        /// <returns>The correct instance of the class implementing <see cref="IResult"/> interface</returns>
        IResult GetResultInstance(int movesCount, string playerName);

        /// <summary>
        /// Gets the correct instance of the class implementing <see cref="IResultFormatter"/> interface.
        /// </summary>
        /// <returns>The correct instance of the class implementing <see cref="IResultFormatter"/> interface</returns>
        IResultFormatter GetResultFormatterInstance();

        /// <summary>
        /// Gets the correct instance of the <see cref="TopResults"/> class.
        /// </summary>
        /// <returns><see cref="TopResults"/> class instance</returns>
        ITable GetTopResultsInstance();

        /// <summary>
        /// Gets the correct instance of the <see cref="FileSerializationManager"/> class.
        /// </summary>
        /// <returns><see cref="FileSerializationManager"/> class instance</returns>
        FileSerializationManager GetSerializationManagerInstance();

        ILanguageStrings GetLanguageStringsInstance();

        IAppender GetFileAppender(string fileName);

        IAppender GetMemoryAppender();

        ILogger GetSimpleLogger(IAppender appender);

        IScene GetConsoleScene(IConsoleRenderer renderer);

        IUiText GetUiText(IntPoint coords, IConsoleRenderer renderer);

        LabyrinthGraphic GetLabyrinthGraphic(IntPoint coords, IConsoleRenderer renderer, ICell[,] matrix);

        IGameLogic GetGameLogic(IPlayer player, IUiText topMessageBox, IUiText bottomMessageBox, 
            LabyrinthGraphic labyrinthGfk, IScene scene, ITable table, IUserInput input, IFactory factory);
    }
}