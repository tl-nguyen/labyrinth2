namespace Labyrinth.Labyrinth.experimental
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

    public class GameEngineX
    {
        private IConsoleRendererX renderer;
        private IUserInput input;
        private IPlayer player;
        private ITable table;
        private ILogger simpleLoggerFileAppender;
       
        private ISceneX scene;
        private IUiTextX topMessageBox;
        private IUiTextX bottomMessageBox;
        private LabyrinthGfkX labyrinthGfk;

        private bool hasEndedGame;

        public GameEngineX(IConsoleRendererX renderer, IUserInput input)
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

            this.scene = new ConsoleSceneX(this.renderer);
            topMessageBox = new UiText(new IntPointX(0, 0), this.renderer, LabyrinthFactory.GetLanguageStringsInstance());
            bottomMessageBox = new UiText(new IntPointX(0, 20), this.renderer, LabyrinthFactory.GetLanguageStringsInstance());
            labyrinthGfk = new LabyrinthGfkX(new IntPointX(0, 9), this.renderer, this.player.Labyrinth.Matrix);
        }

        public GameEngineX()
            : this(new ConsoleRendererX(), LabyrinthFactory.GetUserInputInstance())
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
