namespace Labyrinth.LabyrinthHandler.Contracts
{
    using System.Collections.Generic;
    using Commons;
    using Entities.Contracts;

    /// <summary>
    /// Move behaviors of the labyrinth
    /// </summary>
    public interface IMoveHandler
    {
        /// <summary>
        /// Checks if a move can be done
        /// </summary>
        /// <param name="labyrinth">The current working labyrinth</param>
        /// <param name="direction">Current user input direction</param>
        /// <returns>True if a move can be made, false if not</returns>
        bool MoveAction(ILabyrinthPlayField labyrinth, Command direction);

        /// <summary>
        /// Adding the successfully moved steps to the cellsOrder queue
        /// </summary>
        /// <param name="labyrinth">The current working labyrinth</param>
        /// <param name="currentCell">The current cell object, where the player is at</param>
        /// <param name="direction">The direction that the player want to move (up, down, left, right)</param>
        /// <param name="cellsOrder">the cells order for all successfully moved steps</param>
        /// <param name="visitedCells">the already visited positions</param>
        void MoveTo(
            ILabyrinthPlayField labyrinth,
            ICell currentCell,
            Direction direction,
            Queue<ICell> cellsOrder,
            HashSet<ICell> visitedCells);

        /// <summary>
        /// Check if a given cell is the at the exit of the labyrinth
        /// </summary>
        /// <param name="labyrinth">The current working labyrinth</param>
        /// <param name="cell">The given cell to check for if it's at the exit of the labyrinth or not</param>
        /// <returns>True if it is, false if it isn't</returns>
        bool ExitFound(ILabyrinthPlayField labyrinth, ICell cell);
    }
}