namespace Labyrinth.UI
{
    using Entities.Contracts;
    using Commons;
    using Renderer.Contracts;
    using System.Text;

    public class ResultsTableConsoleGraphic : EntityConsoleGraphic
    {
        private const string HORIZONTAL_LINE = "|----------------------------------|";
        private const string TITLE = "|         Top Results Table        |";
        private const string TABLE_IS_EMPTY = "|     The scoreboard is empty.     |";

        private IResultsTable table;

        public ResultsTableConsoleGraphic(IResultsTable table, IntPoint coords, IRenderer renderer)
            : base(table, coords, renderer)
        {
            this.table = table;
            this.Graphic = this.GenerateStringGraphic();
        }

        override protected string GenerateStringGraphic()
        {
            StringBuilder sb = new StringBuilder();
            string[] results = this.table.Table.GetTopResultsStrings();

            sb.AppendLine(ResultsTableConsoleGraphic.HORIZONTAL_LINE);
            sb.AppendLine(ResultsTableConsoleGraphic.TITLE);
            sb.AppendLine(ResultsTableConsoleGraphic.HORIZONTAL_LINE);

            int resultsCount = results.Length;
            for (int i = 0; i < resultsCount; i++)
            {
                sb.AppendFormat("| {0}. {1} |", i + 1, results[i]);
                sb.AppendLine();
            }
            if (resultsCount == 0)
            {
                sb.AppendLine(ResultsTableConsoleGraphic.TABLE_IS_EMPTY);
            }
            sb.AppendLine(ResultsTableConsoleGraphic.HORIZONTAL_LINE);

            string output = sb.ToString();
            return output;
        }
    }
}
