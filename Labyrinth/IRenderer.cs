namespace Labyrinth
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public interface IRenderer
    {
        void RenderLabyrinth(ILabyrinth labyrinth);

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
