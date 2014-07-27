// ********************************
// <copyright file="ConsoleGraphicFactory.cs" company="Telerik Academy">
// Copyright (c) 2014 Telerik Academy. All rights reserved.
// </copyright>
//
// ********************************
namespace Labyrinth.UI
{
    using Contracts;
    using Commons;
    using Entities.Contracts;
    using Renderer.Contracts;
    using Renderer;

    public class ConsoleGraphicFactory : IConsoleGraphicFactory
    {
        public IntPoint GetCoordinates(int x, int y)
        {
            return new IntPoint(x, y);
        }

        public IConsoleRenderer GetConsoleRenderer()
        {
            return new ConsoleRenderer();
        }

        public IScene GetConsoleScene(Renderer.Contracts.IConsoleRenderer consoleRenderer)
        {
            return new ConsoleScene(consoleRenderer);
        }

        public IRenderable GetLabyrinthConsoleGraphic(ILabyrinthPlayField labyrinth, IntPoint coords, IRenderer renderer)
        {
            return new LabyrinthConsoleGraphic(labyrinth, coords, renderer);
        }

        public IRenderable GetResultsTableConsoleGraphic(IResultsTable table, IntPoint coords, IRenderer renderer)
        {
            return new ResultsTableConsoleGraphic(table, coords, renderer);
        }

        public IRenderable GetGameConsoleGraphic(IGameConsole gameConsole, IntPoint coords, IRenderer renderer)
        {
            return new GameConsoleConsoleGraphic(gameConsole, coords, renderer);
        }
    }
}
