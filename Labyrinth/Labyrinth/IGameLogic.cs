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
        /// Receives a Command, processes it and updates the game entities accordingly
        /// </summary>
        void Update();

        /// <summary>
        /// Is set to false normally, sets to true if a game ending condition is reached.
        /// </summary>
        bool Exit { get; }
    }
}
