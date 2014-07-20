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
        private IScene scene;
        private IUiText topMessageBox;
        private IUiText bottomMessageBox;
        private ITable table;
        private IUserInput input;
        private IFactory factory;

        public GameLogic(ILabyrinth labyrinth, IUiText topMessageBox, IUiText bottomMessageBox,
            IScene scene, ITable table, IUserInput input, IFactory factory)
        {
            this.labyrinth = labyrinth;
            this.topMessageBox = topMessageBox;
            this.bottomMessageBox = bottomMessageBox;
            this.scene = scene;
            this.table = table;
            this.input = input;
            this.IsGameOver = false;
            this.factory = factory;
        }

        /// <summary>
        /// Is set to false normally, sets to true if a game ending condition is reached.
        /// </summary>
        public bool IsGameOver { get; private set; }

        /// <summary>
        /// Receives a Command, processes it, making modifications to the game objects, and sets IsGameOver
        /// </summary>
        public void ProcessInput(Command input, ref int movesCount)
        {
            movesCount = ExecuteCommand(input, movesCount);

            if (this.IsGameFinished(this.labyrinth) && input != Command.Restart)
            {
                this.GameOver(movesCount);
            }
        }

        private int ExecuteCommand(Command input, int movesCount)
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

            return movesCount;
        }

        private void Exit()
        {
            this.labyrinth.Deactivate();
            this.topMessageBox.SetText("GoodBye", true);
            this.bottomMessageBox.SetText("Press any key to exit...", false);
            this.bottomMessageBox.SetY(1);
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

        private void GameOver(int movesCount)
        {
            this.labyrinth.Deactivate();
            topMessageBox.SetText("WinMessage", new string[] { movesCount.ToString() });
            if (this.table.IsTopResult(movesCount))
            {
                bottomMessageBox.SetText("EnterName", true);
                bottomMessageBox.SetY(1);
                scene.Render();
                Console.WriteLine();
                string name = this.input.GetPlayerName();
                this.table.Add(factory.GetResultInstance(movesCount, name));
            }

            this.IsGameOver = true;
        }
    }
}
