// ********************************
// <copyright file="UserInputConsole.cs" company="Telerik Academy">
// Copyright (c) 2014 Telerik Academy. All rights reserved.
// </copyright>
//
// ********************************
namespace Labyrinth
{
    using Commons;
    using System;

    /// <summary>
    /// Concrete implimentation of IUserInput that receives commands from the console, and returns them as an enumeration ( or string )
    /// </summary>
    public class UserInputConsole : IUserInput
    {
        /// <summary>
        /// Gets the user input, and returns it as a Command
        /// </summary>
        /// <returns>Command</returns>
        public Command GetInput()
        {
            var inputLine = Console.ReadKey();
            //inputLine = inputLine.Trim().ToLower();
            switch (inputLine.KeyChar)
            {
                case 'w': return Command.Up;
                case 's': return Command.Down;
                case 'd': return Command.Right;
                case 'a': return Command.Left;
                case 'r': return Command.Restart;
                case 'e': return Command.Exit;
                case 't': return Command.Top;
                default:
                    return Command.InvalidInput;
            }
        }

        /// <summary>
        /// Gets the player name from the user
        /// </summary>
        /// <returns>the player name as a string</returns>
        public string GetPlayerName()
        {
            string inputLine = Console.ReadLine();
            return inputLine.Trim();
        }
    }
}