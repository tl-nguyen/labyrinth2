namespace Labyrinth.UI
{
    using Commons;
    using UI.Contracts;
    using Renderer.Contracts;
    using Entities.Contracts;

    public abstract class ConsoleRenderableEntity : RenderableEntity
    {
        public ConsoleRenderableEntity(IEntity entity, IntPoint coords, IRenderer renderer)
            :base(entity, coords, renderer)
        {
        }

        override public void Render()
        {
            if (this.entity.Active)
            {
                this.UpdateGraphic();
                this.renderer.RenderEntity(this);
            }
        }

        private void UpdateGraphic()
        {
            this.Graphic = this.GenerateStringGraphic();
        }

        protected abstract string GenerateStringGraphic();
    }
}
