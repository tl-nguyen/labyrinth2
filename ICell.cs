using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labyrinth
{
    public interface ICell
    {
        int Row { get; set; }
        int Col { get; set; }
        CellState CellValue { get; set; }
        bool IsEmpty();
    }
}
