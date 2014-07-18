using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labyrinth.Labyrinth.experimental
{
    public interface IRenderableX
    {
        IntPointX TopLeft { get; set; }
        void Render();
        void SetX(int x);
        void SetY(int y);
    }
}
