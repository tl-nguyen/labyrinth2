// ********************************
namespace Labyrinth.Entities
{
    using Entities.Contracts;

    public abstract class Entity : IEntity
    {
        public Entity(bool active)
        {
            this.Active = active;
        }

        public Entity()
            : this(true)
        {
        }

        public bool Active { get; private set; }

        public void Activate()
        {
            this.Active = true;
        }

        public void Deactivate()
        {
            this.Active = false;
        }
    }
}