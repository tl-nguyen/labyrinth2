namespace Labyrinth
{
    using Commons;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public interface IGameLogic
    {
        void ProcessInput(Command command, ref int movesCount);
        bool IsGameOver { get; }
    }
}
