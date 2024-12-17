namespace Tetris
{
    public class GameGrid
    {
        private readonly int[,] grid;
        public int Rows { get; }
        public int Columns { get; }

        public int this[int row, int column]
        {
            get => grid[row, column];
            set => grid[row, column] = value;
        }

        public GameGrid(int rows, int columns)
        {
            Rows = rows;
            Columns = columns;
            grid = new int[rows, columns];
        }

        public bool IsInside(int row, int column)
        {
            return row >= 0 && row < Rows && column >= 0 && column < Columns;
        }

        public bool IsEmpty(int row, int column)
        {
            return IsInside(row, column) && grid[row, column] == 0;
        }

        public bool RowIsFull(int row)
        {
            for (int column = 0; column < Columns; column++)
            {
                if (grid[row, column] == 0)
                {
                    return false;
                }
            }
            return true;
        }

        public bool IsRowEmpty(int row)
        {
            for (int column = 0; column < Columns; column++)
            {
                if (grid[row, column] != 0)
                {
                    return false;
                }
            }
            return true;
        }

        private void ClearRow(int row)
        {
            for (int column = 0; column < Columns; column++)
            {
                grid[row, column] = 0;
            }
        }

        private void MoveRowDown(int row, int numRows)
        {
            for (int column = 0; column < Columns; column++)
            {
                grid[row + numRows, column] = grid[row, column];
                grid[row, column] = 0;
            }
        }

        public int ClearFullRows()
        {
            int cleared = 0;

            for (int row = Rows-1; row >= 0; row--)
            {
                if (RowIsFull(row))
                {
                    ClearRow(row);
                    cleared++;
                }
                else if (cleared > 0)
                {
                    MoveRowDown(row, cleared);
                }
            }

            return cleared;
        }
    }
}
