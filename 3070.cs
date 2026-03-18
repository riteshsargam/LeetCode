public class Solution {
    public int CountSubmatrices(int[][] grid, int k) {
        int m = grid.Length, n = grid[0].Length, res = 0;
        int[,] pref = new int[m, n];

        for (int r = 0; r < m; r++)
            for (int c = 0; c < n; c++) {
                pref[r, c] = grid[r][c];
                if (r > 0) pref[r, c] += pref[r-1, c];
                if (c > 0) pref[r, c] += pref[r, c-1];
                if (r > 0 && c > 0) pref[r, c] -= pref[r-1, c-1];
                if (pref[r, c] <= k) res++;
            }

        return res;
    }
}
