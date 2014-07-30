// ********************************
// <copyright file="ConsoleRenderer.cs" company="Telerik Academy">
// Copyright (c) 2014 Telerik Academy. All rights reserved.
// </copyright>
//
// ********************************
namespace Labyrinth.Renderer
{
    using System;
    using Renderer.Contracts;
    using UI.Contracts;

    /// <summary>
    /// Concrete implementation of the IConsoleRenderer interface
    /// </summary>
    public class ConsoleRenderer : IConsoleRenderer
    {
        /// <summary>
        /// Sets the console size, removes the scrollbars.
        /// </summary>
        /// <param name="windowWidth">valid range in default console: [1, 169]</param>
        /// <param name="windowHeight"> valid range in default console: [1, 61]</param>
        public void Init(int windowWidth, int windowHeight)
        {
            if (windowWidth <= 0)
            {
                throw new ArgumentOutOfRangeException("Value of the window width must not be negative or zero");
            }
            else if (windowWidth > Console.LargestWindowWidth)
            {
                string exceptionMsg = string.Format("Value of the window width must not be higher than {0}", Console.LargestWindowWidth);
                throw new ArgumentOutOfRangeException(exceptionMsg);
            }

            if (windowHeight <= 0)
            {
                throw new ArgumentOutOfRangeException("Value of the window height must not be negative or zero");
            }
            else if (windowHeight > Console.LargestWindowHeight)
            {
                string exceptionMsg = string.Format("Value of the window height must not be higher than {0}", Console.LargestWindowHeight);
                throw new ArgumentOutOfRangeException(exceptionMsg);
            }

            Console.WindowWidth = windowWidth;
            Console.WindowHeight = windowHeight;

            Console.BufferWidth = Console.WindowWidth;
            Console.BufferHeight = Console.WindowHeight;
        }

        /// <summary>
        /// Renders the object it receives
        /// </summary>
        /// <param name="entity">Gets a non null <see cref="IRenderable"/> implementation to render</param>
        public void RenderEntity(IRenderable entity)
        {
            int x = entity.TopLeft.X;
            int y = entity.TopLeft.Y;
            string[] entityGraphic = entity.Graphic;
            int entityGrapicLines = entityGraphic.Length;
            for (int i = 0; i < entityGrapicLines; i++)
            {
                Console.SetCursorPosition(x, y + i);
                Console.Write(entityGraphic[i]);
            }
        }

        /// <summary>
        /// Clears the console.
        /// </summary>
        public void Clear()
        {
            Console.Clear();
        }
    }
}