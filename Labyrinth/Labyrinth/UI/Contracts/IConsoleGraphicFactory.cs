namespace Labyrinth.UI.Contracts
{
    using UI;
    using Entities.Contracts;
    using Commons;
    using Renderer.Contracts;

    public interface IConsoleGraphicFactory
    {
        IRenderable GetLabyrinthConsoleGraphic(ILabyrinth labyrinth, IntPoint coords, IRenderer renderer);
    }
}
