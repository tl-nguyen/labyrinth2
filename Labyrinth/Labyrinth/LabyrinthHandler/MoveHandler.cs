﻿namespace Labyrinth.LabyrinthHandler
{
    using System.Collections.Generic;
    using Contracts;
    using Commons;

    public abstract class MoveHandler : ILabyrinthMoveHandler
    {
        //TODO: IMPORTANT refactor this public constant, remove it, and use the actual labyrinth to get it each time, not an effectively static field that if we remove this class, we will not have if we only use ILabyrinthMoveHandler !
        public const int LABYRINTH_SIZE = 10;

        public ICell[,] Matrix { get; set; }

        public ICell CurrentCell { get; set; }

        /// <summary>
        /// Checks if a move can be done using the parent's method TryMove
        /// </summary>
        /// <param name="direction">Current user input direction</param>
        /// <returns>True if a move can be made, false if not</returns>
        public bool MoveAction(Command direction)
        {
            bool moveDone = false;
            switch (direction)
            {
                case Command.Up:
                    moveDone =
                        TryMove(this.CurrentCell, Direction.Up);
                    break;
                case Command.Down:
                    moveDone =
                        TryMove(this.CurrentCell, Direction.Down);
                    break;
                case Command.Left:
                    moveDone =
                        TryMove(this.CurrentCell, Direction.Left);
                    break;
                case Command.Right:
                    moveDone =
                        TryMove(this.CurrentCell, Direction.Right);
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
        private bool TryMove(ICell currentCell, Direction direction)
        {
            ICell newCell = FindNewCellCoordinates(currentCell, direction);

            if (newCell.Row < 0 ||
                newCell.Col < 0 ||
                newCell.Row >= this.Matrix.GetLength(0) ||
                newCell.Col >= this.Matrix.GetLength(1))
            {
                return false;
            }

            if (!this.Matrix[newCell.Row, newCell.Col].IsEmpty())
            {
                return false;
            }

            this.Matrix[newCell.Row, newCell.Col].CellValue = newCell.CellValue;
            this.Matrix[currentCell.Row, currentCell.Col].CellValue = CellState.Empty;
            this.CurrentCell = this.Matrix[newCell.Row, newCell.Col];

            return true;
        }

        /// <summary>
        /// Return a new cell object, after the player is moved by a direction
        /// </summary>
        /// <param name="currentCell">The current cell object, where the player is at</param>
        /// <param name="direction">The direction that the player want to move (up, down, left, right)</param>
        public ICell FindNewCellCoordinates(ICell currentCell, Direction direction)
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
        public void MoveTo(ICell currentCell, Direction direction,
            Queue<ICell> cellsOrder, HashSet<ICell> visitedCells)
        {
            ICell newCell = FindNewCellCoordinates(currentCell, direction);

            if (newCell.Row < 0 ||
                newCell.Col < 0 ||
                newCell.Row >= this.Matrix.GetLength(0) ||
                newCell.Col >= this.Matrix.GetLength(1))
            {
                return;
            }

            if (visitedCells.Contains(this.Matrix[newCell.Row, newCell.Col]))
            {
                return;
            }

            if (this.Matrix[newCell.Row, newCell.Col].IsEmpty())
            {
                cellsOrder.Enqueue(this.Matrix[newCell.Row, newCell.Col]);
            }
        }

        /// <summary>
        /// Check if a given cell is the at the exit of the labyrinth
        /// </summary>
        /// <param name="cell">The given cell to check for if it's at the exit of the labyrinthor not</param>
        public bool ExitFound(ICell cell)
        {
            if (cell.Row == LABYRINTH_SIZE - 1 ||
                cell.Col == LABYRINTH_SIZE - 1 ||
                cell.Row == 0 ||
                cell.Col == 0)
            {
                return true;
            }

            return false;
        }
    }
}
