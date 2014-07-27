namespace Labyrinth.UI
{
    using Commons;
    using Contracts;
    using Entities.Contracts;
    using Renderer;
    using Renderer.Contracts;

    /// <summary>
    /// Class for generating instances of the console graphic classes.
    /// </summary>
    public class ConsoleGraphicFactory : IConsoleGraphicFactory
    {
        /// <summary>
        /// Gets the correct instance of the <see cref="IntPoint"/> class.
        /// </summary>
        /// <param name="x">X coordinate.</param>
        /// <param name="y">Y coordinate.</param>
        /// <returns>Instance of the <see cref="IntPoint"/> class.</returns>
        public IntPoint GetCoordinates(int x, int y)
        {
            return new IntPoint(x, y);
        }

        /// <summary>
        /// Gets the correct instance of the <see cref="ConsoleRenderer"/> class.
        /// </summary>
        /// <returns>Instance of the <see cref="ConsoleRenderer"/> class.</returns>
        public IConsoleRenderer GetConsoleRenderer()
        {
            return new ConsoleRenderer();
        }

        /// <summary>
        /// Gets the correct instance of the <see cref="GetConsoleScene"/> class.
        /// </summary>
        /// <param name="consoleRenderer">Console renderer for the scene.</param>
        /// <returns>Instance of the <see cref="GetConsoleScene"/> class.</returns>
        public IScene GetConsoleScene(Renderer.Contracts.IConsoleRenderer consoleRenderer)
        {
            return new ConsoleScene(consoleRenderer);
        }

        /// <summary>
        /// Gets the correct instance of the <see cref="GetLabyrinthConsoleGraphic"/> class.
        /// </summary>
        /// <param name="labyrinth">Labyrinth for render.</param>
        /// <param name="coords">Coordinates of the labyrinth.</param>
        /// <param name="renderer">Renderer of the labyrinth.</param>
        /// <returns>Instance of the <see cref="GetLabyrinthConsoleGraphic"/> class.</returns>
        public IRenderable GetLabyrinthConsoleGraphic(ILabyrinthPlayField labyrinth, IntPoint coords, IRenderer renderer)
        {
            return new LabyrinthConsoleGraphic(labyrinth, coords, renderer);
        }

        /// <summary>
        /// Gets the correct instance of the <see cref="GetTableConsoleGraphic"/> class.
        /// </summary>
        /// <param name="table">Table for render.</param>
        /// <param name="coords">Coordinates of the table.</param>
        /// <param name="renderer">Renderer of the table.</param>
        /// <returns>Instance of the <see cref="GetTableConsoleGraphic"/> class.</returns>
        public IRenderable GetResultsTableConsoleGraphic(IResultsTable table, IntPoint coords, IRenderer renderer)
        {
            return new ResultsTableConsoleGraphic(table, coords, renderer);
        }

        /// <summary>
        /// Gets the correct instance of the <see cref="GetGameConsoleGraphic"/> class.
        /// </summary>
        /// <param name="gameConsole">Game for render.</param>
        /// <param name="coords">Coordinates of the game.</param>
        /// <param name="renderer">Renderer for the game.</param>
        /// <returns>Instance of the <see cref="GetGameConsoleGraphic"/> class.</returns>
        public IRenderable GetGameConsoleGraphic(IGameConsole gameConsole, IntPoint coords, IRenderer renderer)
        {
            return new GameConsoleConsoleGraphic(gameConsole, coords, renderer);
        }
    }
}
