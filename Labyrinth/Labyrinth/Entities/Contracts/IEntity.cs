using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labyrinth.Entities.Contracts
{
    public interface IEntity
    {
        bool Active { get; }
        void Activate();
        void Deactivate();
    }
}
