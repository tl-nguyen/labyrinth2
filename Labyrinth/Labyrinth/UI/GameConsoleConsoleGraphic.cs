// ********************************
// <copyright file="GameConsoleConsoleGraphic.cs" company="Telerik Academy">
// Copyright (c) 2014 Telerik Academy. All rights reserved.
// </copyright>
//
// ********************************
namespace Labyrinth.UI
{
    using System.Text;
    using Commons;
    using Entities.Contracts;
    using Renderer.Contracts;

    public class GameConsoleConsoleGraphic : EntityConsoleGraphic
    {
        private const int DEFAULT_VISIBLE_LINES_COUNT = 10;

        private IGameConsole gameConsole;
        private int visibleLinesCount;

        public GameConsoleConsoleGraphic(IGameConsole gameConsole, IntPoint coords, IRenderer renderer, int visibleLines)
            : base(gameConsole, coords, renderer)
        {
            this.gameConsole = gameConsole;
            this.visibleLinesCount = visibleLines;
        }
        public GameConsoleConsoleGraphic(IGameConsole gameConsole, IntPoint coords, IRenderer renderer)
            : this (gameConsole, coords, renderer, DEFAULT_VISIBLE_LINES_COUNT)
        {
        }

        override protected string[] GenerateStringGraphic()
        {
            int linesCount = this.visibleLinesCount;
            string[] graphic = this.gameConsole.GetLastLines(linesCount);
            return graphic;
        }
    }
}
