public class Solution {
    public string ShortestPalindrome(string s) {
        int count = Kmp(new string(s.Reverse().ToArray()), s);
        return new string(s.Substring(count).Reverse().ToArray()) + s;
    }

    private int Kmp(string txt, string patt) {
        string newString = patt + '#' + txt;
        int[] pi = new int[newString.Length];
        int i = 1, k = 0;
        while (i < newString.Length) {
            if (newString[i] == newString[k]) {
                k++;
                pi[i] = k;
                i++;
            } else {
                if (k > 0) {
                    k = pi[k - 1];
                } else {
                    pi[i] = 0;
                    i++;
                }
            }
        }
        return pi[newString.Length - 1];
    }
}
