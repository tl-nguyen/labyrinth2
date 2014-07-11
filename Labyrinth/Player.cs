using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labyrinth
{
    public class Player: MoveHandler
    {
        public Player(Labyrinth labyrinth)
        {
            this.Labyrinth = labyrinth.Labyrinth;
            this.CurrentCell = labyrinth.CurrentCell;
        }

        public bool MoveAction(Command direction)
        {
            bool moveDone = false;
            switch (direction)
            {
                case Command.Up:
                    moveDone =
                        TryMove(this.CurrentCell, Direction.Up);
                    break;
                case Command.Down:
                    moveDone =
                        TryMove(this.CurrentCell, Direction.Down);
                    break;
                case Command.Left:
                    moveDone =
                        TryMove(this.CurrentCell, Direction.Left);
                    break;
                case Command.Right:
                    moveDone =
                        TryMove(this.CurrentCell, Direction.Right);
                    break;
                default:
                    break;
            }

            return moveDone;
        }
    }
}
