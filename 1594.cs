public class Solution {
  public int MaxProductPath(int[][] grid) {
      int MOD = 1000000007;
      int m = grid.Length, n = grid[0].Length;

      long[,] max = new long[m, n];
      long[,] min = new long[m, n];

      max[0,0] = min[0,0] = grid[0][0];

      for (int i = 0; i < m; i++) {
          for (int j = 0; j < n; j++) {
              if (i == 0 && j == 0) continue;

              long val = grid[i][j];
              long maxCandidate = long.MinValue;
              long minCandidate = long.MaxValue;

              if (i > 0) {
                  maxCandidate = Math.Max(maxCandidate, val * max[i-1,j]);
                  maxCandidate = Math.Max(maxCandidate, val * min[i-1,j]);
                  minCandidate = Math.Min(minCandidate, val * max[i-1,j]);
                  minCandidate = Math.Min(minCandidate, val * min[i-1,j]);
              }
              if (j > 0) {
                  maxCandidate = Math.Max(maxCandidate, val * max[i,j-1]);
                  maxCandidate = Math.Max(maxCandidate, val * min[i,j-1]);
                  minCandidate = Math.Min(minCandidate, val * max[i,j-1]);
                  minCandidate = Math.Min(minCandidate, val * min[i,j-1]);
              }

              max[i,j] = maxCandidate;
              min[i,j] = minCandidate;
          }
      }

      long result = max[m-1,n-1];
      if (result < 0) return -1;
      return (int)(result % MOD);
  }
}
