namespace Labyrinth
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Commons;
    using Labyrinth.Entities.Contracts;
using Labyrinth.Entities;
    using Labyrinth.Results.Contracts;
    using Labyrinth.LabyrinthHandler;

    public class GameLogic : IGameLogic
    {
        public bool IsGameOver { get; private set; }

        private IPlayer player;
        private IScene scene;
        private IUiText topMessageBox;
        private IUiText bottomMessageBox;
        private LabyrinthGfk labyrinthGfk;
        private ITable table;
        private IUserInput input;

        public GameLogic(IPlayer player, IUiText topMessageBox, IUiText bottomMessageBox, LabyrinthGfk labyrinthGfk, IScene scene, ITable table, IUserInput input)
        {
            this.player = player;
            this.topMessageBox = topMessageBox;
            this.bottomMessageBox = bottomMessageBox;
            this.labyrinthGfk = labyrinthGfk;
            this.scene = scene;
            this.table = table;
            this.input = input;
            this.IsGameOver = false;
        }

        public void ProcessInput(Command input, ref int movesCount)
        {
            movesCount = ExecuteCommand(input, movesCount);

            if (this.IsGameFinished(this.player) && input != Command.Restart)
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

            return movesCount;
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

        private bool IsGameFinished(IPlayer player)
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

        private void GameOver(int movesCount)
        {
            this.scene.Remove(labyrinthGfk);
            topMessageBox.SetText("WinMessage", new string[] { movesCount.ToString() });
            if (this.table.IsTopResult(movesCount))
            {
                bottomMessageBox.SetText("EnterName", true);
                bottomMessageBox.SetY(1);
                scene.Render();
                Console.WriteLine();
                string name = this.input.GetPlayerName();
                this.table.Add(LabyrinthFactory.GetResultInstance(movesCount, name));
            }

            this.IsGameOver = true;
        }
    }
}
