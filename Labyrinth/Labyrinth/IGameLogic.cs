// ********************************
// <copyright file="IGameLogic.cs" company="Telerik Academy">
// Copyright (c) 2014 Telerik Academy. All rights reserved.
// </copyright>
//
// ********************************
namespace Labyrinth
{
    /// <summary>
    /// Interface that handles input, and changes game objects
    /// </summary>
    public interface IGameLogic
    {
        /// <summary>
        /// Gets a value indicating whether a game ending condition is reached. Default value is false.
        /// </summary>
        bool Exit { get; }

        /// <summary>
        /// Receives a Command, processes it and updates the game entities accordingly
        /// </summary>
        void Update();
    }
}