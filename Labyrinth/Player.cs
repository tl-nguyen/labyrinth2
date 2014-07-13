using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labyrinth
{
    public class Player :  IPlayer
    {
        public ILabyrinthMoveHandler Labyrinth { get; private set; }
        public Player(ILabyrinthMoveHandler labyrinth)
        {
            this.Labyrinth = labyrinth;
        }
        /// <summary>
        /// Checks if a move can be done using the parent's method TryMove
        /// </summary>
        /// <param name="direction">Current user input direction</param>
        /// <returns>True if a move can be made, false if not</returns>
        public bool MoveAction(Command direction)
        {
            bool moveDone = false;
            switch (direction)
            {
                case Command.Up:
                    moveDone =
                        this.Labyrinth.TryMove(this.Labyrinth.CurrentCell, Direction.Up);
                    break;
                case Command.Down:
                    moveDone =
                        this.Labyrinth.TryMove(this.Labyrinth.CurrentCell, Direction.Down);
                    break;
                case Command.Left:
                    moveDone =
                        this.Labyrinth.TryMove(this.Labyrinth.CurrentCell, Direction.Left);
                    break;
                case Command.Right:
                    moveDone =
                        this.Labyrinth.TryMove(this.Labyrinth.CurrentCell, Direction.Right);
                    break;
                default:
                    break;
            }

            return moveDone;
        }
    }
}
