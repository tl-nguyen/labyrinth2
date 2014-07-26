namespace Labyrinth
{
    using System;
    using Commons;
    using Entities;
    using Entities.Contracts;
    using Loggers.Contracts;
    using Renderer.Contracts;
    using UI.Contracts;

    /// <summary>
    /// Class that gives the game objects to different modules, and transfers commands from one class to another, allowing them to be detached.
    /// </summary>
    public class GameEngine
    {
        private int windowWidth;
        private int windowHeight;

        private IFactory factory;
        private IUserInput input;

        private IConsoleRenderer renderer;

        private ILogger simpleLoggerFileAppender;
        private IGameConsole gameConsole;
        private IGameLogic gameLogic;
        private ILabyrinthPlayField labyrinth;
        private IResultsTable resultsTable;

        private IConsoleGraphicFactory consoleGraphicFactory;
        private IScene scene;
        private IRenderable gameConsoleGraphic;
        private IRenderable labyrinthGraphic;
        private IRenderable tableGraphic;

        /// <summary>
        /// Initializes a new instance of the <see cref="GameEngine"/> class
        /// </summary>
        /// <param name="width">Integer value for the width</param>
        /// <param name="height">Integer value for the height</param>
        /// <param name="factory">A non null instance of <see cref="IFactory"/></param>
        public GameEngine(int width, int height, IFactory factory)
        {
            this.windowWidth = width;
            this.windowHeight = height;
            this.factory = factory;
            this.input = this.factory.GetUserInputInstance();
            this.labyrinth = this.factory.GetLabyrinthInstance(factory, this.factory.GetMoveHandlerInstance());

            // TODO: use factory
            this.gameConsole = new GameConsole(this.factory.GetLanguageStringsInstance());
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

            this.labyrinthGraphic = this.consoleGraphicFactory.GetLabyrinthConsoleGraphic(this.labyrinth, this.consoleGraphicFactory.GetCoordinates(2, 1), this.renderer);
            this.gameConsoleGraphic = this.consoleGraphicFactory.GetGameConsoleGraphic(this.gameConsole, this.consoleGraphicFactory.GetCoordinates(2, this.labyrinth.LabyrinthSize + 2), this.renderer);
            this.tableGraphic = this.consoleGraphicFactory.GetResultsTableConsoleGraphic(this.resultsTable, this.consoleGraphicFactory.GetCoordinates(2, 1), this.renderer);

            this.gameLogic = factory.GetGameLogic(this.labyrinth, this.gameConsole, this.resultsTable, this.input, this.factory);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="GameEngine"/> class
        /// </summary>
        /// <param name="width">Integer value for the width</param>
        /// <param name="height">Integer value for the height</param>
        public GameEngine(int width, int height)
            : this(width, height, new Factory())
        {
        }

        /// <summary>
        /// Starts the game.
        /// </summary>
        public void Run()
        {
            this.Init();

            while (!this.gameLogic.Exit)
            {
                this.GameLoop();
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
            this.renderer.Init(this.windowWidth, this.windowHeight);
            this.resultsTable.Deactivate();
            this.scene.Add(this.labyrinthGraphic);
            this.scene.Add(this.tableGraphic);
            this.scene.Add(this.gameConsoleGraphic);
            this.gameConsole.AddInput(Dialog.Welcome);
            this.gameConsole.AddInput(Dialog.Input);
            this.scene.Render();
        }

        private void ExitApplication()
        {
            Command anyKey = this.input.GetInput();
            Environment.Exit(0);
        }
    }
}