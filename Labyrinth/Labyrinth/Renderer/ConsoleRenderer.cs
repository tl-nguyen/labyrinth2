using System;
using Labyrinth.Renderer.Contracts;
using Labyrinth.Entities.Contracts;

namespace Labyrinth.Renderer
{
    public class ConsoleRenderer : IConsoleRenderer
    {
        public void RenderEntity(IRenderable entity)
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
