// ********************************
// <copyright file="ConsoleScene.cs" company="Telerik Academy">
// Copyright (c) 2014 Telerik Academy. All rights reserved.
// </copyright>
//
// ********************************
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
