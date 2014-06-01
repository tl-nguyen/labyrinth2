namespace Labyrinth
{
    using System;

    public class Cell
    {
        public const char CELL_EMPTY_VALUE = '-';

        public const char CELL_WALL_VALUE = 'X';

        private int row;
        private int col;

        public Cell(int row, int col, char value)
        {
            this.Row = row;
            this.Col = col;
            this.ValueChar = value;
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

        public char ValueChar { get; set; }

        public bool IsEmpty()
        {
            if (this.ValueChar == CELL_EMPTY_VALUE)
            {
                return true;
            }

            return false;
        }
    }
}