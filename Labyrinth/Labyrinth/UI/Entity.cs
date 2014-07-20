using Labyrinth.Commons;
using Labyrinth.UI.Contracts;

namespace Labyrinth.UI
{
    public abstract class Entity : IRenderable
    {
        public IntPoint TopLeft { get; set; }

        public Entity(IntPoint coords)
        {
            this.TopLeft = coords;
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
