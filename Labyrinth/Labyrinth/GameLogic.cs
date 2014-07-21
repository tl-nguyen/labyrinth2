namespace Labyrinth
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Commons;
    using UI.Contracts;
    using UI;
    using Results.Contracts;
    using LabyrinthHandler;
    using LabyrinthHandler.Contracts;
    using Entities;
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

        private IScene scene; //temporary, untill we finish redistributing responsibilites, so that GameLogic doesn't work with rendering

        public GameLogic(ILabyrinth labyrinth, IGameConsole gameConsole,
            IScene scene, IResultsTable resultsTable, IUserInput input, IFactory factory)
        {
            this.labyrinth = labyrinth;
            this.gameConsole = gameConsole;
            this.scene = scene;
            this.resultsTable = resultsTable;
            this.input = input;
            this.Terminate = false;
            this.factory = factory;
            this.movesCount = 0;
        }

        /// <summary>
        /// Is set to false normally, sets to true if a game ending condition is reached.
        /// </summary>
        public bool Terminate { get; private set; }

        /// <summary>
        /// Receives a Command, processes it, making modifications to the game objects, and sets IsGameOver
        /// </summary>
        public void ProcessInput(Command input)
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
                    break;
                case Command.Top:
                    this.ShowTopResults(); //TODO: look at method comment
                    break;
                case Command.Exit:
                    this.Exit();
                    break;
                case Command.Restart:
                    /*
                     * TODO: fix unwanted behaviour(player graphic is shown at correct place,
                     * but player's actual position is the old position)
                     */
                    this.labyrinth.GenerateLabyrinth();
                    this.movesCount = 0;
                    break;
                default:
                    this.gameConsole.AddInput("InvalidCommand");
                    break;
            }
        }

        private void Exit()
        {
            this.labyrinth.Deactivate();
            this.gameConsole.AddInput("GoodBye");
            this.scene.Render();
            if (Console.ReadKey(true) != null)
            {
                Environment.Exit(0);
            }
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
            this.labyrinth.Deactivate();
            this.gameConsole.AddInput("WinMessage", new string[] { this.movesCount.ToString() });
            if (this.resultsTable.Table.IsTopResult(this.movesCount))
            {
                this.gameConsole.AddInput("EnterName");
                scene.Render();
                string name = this.input.GetPlayerName();
                this.resultsTable.Table.Add(factory.GetResultInstance(this.movesCount, name));
            }

            this.Terminate = true;
        }
        /*
         * TODO: use bool flag to decide whether to activate table, deactive labyrinth or vice versa
         */
        private void ShowTopResults()
        {
            this.resultsTable.Activate();
            this.labyrinth.Deactivate();
        }

        private void UpdateUserInput()
        {
            Command input = Command.InvalidInput;

            input = this.input.GetInput();
            this.ProcessInput(input);
        }

        public void Update()
        {
            this.UpdateUserInput();
        }
    }
}
