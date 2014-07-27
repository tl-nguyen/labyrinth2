namespace Labyrinth.UI.Contracts
{
    /// <summary>
    /// Interface for rendering entities. 
    /// </summary>
    public interface IScene
    {
        /// <summary>
        /// Renders the scene.
        /// </summary>
        void Render();

        /// <summary>
        /// Adds entity for the scene.
        /// </summary>
        /// <param name="entity">Entity for adding.</param>
        void Add(IRenderable entity);

        /// <summary>
        /// Removes entity for the scene.
        /// </summary>
        /// <param name="entity">Entity for removal.</param>
        void Remove(IRenderable entity);
    }
}
