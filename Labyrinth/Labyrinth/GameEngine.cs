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
        
        private ITable table;
        private ILogger simpleLoggerFileAppender;
        private IGameConsole gameConsole;
        private IGameLogic gameLogic;
        private ILabyrinth labyrinth;
        

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
            this.table = this.factory.GetTopResultsInstance();
            
            this.table.Changed += (sender, e) =>
            {
                this.factory.GetSerializationManagerInstance().Serialize(sender);
            };
            var fileAppender = this.factory.GetFileAppender("Log.txt");

            this.simpleLoggerFileAppender = this.factory.GetSimpleLogger(fileAppender);

            this.consoleGraphicFactory = this.factory.GetConsoleGraphicFactory();
            this.renderer = this.consoleGraphicFactory.GetConsoleRenderer();
            this.scene = this.factory.GetConsoleScene(this.renderer);

            this.gameConsoleGraphic = this.consoleGraphicFactory.GetGameConsoleGraphic(this.gameConsole, 
                this.consoleGraphicFactory.GetCoordinates(0, 15), this.renderer);
            this.labyrinthGraphic = this.consoleGraphicFactory.GetLabyrinthConsoleGraphic(this.labyrinth,
                this.consoleGraphicFactory.GetCoordinates(0, 0), this.renderer);


            this.gameLogic = factory.GetGameLogic(this.labyrinth, this.gameConsole, this.scene, this.table, this.input,this.factory);
        }

        public GameEngine()
            : this(new UserInputAndOutput(),new Factory(), new MoveHandler())
        {
        }

        public void Run()
        {
            this.Init();

            int movesCount = 0;

            while (!this.gameLogic.IsGameOver)
            {
                this.GameLoop(ref movesCount);
            }
            Console.WriteLine();
        }

        private void GameLoop(ref int movesCount)
        {
            this.UpdateUserInput(ref movesCount);
            this.scene.Render();
        }

        private void Init()
        {
            this.scene.Add(this.labyrinthGraphic);
            this.scene.Add(this.gameConsoleGraphic);
            this.gameConsole.AddInput("Welcome");
            this.gameConsole.AddInput("Input");
            scene.Render();
        }

        private void UpdateUserInput(ref int movesCount)
        {
            Command input = Command.InvalidInput;

            input = this.input.GetInput();
            this.gameLogic.ProcessInput(input, ref movesCount);
        }
    }
}
