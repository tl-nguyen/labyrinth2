namespace Labyrinth.UI
{
    using System.Text;
    using Renderer.Contracts;
    using Commons;
    using Entities.Contracts;

    public class GameConsoleConsoleGraphic : EntityConsoleGraphic
    {
        private const int DEFAULT_VISIBLE_LINES_COUNT = 15;

        private IGameConsole gameConsole;
        private int visibleLinesCount;

        public GameConsoleConsoleGraphic(IGameConsole gameConsole, IntPoint coords, IRenderer renderer, int visibleLines)
            : base(gameConsole, coords, renderer)
        {
            this.gameConsole = gameConsole;
            this.visibleLinesCount = visibleLines;
        }
        public GameConsoleConsoleGraphic(IGameConsole gameConsole, IntPoint coords, IRenderer renderer)
            : this (gameConsole, coords, renderer, DEFAULT_VISIBLE_LINES_COUNT)
        {
        }

        override protected string GenerateStringGraphic()
        {
            int linesCount = this.visibleLinesCount;
            string[] lines = this.gameConsole.GetLastLines(linesCount);

            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < lines.Length; i++)
            {
                sb.AppendLine(lines[i]);
            }
            return sb.ToString();
        }
    }
}
