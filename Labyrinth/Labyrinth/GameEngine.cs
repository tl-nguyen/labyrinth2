namespace Labyrinth
{
    using Loggers;
    using System;
    using System.Collections.Generic;
    using LabyrinthHandler;
    using Results.Contracts;
    using Loggers.Contracts;
    using Commons;
    using Renderer;
    using Renderer.Contracts;
    using Entities.Contracts;
    using Entities;

    /// <summary>
    /// Class that gives the game objects to different modules, and transfers commands from one class to another, allowing them to be detached.
    /// </summary>
    public class GameEngine
    {
        private IConsoleRenderer renderer;
        private IUserInput input;
        private IPlayer player;
        private ITable table;
        private ILogger simpleLoggerFileAppender;
       
        private IScene scene;
        private IUiText topMessageBox;
        private IUiText bottomMessageBox;
        private LabyrinthGraphic labyrinthGraphic;

        private IGameLogic gameLogic;

        public GameEngine(IConsoleRenderer renderer, IUserInput input)
        {
            this.input = input;
            this.renderer = renderer;
            this.player = LabyrinthFactory.GetPlayerInstance(LabyrinthFactory.GetLabyrinthInstance());
            this.table = LabyrinthFactory.GetTopResultsInstance();
            this.table.Changed += (sender, e) =>
            {
                LabyrinthFactory.GetSerializationManagerInstance().Serialize(sender);
            };

            var fileAppender = LabyrinthFactory.GetFileAppender("Log.txt");
            this.simpleLoggerFileAppender = LabyrinthFactory.GetSimpleLogger(fileAppender);

            this.scene = LabyrinthFactory.GetConsoleScene(this.renderer);
            this.topMessageBox = LabyrinthFactory.GetUiText(new IntPoint(0,0), this.renderer);
            this.bottomMessageBox = LabyrinthFactory.GetUiText(new IntPoint(0, 20), this.renderer);
            this.labyrinthGraphic = LabyrinthFactory.GetLabyrinthGraphic(new IntPoint(0, 9), this.renderer, this.player.Labyrinth.Matrix);

            this.gameLogic = LabyrinthFactory.GetGameLogic(this.player, this.topMessageBox, this.bottomMessageBox, this.labyrinthGraphic, this.scene, this.table, this.input);
            //TODO: labyrinth size refactor
            //TODO: 1 more layer of abstraction renderable entity : entity logic
            //TODO: UI Controller
            //TODO: Bottom messages as console
        }

        public GameEngine()
            : this(new ConsoleRenderer(), LabyrinthFactory.GetUserInputInstance())
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
