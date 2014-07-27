// ********************************
// <copyright file="IGameConsole.cs" company="Telerik Academy">
// Copyright (c) 2014 Telerik Academy. All rights reserved.
// </copyright>
//
// ********************************
namespace Labyrinth.Entities.Contracts
{
    using Labyrinth.Commons;

    public interface IGameConsole : IEntity
    {
        void AddInput(Dialog key, string[] args);

        void AddInput(Dialog key);

        string[] GetLastLines(int numberOfLines);
    }
}