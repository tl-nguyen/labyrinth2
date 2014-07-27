namespace Labyrinth.UI
{
    using System;
    using System.Collections.Generic;
    using Renderer.Contracts;
    using UI.Contracts;

    /// <summary>
    /// Holds a list of entities
    /// </summary>
    public abstract class Scene : IScene
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Scene" /> class.
        /// </summary>
        public Scene()
        {
            this.Entities = new List<IRenderable>();
        }

        /// <summary>
        /// Gets or sets the list of the entities in the scene.
        /// </summary>
        protected List<IRenderable> Entities { get; set; }

        /// <summary>
        /// Renders the entities.
        /// </summary>
        public abstract void Render();

        /// <summary>
        /// Adds an entity to the scene.
        /// </summary>
        /// <param name="entity">Entity to be added.</param>
        public void Add(IRenderable entity)
        {
            bool entityAlreadyAdded = this.CheckIfEntityExists(entity);

            if (entityAlreadyAdded)
            {
                throw new ArgumentException("This entity has already been added to the scene.");
            }

            this.Entities.Add(entity);
        }

        /// <summary>
        /// Removes an entity from the scene.
        /// </summary>
        /// <param name="entity">An entity for removal.</param>
        public void Remove(IRenderable entity)
        {
            bool entityFound = this.CheckIfEntityExists(entity);

            if (entityFound == false)
            {
                throw new ArgumentException("No such entity found in scene.");
            }

            this.Entities.Remove(entity);
        }

        /// <summary>
        /// Checks if entity exists.
        /// </summary>
        /// <param name="entity">An entity for check.</param>
        /// <returns>Boolean value whether the entity exists in the scene.</returns>
        protected bool CheckIfEntityExists(IRenderable entity)
        {
            bool entityFound = false;

            for (int i = 0; i < this.Entities.Count; i++)
            {
                if (this.Entities[i] == entity)
                {
                    entityFound = true;
                    break;
                }
            }

            return entityFound;
        }
    }
}
