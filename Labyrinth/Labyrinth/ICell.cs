namespace Labyrinth
{
    using Commons;
    using System;

    public interface ICell : ICloneable
    {
        /// <summary>
        /// Property for the current row. Values are integers that cannot be negative
        /// </summary>
        int Row { get; set; }

        /// <summary>
        /// Property for the current column. Values are integers that cannot be negative
        /// </summary>
        int Col { get; set; }

        /// <summary>
        /// Gets and sets the value of the Cell
        /// </summary>
        CellState CellValue { get; set; }

        /// <summary>
        /// Checks if the current cell is empty
        /// </summary>
        /// <returns>Returns true if the cell is empty</returns>
        bool IsEmpty();
    }
}