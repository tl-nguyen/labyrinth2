namespace Labyrinth.Renderer.Contracts
{
    using Labyrinth.UI.Contracts;

    /// <summary>
    /// Interface defining a rendering engine.
    /// </summary>
    public interface IRenderer
    {
        /// <summary>
        /// Initializes the rendering engine, using the given parameters width and height. 
        /// The units used for measurement(pixels, cells, other...),  depend on the renderer implementation.
        /// </summary>
        /// <param name="windowWidth">Receives a window width</param>
        /// <param name="windowHeight">Receives a window height</param>
        void Init(int windowWidth, int windowHeight);

        /// <summary>
        /// Renders the <see cref="IRenderable"/> given.
        /// </summary>
        /// <param name="entity">The object to render.</param>
        void RenderEntity(IRenderable entity);
    }
}