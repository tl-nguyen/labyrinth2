using Labyrinth.Commons;

namespace Labyrinth.UI.Contracts
{
    public interface IRenderable
    {
        IntPoint TopLeft { get; set; }
        dynamic Graphic { get; }
        void Render();
        void SetX(int x);
        void SetY(int y);
    }
}
