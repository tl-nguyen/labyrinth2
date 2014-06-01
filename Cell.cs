namespace Labyrinth
{
    using System;

    public class Cell : ICell
    {
        private int row;
        private int col;

        public Cell(int row, int col, CellState value)
        {
            this.Row = row;
            this.Col = col;
            this.CellValue = value;
        }

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

        public CellState CellValue { get; set; }

        public bool IsEmpty()
        {
            if (this.CellValue == CellState.Empty)
            {
                return true;
            }

            return false;
        }
    }
}