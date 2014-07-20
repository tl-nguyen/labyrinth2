using System;
using System.Text;
using Labyrinth.Renderer.Contracts;
using Labyrinth.Commons;
using Labyrinth.UI.Contracts;
using Labyrinth.LabyrinthHandler;
using Labyrinth.LabyrinthHandler.Contracts;

namespace Labyrinth.UI
{
    public class ConsoleRenderableLabyrinth : RenderableEntity, IRenderable
    {
        private const char EMPTY_CELL = '-';
        private const char WALL_CELL = 'X';
        private const char PLAYER_CELL = '*';

        private ILabyrinth labyrinth;

        public ConsoleRenderableLabyrinth(IntPoint coords, IRenderer renderer, ILabyrinth labyrinth)
            : base(coords, renderer)
        {
            this.labyrinth = labyrinth;
            this.Graphic = this.GenerateStringGraphic();
        }

        override public void Render()
        {
            this.UpdateGraphic();
            this.renderer.RenderEntity(this);
        }

        private void UpdateGraphic()
        {
            this.Graphic = this.GenerateStringGraphic();
        }
        private string GenerateStringGraphic()
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
