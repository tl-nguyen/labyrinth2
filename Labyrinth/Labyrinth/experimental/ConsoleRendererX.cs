using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labyrinth.Labyrinth.experimental
{
    public class ConsoleRendererX : IConsoleRendererX
    {
        public void RenderEntity(IRenderableX entity)
        {
            int x = entity.TopLeft.X;
            int y = entity.TopLeft.Y;
            Console.SetCursorPosition(x, y);
            Console.Write(entity.ToString());
        }

        public void Clear()
        {
            Console.Clear();
        }
    }
}
