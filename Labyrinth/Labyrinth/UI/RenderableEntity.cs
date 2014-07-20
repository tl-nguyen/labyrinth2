using Labyrinth.Commons;
using Labyrinth.UI.Contracts;
using Labyrinth.Renderer.Contracts;
using Labyrinth.Entities.Contracts;

namespace Labyrinth.UI
{
    public abstract class RenderableEntity : IRenderable
    {
        protected IRenderer renderer;

        public IntPoint TopLeft { get; set; }
        public dynamic Graphic { get; protected set; }
        protected IEntity entity;

        public RenderableEntity(IEntity entity, IntPoint coords, IRenderer renderer)
        {
            this.entity = entity;
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
