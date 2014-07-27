namespace Labyrinth.UI.Contracts
{
    using Commons;

    /// <summary>
    /// Interface for rendering of entities.
    /// </summary>
    public interface IRenderable
    {
        /// <summary>
        /// Gets or sets coordinates of the graphic of the entity.
        /// </summary>
        IntPoint TopLeft { get; set; }

        /// <summary>
        /// Gets the graphic.
        /// </summary>
        dynamic Graphic { get; }

        /// <summary>
        /// Renders the entity.
        /// </summary>
        void Render();
    }
}
