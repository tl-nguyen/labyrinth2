using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Labyrinth.Entities.Contracts;

namespace Labyrinth.Entities
{
    public abstract class Entity : IEntity
    {
        public bool Active { get; private set; }

        public Entity(bool active)
        {
            this.Active = active;
        }
        public Entity()
            : this(true)
        {
        }
        
        public void Activate()
        {
            this.Active = true;
        }

        public void Deactivate()
        {
            this.Active = false;
        }
    }
}
