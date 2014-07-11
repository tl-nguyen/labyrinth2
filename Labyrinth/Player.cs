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
    }
}
