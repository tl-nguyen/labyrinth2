namespace Labyrinth.Tests.LabyrinthHandler
{
    using Labyrinth.Entities;
    using Labyrinth.Entities.Contracts;
    using Labyrinth.Commons;
    using Labyrinth.LabyrinthHandler.Contracts;

    /// <summary>
    /// This class is specially created to test the MoveHandler class
    /// </summary>
    class MockLabyrinth : Entity, ILabyrinthPlayField
    {
        public MockLabyrinth()
        {
            GenerateLabyrinth();
        }

        public ICell[,] Matrix { get; set; }

        public ICell CurrentCell { get; set; }

        public IMoveHandler MoveHandler { get; set; }

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
