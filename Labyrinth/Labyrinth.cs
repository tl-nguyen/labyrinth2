namespace Labyrinth
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Class representation of a single level(labyrinth) of the game
    /// </summary>
    public class Labyrinth : ILabyrinth
    {
        public const int LABYRINTH_SIZE = 10;

        private readonly int labyrintStartRow = LABYRINTH_SIZE / 2;
        private readonly int labyrinthStartCol = LABYRINTH_SIZE / 2;
        private ICell[,] labyrinth;
        private ICell currentCell;

        public ICell CurrentCell
        {
            get
            {
                return this.currentCell;
            }
            private set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("the current cell cannot be null");
                }
                this.currentCell = value;
            }
        }

        public Labyrinth()
        {
            GenerateLabyrinth();
            this.CurrentCell = labyrinth[labyrintStartRow, labyrintStartRow];
        }

        /// <summary>
        /// Return a specific cell from the labyrinth by its row and col positions
        /// </summary>
        /// <param name="row">The row of the wanted cell</param>
        /// <param name="col">The col of the wanted cell</param>
        public ICell GetCell(int row, int col)
        {
            return labyrinth[row, col];
        }

        /// <summary>
        /// Try the next move to the new cell, if it is valid
        /// </summary>
        /// <param name="currentCell">The current cell object, where the player is at</param>
        /// <param name="direction">The direction that the player want to move (up, down, left, right)</param>
        public bool TryMove(ICell currentCell, Direction direction)
        {
            ICell newCell = FindNewCellCoordinates(currentCell, direction);

            if (newCell.Row < 0 ||
                newCell.Col < 0 ||
                newCell.Row >= labyrinth.GetLength(0) ||
                newCell.Col >= labyrinth.GetLength(1))
            {
                return false;
            }

            if (!labyrinth[newCell.Row, newCell.Col].IsEmpty())
            {
                return false;
            }

            this.labyrinth[newCell.Row, newCell.Col].CellValue = newCell.CellValue;
            this.labyrinth[currentCell.Row, currentCell.Col].CellValue = CellState.Empty;
            this.CurrentCell = labyrinth[newCell.Row, newCell.Col];

            return true;
        }

        /// <summary>
        /// Return a new cell object, after the player is moved by a direction
        /// </summary>
        /// <param name="currentCell">The current cell object, where the player is at</param>
        /// <param name="direction">The direction that the player want to move (up, down, left, right)</param>
        private ICell FindNewCellCoordinates(ICell currentCell, Direction direction)
        {
            ICell newCell = LabyrinthFactory.GetCellInstance(currentCell.Row, currentCell.Col, currentCell.CellValue);

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
        private void MoveTo(ICell currentCell, Direction direction,
            Queue<ICell> cellsOrder, HashSet<ICell> visitedCells)
        {
            ICell newCell = FindNewCellCoordinates(currentCell, direction);

            if (newCell.Row < 0 ||
                newCell.Col < 0 ||
                newCell.Row >= labyrinth.GetLength(0) ||
                newCell.Col >= labyrinth.GetLength(1))
            {
                return;
            }

            if (visitedCells.Contains(labyrinth[newCell.Row, newCell.Col]))
            {
                return;
            }

            if (labyrinth[newCell.Row, newCell.Col].IsEmpty())
            {
                cellsOrder.Enqueue(labyrinth[newCell.Row, newCell.Col]);
            }
        }

        /// <summary>
        /// Check if a given cell is the at the exit of the labyrinth
        /// </summary>
        /// <param name="cell">The given cell to check for if it's at the exit of the labyrinthor not</param>
        private bool ExitFound(ICell cell)
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

        /// <summary>
        /// Check if the generated labyrinth has an exit or not
        /// </summary>
        private bool ExitPathExists()
        {
            Queue<ICell> cellsOrder = new Queue<ICell>();
            ICell startCell = labyrinth[labyrintStartRow, labyrinthStartCol];
            cellsOrder.Enqueue(startCell);
            HashSet<ICell> visitedCells = new HashSet<ICell>();

            while (cellsOrder.Count > 0)
            {
                ICell currentCell = cellsOrder.Dequeue();
                visitedCells.Add(currentCell);

                if (ExitFound(currentCell))
                {
                    return true;
                }

                MoveTo(currentCell, Direction.Down, cellsOrder, visitedCells);
                MoveTo(currentCell, Direction.Up, cellsOrder, visitedCells);
                MoveTo(currentCell, Direction.Left, cellsOrder, visitedCells);
                MoveTo(currentCell, Direction.Right, cellsOrder, visitedCells);
            }

            return false;
        }

        /// <summary>
        /// Generating the labyrinth for the game
        /// </summary>
        public void GenerateLabyrinth()
        {
            Random rand = new Random();
            this.labyrinth = new Cell[LABYRINTH_SIZE, LABYRINTH_SIZE];

            bool exitPathExists = false;
            while (!exitPathExists)
            {
                for (int row = 0; row < LABYRINTH_SIZE; row++)
                {
                    for (int col = 0; col < LABYRINTH_SIZE; col++)
                    {
                        int cellRandomValue = rand.Next(0, 2);

                        CellState state = CellState.Wall;
                        if (cellRandomValue == 0)
                        {
                            state = CellState.Empty;
                        }
                        this.labyrinth[row, col] = LabyrinthFactory.GetCellInstance(row, col, state);
                    }
                }
                exitPathExists = ExitPathExists();
            }

            this.labyrinth[labyrintStartRow, labyrinthStartCol].CellValue = CellState.Player;
        }
    }
}
