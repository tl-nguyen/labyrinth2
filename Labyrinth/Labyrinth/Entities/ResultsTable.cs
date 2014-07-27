namespace Labyrinth.Entities
{
    using Contracts;
    using Results.Contracts;

    /// <summary>
    /// Class for creating results table for rendering.
    /// </summary>
    public class ResultsTable : Entity, IResultsTable
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ResultsTable"/> class.
        /// </summary>
        /// <param name="table">Results table instance.</param>
        public ResultsTable(ITable table)
        {
            this.Table = table;
        }

        /// <summary>
        /// Gets the results table.
        /// </summary>
        public ITable Table { get; private set; }
    }
}