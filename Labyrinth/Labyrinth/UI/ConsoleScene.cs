using System;
using System.Collections.Generic;
using Labyrinth.UI.Contracts;
using Labyrinth.Renderer.Contracts;

namespace Labyrinth.UI
{
    /// <summary>
    /// Implements the Render method for a ConsoleRenderer
    /// </summary>
    public class ConsoleScene : Scene
    {
        private IConsoleRenderer renderer;

        public ConsoleScene(IConsoleRenderer renderer)
            : base()
        {
            this.renderer = renderer;
        }

        override public void Render()
        {
            this.renderer.Clear();
            foreach (IRenderable entity in entities)
            {
                entity.Render();
            }
        }
    }
}
