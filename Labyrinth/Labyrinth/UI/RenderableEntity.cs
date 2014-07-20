using Labyrinth.Commons;
using Labyrinth.UI.Contracts;
using Labyrinth.Renderer.Contracts;

namespace Labyrinth.UI
{
    public abstract class RenderableEntity : IRenderable
    {
        protected IRenderer renderer;

        public IntPoint TopLeft { get; set; }
        public dynamic Graphic { get; protected set; }

        public RenderableEntity(IntPoint coords, IRenderer renderer)
        {
            this.TopLeft = coords;
            this.renderer = renderer;
        }

        abstract public void Render();

        public void SetX(int x)
        {
            this.TopLeft.X = x;
        }

        public void SetY(int y)
        {
            this.TopLeft.Y = y;
        }
    }
}
