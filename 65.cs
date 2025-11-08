public class Solution {
    public bool IsNumber(string s) {
        s = s.Trim();
        bool seenDigit = false, seenDot = false, seenE = false, digitAfterE = true;

        for (int i = 0; i < s.Length; i++) {
            char c = s[i];
            if (char.IsDigit(c)) {
                seenDigit = true;
                if (seenE) digitAfterE = true;
            } else if (c == '+' || c == '-') {
                if (i > 0 && s[i - 1] != 'e' && s[i - 1] != 'E') return false;
            } else if (c == '.') {
                if (seenDot || seenE) return false;
                seenDot = true;
            } else if (c == 'e' || c == 'E') {
                if (seenE || !seenDigit) return false;
                seenE = true;
                digitAfterE = false;
            } else return false;
        }

        return seenDigit && digitAfterE;
    }
}
