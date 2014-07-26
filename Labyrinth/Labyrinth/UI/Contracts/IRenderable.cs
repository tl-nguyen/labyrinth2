namespace Labyrinth.UI.Contracts
{
    using Commons;

    public interface IRenderable
    {
        IntPoint TopLeft { get; set; }
        dynamic Graphic { get; }
        void Render();
    }
}
