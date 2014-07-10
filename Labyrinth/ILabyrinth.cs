using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labyrinth
{
    public interface ILabyrinth
    {
        void GenerateLabyrinth();
        bool TryMove(ICell currentCell, Direction direction);
        ICell GetCell(int row, int col);
        ICell CurrentCell { get; }
    }
}
