namespace Labyrinth.UI
{
    using Commons;
    using Entities.Contracts;
    using Renderer.Contracts;
    using UI.Contracts;

    /// <summary>
    /// Base class for console graphic of the entities.
    /// </summary>
    public abstract class EntityConsoleGraphic : IRenderable
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EntityConsoleGraphic"/> class.
        /// </summary>
        /// <param name="entity">Entity for render on the console.</param>
        /// <param name="coords">Coordinates of the console graphic of the entity.</param>
        /// <param name="renderer">Renderer for the console graphic of the entity.</param>
        public EntityConsoleGraphic(IEntity entity, IntPoint coords, IRenderer renderer)
        {
            this.Entity = entity;
            this.TopLeft = coords;
            this.Renderer = renderer;
        }

        /// <summary>
        /// Gets or sets coordinates of the console graphic of the entity.
        /// </summary>
        public IntPoint TopLeft { get; set; }

        /// <summary>
        /// Gets or sets the console graphic.
        /// </summary>
        public dynamic Graphic { get; protected set; }

        /// <summary>
        /// Gets or sets entity for render on the console.
        /// </summary>
        protected IEntity Entity { get; set; }

        /// <summary>
        /// Gets or sets renderer for the console graphic of the entity.
        /// </summary>
        protected IRenderer Renderer { get; set; }

        /// <summary>
        /// Renders the entity on the console.
        /// </summary>
        public void Render()
        {
            if (this.Entity.Active)
            {
                this.UpdateGraphic();
                this.Renderer.RenderEntity(this);
            }
        }

        /// <summary>
        /// Generates string graphic for the console.
        /// </summary>
        /// <returns>Array of strings representing the graphic of the entity.</returns>
        protected abstract string[] GenerateStringGraphic();

        /// <summary>
        /// Updates the console graphic
        /// </summary>
        private void UpdateGraphic()
        {
            this.Graphic = this.GenerateStringGraphic();
        }
    }
}
