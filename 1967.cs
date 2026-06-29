public class Solution {
    public int NumOfStrings(string[] patterns, string word) {
        int res = 0;
        foreach (string pattern in patterns) {
            if (check(pattern, word)) {
                res++;
            }
        }
        return res;
    }

    private bool check(string pattern, string word) {
        int m = pattern.Length;
        int n = word.Length;

        // generate the prefix array of the pattern
        int[] pi = new int[m];
        for (int i = 1, j = 0; i < m; i++) {
            while (j > 0 && pattern[i] != pattern[j]) {
                j = pi[j - 1];
            }
            if (pattern[i] == pattern[j]) {
                j++;
            }
            pi[i] = j;
        }

        // using prefix arrays for matching
        for (int i = 0, j = 0; i < n; i++) {
            while (j > 0 && word[i] != pattern[j]) {
                j = pi[j - 1];
            }
            if (word[i] == pattern[j]) {
                j++;
            }
            if (j == m) {
                return true;
            }
        }
        return false;
    }
}
