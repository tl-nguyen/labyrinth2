namespace Labyrinth
{
    using Entities;
    using Entities.Contracts;
    using Loggers.Contracts;
    using Renderer.Contracts;
    using System;
    using UI.Contracts;
    using Commons;

    /// <summary>
    /// Class that gives the game objects to different modules, and transfers commands from one class to another, allowing them to be detached.
    /// </summary>
    public class GameEngine
    {
        private int window_width; 
        private int window_height;

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

        public GameEngine(int width, int height, IFactory factory)
        {
            this.window_width = width;
            this.window_height = height;
            this.factory = factory;
            this.input = this.factory.GetUserInputInstance();
            this.labyrinth = this.factory.GetLabyrinthInstance(factory, this.factory.GetMoveHandlerInstance());
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

        //TODO: word better
        /// <summary>
        /// Width and height units depend on the specific renderer. In the case of a Console renderer they are in console rows and cols.
        /// </summary>
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
            this.renderer.Init(this.window_width, this.window_height);
            this.resultsTable.Deactivate();
            this.scene.Add(this.labyrinthGraphic);
            this.scene.Add(this.tableGraphic);
            this.scene.Add(this.gameConsoleGraphic);
            this.gameConsole.AddInput("Welcome");
            this.gameConsole.AddInput("Input");
            scene.Render();
        }

        private void ExitApplication()
        {
            Command anyKey = this.input.GetInput();
            Environment.Exit(0);
        }
    }
}