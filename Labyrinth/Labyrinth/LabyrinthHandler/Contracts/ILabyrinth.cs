namespace Labyrinth.LabyrinthHandler.Contracts
{
    using System.Collections.Generic;
    using Commons;

    public interface ILabyrinth
    {
        ICell[,] Matrix { get; set; }

        ICell CurrentCell { get; set; }

        IMoveHandler MoveHandler { get; }

        int LabyrinthSize { get; }
    }
}