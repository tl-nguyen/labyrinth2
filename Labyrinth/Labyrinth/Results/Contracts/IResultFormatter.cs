// ********************************
// <copyright file="IResultFormatter.cs" company="Telerik Academy">
// Copyright (c) 2014 Telerik Academy. All rights reserved.
// </copyright>
//
// ********************************
namespace Labyrinth.Results.Contracts
{
    using System.Runtime.Serialization;

    /// <summary>
    /// Interface for game result formatting.
    /// </summary>
    public interface IResultFormatter : ISerializable
    {
        /// <summary>
        /// Formats the name of the player and the moves count of the game result.
        /// </summary>
        /// <param name="name">Name of the player.</param>
        /// <param name="moves">Moves count.</param>
        /// <returns>String representing the formatted result.</returns>
        string Format(string name, string moves);
    }
}