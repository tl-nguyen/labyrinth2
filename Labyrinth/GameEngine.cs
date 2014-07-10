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
        public GameEngine(IRenderer renderer, IUserInput input)
        {
            this.input = input;
            this.renderer = renderer;
            Labyrinth labyrinth = new Labyrinth();

            renderer.RenderWelcomeMessage();

            TopResults.List.Parse(FileManager.LoadFromFile());
            TopResults.List.Changed += new ChangedTopResultsEventHandler(FileManager.SaveToFile);

            UpdateUserInput(labyrinth);

        }
        private void UpdateUserInput(Labyrinth labyrinth)
        {
            Command input = Command.InvalidInput;
            int movesCount = 0;

            while (!this.IsGameOver(labyrinth) && input != Command.Restart)
            {
                renderer.RenderLabyrinth(labyrinth);
                renderer.RenderPromptInput();
                input = this.input.GetInput();
                renderer.Clear();
                this.ProccessInput(input, labyrinth, ref movesCount);
                
            }

            if (input != Command.Restart)
            {
                renderer.RenderWinMessage(movesCount);
                if (TopResults.List.IsTopResult(movesCount))
                {
                    renderer.RenderEnterNameForScoreboard();
                    string name = this.input.GetPlayerName(); 
                    TopResults.List.Add(new Result(movesCount, name));
                }
            }
        }
        private bool IsGameOver(Labyrinth labyrinth)
        {
            bool isGameOver = false;
            int currentRow = labyrinth.CurrentCell.Row;
            int currentCol = labyrinth.CurrentCell.Col;
            if (currentRow == 0 ||
                currentCol == 0 ||
                currentRow == Labyrinth.LABYRINTH_SIZE - 1 ||
                currentCol == Labyrinth.LABYRINTH_SIZE - 1)
            {
                isGameOver = true;
            }

            return isGameOver;
        }

        private bool TryMove(Command direction, Labyrinth labyrinth)
        {
            bool moveDone = false;
            switch (direction)
            {
                case Command.Up:
                    moveDone =
                        labyrinth.TryMove(labyrinth.CurrentCell, Direction.Up);
                    break;
                case Command.Down:
                    moveDone =
                        labyrinth.TryMove(labyrinth.CurrentCell, Direction.Down);
                    break;
                case Command.Left:
                    moveDone =
                        labyrinth.TryMove(labyrinth.CurrentCell, Direction.Left);
                    break;
                case Command.Right:
                    moveDone =
                        labyrinth.TryMove(labyrinth.CurrentCell, Direction.Right);
                    break;
                default:
                    renderer.RenderInvalidMove();
                    break;
            }
            
            if (moveDone == false)
            {
                renderer.RenderInvalidMove();
            }

            return moveDone;
        }

        private void ProccessInput(Command input, Labyrinth labyrinth, ref int movesCount)
        {
            switch (input)
            {
                case Command.Up:
                case Command.Down:
                case Command.Left:
                case Command.Right:
                    bool moveDone =
                        this.TryMove(input, labyrinth);
                    if (moveDone == true)
                    {
                        movesCount++;
                    }
                    break;
                case Command.Top:
                    renderer.RenderTopResults(TopResults.List.ToString());
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
