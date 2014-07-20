namespace Labyrinth.LabyrinthHandler
{
    using System.Collections.Generic;
    using Contracts;
    using Commons;
    using Entities.Contracts;

    public class MoveHandler : IMoveHandler
    {
        /// <summary>
        /// Checks if a move can be done using the parent's method TryMove
        /// </summary>
        /// <param name="direction">Current user input direction</param>
        /// <returns>True if a move can be made, false if not</returns>
        public bool MoveAction(ILabyrinth labyrinth, Command direction)
        {
            bool moveDone = false;
            switch (direction)
            {
                case Command.Up:
                    moveDone =
                        TryMove(labyrinth, Direction.Up);
                    break;
                case Command.Down:
                    moveDone =
                        TryMove(labyrinth, Direction.Down);
                    break;
                case Command.Left:
                    moveDone =
                        TryMove(labyrinth, Direction.Left);
                    break;
                case Command.Right:
                    moveDone =
                        TryMove(labyrinth, Direction.Right);
                    break;
                default:
                    break;
            }

            return moveDone;
        }

        /// <summary>
        /// Try the next move to the new cell, if it is valid
        /// </summary>
        /// <param name="currentCell">The current cell object, where the player is at</param>
        /// <param name="direction">The direction that the player want to move (up, down, left, right)</param>
        private bool TryMove(ILabyrinth labyrinth, Direction direction)
        {
            ICell newCell = FindNewCellCoordinates(labyrinth.CurrentCell, direction);

            if (newCell.Row < 0 ||
                newCell.Col < 0 ||
                newCell.Row >= labyrinth.Matrix.GetLength(0) ||
                newCell.Col >= labyrinth.Matrix.GetLength(1))
            {
                return false;
            }

            if (!labyrinth.Matrix[newCell.Row, newCell.Col].IsEmpty())
            {
                return false;
            }

            labyrinth.Matrix[newCell.Row, newCell.Col].CellValue = newCell.CellValue;
            labyrinth.Matrix[labyrinth.CurrentCell.Row, labyrinth.CurrentCell.Col].CellValue = CellState.Empty;
            labyrinth.CurrentCell = labyrinth.Matrix[newCell.Row, newCell.Col];

            return true;
        }

        /// <summary>
        /// Return a new cell object, after the player is moved by a direction
        /// </summary>
        /// <param name="currentCell">The current cell object, where the player is at</param>
        /// <param name="direction">The direction that the player want to move (up, down, left, right)</param>
        private ICell FindNewCellCoordinates(ICell currentCell, Direction direction)
        {
            ICell newCell = (ICell)currentCell.Clone();
            
            switch (direction)
            {
                case Direction.Up:
                    newCell.Row -= 1;
                    break;
                case Direction.Down:
                    newCell.Row += 1;
                    break;
                case Direction.Left:
                    newCell.Col -= 1;
                    break;
                case Direction.Right:
                    newCell.Col += 1;
                    break;
            }

            return newCell;
        }

        /// <summary>
        /// Adding the successfuly moved steps to the cellsOrder queue
        /// </summary>
        /// <param name="currentCell">The current cell object, where the player is at</param>
        /// <param name="direction">The direction that the player want to move (up, down, left, right)</param>
        /// <param name="cellsOrder">the cells order for all successfully moved steps</param>
        /// <param name="visitedCells">the already visited positions</param>
        public void MoveTo(ILabyrinth labyrinth, ICell currentCell, Direction direction,
            Queue<ICell> cellsOrder, HashSet<ICell> visitedCells)
        {
            ICell newCell = FindNewCellCoordinates(currentCell, direction);

            if (newCell.Row < 0 ||
                newCell.Col < 0 ||
                newCell.Row >= labyrinth.Matrix.GetLength(0) ||
                newCell.Col >= labyrinth.Matrix.GetLength(1))
            {
                return;
            }

            if (visitedCells.Contains(labyrinth.Matrix[newCell.Row, newCell.Col]))
            {
                return;
            }

            if (labyrinth.Matrix[newCell.Row, newCell.Col].IsEmpty())
            {
                cellsOrder.Enqueue(labyrinth.Matrix[newCell.Row, newCell.Col]);
            }
        }

        /// <summary>
        /// Check if a given cell is the at the exit of the labyrinth
        /// </summary>
        /// <param name="cell">The given cell to check for if it's at the exit of the labyrinthor not</param>
        public bool ExitFound(ILabyrinth labyrinth, ICell cell)
        {
            if (cell.Row == labyrinth.LabyrinthSize - 1 ||
                cell.Col == labyrinth.LabyrinthSize - 1 ||
                cell.Row == 0 ||
                cell.Col == 0)
            {
                return true;
            }

            return false;
        }
    }
}
