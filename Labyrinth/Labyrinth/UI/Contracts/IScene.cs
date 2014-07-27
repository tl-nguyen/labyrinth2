// ********************************
// <copyright file="IScene.cs" company="Telerik Academy">
// Copyright (c) 2014 Telerik Academy. All rights reserved.
// </copyright>
//
// ********************************
namespace Labyrinth.UI.Contracts
{
    public interface IScene
    {
        void Render();

        void Add(IRenderable entity);

        void Remove(IRenderable entity);
    }
}
