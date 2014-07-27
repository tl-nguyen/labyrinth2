namespace Labyrinth.UI
{
    using System.Text;
    using Commons;
    using Entities.Contracts;
    using Renderer.Contracts;

    /// <summary>
    /// Class for console graphic of the top results table.
    /// </summary>
    public class ResultsTableConsoleGraphic : EntityConsoleGraphic
    {
        /// <summary>
        /// Width of the results table.
        /// </summary>
        private const int Width = 35;

        /// <summary>
        /// Horizontal line literal.
        /// </summary>
        private const string HorizontalLine = "|----------------------------------|";

        /// <summary>
        /// Results table title.
        /// </summary>
        private const string Title = "|         Top Results Table        |";

        /// <summary>
        /// Empty results table literal.
        /// </summary>
        private const string TableIsEmpty = "|     The scoreboard is empty.     |";

        /// <summary>
        /// Results table.
        /// </summary>
        private IResultsTable table;

        /// <summary>
        /// Initializes a new instance of the <see cref="ResultsTableConsoleGraphic"/> class.
        /// </summary>
        /// <param name="table">Results table.</param>
        /// <param name="coords">Coordinates of the results table.</param>
        /// <param name="renderer">Renderer for the results table.</param>
        public ResultsTableConsoleGraphic(IResultsTable table, IntPoint coords, IRenderer renderer)
            : base(table, coords, renderer)
        {
            this.table = table;
            this.Graphic = this.GenerateStringGraphic();
        }

        /// <summary>
        /// Generates console graphic of the results table.
        /// </summary>
        /// <returns>String array with the graphic of the results table.</returns>
        protected override string[] GenerateStringGraphic()
        {
            string[] results = this.table.Table.GetTopResultsStrings();
            int resultsCount = results.Length;
            bool tableIsEmpty = resultsCount == 0;

            int extraLines = 4;
            if (tableIsEmpty)
            {
                extraLines++; // one more line for "table is empty" message
            }

            string[] graphic = new string[resultsCount + extraLines];
            int currentLine = 0;

            graphic[currentLine] = ResultsTableConsoleGraphic.HorizontalLine;
            currentLine++;
            graphic[currentLine] = ResultsTableConsoleGraphic.Title;
            currentLine++;
            graphic[currentLine] = ResultsTableConsoleGraphic.HorizontalLine;
            currentLine++;

            if (tableIsEmpty)
            {
                graphic[currentLine] = ResultsTableConsoleGraphic.TableIsEmpty;
                currentLine++;
            }
            else
            {
                for (int i = 0; i < resultsCount; i++)
                {
                    graphic[currentLine] = string.Format("| {0}. {1}", i + 1, results[i]);
                    currentLine++;
                }
            }

            graphic[currentLine] = ResultsTableConsoleGraphic.HorizontalLine;

            return graphic;
        }
    }
}
