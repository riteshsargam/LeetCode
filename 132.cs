public class Solution {
    public int MinCut(string s) {
          int n = s.Length;
  bool[,] isPalindrome = new bool[n, n];

  for (int len = 1; len <= n; len++)
  {
      for (int start = 0; start <= n - len; start++)
      {
          int end = start + len - 1;

          if (s[start] == s[end])
          {
              if (len <= 2)
              {
                  isPalindrome[start, end] = true;
              }
              else
              {
                  isPalindrome[start, end] = isPalindrome[start + 1, end - 1];
              }
          }
      }
  }

  int[] dp = new int[n];
  Array.Fill(dp, int.MaxValue);

  for (int i = 0; i < n; i++)
  {
      for (int j = 0; j <= i; j++)
      {

          if (isPalindrome[j, i])
          {
              if (j == 0)
              {
                  dp[i] = 0;
              }
              else
              {
                  dp[i] = Math.Min(dp[i], dp[j - 1] + 1);
              }
          }
      }
  }

  return dp[n - 1];

    }
}
