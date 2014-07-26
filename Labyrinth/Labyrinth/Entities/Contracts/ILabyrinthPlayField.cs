namespace Labyrinth.Entities.Contracts
{
    using LabyrinthHandler.Contracts;

    public interface ILabyrinthPlayField : IEntity
    {
        ICell[,] Matrix { get; set; }

        ICell CurrentCell { get; set; }

        IMoveHandler MoveHandler { get; }

        int LabyrinthSize { get; }

        /// <summary>
        /// Generating the labyrinth for the game
        /// </summary>
        void GenerateLabyrinth();
    }
}