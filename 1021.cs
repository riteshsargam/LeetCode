public class Solution {
    public string RemoveOuterParentheses(string s) {
        StringBuilder sb = new StringBuilder(s.Length);
        int track = 0;

        foreach (char c in s) {
            if (c == '(' && track == 0) {
                track++;
            }
            else if (c == ')' && track == 1){
                track--;
            }
            else {
                if (c == '(') {
                    sb.Append(c);
                    track++;
                }
                else {
                    sb.Append(c);
                    track--;
                }
            }
        }

        return sb.ToString();
    }
}
