namespace Labyrinth.Entities.Contracts
{
    using LabyrinthHandler.Contracts;

    /// <summary>
    /// Interface represents the labyrinth play-field
    /// </summary>
    public interface ILabyrinthPlayField : IEntity
    {
        /// <summary>
        /// Gets or sets the matrix of the labyrinth.
        /// </summary>
        ICell[,] Matrix { get; set; }

        /// <summary>
        /// Gets or sets the current cell.
        /// </summary>
        ICell CurrentCell { get; set; }

        /// <summary>
        /// Gets the move handler.
        /// </summary>
        IMoveHandler MoveHandler { get; }

        /// <summary>
        /// Gets the size of the labyrinth.
        /// </summary>
        int LabyrinthSize { get; }

        /// <summary>
        /// Generating the labyrinth for the game
        /// </summary>
        void GenerateLabyrinth();
    }
}