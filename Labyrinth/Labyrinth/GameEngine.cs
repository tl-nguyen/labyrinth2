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
        private LabyrinthGfk labyrinthGfk;

        private bool hasEndedGame;

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
            this.labyrinthGfk = LabyrinthFactory.GetLabyrinthGfk(new IntPoint(0, 9), this.renderer, this.player.Labyrinth.Matrix);

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

            while (!this.hasEndedGame)
            {
                this.GameLoop(ref movesCount);
            }
        }

        private void GameLoop(ref int movesCount)
        {
            this.UpdateUserInput(ref movesCount);
            this.scene.Render();
        }

        private void Init()
        {
            this.scene.Add(this.labyrinthGfk);
            this.scene.Add(this.topMessageBox);
            this.scene.Add(this.bottomMessageBox);
            this.topMessageBox.SetText("Welcome", true);
            this.bottomMessageBox.SetText("Input", true);
            scene.Render();
        }

        private void GameOver(int movesCount)
        {
            this.scene.Remove(labyrinthGfk);
            topMessageBox.SetText("WinMessage", new string[] {movesCount.ToString()});
            if (this.table.IsTopResult(movesCount))
            {
                bottomMessageBox.SetText("EnterName", true);
                bottomMessageBox.SetY(1);
                scene.Render();
                Console.WriteLine();
                string name = this.input.GetPlayerName();
                this.table.Add(LabyrinthFactory.GetResultInstance(movesCount, name));
            }
            this.hasEndedGame = true;
        }

        private void Exit()
        {
            this.scene.Remove(labyrinthGfk);
            this.topMessageBox.SetText("GoodBye", true);
            this.bottomMessageBox.SetText("Press any key to exit...", false);
            this.bottomMessageBox.SetY(1);
            this.scene.Render();
            if (Console.ReadKey(true) != null) //TODO: refactor
            {
                Environment.Exit(0);
            } 
        }

        private void UpdateUserInput(ref int movesCount)
        {
            Command input = Command.InvalidInput;

            input = this.input.GetInput();
            this.ProccessInput(input, ref movesCount);

            if (this.IsGameOver(this.player) &&input != Command.Restart)
            {
                this.GameOver(movesCount);
            }
        }

        private bool IsGameOver(IPlayer player)
        {
            bool isGameOver = false;
            int currentRow = player.Labyrinth.CurrentCell.Row;
            int currentCol = player.Labyrinth.CurrentCell.Col;
            if (currentRow == 0 ||
                currentCol == 0 ||
                currentRow == MoveHandler.LABYRINTH_SIZE - 1 ||
                currentCol == MoveHandler.LABYRINTH_SIZE - 1)
            {
                isGameOver = true;
            }

            return isGameOver;
        }

        private void ProccessInput(Command input, ref int movesCount)
        {
            simpleLoggerFileAppender.Log(input.ToString());

            switch (input)
            {
                case Command.Up:
                case Command.Down:
                case Command.Left:
                case Command.Right:
                    bool moveDone =
                        this.player.MoveAction(input);
                    if (moveDone == true)
                    {
                        movesCount++;
                        this.topMessageBox.Clear();
                    }
                    else
                    {
                        this.topMessageBox.SetText("InvalidMove", true);
                    }
                    break;
                case Command.Top:
                    this.topMessageBox.SetText(this.table.ToString());
                    break;
                case Command.Exit:
                    this.Exit();
                    break;
                case Command.Restart:
                    break;
                default:
                    this.topMessageBox.SetText("InvalidCommand", true);
                    break;
            }
        }
    }
}

/* old GameEngine.cs
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
    /// <summary>
    /// Class for generating the main logic of the game 
    /// </summary>
    public class GameEngine
    {
        private IRenderer renderer;
        private IUserInput input;
        private IPlayer player;
        private ITable table;
        private ILogger simpleLoggerFileAppender;

        /// <summary>
        /// Property used for ending the game loop in Run method
        /// </summary>
        private bool hasEndedGame;

        public GameEngine(IRenderer renderer, IUserInput input)
        {
            this.input = input;
            this.renderer = renderer;
            this.player = LabyrinthFactory.GetPlayerInstance(LabyrinthFactory.GetLabyrinthInstance());
            this.table = LabyrinthFactory.GetTopResultsInstance();
            this.table.Changed += (sender, e) =>
            {
                LabyrinthFactory.GetSerializationManagerInstance().Serialize(sender);
            };
            renderer.RenderWelcomeMessage();

            var fileAppender = LabyrinthFactory.GetFileAppender("Log.txt");
            this.simpleLoggerFileAppender = LabyrinthFactory.GetSimpleLogger(fileAppender);
        }

        public GameEngine()
            : this(LabyrinthFactory.GetRendererInstance(LabyrinthFactory.GetLanguageStringsInstance()), LabyrinthFactory.GetUserInputInstance())
        {
        }

        /// <summary>
        /// Public method used to run the game 
        /// </summary>
        public void Run()
        {
            while (!this.hasEndedGame)
            {
                this.UpdateUserInput();
            }
        }
        /// <summary>
        /// Updates the state of user's input and renders the game according to it
        /// </summary>
        private void UpdateUserInput()
        {
            Command input = Command.InvalidInput;
            int movesCount = 0;

            while (!this.IsGameOver(this.player) && input != Command.Restart)
            {
                renderer.RenderLabyrinth(this.player.Labyrinth.Matrix);
                renderer.RenderPromptInput();
                input = this.input.GetInput();
                renderer.Clear();
                this.ProccessInput(input, ref movesCount);
            }

            if (input != Command.Restart)
            {
                renderer.RenderWinMessage(movesCount);
                if (this.table.IsTopResult(movesCount))
                {
                    renderer.RenderEnterNameForScoreboard();
                    string name = this.input.GetPlayerName();
                    this.table.Add(LabyrinthFactory.GetResultInstance(movesCount, name));

                }
                this.hasEndedGame = true;
            }
        }
        /// <summary>
        /// Checks if the user has made his way out of the labyrinth
        /// </summary>
        /// <param name="player">The object which current position is checked</param>
        /// <returns>True if the player has got out of the labyrinth, false if not</returns>
        private bool IsGameOver(IPlayer player)
        {
            bool isGameOver = false;
            int currentRow = player.Labyrinth.CurrentCell.Row;
            int currentCol = player.Labyrinth.CurrentCell.Col;
            if (currentRow == 0 ||
                currentCol == 0 ||
                currentRow == MoveHandler.LABYRINTH_SIZE - 1 ||
                currentCol == MoveHandler.LABYRINTH_SIZE - 1)
            {
                isGameOver = true;
            }

            return isGameOver;
        }
        /// <summary>
        /// Handles the user's input
        /// </summary>
        /// <param name="input">The current input command of the user</param>
        /// <param name="movesCount">The count of player's move done already</param>
        private void ProccessInput(Command input, ref int movesCount)
        {
            simpleLoggerFileAppender.Log(input.ToString());

            switch (input)
            {
                case Command.Up:
                case Command.Down:
                case Command.Left:
                case Command.Right:
                    bool moveDone =
                        this.player.MoveAction(input);
                    if (moveDone == true)
                    {
                        movesCount++;
                    }
                    else
                    {
                        renderer.RenderInvalidMove();
                    }
                    break;
                case Command.Top:
                    renderer.RenderTopResults(this.table.ToString());
                    break;
                case Command.Exit:
                    renderer.RenderExitMessage();
                    Environment.Exit(0);
                    break;
                case Command.Restart:
                    break;
                default:
                    renderer.RenderInvalidCommand();
                    break;
            }
        }
    }
}

 */
