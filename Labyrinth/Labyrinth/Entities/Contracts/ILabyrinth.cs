namespace Labyrinth.Entities.Contracts
{
    using System.Collections.Generic;
    using Commons;
    using LabyrinthHandler.Contracts;

    public interface ILabyrinth : IEntity
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