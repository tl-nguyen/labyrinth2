namespace Labyrinth
{
    public interface IPlayer  
    {
        /// <summary>
        /// Checks if a move can be done using the parent's method TryMove
        /// </summary>
        /// <param name="direction">Current user input direction</param>
        /// <returns>True if a move can be made, false if not</returns>
        bool MoveAction(Command direction);

        ILabyrinthMoveHandler Labyrinth { get; }
    }
}