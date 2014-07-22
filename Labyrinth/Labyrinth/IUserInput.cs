namespace Labyrinth
{
    using Commons;

    /// <summary>
    /// Interface that provides abstraction for receiving commands from the User
    /// </summary>
    public interface IUserInput
    {
        /// <summary>
        /// Gets the user input, and returns it as a Command
        /// </summary>
        /// <returns>Command</returns>
        Command GetInput();

        /// <summary>
        /// Gets the player name from the user
        /// </summary>
        /// <returns>the player name as a string</returns>
        string GetPlayerName();
    }
}