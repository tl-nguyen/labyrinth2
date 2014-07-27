// ********************************
// <copyright file="IRenderable.cs" company="Telerik Academy">
// Copyright (c) 2014 Telerik Academy. All rights reserved.
// </copyright>
//
// ********************************
namespace Labyrinth.UI.Contracts
{
    using Commons;

    public interface IRenderable
    {
        IntPoint TopLeft { get; set; }
        dynamic Graphic { get; }
        void Render();
    }
}
