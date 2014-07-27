namespace Labyrinth.UI
{
    using System;
    using System.Text;
    using Commons;
    using Entities.Contracts;
    using LabyrinthHandler;
    using LabyrinthHandler.Contracts;
    using Renderer.Contracts;
    using UI.Contracts;

    /// <summary>
    /// Class for console graphic of the labyrinth.
    /// </summary>
    public class LabyrinthConsoleGraphic : EntityConsoleGraphic
    {
        /// <summary>
        /// Labyrinth empty cell symbol.
        /// </summary>
        private const char EmptyCell = '-';

        /// <summary>
        /// Labyrinth wall cell symbol.
        /// </summary>
        private const char WallCell = 'X';

        /// <summary>
        /// Labyrinth player cell symbol.
        /// </summary>
        private const char PlayerCell = '*';

        /// <summary>
        /// Labyrinth for console graphic.
        /// </summary>
        private ILabyrinthPlayField labyrinth;

        /// <summary>
        /// Initializes a new instance of the <see cref="LabyrinthConsoleGraphic"/> class.
        /// </summary>
        /// <param name="labyrinth">Labyrinth for the graphic.</param>
        /// <param name="coords">Console graphic coordinates.</param>
        /// <param name="renderer">Renderer of the console graphic.</param>
        public LabyrinthConsoleGraphic(ILabyrinthPlayField labyrinth, IntPoint coords, IRenderer renderer)
            : base(labyrinth, coords, renderer)
        {
            this.labyrinth = labyrinth;
            this.Graphic = this.GenerateStringGraphic();
        }

        /// <summary>
        /// Generates a console graphic of the labyrinth.
        /// </summary>
        /// <returns>String array with the graphic.</returns>
        protected override string[] GenerateStringGraphic()
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
                            sb.Append(EmptyCell + " ");
                            break;
                        case CellState.Wall:
                            sb.Append(WallCell + " ");
                            break;
                        case CellState.Player:
                            sb.Append(PlayerCell + " ");
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
