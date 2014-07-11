using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labyrinth
{
    class MoveHandler:IMoveHandler
    {
         public bool TryMove(Command direction, ILabyrinth labyrinth)
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
                    break;
            }

            return moveDone;
        }
    }
}
