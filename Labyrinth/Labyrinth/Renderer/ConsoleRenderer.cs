namespace Labyrinth.Renderer
{
    using Renderer.Contracts;
    using System;
    using UI.Contracts;

    public class ConsoleRenderer : IConsoleRenderer
    {
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