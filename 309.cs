public class Solution {
    public int MaxProfit(int[] prices) {
        int n = prices.Length;
        int[,] dp = new int[n + 1, 2];
        dp[1,0] = 0;
        dp[1,1] = -prices[0];

        for (int i = 2; i <= n; i++) {
            dp[i,0] = Math.Max(dp[i-1,0], dp[i-1,1] + prices[i-1]);
            dp[i,1] = Math.Max(dp[i-1,1], dp[i-2,0] - prices[i-1]);
        }

        return dp[n,0];
    }
}
