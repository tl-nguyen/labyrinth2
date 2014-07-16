namespace Labyrinth
{
    using System.Collections.Generic;

    public interface ILabyrinthMoveHandler : IMoveHandler
    {
        ICell[,] Matrix { get; set; }

        ICell CurrentCell { get; set; }

        /// <summary>
        /// Try the next move to the new cell, if it is valid
        /// </summary>
        /// <param name="currentCell">The current cell object, where the player is at</param>
        /// <param name="direction">The direction that the player want to move (up, down, left, right)</param>
        bool TryMove(ICell currentCell, Direction direction);

        /// <summary>
        /// Return a new cell object, after the player is moved by a direction
        /// </summary>
        /// <param name="currentCell">The current cell object, where the player is at</param>
        /// <param name="direction">The direction that the player want to move (up, down, left, right)</param>
        ICell FindNewCellCoordinates(ICell currentCell, Direction direction);

        /// <summary>
        /// Adding the successfuly moved steps to the cellsOrder queue
        /// </summary>
        /// <param name="currentCell">The current cell object, where the player is at</param>
        /// <param name="direction">The direction that the player want to move (up, down, left, right)</param>
        /// <param name="cellsOrder">the cells order for all successfully moved steps</param>
        /// <param name="visitedCells">the already visited positions</param>
        void MoveTo(ICell currentCell, Direction direction,
            Queue<ICell> cellsOrder, HashSet<ICell> visitedCells);

        /// <summary>
        /// Check if a given cell is the at the exit of the labyrinth
        /// </summary>
        /// <param name="cell">The given cell to check for if it's at the exit of the labyrinthor not</param>
        bool ExitFound(ICell cell);
    }
}