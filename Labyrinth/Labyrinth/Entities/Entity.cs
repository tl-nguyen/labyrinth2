// ********************************
namespace Labyrinth.Entities
{
    using Entities.Contracts;

    /// <summary>
    /// Abstract class for rendering entities.
    /// </summary>
    public abstract class Entity : IEntity
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Entity"/> class.
        /// </summary>
        /// <param name="active">True if entity is active.</param>
        public Entity(bool active)
        {
            this.Active = active;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Entity"/> class.
        /// </summary>
        public Entity()
            : this(true)
        {
        }

        /// <summary>
        /// Gets a value indicating whether the entity is active.
        /// </summary>
        public bool Active { get; private set; }

        /// <summary>
        /// Activates the entity.
        /// </summary>
        public void Activate()
        {
            this.Active = true;
        }

        /// <summary>
        /// Deactivates the entity. 
        /// </summary>
        public void Deactivate()
        {
            this.Active = false;
        }
    }
}