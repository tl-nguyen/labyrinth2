namespace Labyrinth
{
    using System;
    using Commons;
    using Entities.Contracts;

    /// <summary>
    /// Class that inherits IGameLogic, and handles input, and changes game objects
    /// </summary>
    public class GameLogic : IGameLogic
    {
        private ILabyrinthPlayField labyrinth;
        private IGameConsole gameConsole;
        private IResultsTable resultsTable;
        private IUserInput input;
        private IResultFactory factory;
        private int movesCount;
        private bool isTopResult;

        /// <summary>
        /// Initializes a new instance of the <see cref="GameLogic"/> class
        /// </summary>
        /// <param name="labyrinth">Receives a non null <see cref="ILabyrinthPlayField"/></param>
        /// <param name="gameConsole">Receives a non null <see cref="IGameConsole"/></param>
        /// <param name="resultsTable">Receives a non null <see cref="IResultsTable"/></param>
        /// <param name="input">Receives a non null <see cref="IUserInput"/></param>
        /// <param name="factory">Receives a non null <see cref="IResultFactory"/></param>
        public GameLogic(ILabyrinthPlayField labyrinth, IGameConsole gameConsole, IResultsTable resultsTable, IUserInput input, IResultFactory factory)
        {
            if (labyrinth == null || gameConsole == null || resultsTable == null || input == null || factory == null)
            {
                throw new ArgumentNullException();
            }

            this.labyrinth = labyrinth;
            this.gameConsole = gameConsole;
            this.resultsTable = resultsTable;
            this.input = input;
            this.Exit = false;
            this.factory = factory;
            this.movesCount = 0;
            this.isTopResult = false;
        }

        /// <summary>
        /// Gets a value indicating whether a game ending condition is reached. Default value is false.
        /// </summary>
        public bool Exit { get; private set; }

        /// <summary>
        /// Receives a Command, processes it and updates the game entities accordingly
        /// </summary>
        public void Update()
        {
            if (this.isTopResult == false)
            {
                this.UpdateUserInput();
            }
            else
            {
                this.RecordTopResult();
            }
        }

        private void UpdateUserInput()
        {
            Command input = Command.InvalidInput;

            input = this.input.GetInput();
            this.ProcessInput(input);
        }

        private void ProcessInput(Command input)
        {
            this.ExecuteCommand(input);

            if (this.IsGameFinished(this.labyrinth) && input != Command.Restart)
            {
                this.GameOver();
            }
        }

        private void ExecuteCommand(Command input)
        {
            switch (input)
            {
                case Command.Up:
                case Command.Down:
                case Command.Left:
                case Command.Right:
                    if (this.labyrinth.Active)
                    {
                        bool moveDone =
                            this.labyrinth.MoveHandler.MoveAction(this.labyrinth, input);
                        if (moveDone == true)
                        {
                            this.movesCount++;
                        }
                        else
                        {
                            this.gameConsole.AddInput(Dialog.InvalidMove);
                        }
                    }

                    break;

                case Command.Top:
                    this.ToggleTopResults();
                    break;

                case Command.Exit:
                    this.Quit();
                    break;

                case Command.Restart:
                    this.Restart();
                    break;

                default:
                    this.gameConsole.AddInput(Dialog.InvalidCommand);
                    break;
            }
        }

        private void ToggleTopResults()
        {
            if (this.resultsTable.Active == false)
            {
                this.resultsTable.Activate();
                this.labyrinth.Deactivate();
            }
            else
            {
                this.resultsTable.Deactivate();
                this.labyrinth.Activate();
            }
        }

        private void Restart()
        {
            this.labyrinth.GenerateLabyrinth();
            this.movesCount = 0;
        }

        private void Quit()
        {
            this.gameConsole.AddInput(Dialog.GoodBye);
            this.Exit = true;
        }

        private bool IsGameFinished(ILabyrinthPlayField labyrinth)
        {
            bool isGameOver = false;
            int currentRow = labyrinth.CurrentCell.Row;
            int currentCol = labyrinth.CurrentCell.Col;
            if (currentRow == 0 ||
                currentCol == 0 ||
                currentRow == labyrinth.LabyrinthSize - 1 ||
                currentCol == labyrinth.LabyrinthSize - 1)
            {
                isGameOver = true;
            }

            return isGameOver;
        }

        private void GameOver()
        {
            this.ToggleTopResults();
            this.gameConsole.AddInput(Dialog.WinMessage, new string[] { this.movesCount.ToString() });
            if (this.resultsTable.Table.IsTopResult(this.movesCount))
            {
                this.gameConsole.AddInput(Dialog.EnterName);
                this.isTopResult = true;
            }
            else
            {
                this.ToggleTopResults();
                this.Restart();
            }
        }

        private void RecordTopResult()
        {
            string name = this.input.GetPlayerName();
            this.resultsTable.Table.Add(this.factory.GetResultInstance(this.movesCount, name));
            this.Restart();
            this.isTopResult = false;
            this.ToggleTopResults();
        }
    }
}