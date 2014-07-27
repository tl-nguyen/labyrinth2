namespace Labyrinth.UI
{
    using System.Text;
    using Commons;
    using Entities.Contracts;
    using Renderer.Contracts;

    /// <summary>
    /// Class for console graphic of the scene.
    /// </summary>
    public class GameConsoleConsoleGraphic : EntityConsoleGraphic
    {
        /// <summary>
        /// Default visible lines of the game.
        /// </summary>
        private const int DefaultVisibleLinesCount = 10;

        /// <summary>
        /// Game console for the graphic.
        /// </summary>
        private IGameConsole gameConsole;

        /// <summary>
        /// Concrete visible lines.
        /// </summary>
        private int visibleLinesCount;

        /// <summary>
        /// Initializes a new instance of the <see cref="GameConsoleConsoleGraphic"/> class.
        /// </summary>
        /// <param name="gameConsole">Game console for the graphic.</param>
        /// <param name="coords">Coordinates of the console.</param>
        /// <param name="renderer">Renderer for the console game.</param>
        /// <param name="visibleLines">Visible lines of the game console.</param>
        public GameConsoleConsoleGraphic(IGameConsole gameConsole, IntPoint coords, IRenderer renderer, int visibleLines)
            : base(gameConsole, coords, renderer)
        {
            this.gameConsole = gameConsole;
            this.visibleLinesCount = visibleLines;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="GameConsoleConsoleGraphic"/> class.
        /// </summary>
        /// <param name="gameConsole">Game console for the graphic.</param>
        /// <param name="coords">Coordinates of the console.</param>
        /// <param name="renderer">Renderer for the console game.</param>
        public GameConsoleConsoleGraphic(IGameConsole gameConsole, IntPoint coords, IRenderer renderer)
            : this(gameConsole, coords, renderer, DefaultVisibleLinesCount)
        {
        }

        /// <summary>
        /// Generates a console graphic.
        /// </summary>
        /// <returns>String array with the graphic.</returns>
        protected override string[] GenerateStringGraphic()
        {
            int linesCount = this.visibleLinesCount;
            string[] graphic = this.gameConsole.GetLastLines(linesCount);
            return graphic;
        }
    }
}
