// ********************************
// <copyright file="IResultFactory.cs" company="Telerik Academy">
// Copyright (c) 2014 Telerik Academy. All rights reserved.
// </copyright>
//
// ********************************
namespace Labyrinth
{
    using Results.Contracts;

    /// <summary>
    /// Abstraction defining a factory that returns the correct <see cref="IResult"/> instances.
    /// </summary>
    public interface IResultFactory
    {
        /// <summary>
        /// Gets the correct instance of the class implementing <see cref="IResult"/> interface.
        /// </summary>
        /// <returns>The correct instance of the class implementing <see cref="IResult"/> interface</returns>
        /// <param name="movesCount">Integer with the moves made</param>
        /// <param name="playerName">String with the player name</param>
        IResult GetIResultInstance(int movesCount, string playerName);
    }
}
