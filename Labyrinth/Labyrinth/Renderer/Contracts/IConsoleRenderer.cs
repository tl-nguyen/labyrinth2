// ********************************
// <copyright file="IConsoleRenderer.cs" company="Telerik Academy">
// Copyright (c) 2014 Telerik Academy. All rights reserved.
// </copyright>
//
// ********************************
namespace Labyrinth.Renderer.Contracts
{
    /// <summary>
    /// Defines an IRenderer with additional clear functionality.
    /// </summary>
    public interface IConsoleRenderer : IRenderer
    {
        /// <summary>
        /// Clears the console.
        /// </summary>
        void Clear();
    }
}