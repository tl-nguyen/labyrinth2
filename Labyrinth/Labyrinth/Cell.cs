namespace Labyrinth
{
    using System;
    using Commons;

    /// <summary>
    /// Encapsulates the object that represents a single instance of the ICell interface
    /// </summary>
    public class Cell : ICell, ICloneable
    {
        private int row;
        private int col;

        /// <summary>
        /// Creates an instance of the Cell class
        /// </summary>
        /// <param name="row">Takes an integer value that is not negative</param>
        /// <param name="col">Takes an integer value that is not negative</param>
        /// <param name="value">Choose a value from the CellState enumeration, that will represent the state of the created Cell</param>
        public Cell(int row, int col, CellState value)
        {
            this.Row = row;
            this.Col = col;
            this.CellValue = value;
        }

        /// <summary>
        /// Property for the current row. Values are integers that cannot be negative
        /// </summary>
        public int Row
        {
            get
            {
                return this.row;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Value of the row must not be negative");
                }

                this.row = value;
            }
        }

        /// <summary>
        /// Property for the current column. Values are integers that cannot be negative
        /// </summary>
        public int Col
        {
            get
            {
                return this.col;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Value of the col must not be negative");
                }

                this.col = value;
            }
        }

        /// <summary>
        /// Gets and sets the value of the Cell
        /// </summary>
        public CellState CellValue { get; set; }

        /// <summary>
        /// Checks if the current cell is empty
        /// </summary>
        /// <returns>Returns true if the cell is empty</returns>
        public bool IsEmpty()
        {
            if (this.CellValue == CellState.Empty)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Creates a deep copy of the object
        /// </summary>
        /// <returns>New deep copy of the object</returns>
        public object Clone()
        {
            Cell copy = new Cell(this.Row, this.Col, this.CellValue);
            return copy;
        }
    }
}