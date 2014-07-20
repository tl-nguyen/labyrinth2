namespace Labyrinth.UI.Contracts
{
    public interface IScene
    {
        void Render();

        void Add(IRenderable entity);

        void Remove(IRenderable entity);

        bool CheckIfEntityExists(IRenderable entity);
    }
}
