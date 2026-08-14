public class Solution {
    public int MaximumLengthSubstring(string s) {
        var dict = new Dictionary<char, int>();
        int max = 0;
        int left = 0;

        for (int i = 0; i < s.Length; i++) {
            if (dict.ContainsKey(s[i])) {
                dict[s[i]] += 1;
                while (dict[s[i]] > 2) {
                    dict[s[left]] -= 1;
                    left++;
                }
            } else {
                dict[s[i]] = 1;
            }
            max = Math.Max(max, i - left + 1);
        }
        return max;
    }
}
