namespace Labyrinth.UI
{
    using Renderer.Contracts;
    using Commons;
    using Entities.Contracts;

    public class ConsoleRenderableGameConsole : ConsoleRenderableEntity
    {
        private const int DEFAULT_VISIBLE_LINES_COUNT = 15;

        private IGameConsole gameConsole;
        private int visibleLinesCount;

        public ConsoleRenderableGameConsole(IntPoint coords, IRenderer renderer, IGameConsole gameConsole, int visibleLines)
            : base(gameConsole, coords, renderer)
        {
            this.gameConsole = gameConsole;
            this.visibleLinesCount = visibleLines;
        }
        public ConsoleRenderableGameConsole(IntPoint coords, IRenderer renderer, IGameConsole gameConsole)
            : this (coords, renderer, gameConsole, DEFAULT_VISIBLE_LINES_COUNT)
        {
        }

        override protected string GenerateStringGraphic()
        {
            return gameConsole.ToString();
        }
    }
}
