// ********************************
// <copyright file="IRenderer.cs" company="Telerik Academy">
// Copyright (c) 2014 Telerik Academy. All rights reserved.
// </copyright>
//
// ********************************

namespace Labyrinth.Renderer.Contracts
{
    using Labyrinth.UI.Contracts;

    public interface IRenderer
    {
        /// <summary>
        /// Initializes the rendering engine, using the given params width and height. 
        /// The units used for measurement(pixels, cells, other...),  depend on the renderer implementation.
        /// </summary>
        void Init(int windowWidth, int windowHeight);

        /// <summary>
        /// Renders the given entity.
        /// </summary>
        void RenderEntity(IRenderable entity);
    }
}