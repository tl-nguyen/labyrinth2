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

    public class ConsoleRenderableLabyrinth : ConsoleRenderableEntity, IRenderable
    {
        private const char EMPTY_CELL = '-';
        private const char WALL_CELL = 'X';
        private const char PLAYER_CELL = '*';

        private ILabyrinth labyrinth;

        public ConsoleRenderableLabyrinth(IntPoint coords, IRenderer renderer, ILabyrinth labyrinth)
            : base(labyrinth, coords, renderer)
        {
            this.labyrinth = labyrinth;
            this.Graphic = this.GenerateStringGraphic();
        }

        override protected string GenerateStringGraphic()
        {
            StringBuilder sb = new StringBuilder();

            int labyrinthSize = this.labyrinth.LabyrinthSize;
            for (int row = 0; row < labyrinthSize; row++)
            {
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
                sb.AppendLine();
            }

            return sb.ToString();
        }
    }
}
