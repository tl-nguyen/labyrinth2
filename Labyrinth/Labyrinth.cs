namespace Labyrinth
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Class representation of a single level(labyrinth) of the game
    /// </summary>
    public class Labyrinth : MoveHandler
    {
        private readonly int labyrintStartRow = LABYRINTH_SIZE / 2;
        private readonly int labyrinthStartCol = LABYRINTH_SIZE / 2;

        public Labyrinth()
        {
            this.Labyrinth = new Cell[LABYRINTH_SIZE, LABYRINTH_SIZE];
            GenerateLabyrinth();
            this.CurrentCell = this.Labyrinth[labyrintStartRow, labyrintStartRow];
        }

        /// <summary>
        /// Generating the labyrinth for the game
        /// </summary>
        public void GenerateLabyrinth()
        {
            Random rand = new Random();
            

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
                        this.Labyrinth[row, col] = LabyrinthFactory.GetCellInstance(row, col, state);
                    }
                }
                exitPathExists = ExitPathExists();
            }

            this.Labyrinth[labyrintStartRow, labyrinthStartCol].CellValue = CellState.Player;
        }


        /// <summary>
        /// Check if the generated labyrinth has an exit or not
        /// </summary>
        private bool ExitPathExists()
        {
            Queue<ICell> cellsOrder = new Queue<ICell>();
            ICell startCell = this.Labyrinth[labyrintStartRow, labyrinthStartCol];
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
    }
}
