namespace Labyrinth.Tests.LabyrinthHandler
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Labyrinth.Entities;
    using Labyrinth.Entities.Contracts;
    using Labyrinth.Commons;

    class MockLabyrinth : Entity, ILabyrinthPlayField
    {
        public ICell[,] Matrix { get; set; }

        public ICell CurrentCell { get; set; }

        public MockLabyrinth()
        {
            GenerateLabyrinth();
        }

        public Labyrinth.LabyrinthHandler.Contracts.IMoveHandler MoveHandler
        {
            get { throw new NotImplementedException(); }
        }

        public int LabyrinthSize { get; set; }

        public void GenerateLabyrinth()
        {
            this.LabyrinthSize = 3;
            this.CurrentCell = new Cell(1, 1, CellState.Player);

            this.Matrix = new ICell[3, 3];

            for (var i = 0; i < this.Matrix.GetLength(0); i++)
            {
                for (var j = 0; j < this.Matrix.GetLength(1); j++)
                {
                    this.Matrix[i, j] = new Cell(i, j, CellState.Empty);
                }
            }

            this.Matrix[1, 1].CellValue = CellState.Player;
            this.Matrix[2, 1].CellValue = CellState.Wall;
        }
    }
}
