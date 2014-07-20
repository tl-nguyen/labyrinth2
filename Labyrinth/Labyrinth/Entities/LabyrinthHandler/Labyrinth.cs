using System;
using System.Collections.Generic;
using Labyrinth.Commons;
using Labyrinth.Entities;
using Labyrinth.Entities.LabyrinthHandler.Contracts;

namespace Labyrinth.Entities.LabyrinthHandler
{
    
    /// <summary>
    /// Class representation of a single level(labyrinth) of the game
    /// </summary>
    public class Labyrinth : Entity, ILabyrinth
    {
        private const int DEFAULT_SIZE = 10;
        private readonly int labyrintStartRow;
        private readonly int labyrinthStartCol;
        private IFactory factory;

        public ICell[,] Matrix { get; set; }

        public ICell CurrentCell { get; set; }

        public IMoveHandler MoveHandler { get; private set; }

        public int LabyrinthSize { get; private set; }

        public Labyrinth(IFactory factory, IMoveHandler moveHandler, int labyrinthSize)
        {
            this.factory = factory;
            this.MoveHandler = moveHandler;
            this.LabyrinthSize = labyrinthSize;
            this.labyrinthStartCol = this.LabyrinthSize / 2;
            this.labyrintStartRow = this.LabyrinthSize / 2;

            this.Matrix = factory.GetICellMatrixInstance(this.LabyrinthSize);
            GenerateLabyrinth();
            this.CurrentCell = this.Matrix[labyrintStartRow, labyrintStartRow];
        }
        public Labyrinth(IFactory factory, IMoveHandler moveHandler)
            : this(factory, moveHandler, DEFAULT_SIZE)
        {
        }

        /// <summary>
        /// Generating the labyrinth for the game
        /// </summary>
        private void GenerateLabyrinth()
        {
            Random rand = new Random();

            bool exitPathExists = false;
            while (!exitPathExists)
            {
                for (int row = 0; row < this.LabyrinthSize; row++)
                {
                    for (int col = 0; col < this.LabyrinthSize; col++)
                    {
                        int cellRandomValue = rand.Next(0, 2);

                        CellState state = CellState.Wall;
                        if (cellRandomValue == 0)
                        {
                            state = CellState.Empty;
                        }
                        this.Matrix[row, col] = this.factory.GetCellInstance(row, col, state);
                    }
                }
                exitPathExists = ExitPathExists();
            }

            this.Matrix[labyrintStartRow, labyrinthStartCol].CellValue = CellState.Player;
        }


        /// <summary>
        /// Check if the generated labyrinth has an exit or not
        /// </summary>
        private bool ExitPathExists()
        {
            Queue<ICell> cellsOrder = new Queue<ICell>();
            ICell startCell = this.Matrix[labyrintStartRow, labyrinthStartCol];
            cellsOrder.Enqueue(startCell);
            HashSet<ICell> visitedCells = new HashSet<ICell>();

            while (cellsOrder.Count > 0)
            {
                ICell currentCell = cellsOrder.Dequeue();
                visitedCells.Add(currentCell);

                if (this.MoveHandler.ExitFound(this, currentCell))
                {
                    return true;
                }

                this.MoveHandler.MoveTo(this, currentCell, Direction.Down, cellsOrder, visitedCells);
                this.MoveHandler.MoveTo(this, currentCell, Direction.Up, cellsOrder, visitedCells);
                this.MoveHandler.MoveTo(this, currentCell, Direction.Left, cellsOrder, visitedCells);
                this.MoveHandler.MoveTo(this, currentCell, Direction.Right, cellsOrder, visitedCells);
            }

            return false;
        }
    }
}
