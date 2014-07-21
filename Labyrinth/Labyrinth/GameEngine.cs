namespace Labyrinth
{
    using Loggers;
    using System;
    using System.Collections.Generic;
    using Results.Contracts;
    using Loggers.Contracts;
    using Commons;
    using Renderer;
    using Renderer.Contracts;
    using UI.Contracts;
    using UI;
    using LabyrinthHandler;
    using LabyrinthHandler.Contracts;
    using Entities;
    using Entities.Contracts;

    /// <summary>
    /// Class that gives the game objects to different modules, and transfers commands from one class to another, allowing them to be detached.
    /// </summary>
    public class GameEngine
    {
        private IFactory factory;
        private IUserInput input;

        private IConsoleRenderer renderer;
        
        private ILogger simpleLoggerFileAppender;
        private IGameConsole gameConsole;
        private IGameLogic gameLogic;
        private ILabyrinth labyrinth;
        private IResultsTable resultsTable;
        

        private IConsoleGraphicFactory consoleGraphicFactory;
        private IScene scene;
        private IRenderable gameConsoleGraphic;
        private IRenderable labyrinthGraphic;
        private IRenderable tableGraphic;

        public GameEngine(IUserInput input, IFactory factory, IMoveHandler moveHandler)
        {
            this.input = input;
            this.factory = factory;
            this.labyrinth = this.factory.GetLabyrinthInstance(factory, moveHandler);
            this.gameConsole = new GameConsole(this.factory.GetLanguageStringsInstance());//TODO: use factory
            this.resultsTable = this.factory.GetTopResultsTableInstance();
            
            this.resultsTable.Table.Changed += (sender, e) =>
            {
                this.factory.GetSerializationManagerInstance().Serialize(sender);
            };
            var fileAppender = this.factory.GetFileAppender("Log.txt");

            this.simpleLoggerFileAppender = this.factory.GetSimpleLogger(fileAppender);

            this.consoleGraphicFactory = this.factory.GetConsoleGraphicFactory();
            this.renderer = this.consoleGraphicFactory.GetConsoleRenderer();
            this.scene = this.factory.GetConsoleScene(this.renderer);

            this.labyrinthGraphic = this.consoleGraphicFactory.GetLabyrinthConsoleGraphic(this.labyrinth,
                this.consoleGraphicFactory.GetCoordinates(0, 1), this.renderer);
            this.gameConsoleGraphic = this.consoleGraphicFactory.GetGameConsoleGraphic(this.gameConsole,
                this.consoleGraphicFactory.GetCoordinates(0, this.labyrinth.LabyrinthSize + 2), this.renderer);
            this.tableGraphic = this.consoleGraphicFactory.GetResultsTableConsoleGraphic(this.resultsTable,
                this.consoleGraphicFactory.GetCoordinates(0, 1), this.renderer);

            this.gameLogic = factory.GetGameLogic(this.labyrinth, this.gameConsole, this.resultsTable, this.input, this.factory);
        }

        public GameEngine()
            : this(new UserInput(),new Factory(), new MoveHandler())
        {
        }

        public void Run()
        {
            this.Init();

            while (!this.gameLogic.Exit)
            {
                this.GameLoop(); ;
            }

            this.ExitApplication();
        }

        private void GameLoop()
        {
            this.gameLogic.Update();
            this.scene.Render();
        }

        private void Init()
        {
            this.resultsTable.Deactivate();
            this.scene.Add(this.labyrinthGraphic);
            this.scene.Add(this.gameConsoleGraphic);
            this.scene.Add(this.tableGraphic);
            this.gameConsole.AddInput("Welcome");
            this.gameConsole.AddInput("Input");
            scene.Render();
        }

        private void ExitApplication()
        {
            if (Console.ReadKey(true) != null)
            {
                Environment.Exit(0);
            }
        }
    }
}
