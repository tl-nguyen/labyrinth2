// ********************************
// <copyright file="ITable.cs" company="Telerik Academy">
// Copyright (c) 2014 Telerik Academy. All rights reserved.
// </copyright>
//
// ********************************
namespace Labyrinth.Results.Contracts
{
    using System.Runtime.Serialization;

    /// <summary>
    /// Interface for scores table
    /// </summary>
    public interface ITable : ISerializable
    {
        /// <summary>
        /// Event for change in the ITable.
        /// </summary>
        event ChangedTableEventHandler Changed;

        string[] GetTopResultsStrings();

        /// <summary>
        /// Checks if currentMoves is good enough to enter the table.
        /// </summary>
        /// <param name="currentMoves">Integer value representing the amount of moves.</param>
        /// <returns>True if currentMoves qualifies for the table.</returns>
        bool IsTopResult(int currentMoves);

        /// <summary>
        /// Adds a new IResult to the table.
        /// </summary>
        /// <param name="result">IResult to be added.</param>
        void Add(IResult result);
    }
}