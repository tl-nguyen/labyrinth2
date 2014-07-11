namespace Labyrinth
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    public class GameEngine    
    {
        private IRenderer renderer;
        private IUserInput input;
        private Player player;
        private TopResults table;

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
            UpdateUserInput();

        }
        private void UpdateUserInput()
        {
            Command input = Command.InvalidInput;
            int movesCount = 0;

            while (!this.IsGameOver(this.player) && input != Command.Restart)
            {
                renderer.RenderLabyrinth(this.player.Labyrinth);
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
                    this.table.Add(new Result(movesCount, name));
                }
            }
        }
        private bool IsGameOver(Player player)
        {
            bool isGameOver = false;
            int currentRow = player.CurrentCell.Row;
            int currentCol = player.CurrentCell.Col;
            if (currentRow == 0 ||
                currentCol == 0 ||
                currentRow == Labyrinth.LABYRINTH_SIZE - 1 ||
                currentCol == Labyrinth.LABYRINTH_SIZE - 1)
            {
                isGameOver = true;
            }

            return isGameOver;
        }

        private void ProccessInput(Command input, ref int movesCount)
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
