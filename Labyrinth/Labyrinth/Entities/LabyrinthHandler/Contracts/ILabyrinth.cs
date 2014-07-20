using System.Collections.Generic;
using Labyrinth.Commons;
using Labyrinth.Entities.Contracts;

namespace Labyrinth.Entities.LabyrinthHandler.Contracts
{
    public interface ILabyrinth : IEntity
    {
        ICell[,] Matrix { get; set; }

        ICell CurrentCell { get; set; }

        IMoveHandler MoveHandler { get; }

        int LabyrinthSize { get; }
    }
}