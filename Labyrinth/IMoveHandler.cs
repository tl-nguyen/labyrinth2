using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labyrinth
{
    public interface IMoveHandler
    {
        bool TryMove(Command direction, ILabyrinth labyrinth);
    }
}
