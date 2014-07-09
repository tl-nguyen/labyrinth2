namespace Labyrinth
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class ConsoleRenderer : IRenderer
    {
        private const char EMPTY_CELL = '-';
        private const char WALL_CELL = 'X';
        private const char PLAYER_CELL = '*';

        private const string INVALID_MOVE_MSG = "Invalid move!";
        private const string INVALID_COMMAND_MSG = "Invalid command!";
        private const string ENTER_NAME_FOR_SCOREBOARD_MSG = "Please enter" +
            "your name for the top scoreboard: ";
        private const string GOODBYE_MSG = "Good Bye";
        private const string GET_INPUT_MSG = "Enter your move (L=left," +
            "R-right, U=up, D=down): ";
        private const string WELLCOME_MSG = "Welcome to “Labirinth” game." +
            " Please try to escape." +
            " Use 'top' to view the top scoreboard," +
            " 'restart' to start a new game and 'exit' to quit the game.";

        public void RenderPromptInput()
        {
            Console.Write(GET_INPUT_MSG);
        }

        public void RenderWelcomeMessage()
        {
            Console.WriteLine(WELLCOME_MSG);
        }

        public void RenderExitMessage()
        {
            Console.WriteLine(GOODBYE_MSG);
        }

        public void RenderInvalidCommand()
        {
            Console.WriteLine(INVALID_COMMAND_MSG);
        }

        public void Clear()
        {
            Console.Clear();
        }

        public void RenderEnterNameForScoreboard()
        {
            Console.WriteLine(ENTER_NAME_FOR_SCOREBOARD_MSG);
        }

        public void RenderWinMessage(int movesCount)
        {
            Console.WriteLine("Congratulations! You escaped in {0} moves.", movesCount);
        }

        public void RenderInvalidMove()
        {
            Console.WriteLine(INVALID_MOVE_MSG); ;
        }
        public void RenderLabyrinth(Labyrinth labyrinth)
        {
            int labyrinthSize = Labyrinth.LABYRINTH_SIZE;
            for (int row = 0; row < labyrinthSize; row++)
            {
                for (int col = 0; col < labyrinthSize; col++)
                {
                    ICell cell = labyrinth.GetCell(row, col);
                    switch (cell.CellValue)
                    {
                        case CellState.Empty: Console.Write(EMPTY_CELL + " ");
                            break;
                        case CellState.Wall: Console.Write(WALL_CELL + " ");
                            break;
                        case CellState.Player: Console.Write(PLAYER_CELL + " ");
                            break;
                        default:
                            throw new ArgumentException("If this happens something is very wrong with the logic of PrintLabyrinth method");
                    }
                }
                Console.WriteLine();
            }
        }

        public void RenderTopResults(string topResults)
        {
            Console.WriteLine(topResults);
        }
    }
}
