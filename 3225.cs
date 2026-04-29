public class Solution {
    public long MaximumScore(int[][] grid) {
        int n = grid.Length;
        long[][] moss = new long[n][];
        for (int j = 0; j < n; j++) {
            moss[j] = new long[n + 1];
            for (int i = 0; i < n; i++) {
                moss[j][i + 1] = moss[j][i] + grid[i][j];
            }
        }        
        long[,] dp = new long[n + 1, 3];
        for (int h = 0; h <= n; h++) {
            dp[h, 0] = 0; 
            dp[h, 1] = dp[h, 2] = -1; 
        }

        for (int col = 1; col < n; col++) {
            long[,] next = new long[n + 1, 3];
            for (int h = 0; h <= n; h++) next[h, 0] = next[h, 1] = next[h, 2] = -1;
            long bestRising = -1;
            for (int h = 0; h <= n; h++) {
                long prev = Math.Max(dp[h, 0], dp[h, 2]);
                if (prev != -1) bestRising = Math.Max(bestRising, prev - moss[col - 1][h]);
                if (bestRising != -1) next[h, 0] = bestRising + moss[col - 1][h];
            }
            long bestFalling = -1;
            for (int h = n; h >= 0; h--) {
                long prev = Math.Max(dp[h, 0], Math.Max(dp[h, 1], dp[h, 2]));
                if (prev != -1) bestFalling = Math.Max(bestFalling, prev + moss[col][h]);
                if (bestFalling != -1) next[h, 1] = bestFalling - moss[col][h];
            }
            long bestFloor = -1;
            for (int h = 0; h <= n; h++) {
                bestFloor = Math.Max(bestFloor, dp[h, 1]);
            }
            for (int h = 0; h <= n; h++) {
                next[h, 2] = bestFloor;
            }

            dp = next;
        }

        long ans = 0;
        for (int h = 0; h <= n; h++) {
            for (int s = 0; s < 3; s++) ans = Math.Max(ans, dp[h, s]);
        }
        return ans;
    }
}
