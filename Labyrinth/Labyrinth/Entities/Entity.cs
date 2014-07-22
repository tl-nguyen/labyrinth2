namespace Labyrinth.Entities
{
    using Entities.Contracts;

    public abstract class Entity : IEntity
    {
        public bool Active { get; private set; }

        public Entity(bool active)
        {
            this.Active = active;
        }

        public Entity()
            : this(true)
        {
        }

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