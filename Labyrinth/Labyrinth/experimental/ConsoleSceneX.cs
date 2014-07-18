using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labyrinth.Labyrinth.experimental
{
    public class ConsoleSceneX : ISceneX
    {
        private List<IRenderableX> entities;
        private IConsoleRendererX renderer;

        public ConsoleSceneX(IConsoleRendererX renderer)
        {
            this.renderer = renderer;
            this.entities = new List<IRenderableX>();
        }

        public void Render()
        {
            this.renderer.Clear();
            foreach (IRenderableX entity in entities)
            {
                entity.Render();
            }
        }

        public void Add(IRenderableX entity)
        {
            bool entityAlreadyAdded = this.CheckIfEntityExists(entity);

            if (entityAlreadyAdded)
            {
                throw new ArgumentException("This entity has already been added to the scene.");
            }

            this.entities.Add(entity);
        }


        public void Remove(IRenderableX entity)
        {
            bool entityFound = this.CheckIfEntityExists(entity);

            if (entityFound == false)
            {
                throw new ArgumentException("No such entity found in scene.");
            }

            this.entities.Remove(entity);
        }

        public bool CheckIfEntityExists(IRenderableX entity)
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
