namespace Labyrinth.UI
{
    using Entities.Contracts;
    using Commons;
    using Renderer.Contracts;

    public class ConsoleRenderableResults : ConsoleRenderableEntity
    {
        private IResultsTable table;

        public ConsoleRenderableResults(IResultsTable table, IntPoint coords, IRenderer renderer)
            : base(table, coords, renderer)
        {
            this.table = table;
            this.Graphic = this.GenerateStringGraphic();
        }

        override protected string GenerateStringGraphic()
        {
            return this.table.ToString();
        }
    }
}
