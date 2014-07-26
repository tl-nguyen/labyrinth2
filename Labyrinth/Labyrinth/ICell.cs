namespace Labyrinth
{
    using System;
    using Commons;

    /// <summary>
    /// Interface defining the abstraction <see cref="ICell"/>
    /// </summary>
    public interface ICell : ICloneable
    {
        /// <summary>
        /// Gets or sets the current row. Values are integers that cannot be negative
        /// </summary>
        int Row { get; set; }

        /// <summary>
        /// Gets or sets the current column. Values are integers that cannot be negative
        /// </summary>
        int Col { get; set; }

        /// <summary>
        /// Gets or sets the value of the Cell
        /// </summary>
        CellState CellValue { get; set; }

        /// <summary>
        /// Checks if the current cell is empty
        /// </summary>
        /// <returns>Returns true if the cell is empty</returns>
        bool IsEmpty();
    }
}