namespace Labyrinth.Entities.Contracts
{
    /// <summary>
    /// Interface for entities for rendering.
    /// </summary>
    public interface IEntity
    {
        /// <summary>
        /// Gets a value indicating whether the state of the entity is active. Could be used to check if an entity should update, render, collide, etc.
        /// </summary>
        bool Active { get; }

        /// <summary>
        /// Sets the entity's Active property to true.
        /// </summary>
        void Activate();

        /// <summary>
        /// Sets the entity's Active property to false.
        /// </summary>
        void Deactivate();
    }
}