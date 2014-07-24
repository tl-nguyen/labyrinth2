namespace Labyrinth.UI
{
    using System;
    using System.Text;
    using Renderer.Contracts;
    using Commons;
    using UI.Contracts;
    using LabyrinthHandler;
    using LabyrinthHandler.Contracts;
    using Entities.Contracts;

    public class LabyrinthConsoleGraphic : EntityConsoleGraphic
    {
        private const char EMPTY_CELL = '-';
        private const char WALL_CELL = 'X';
        private const char PLAYER_CELL = '*';

        private ILabyrinth labyrinth;

        public LabyrinthConsoleGraphic(ILabyrinth labyrinth, IntPoint coords, IRenderer renderer)
            : base(labyrinth, coords, renderer)
        {
            this.labyrinth = labyrinth;
            this.Graphic = this.GenerateStringGraphic();
        }

        override protected string[] GenerateStringGraphic()
        {
            int labyrinthSize = this.labyrinth.LabyrinthSize;
            string[] graphic = new string[labyrinthSize];
            for (int row = 0; row < labyrinthSize; row++)
            {
                StringBuilder sb = new StringBuilder();
                for (int col = 0; col < labyrinthSize; col++)
                {
                    ICell cell = this.labyrinth.Matrix[row, col];
                    switch (cell.CellValue)
                    {
                        case CellState.Empty:
                            sb.Append(EMPTY_CELL + " ");
                            break;
                        case CellState.Wall:
                            sb.Append(WALL_CELL + " ");
                            break;
                        case CellState.Player:
                            sb.Append(PLAYER_CELL + " ");
                            break;
                        default:
                            throw new ArgumentException("invalid cell value");
                    }
                }
                graphic[row] = sb.ToString();
            }
            return graphic;
        }
    }
}
