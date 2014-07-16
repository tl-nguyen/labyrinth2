namespace Labyrinth
{
    public interface IRenderer
    {
        void RenderLabyrinth(ICell[,] labyrinth);

        void RenderPromptInput();

        void RenderWelcomeMessage();

        void RenderExitMessage();

        void RenderInvalidCommand();

        void Clear();

        void RenderEnterNameForScoreboard();

        void RenderWinMessage(int movesCount);

        void RenderInvalidMove();

        void RenderTopResults(string topResults);
    }
}
