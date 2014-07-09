namespace Labyrinth
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Returns instances of all classes for the project
    /// </summary>
    public class LabyrinthFactory
    {
        //TODO: Refactor other classes, and make instances be returned only here.


        /// <summary>
        /// Gets the correct instance of the ICell interface
        /// </summary>
        /// <returns>ICell instance</returns>
        public static ICell GetCellInstance(int row, int col, CellState value)
        {
            return new Cell(row, col, value);
        }

        public static IRenderer GetRendererInstance()
        {
            return new ConsoleRenderer();
        }
    }
}
