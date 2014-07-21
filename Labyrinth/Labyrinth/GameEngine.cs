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
        private IConsoleRenderer renderer;
        private IUserInput input;
        private ITable table;
        private ILogger simpleLoggerFileAppender;
       
        
        private IGameConsole gameConsole;
        

        private IGameLogic gameLogic;
        private ILabyrinth labyrinth;
        private IFactory factory;

        private IScene scene;
        private ConsoleRenderableGameConsole gameConsoleGraphic;
        private ConsoleRenderableLabyrinth labyrinthGraphic;
        //private ConsoleRenderableResults tableGraphic;

        public GameEngine(IConsoleRenderer renderer, IUserInput input, IFactory factory, IMoveHandler moveHandler)
        {
            this.input = input;
            this.renderer = renderer;
            this.factory = factory;
            this.labyrinth = this.factory.GetLabyrinthInstance(factory, moveHandler);

            this.table = this.factory.GetTopResultsInstance();
            
            this.table.Changed += (sender, e) =>
            {
                this.factory.GetSerializationManagerInstance().Serialize(sender);
            };
            var fileAppender = this.factory.GetFileAppender("Log.txt");

            this.simpleLoggerFileAppender = this.factory.GetSimpleLogger(fileAppender);

            this.scene = this.factory.GetConsoleScene(this.renderer);
            this.gameConsole = new GameConsole(this.factory.GetLanguageStringsInstance());//TODO: use factory
            this.gameConsoleGraphic = new ConsoleRenderableGameConsole(this.gameConsole, new IntPoint(0, 11), this.renderer, 11);//TODO: use factory
            this.labyrinthGraphic = this.factory.GetLabyrinthGraphic(this.labyrinth, new IntPoint(0, 0), this.renderer);

            this.gameLogic = factory.GetGameLogic(this.labyrinth, this.gameConsole, this.scene, this.table, this.input,this.factory);
        }

        public GameEngine()
            : this(new ConsoleRenderer(), new UserInputAndOutput(),new Factory(), new MoveHandler())
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
