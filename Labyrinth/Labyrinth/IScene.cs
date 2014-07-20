using Labyrinth.UI.Contracts;

namespace Labyrinth
{
    public interface IScene
    {
        void Render();

        void Add(IRenderable entity);

        void Remove(IRenderable entity);

        bool CheckIfEntityExists(IRenderable entity);
    }
}
