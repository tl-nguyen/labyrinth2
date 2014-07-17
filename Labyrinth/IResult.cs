// ********************************
// <copyright file="IResult.cs" company="Telerik Academy">
// Copyright (c) 2014 Telerik Academy. All rights reserved.
// </copyright>
//
// ********************************
namespace Labyrinth
{
    using System.Runtime.Serialization;

    /// <summary>
    /// Interface for game results.
    /// </summary>
    public interface IResult : ISerializable
    {
        /// <summary>
        /// Gets the count of player moves.
        /// </summary>
        int MovesCount { get; }

        /// <summary>
        /// Gets the player name.
        /// </summary>
        string PlayerName { get; }

        /// <summary>
        /// Compares two results.
        /// </summary>
        /// <param name="other">Result for comparison.</param>
        /// <returns>Integer less than zero if this is less than other or zero if equal or greater than zero if this is greater than other.</returns>
        int CompareTo(object other);
    }
}