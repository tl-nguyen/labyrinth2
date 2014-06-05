namespace Labyrinth
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class GameEngine    
    {
        public GameEngine()
        {
            Labyrinth labyrinth = new Labyrinth();

            UserInputAndOutput.PrintWelcomeMessage();

            UpdateUserInput(labyrinth);

            Console.WriteLine();
        }
        private void UpdateUserInput(Labyrinth labyrinth)
        {
            string input = string.Empty;
            int movesCount = 0;

            while (!this.IsGameOver(labyrinth) && input != "restart")
            {
                
                UserInputAndOutput.PrintLabyrinth(labyrinth);
                input = UserInputAndOutput.GetInput();
                Console.Clear();
                this.ProccessInput(input, labyrinth, ref movesCount);
                
            }

            if (input != "restart")
            {
                Console.WriteLine("Congratulations! You escaped in {0} moves.", movesCount);
                if (TopResults.List.IsTopResult(movesCount))
                {
                    Console.WriteLine(
                        UserInputAndOutput.ENTER_NAME_FOR_SCOREBOARD_MSG);
                    string name = Console.ReadLine();
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
                    Console.WriteLine(UserInputAndOutput.INVALID_MOVE_MSG);
                    break;
            }
            
            if (moveDone == false)
            {
                Console.WriteLine(UserInputAndOutput.INVALID_MOVE_MSG);
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
                    Console.WriteLine(TopResults.List);
                    break;
                case "exit":
                    Console.WriteLine(UserInputAndOutput.GOODBYE_MSG);
                    Environment.Exit(0);
                    break;
                case "restart":
                    break;
                default:
                    string errorMessage = UserInputAndOutput.INVALID_COMMAND_MSG;
                    Console.WriteLine(errorMessage);
                    break;
            }
        }
    }
}
