namespace Labyrinth.UI
{
    using Commons;
    using UI.Contracts;
    using Renderer.Contracts;
    using Entities.Contracts;

    public abstract class EntityConsoleGraphic : IRenderable
    {
        protected IEntity entity;
        protected IRenderer renderer;

        public IntPoint TopLeft { get; set; }
        public dynamic Graphic { get; protected set; }
        

        public EntityConsoleGraphic(IEntity entity, IntPoint coords, IRenderer renderer)
        {
            this.entity = entity;
            this.TopLeft = coords;
            this.renderer = renderer;
        }

        public void Render()
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

        protected abstract string[] GenerateStringGraphic();
    }
}
