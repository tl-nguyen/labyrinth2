namespace Labyrinth
{
    using Results.Contracts;

    public interface IResultFactory
    {
        /// <summary>
        /// Gets the correct instance of the class implementing <see cref="IResult"/> interface.
        /// </summary>
        /// <returns>The correct instance of the class implementing <see cref="IResult"/> interface</returns>
        IResult GetResultInstance(int movesCount, string playerName);
    }
}
