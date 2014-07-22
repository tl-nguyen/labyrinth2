namespace Labyrinth.Entities.Contracts
{
    using Results.Contracts;

    public interface IResultsTable : IEntity
    {
        ITable Table { get; }
    }
}