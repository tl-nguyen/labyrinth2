using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labyrinth.Labyrinth.experimental
{
    public interface ISceneX
    {
        void Render();

        void Add(IRenderableX entity);

        void Remove(IRenderableX entity);

        bool CheckIfEntityExists(IRenderableX entity);
    }
}
