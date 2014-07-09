namespace Labyrinth
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    public class GameEngine    
    {
        private IRenderer renderer;
        public GameEngine(IRenderer renderer)
        {
            this.renderer = renderer;
            Labyrinth labyrinth = new Labyrinth();

            renderer.RenderWelcomeMessage();

            TopResults.List.Parse(FileManager.LoadFromFile());
            TopResults.List.Changed += new ChangedTopResultsEventHandler(FileManager.SaveToFile);

            UpdateUserInput(labyrinth);

        }
        private void UpdateUserInput(Labyrinth labyrinth)
        {
            string input = string.Empty;
            int movesCount = 0;

            while (!this.IsGameOver(labyrinth) && input != "restart")
            {
                renderer.RenderLabyrinth(labyrinth);
                renderer.RenderPromptInput();
                input = UserInputAndOutput.GetInput();
                renderer.Clear();
                this.ProccessInput(input, labyrinth, ref movesCount);
                
            }

            if (input != "restart")
            {
                renderer.RenderWinMessage(movesCount);
                if (TopResults.List.IsTopResult(movesCount))
                {
                    renderer.RenderEnterNameForScoreboard();
                    string name = Console.ReadLine(); //TODO: MOVE ALL Console.Readline() to the UserInputOutput
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

        private bool TryMove(string direction, Labyrinth labyrinth)
        {
            bool moveDone = false;
            switch (direction)
            {
                case "u":
                    moveDone =
                        labyrinth.TryMove(labyrinth.CurrentCell, Direction.Up);
                    break;
                case "d":
                    moveDone =
                        labyrinth.TryMove(labyrinth.CurrentCell, Direction.Down);
                    break;
                case "l":
                    moveDone =
                        labyrinth.TryMove(labyrinth.CurrentCell, Direction.Left);
                    break;
                case "r":
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

        private void ProccessInput(string input, Labyrinth labyrinth, ref int movesCount)
        {
            string inputToLower = input.ToLower();
            switch (inputToLower)
            {
                case "u":
                case "d":
                case "l":
                case "r":
                    bool moveDone =
                        this.TryMove(inputToLower, labyrinth);
                    if (moveDone == true)
                    {
                        movesCount++;
                    }
                    break;
                case "top":
                    renderer.RenderTopResults(TopResults.List.ToString());
                    break;
                case "exit":
                    renderer.RenderExitMessage();
                    Environment.Exit(0);
                    break;
                case "restart":
                    break;
                default:
                    renderer.RenderInvalidCommand();
                    break;
            }
        }
    }
}
