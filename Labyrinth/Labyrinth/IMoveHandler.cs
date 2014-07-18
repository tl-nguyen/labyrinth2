namespace Labyrinth
{
    using Commons;

    public interface IMoveHandler
    {
        bool TryMove(ICell currentCell, Direction direction);
    }
}
