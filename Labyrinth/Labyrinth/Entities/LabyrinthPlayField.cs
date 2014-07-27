namespace Labyrinth.Entities
{
    using System;
    using System.Collections.Generic;
    using Commons;
    using Entities.Contracts;
    using LabyrinthHandler.Contracts;

    /// <summary>
    /// Class representation of a single level(labyrinth) of the game
    /// </summary>
    public class LabyrinthPlayField : Entity, ILabyrinthPlayField
    {
        /// <summary>
        /// Default field size.
        /// </summary>
        private const int DefaultSize = 10;

        /// <summary>
        /// Labyrinth start row.
        /// </summary>
        private readonly int labyrintStartRow;

        /// <summary>
        /// Labyrinth end column.
        /// </summary>
        private readonly int labyrinthStartCol;

        /// <summary>
        /// Current cell.
        /// </summary>
        private ICell currentCell;

        /// <summary>
        /// Factory for the game.
        /// </summary>
        private IFactory factory;

        /// <summary>
        /// Initializes a new instance of the <see cref="LabyrinthPlayField" /> class
        /// </summary>
        /// <param name="factory">The factory that is used to produce object in labyrinth</param>
        /// <param name="moveHandler">The move behavior of labyrinth</param>
        /// <param name="labyrinthSize">Labyrinth size</param>
        public LabyrinthPlayField(IFactory factory, IMoveHandler moveHandler, int labyrinthSize)
        {
            this.factory = factory;
            this.MoveHandler = moveHandler;
            this.LabyrinthSize = labyrinthSize;
            this.labyrintStartRow = this.LabyrinthSize / 2;
            this.labyrinthStartCol = this.LabyrinthSize / 2;

            this.Matrix = factory.GetICellMatrixInstance(this.LabyrinthSize);
            this.GenerateLabyrinth();
            this.CurrentCell = this.Matrix[this.labyrintStartRow, this.labyrinthStartCol];
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LabyrinthPlayField" /> class
        /// </summary>
        /// <param name="factory">The factory that is used to produce object in labyrinth</param>
        /// <param name="moveHandler">The move behavior of labyrinth</param>
        public LabyrinthPlayField(IFactory factory, IMoveHandler moveHandler)
            : this(factory, moveHandler, DefaultSize)
        {
        }

        /// <summary>
        /// Gets or sets matrix which contains all the labyrinth cells
        /// </summary>
        public ICell[,] Matrix { get; set; }

        /// <summary>
        /// Gets Labyrinth Move Behavior
        /// </summary>
        public IMoveHandler MoveHandler { get; private set; }

        /// <summary>
        /// Gets Labyrinth Size
        /// </summary>
        public int LabyrinthSize { get; private set; }

        /// <summary>
        /// Gets or sets Labyrinth Current cell, where the cursor is
        /// </summary>
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

                        this.Matrix[row, col] = this.factory.GetICellInstance(row, col, state);
                    }
                }

                exitPathExists = this.ExitPathExists();
            }

            this.Matrix[this.labyrintStartRow, this.labyrinthStartCol].CellValue = CellState.Player;
            this.CurrentCell = this.Matrix[this.labyrintStartRow, this.labyrinthStartCol];
        }

        /// <summary>
        /// Check if the generated labyrinth has an exit or not
        /// </summary>
        /// <returns>True if it has, false if it hasn't</returns>
        private bool ExitPathExists()
        {
            Queue<ICell> cellsOrder = new Queue<ICell>();
            ICell startCell = this.Matrix[this.labyrintStartRow, this.labyrinthStartCol];
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