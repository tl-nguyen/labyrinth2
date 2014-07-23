namespace Labyrinth.Entities
{
    using Commons;
    using Entities.Contracts;
    using LabyrinthHandler.Contracts;
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Class representation of a single level(labyrinth) of the game
    /// </summary>
    public class LabyrinthPlayField : Entity, ILabyrinth
    {
        private const int DEFAULT_SIZE = 10;
        private readonly int labyrintStartRow;
        private readonly int labyrinthStartCol;
        private ICell currentCell;
        private IFactory factory;

        public ICell[,] Matrix { get; set; }

        public ICell CurrentCell
        {
            get
            {
                return this.currentCell;
            }
            set
            {
                if (value.Row < 0 || value.Row >= this.LabyrinthSize ||
                    value.Col < 0 || value.Col >= this.LabyrinthSize)
                {
                    throw new ArgumentOutOfRangeException("The size must be between 0 and " + this.LabyrinthSize);
                }

                this.currentCell = value;
            }
        }

        public IMoveHandler MoveHandler { get; private set; }

        public int LabyrinthSize { get; private set; }

        public LabyrinthPlayField(IFactory factory, IMoveHandler moveHandler, int labyrinthSize)
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

        public LabyrinthPlayField(IFactory factory, IMoveHandler moveHandler)
            : this(factory, moveHandler, DEFAULT_SIZE)
        {
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
            this.CurrentCell = this.Matrix[labyrintStartRow, labyrinthStartCol];
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