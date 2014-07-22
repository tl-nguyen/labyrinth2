using Labyrinth.UI.Contracts;

namespace Labyrinth.Renderer.Contracts
{
    public interface IRenderer
    {
        void RenderEntity(IRenderable entity);
    }
}