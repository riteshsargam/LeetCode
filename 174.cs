public class Solution {
    public int CalculateMinimumHP(int[][] dungeon) {
        int rows = dungeon.Length;
        int cols = dungeon[0].Length;
        int[,] dp = new int[rows, cols];

        for (int i = rows - 1; i >= 0; i--) {
            for (int j = cols - 1; j >= 0; j--) {
                if (i == rows - 1 && j == cols - 1) {
                    dp[i, j] = dungeon[i][j];
                } else if (i == rows - 1) {
                    dp[i, j] = dungeon[i][j] + dp[i, j + 1];
                } else if (j == cols - 1) {
                    dp[i, j] = dungeon[i][j] + dp[i + 1, j];
                } else {
                    dp[i, j] = dungeon[i][j] + Math.Max(dp[i + 1, j], dp[i, j + 1]);
                }

                dp[i, j] = Math.Min(dp[i, j], 0);
            }
        }

        return Math.Abs(dp[0, 0]) + 1;
    }
}
