namespace Labyrinth.Tests.UI
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Labyrinth.UI;
    using Labyrinth.Commons;
    using Labyrinth.Renderer.Contracts;
    using Labyrinth.Renderer;
    using Labyrinth.UI.Contracts;
    using Labyrinth.UI;
    using Labyrinth.Entities.Contracts;
    using Labyrinth.Entities;
    using Labyrinth.LabyrinthHandler.Contracts;
    using Labyrinth.LabyrinthHandler;
    using Labyrinth.Results.Contracts;
    using Labyrinth.Results;

    [TestClass]
    public class ConsoleGraphicFactoryTests
    {
        ConsoleGraphicFactory testConsoleGraphicFactory = new ConsoleGraphicFactory();

        [TestMethod]
        public void TestIntPointInstance()
        {
            int x = 5;
            int y = 5;
            IntPoint testIntPoint = new IntPoint(x, y);
            IntPoint factoryIntPoint = testConsoleGraphicFactory.GetCoordinates(x, y);
            Object.Equals(testIntPoint, factoryIntPoint);
        }

        [TestMethod]
        public void TestConsoleRendererInstance()
        {
            IConsoleRenderer testConsRenderer = new ConsoleRenderer();
            IConsoleRenderer factoryConsRenderer = testConsoleGraphicFactory.GetConsoleRenderer();
            Object.Equals(testConsRenderer, factoryConsRenderer);
        }

        [TestMethod]
        public void TestConsoleSceneInstance()
        {

            IConsoleRenderer testConsRenderer = new ConsoleRenderer();
            IScene testConsScene = new ConsoleScene(testConsRenderer);
            IScene factoryConsScene = testConsoleGraphicFactory.GetConsoleScene(testConsRenderer);
            Object.Equals(testConsScene, factoryConsScene);
        }

        [TestMethod]
        public void TestLabyrinthConsoleGraphicInstance()
        {
            IFactory testFactory = new Factory();
            IMoveHandler testHandler = new MoveHandler();
            ILabyrinthPlayField testLabyrinth = new LabyrinthPlayField(testFactory, testHandler);
            IntPoint testCoords = new IntPoint(5, 5);
            IRenderer testRenderer = new ConsoleRenderer();

            IRenderable testLabConsGraphic = new LabyrinthConsoleGraphic(testLabyrinth, testCoords, testRenderer);
            IRenderable factoryLabConsGraphic = testConsoleGraphicFactory.GetLabyrinthConsoleGraphic(testLabyrinth, testCoords, testRenderer);
            Object.Equals(testLabConsGraphic, factoryLabConsGraphic);
        }

        [TestMethod]
        public void TestResultsTableConsoleGraphicInstance()
        {
            ITable testTopResults = new TopResults();
            IResultsTable testResultsTable = new ResultsTable(testTopResults);
            IntPoint testCoords = new IntPoint(5, 5);
            IRenderer testRenderer = new ConsoleRenderer();

            IRenderable testResultsTableConsGraphic = new ResultsTableConsoleGraphic(testResultsTable, testCoords, testRenderer);
            IRenderable factoryResultsTableConsGraphic = testConsoleGraphicFactory.GetResultsTableConsoleGraphic(testResultsTable, testCoords, testRenderer);
            Object.Equals(testResultsTableConsGraphic, factoryResultsTableConsGraphic);
        }

        [TestMethod]
        public void TestGameConsoleConsoleGraphicInstance()
        {
            ILanguageStrings testDialogList = new LanguageStrings();
            IGameConsole testGameConsole = new GameConsole(testDialogList);
            IntPoint testCoords = new IntPoint(5, 5);
            IRenderer testRenderer = new ConsoleRenderer();

            IRenderable testGameConsoleConsoleGraphic = new GameConsoleConsoleGraphic(testGameConsole, testCoords, testRenderer);
            IRenderable factoryGameConsoleConsoleGraphic = testConsoleGraphicFactory.GetGameConsoleGraphic(testGameConsole, testCoords, testRenderer);
            Object.Equals(testGameConsoleConsoleGraphic, factoryGameConsoleConsoleGraphic);
        }
    }
}