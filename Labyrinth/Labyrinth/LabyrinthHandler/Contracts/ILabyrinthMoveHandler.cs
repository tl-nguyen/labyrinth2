namespace Labyrinth.LabyrinthHandler.Contracts
{
    using System.Collections.Generic;
    using Commons;

    public interface ILabyrinth : IMoveHandler
    {
        ICell[,] Matrix { get; set; }

        ICell CurrentCell { get; set; }

        int LabyrinthSize { get; }
    }
}