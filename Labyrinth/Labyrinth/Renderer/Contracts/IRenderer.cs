using Labyrinth.UI.Contracts;

namespace Labyrinth.Renderer.Contracts
{
    public interface IRenderer
    {
        void Init(int window_width, int window_height);
        void RenderEntity(IRenderable entity);
    }
}