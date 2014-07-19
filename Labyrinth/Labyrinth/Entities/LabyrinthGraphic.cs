using System;
using System.Text;
using Labyrinth.Renderer.Contracts;
using Labyrinth.Commons;
using Labyrinth.Entities.Contracts;
using Labyrinth.LabyrinthHandler;
using Labyrinth.LabyrinthHandler.Contracts;

namespace Labyrinth.Entities
{
    public class LabyrinthGraphic : Entity, IRenderable
    {
        private const char EMPTY_CELL = '-';
        private const char WALL_CELL = 'X';
        private const char PLAYER_CELL = '*';

        private IRenderer renderer;
        private ILabyrinth labyrinth;

        public LabyrinthGraphic(IntPoint coords, IRenderer renderer, ILabyrinth labyrinth)
            : base(coords)
        {
            this.renderer = renderer;
            this.labyrinth = labyrinth;
        }

        override public void Render()
        {
            this.renderer.RenderEntity(this);
        }

        public override string ToString()
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
