namespace Labyrinth
{
    using System;

    public class ConsoleRenderer : IRenderer
    {
        public ILanguageStrings DialogList { get; private set; }

        private const char EMPTY_CELL = '-';
        private const char WALL_CELL = 'X';
        private const char PLAYER_CELL = '*';

        public ConsoleRenderer(ILanguageStrings dialogList)
        {
            this.DialogList = dialogList;
        }

        public ConsoleRenderer() : this(LabyrinthFactory.GetLanguageStringsInstance())
        {
        }

        public void RenderPromptInput()
        {
            Console.Write(DialogList.GetDialog("Input"));
        }

        public void RenderWelcomeMessage()
        {
            Console.WriteLine(DialogList.GetDialog("Welcome"));
        }

        public void RenderExitMessage()
        {
            Console.WriteLine(DialogList.GetDialog("GoodBye"));
        }

        public void RenderInvalidCommand()
        {
            Console.WriteLine(DialogList.GetDialog("InvalidCommand"));
        }

        public void Clear()
        {
            Console.Clear();
        }

        public void RenderEnterNameForScoreboard()
        {
            Console.WriteLine(DialogList.GetDialog("EnterName"));
        }

        public void RenderWinMessage(int movesCount)
        {
            Console.WriteLine(DialogList.GetDialog("WinMessage"), movesCount);
        }

        public void RenderInvalidMove()
        {
            Console.WriteLine(DialogList.GetDialog("InvalidMove"));
        }
        public void RenderLabyrinth(ICell[,] labyrinth)
        {
            int labyrinthSize = Labyrinth.LABYRINTH_SIZE;
            for (int row = 0; row < labyrinthSize; row++)
            {
                for (int col = 0; col < labyrinthSize; col++)
                {
                    ICell cell = labyrinth[row, col];
                    switch (cell.CellValue)
                    {
                        case CellState.Empty: Console.Write(EMPTY_CELL + " ");
                            break;
                        case CellState.Wall: Console.Write(WALL_CELL + " ");
                            break;
                        case CellState.Player: Console.Write(PLAYER_CELL + " ");
                            break;
                        default:
                            throw new ArgumentException(DialogList.GetDialog("AllWrong"));
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
