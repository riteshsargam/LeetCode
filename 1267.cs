public class Solution {
    public int CountServers(int[][] grid) {
        int row = grid.Length;
        int col = grid[0].Length;

        int[] Rows = new int[row];
        int[] Cols = new int[col];

        // Count servers in each row and column
        for (int i = 0; i < row; i++) {
            for (int j = 0; j < col; j++) {
                Rows[i] += grid[i][j];
                Cols[j] += grid[i][j];
            }
        }

        // Count communicating servers
        int ans = 0;

        for (int i = 0; i < row; i++) {
            for (int j = 0; j < col; j++) {
                if (grid[i][j] == 1 &&
                    (Rows[i] > 1 || Cols[j] > 1)) {
                    ans++;
                }
            }
        }

        return ans;
    }
}
