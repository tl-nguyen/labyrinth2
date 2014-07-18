using Labyrinth.Entities.Contracts;

namespace Labyrinth.Renderer.Contracts
{
    public interface IRenderer
    {
        void RenderEntity(IRenderable entity);
    }
}
