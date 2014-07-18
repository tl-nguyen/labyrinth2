using Labyrinth.Commons;

namespace Labyrinth.Entities.Contracts
{
    public interface IRenderable
    {
        IntPoint TopLeft { get; set; }
        void Render();
        void SetX(int x);
        void SetY(int y);
    }
}
