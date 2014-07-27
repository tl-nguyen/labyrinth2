namespace Labyrinth.Entities.Contracts
{
    using Results.Contracts;

    /// <summary>
    /// Interface for results table.
    /// </summary>
    public interface IResultsTable : IEntity
    {
        /// <summary>
        /// Gets the results table.
        /// </summary>
        ITable Table { get; }
    }
}