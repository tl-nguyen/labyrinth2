using System;
using System.Collections.Generic;
using Labyrinth.UI.Contracts;
using Labyrinth.Renderer.Contracts;

namespace Labyrinth.UI
{
    /// <summary>
    /// Holds a list of the renderable entities
    /// </summary>
    public abstract class Scene : IScene
    {
        protected List<IRenderable> entities;

        public Scene()
        {
            this.entities = new List<IRenderable>();
        }

        public abstract void Render();

        public void Add(IRenderable entity)
        {
            bool entityAlreadyAdded = this.CheckIfEntityExists(entity);

            if (entityAlreadyAdded)
            {
                throw new ArgumentException("This entity has already been added to the scene.");
            }

            this.entities.Add(entity);
        }


        public void Remove(IRenderable entity)
        {
            bool entityFound = this.CheckIfEntityExists(entity);

            if (entityFound == false)
            {
                throw new ArgumentException("No such entity found in scene.");
            }

            this.entities.Remove(entity);
        }

        protected bool CheckIfEntityExists(IRenderable entity)
        {
            bool entityFound = false;

            for (int i = 0; i < this.entities.Count; i++)
            {
                if (this.entities[i] == entity)
                {
                    entityFound = true;
                    break;
                }
            }

            return entityFound;
        }
    }
}
