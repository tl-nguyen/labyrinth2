// ********************************
// <copyright file="GameStart.cs" company="Telerik Academy">
// Copyright (c) 2014 Telerik Academy. All rights reserved.
// </copyright>
//
// ********************************
namespace Labyrinth
{
    /// <summary>
    /// Entry point of the program.
    /// </summary>
    public class GameStart
    {
        private const int GameScreenCols = 80;
        private const int GameScreenRows = 30;

        /// <summary>
        /// Entry method of the program.
        /// </summary>
        public static void Main()
        {
            GameEngine game = new GameEngine(GameScreenCols, GameScreenRows);
            game.Run();
        }
    }
}