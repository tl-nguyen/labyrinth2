namespace Labyrinth.Entities.Contracts
{
    using Labyrinth.Commons;

    /// <summary>
    /// Interface for console game.
    /// </summary>
    public interface IGameConsole : IEntity
    {
        /// <summary>
        /// Adds a string to the input with arguments.
        /// </summary>
        /// <param name="key">Dialog key for the current input.</param>
        /// <param name="args">String array of formatting arguments.</param>
        void AddInput(Dialog key, string[] args);

        /// <summary>
        /// Adds a string to the input without arguments.
        /// </summary>
        /// <param name="key">Dialog key for the current input.</param>
        void AddInput(Dialog key);

        /// <summary>
        /// Gets the lines for the dialog.
        /// </summary>
        /// <param name="numberOfLines">Number of lines.</param>
        /// <returns>String array of the lines.</returns>
        string[] GetLastLines(int numberOfLines);
    }
}