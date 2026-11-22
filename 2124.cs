public class Solution {
    public bool CheckString(string s) {
        int n = s.Length;
        int lasta = -1;  // Index of the last occurrence of 'a'
        int firstb = n;  // Index of the first occurrence of 'b'
        for (int i = 0; i < n; ++i) {
            if (s[i] == 'a') {
                lasta = Math.Max(lasta, i);
            } else {
                firstb = Math.Min(firstb, i);
            }
        }
        return lasta < firstb;
    }
}
