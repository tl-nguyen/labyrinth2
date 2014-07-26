namespace Labyrinth.UI.Contracts
{
    using UI;
    using Entities.Contracts;
    using Commons;
    using Renderer.Contracts;

    public interface IConsoleGraphicFactory
    {
        IntPoint GetCoordinates(int x, int y);

        IConsoleRenderer GetConsoleRenderer();

        IScene GetConsoleScene(IConsoleRenderer consoleRenderer);

        IRenderable GetLabyrinthConsoleGraphic(ILabyrinthPlayField labyrinth, IntPoint coords, IRenderer renderer);

        IRenderable GetResultsTableConsoleGraphic(IResultsTable table, IntPoint coords, IRenderer renderer);

        IRenderable GetGameConsoleGraphic(IGameConsole gameConsole, IntPoint coords, IRenderer renderer);
    }
}
