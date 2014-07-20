using System;
using System.Collections.Generic;
using Labyrinth.UI.Contracts;
using Labyrinth.Renderer.Contracts;

namespace Labyrinth
{
    public class ConsoleScene : IScene
    {
        private List<IRenderable> entities;
        private IConsoleRenderer renderer;

        public ConsoleScene(IConsoleRenderer renderer)
        {
            this.renderer = renderer;
            this.entities = new List<IRenderable>();
        }

        public void Render()
        {
            this.renderer.Clear();
            foreach (IRenderable entity in entities)
            {
                entity.Render();
            }
        }

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

        public bool CheckIfEntityExists(IRenderable entity)
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
