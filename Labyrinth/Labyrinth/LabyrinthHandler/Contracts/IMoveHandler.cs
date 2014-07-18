namespace Labyrinth.LabyrinthHandler.Contracts
{
    using Commons;

    public interface IMoveHandler
    {
        bool TryMove(ICell currentCell, Direction direction);
    }
}
