public class Solution {
    private int[,,] memo;
    private string s1, s2;

    public bool IsScramble(string s1, string s2) {
        if (s1.Length != s2.Length)
            return false;
        if (s1 == s2)
            return true;

        int n = s1.Length;
        this.s1 = s1;
        this.s2 = s2;
        memo = new int[n, n, n + 1];

        return Dfs(0, 0, n);
    }

    private bool Dfs(int i, int j, int len) {
        if (memo[i, j, len] != 0)
            return memo[i, j, len] == 1;

        string a = s1.Substring(i, len);
        string b = s2.Substring(j, len);

        if (a == b) {
            memo[i, j, len] = 1;
            return true;
        }

        int[] count = new int[26];
        for (int k = 0; k < len; k++) {
            count[s1[i + k] - 'a']++;
            count[s2[j + k] - 'a']--;
        }
        foreach (var c in count)
            if (c != 0) {
                memo[i, j, len] = -1;
                return false;
            }

        for (int k = 1; k < len; k++) {
            if (Dfs(i, j, k) && Dfs(i + k, j + k, len - k)) {
                memo[i, j, len] = 1;
                return true;
            }
            if (Dfs(i, j + len - k, k) && Dfs(i + k, j, len - k)) {
                memo[i, j, len] = 1;
                return true;
            }
        }

        memo[i, j, len] = -1;
        return false;
    }
}
