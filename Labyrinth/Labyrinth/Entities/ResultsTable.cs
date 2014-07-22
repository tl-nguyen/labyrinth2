namespace Labyrinth.Entities
{
    using Contracts;
    using Results.Contracts;

    public class ResultsTable : Entity, IResultsTable
    {
        public ITable Table { get; private set; }

        public ResultsTable(ITable table)
        {
            this.Table = table;
        }
    }
}