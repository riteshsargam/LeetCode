public class Solution {
    public int LongestValidParentheses(string s) {
        int n = s.Length;
        int[] dp = new int[n];
        int maxLen = 0;

        for (int i = 1; i < n; i++) {
            if (s[i] == ')') {
                if (s[i - 1] == '(') {
                    dp[i] = 2 + (i >= 2 ? dp[i - 2] : 0);
                }
                else {
                    int prev = i - dp[i - 1] - 1;
                    if (prev >= 0 && s[prev] == '(') {
                        dp[i] = dp[i - 1] + 2
                              + (prev >= 1 ? dp[prev - 1] : 0);
                    }
                }
                maxLen = Math.Max(maxLen, dp[i]);
            }
        }

        return maxLen;
    }
}
