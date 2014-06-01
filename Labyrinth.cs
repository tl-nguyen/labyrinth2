using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Labyrinth
{
    class Labyrinth
    {
        public const int LABYRINTH_SIZE = 7;
        private readonly int LabyrintStartRow = LABYRINTH_SIZE / 2;
        private readonly int LabyrinthStartCol = LABYRINTH_SIZE / 2;
        private Cell[,] labyrinth;
        public Cell currentCell;

        public Labyrinth(Random rand)
        {
            GenerateLabyrinth(rand);
            this.currentCell = labyrinth[LabyrintStartRow, LabyrintStartRow];
        }

        public Cell GetCell(int row, int col)
        {
            return labyrinth[row, col];
        }

        public bool TryMove(Cell currentCell, Direction direction)
        {
            Cell newCell = FindNewCellCoordinates(currentCell, direction);

            if (newCell.Row < 0 || newCell.Col < 0 ||
                newCell.Row >= labyrinth.GetLength(0) || newCell.Col >= labyrinth.GetLength(1))
            {
                return false;
            }
            
            if (!labyrinth[newCell.Row, newCell.Col].IsEmpty())
            {
                return false;
            }

            this.labyrinth[newCell.Row, newCell.Col].ValueChar = newCell.ValueChar;
            this.labyrinth[currentCell.Row, currentCell.Col].ValueChar = Cell.CELL_EMPTY_VALUE;
            this.currentCell = labyrinth[newCell.Row, newCell.Col];

            return true;
        }

        private Cell FindNewCellCoordinates(Cell currentCell, Direction direction)
        {
            Cell newCell = new Cell(currentCell.Row, currentCell.Col, currentCell.ValueChar);

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

        private void moveTo(Cell currentCell, Direction direction,
            Queue<Cell> cellsOrder, HashSet<Cell> visitedCells)
        {
            Cell newCell = FindNewCellCoordinates(currentCell, direction);

            if (newCell.Row < 0 || newCell.Col < 0 ||
                newCell.Row >= labyrinth.GetLength(0) || newCell.Col >= labyrinth.GetLength(1))
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

        private bool ExitFound(Cell cell)
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
            Queue<Cell> cellsOrder = new Queue<Cell>();
            Cell startCell = labyrinth[LabyrintStartRow, LabyrinthStartCol];
            cellsOrder.Enqueue(startCell);
            HashSet<Cell> visitedCells = new HashSet<Cell>();

            bool pathExists = false;
            while (cellsOrder.Count > 0)
            {
                Cell currentCell = cellsOrder.Dequeue();
                visitedCells.Add(currentCell);

                if (ExitFound(currentCell))
                {
                    pathExists = true;
                    break;
                }

                moveTo(currentCell, Direction.Down, cellsOrder, visitedCells);
                moveTo(currentCell, Direction.Up, cellsOrder, visitedCells);
                moveTo(currentCell, Direction.Left, cellsOrder, visitedCells);
                moveTo(currentCell, Direction.Right, cellsOrder, visitedCells);
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

                    char charValue;
                    if (cellRandomValue == 0)
                    {
                        charValue = Cell.CELL_EMPTY_VALUE;
                    }
                    else
                    {
                        charValue = Cell.CELL_WALL_VALUE;
                    }
                    this.labyrinth[row, col] = new Cell(row, col, charValue);
                }
            }

            this.labyrinth[LabyrintStartRow, LabyrinthStartCol].ValueChar = '*';

            bool exitPathExists = ExitPathExists();

            if (!exitPathExists)
            {
                GenerateLabyrinth(rand);
            }
        }
    }
}
