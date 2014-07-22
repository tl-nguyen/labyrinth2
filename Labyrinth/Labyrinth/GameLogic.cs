namespace Labyrinth
{
    using Commons;
    using Entities.Contracts;

    /// <summary>
    /// Class that inherits IGameLogic, and handles input, and changes game objects
    /// </summary>
    public class GameLogic : IGameLogic
    {
        private ILabyrinth labyrinth;
        private IGameConsole gameConsole;
        private IResultsTable resultsTable;
        private IUserInput input;
        private IFactory factory;
        private int movesCount;
        private bool isTopResult;

        public GameLogic(ILabyrinth labyrinth, IGameConsole gameConsole,
            IResultsTable resultsTable, IUserInput input, IFactory factory)
        {
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
        /// Is set to false normally, sets to true if a game ending condition is reached.
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
                            this.gameConsole.AddInput("InvalidMove");
                        }
                    }
                    break;

                case Command.Top:
                    this.ShowTopResults();
                    break;

                case Command.Exit:
                    this.Quit();
                    break;

                case Command.Restart:
                    this.Restart();
                    break;

                default:
                    this.gameConsole.AddInput("InvalidCommand");
                    break;
            }
        }

        private void ShowTopResults()
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
            this.gameConsole.AddInput("GoodBye");
            this.Exit = true;
        }

        private bool IsGameFinished(ILabyrinth labyrinth)
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
            this.ShowTopResults();
            this.gameConsole.AddInput("WinMessage", new string[] { this.movesCount.ToString() });
            if (this.resultsTable.Table.IsTopResult(this.movesCount))
            {
                this.gameConsole.AddInput("EnterName");
                this.isTopResult = true;
            }
            else
            {
                this.Quit();
            }
        }

        private void RecordTopResult()
        {
            string name = this.input.GetPlayerName();
            this.resultsTable.Table.Add(this.factory.GetResultInstance(this.movesCount, name));
            this.Quit();
        }
    }
}