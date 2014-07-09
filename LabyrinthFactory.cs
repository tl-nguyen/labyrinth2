namespace Labyrinth
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    public class LabyrinthFactory
    {

        /// <summary>
        /// Gets the correct instance of the ICell interface
        /// </summary>
        /// <returns>ICell instance</returns>
        public static ICell GetCellInstance(int row, int col, CellState value)
        {
            return new Cell(row, col, value);
        }
    }
}
