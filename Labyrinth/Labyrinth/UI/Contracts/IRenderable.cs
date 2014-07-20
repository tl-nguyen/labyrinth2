namespace Labyrinth.UI.Contracts
{
    using Labyrinth.Commons;

    public interface IRenderable
    {
        IntPoint TopLeft { get; set; }
        dynamic Graphic { get; }
        void Render();
        void SetX(int x);
        void SetY(int y);
    }
}
