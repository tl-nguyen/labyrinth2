using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labyrinth.Labyrinth.experimental
{
    public abstract class EntityX : IRenderableX
    {
        public IntPointX TopLeft { get; set; }

        public EntityX(IntPointX coords)
        {
            this.TopLeft = coords;
        }

        abstract public void Render();

        public void SetX(int x)
        {
            this.TopLeft.X = x;
        }

        public void SetY(int y)
        {
            this.TopLeft.Y = y;
        }
    }
}
