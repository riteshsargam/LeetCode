public class Solution {
    public void SolveSudoku(char[][] board) {
        SolveSudoku(board, 0, 0);
    }

    private bool SolveSudoku(char[][] board, int row, int col)
    {
        // Check if we have reached the end of the board.
        if (col == 9)
        {
            col = 0;
            row++;

            if (row == 9)
            {
                return true;
            }
        }

        // Skip filled cells.
        if (board[row][col] != '.')
        {
            return SolveSudoku(board, row, col + 1);
        }

        // Try filling the current cell with each of the digits 1-9.
        for (char c = '1'; c <= '9'; c++)
        {
            if (IsValid(board, row, col, c))
            {
                board[row][col] = c;

                if (SolveSudoku(board, row, col + 1))
                {
                    return true;
                }

                // Backtrack.
                board[row][col] = '.';
            }
        }

        return false;
    }

    private bool IsValid(char[][] board, int row, int col, char c)
    {
        // Check if the given character occurs in the current row.
        for (int i = 0; i < 9; i++)
        {
            if (board[row][i] == c)
            {
                return false;
            }
        }

        // Check if the given character occurs in the current column.
        for (int i = 0; i < 9; i++)
        {
            if (board[i][col] == c)
            {
                return false;
            }
        }

        // Check if the given character occurs in the current 3x3 sub-box.
        int startRow = (row / 3) * 3;
        int startCol = (col / 3) * 3;
        for (int i = startRow; i < startRow + 3; i++)
        {
            for (int j = startCol; j < startCol + 3; j++)
            {
                if (board[i][j] == c)
                {
                    return false;
                }
            }
        }

        return true;
    }
}
