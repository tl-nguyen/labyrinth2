namespace Labyrinth
{
    using Loggers;
    using System;
    using System.Collections.Generic;
    using Entities.LabyrinthHandler;
    using Results.Contracts;
    using Loggers.Contracts;
    using Commons;
    using Renderer;
    using Renderer.Contracts;
    using UI.Contracts;
    using UI;
    using Entities.LabyrinthHandler.Contracts;

    /// <summary>
    /// Class that gives the game objects to different modules, and transfers commands from one class to another, allowing them to be detached.
    /// </summary>
    public class GameEngine
    {
        private IConsoleRenderer renderer;
        private IUserInput input;
        private ITable table;
        private ILogger simpleLoggerFileAppender;
       
        private IScene scene;
        private IUiText topMessageBox;
        private IUiText bottomMessageBox;
        private ConsoleRenderableLabyrinth labyrinthGraphic;

        private IGameLogic gameLogic;
        private ILabyrinth labyrinth;
        private IFactory factory;

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
            this.topMessageBox = this.factory.GetUiText(new IntPoint(0, 0), this.renderer);

            this.bottomMessageBox = this.factory.GetUiText(new IntPoint(0, 20), this.renderer);

            this.labyrinthGraphic = this.factory.GetLabyrinthGraphic(new IntPoint(0, 9), this.renderer, this.labyrinth);

            this.gameLogic = factory.GetGameLogic(this.labyrinth, this.topMessageBox, this.bottomMessageBox, 
                this.scene, this.table, this.input,this.factory);
            //TODO: 1 more layer of abstraction renderable entity : entity logic
            //TODO: UI Controller
            //TODO: Bottom messages as console
        }

        public GameEngine()
            : this(new ConsoleRenderer(), new UserInputAndOutput(),new Factory(), new MoveHandler())
        {
        }

        public void Run()
        {
            this.Init();

            int movesCount = 0;

            //test
            GameConsole testConsole = new GameConsole(this.factory.GetLanguageStringsInstance());
            testConsole.AddInput("WelcomeV2");

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
            this.scene.Add(this.topMessageBox);
            this.scene.Add(this.bottomMessageBox);
            this.topMessageBox.SetText("Welcome", true);
            this.bottomMessageBox.SetText("Input", true);
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
