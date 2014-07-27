// ********************************
// <copyright file="ILabyrinthPlayField.cs" company="Telerik Academy">
// Copyright (c) 2014 Telerik Academy. All rights reserved.
// </copyright>
//
// ********************************
namespace Labyrinth.Entities.Contracts
{
    using LabyrinthHandler.Contracts;

    /// <summary>
    /// Class represents the labyrinth play-field
    /// </summary>
    public interface ILabyrinthPlayField : IEntity
    {
        ICell[,] Matrix { get; set; }

        ICell CurrentCell { get; set; }

        IMoveHandler MoveHandler { get; }

        int LabyrinthSize { get; }

        /// <summary>
        /// Generating the labyrinth for the game
        /// </summary>
        void GenerateLabyrinth();
    }
}