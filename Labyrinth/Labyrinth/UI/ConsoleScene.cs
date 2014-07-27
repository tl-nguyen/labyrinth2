namespace Labyrinth.UI
{
    using System;
    using System.Collections.Generic;
    using Renderer.Contracts;
    using UI.Contracts;

    /// <summary>
    /// Implements the Render method for a ConsoleRenderer
    /// </summary>
    public class ConsoleScene : Scene
    {
        /// <summary>
        /// Console renderer for the scene.
        /// </summary>
        private IConsoleRenderer renderer;

        /// <summary>
        /// Initializes a new instance of the <see cref="ConsoleScene" /> class.
        /// </summary>
        /// <param name="renderer">Renderer for the scene.</param>
        public ConsoleScene(IConsoleRenderer renderer)
            : base()
        {
            this.renderer = renderer;
        }

        /// <summary>
        /// Renders the console scene.
        /// </summary>
        public override void Render()
        {
            this.renderer.Clear();
            foreach (IRenderable entity in this.Entities)
            {
                entity.Render();
            }
        }
    }
}
