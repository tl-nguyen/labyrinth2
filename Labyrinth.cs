namespace Labyrinth
{

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    class Labyrinth
    {
        public const int LABYRINTH_SIZE = 7;
        private readonly int labyrintStartRow = LABYRINTH_SIZE / 2;
        private readonly int labyrinthStartCol = LABYRINTH_SIZE / 2;
        private ICell[,] labyrinth;

        public ICell CurrentCell;

        public Labyrinth(Random rand)
        {
            GenerateLabyrinth(rand);
            this.CurrentCell = labyrinth[labyrintStartRow, labyrintStartRow];
        }

        public ICell GetCell(int row, int col)
        {
            return labyrinth[row, col];
        }

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

        private ICell FindNewCellCoordinates(ICell currentCell, Direction direction)
        {
            ICell newCell = new Cell(currentCell.Row, currentCell.Col, currentCell.CellValue);

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

        private bool ExitFound(ICell cell)
        {
            bool exitFound = false;

            if (cell.Row == LABYRINTH_SIZE - 1 ||
                cell.Col == LABYRINTH_SIZE - 1 ||
                cell.Row == 0 ||
                cell.Col == 0)
            {
                exitFound = true;
            }

            return exitFound;
        }

        private bool ExitPathExists()
        {
            Queue<ICell> cellsOrder = new Queue<ICell>();
            ICell startCell = labyrinth[labyrintStartRow, labyrinthStartCol];
            cellsOrder.Enqueue(startCell);
            HashSet<ICell> visitedCells = new HashSet<ICell>();

            bool pathExists = false;
            while (cellsOrder.Count > 0)
            {
                ICell currentCell = cellsOrder.Dequeue();
                visitedCells.Add(currentCell);

                if (ExitFound(currentCell))
                {
                    pathExists = true;
                    break;
                }

                MoveTo(currentCell, Direction.Down, cellsOrder, visitedCells);
                MoveTo(currentCell, Direction.Up, cellsOrder, visitedCells);
                MoveTo(currentCell, Direction.Left, cellsOrder, visitedCells);
                MoveTo(currentCell, Direction.Right, cellsOrder, visitedCells);
            }

            return pathExists;
        }

        private void GenerateLabyrinth(Random rand)
        {
            this.labyrinth = new Cell[LABYRINTH_SIZE, LABYRINTH_SIZE];

            for (int row = 0; row < LABYRINTH_SIZE; row++)
            {
                for (int col = 0; col < LABYRINTH_SIZE; col++)
                {
                    int cellRandomValue = rand.Next(0, 2);

                    CellState state;
                    if (cellRandomValue == 0)
                    {
                        state = CellState.Empty;
                    }
                    else
                    {
                        state = CellState.Wall;
                    }
                    this.labyrinth[row, col] = new Cell(row, col, state);
                }
            }

            this.labyrinth[labyrintStartRow, labyrinthStartCol].CellValue = CellState.Player;

            bool exitPathExists = ExitPathExists();

            if (!exitPathExists)
            {
                GenerateLabyrinth(rand);
            }
        }
    }
}
