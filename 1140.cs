public class Solution {
    public int StoneGameII(int[] piles) {
        int n = piles.Length;
        // Суффиксный массив
        int[] suffix = new int[n + 1];
        for (int i = n - 1; i >= 0; i--) {
            suffix[i] = suffix[i + 1] + piles[i];
        }

        // Мемоизация (используем Nullable<int> для обозначения невычисленных значений)
        int?[,] memo = new int?[n + 1, n + 1];

        // Рекурсивная функция
        Func<int, int, int> dfs = null;
        dfs = (i, M) => {
            if (i >= n) return 0;
            if (i + 2 * M >= n) return suffix[i];
            if (memo[i, M].HasValue) return memo[i, M].Value;

            int best = 0;
            for (int X = 1; X <= 2 * M; X++) {
                int opponent = dfs(i + X, Math.Max(M, X));
                best = Math.Max(best, suffix[i] - opponent);
            }
            memo[i, M] = best;
            return best;
        };

        return dfs(0, 1);
    }
}
