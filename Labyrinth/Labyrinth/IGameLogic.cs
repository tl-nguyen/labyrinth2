namespace Labyrinth
{
    using Commons;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Interface that handles input, and changes game objects
    /// </summary>
    public interface IGameLogic
    {
        /// <summary>
        /// Receives a Command, processes it, making modifications to the game objects, and sets IsGameOver
        /// </summary>
        void ProcessInput(Command command, ref int movesCount);

        /// <summary>
        /// Is set to false normally, sets to true if a game ending condition is reached.
        /// </summary>
        bool IsGameOver { get; }
    }
}
