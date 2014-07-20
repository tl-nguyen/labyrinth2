namespace Labyrinth.Entities.Contracts
{
    public interface IEntity
    {
        bool Active { get; }
        void Activate();
        void Deactivate();
    }
}
