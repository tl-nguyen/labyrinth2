// ********************************
// <copyright file="IConsoleGraphicFactory.cs" company="Telerik Academy">
// Copyright (c) 2014 Telerik Academy. All rights reserved.
// </copyright>
//
// ********************************
namespace Labyrinth.UI.Contracts
{
    
    using Commons;
    using Entities.Contracts;
    using Renderer.Contracts;
    using UI;

    public interface IConsoleGraphicFactory
    {
        IntPoint GetCoordinates(int x, int y);

        IConsoleRenderer GetConsoleRenderer();

        IScene GetConsoleScene(IConsoleRenderer consoleRenderer);

        IRenderable GetLabyrinthConsoleGraphic(ILabyrinthPlayField labyrinth, IntPoint coords, IRenderer renderer);

        IRenderable GetResultsTableConsoleGraphic(IResultsTable table, IntPoint coords, IRenderer renderer);

        IRenderable GetGameConsoleGraphic(IGameConsole gameConsole, IntPoint coords, IRenderer renderer);
    }
}
