namespace Labyrinth
{
    public interface IMoveHandler
    {
        bool TryMove(ICell currentCell, Direction direction);
    }
}
