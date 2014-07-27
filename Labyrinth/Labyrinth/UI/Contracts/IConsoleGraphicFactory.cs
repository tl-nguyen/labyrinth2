namespace Labyrinth.UI.Contracts
{  
    using Commons;
    using Entities.Contracts;
    using Renderer.Contracts;
    using UI;

    /// <summary>
    /// Interface for the console graphic factory.
    /// </summary>
    public interface IConsoleGraphicFactory
    {
        /// <summary>
        /// Gets the correct instance of the <see cref="IntPoint"/> class.
        /// </summary>
        /// <param name="x">X coordinate.</param>
        /// <param name="y">Y coordinate.</param>
        /// <returns>Instance of the <see cref="IntPoint"/> class.</returns>
        IntPoint GetCoordinates(int x, int y);

        /// <summary>
        /// Gets the correct instance of the <see cref="ConsoleRenderer"/> class.
        /// </summary>
        /// <returns>Instance of the <see cref="ConsoleRenderer"/> class.</returns>
        IConsoleRenderer GetConsoleRenderer();
        
        /// <summary>
        /// Gets the correct instance of the <see cref="GetConsoleScene"/> class.
        /// </summary>
        /// <param name="consoleRenderer">Console renderer for the scene.</param>
        /// <returns>Instance of the <see cref="GetConsoleScene"/> class.</returns>
        IScene GetConsoleScene(IConsoleRenderer consoleRenderer);

        /// <summary>
        /// Gets the correct instance of the <see cref="GetLabyrinthConsoleGraphic"/> class.
        /// </summary>
        /// <param name="labyrinth">Labyrinth for render.</param>
        /// <param name="coords">Coordinates of the labyrinth.</param>
        /// <param name="renderer">Renderer of the labyrinth.</param>
        /// <returns>Instance of the <see cref="GetLabyrinthConsoleGraphic"/> class.</returns>
        IRenderable GetLabyrinthConsoleGraphic(ILabyrinthPlayField labyrinth, IntPoint coords, IRenderer renderer);

        /// <summary>
        /// Gets the correct instance of the <see cref="GetTableConsoleGraphic"/> class.
        /// </summary>
        /// <param name="table">Table for render.</param>
        /// <param name="coords">Coordinates of the table.</param>
        /// <param name="renderer">Renderer of the table.</param>
        /// <returns>Instance of the <see cref="GetTableConsoleGraphic"/> class.</returns>
        IRenderable GetResultsTableConsoleGraphic(IResultsTable table, IntPoint coords, IRenderer renderer);

        /// <summary>
        /// Gets the correct instance of the <see cref="GetGameConsoleGraphic"/> class.
        /// </summary>
        /// <param name="gameConsole">Game for render.</param>
        /// <param name="coords">Coordinates of the game.</param>
        /// <param name="renderer">Renderer for the game.</param>
        /// <returns>Instance of the <see cref="GetGameConsoleGraphic"/> class.</returns>
        IRenderable GetGameConsoleGraphic(IGameConsole gameConsole, IntPoint coords, IRenderer renderer);
    }
}
