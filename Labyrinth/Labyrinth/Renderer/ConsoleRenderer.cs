namespace Labyrinth.Renderer
{
    using Renderer.Contracts;
    using System;
    using UI.Contracts;

    public class ConsoleRenderer : IConsoleRenderer
    {
        public void Init(int window_width, int window_height)
        {
            Console.WindowWidth = window_width;
            Console.WindowHeight = window_height;

            Console.BufferWidth = Console.WindowWidth;
            Console.BufferHeight = Console.WindowHeight;
        }
        public void RenderEntity(IRenderable entity)
        {
            int x = entity.TopLeft.X;
            int y = entity.TopLeft.Y;
            Console.SetCursorPosition(x, y);
            Console.Write(entity.Graphic.ToString());
        }

        public void Clear()
        {
            Console.Clear();
        }
    }
}