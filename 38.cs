public class Solution {
    public string CountAndSay(int n) {
        string st = "1";

        if (n == 1) return st;

        while (--n > 0) {
            var sb = new StringBuilder();
            int i = 0;

            while (i < st.Length) {
                char currentChar = st[i];
                int count = 1;
                while (i + 1 < st.Length && st[i + 1] == currentChar) {
                    count++;
                    i++;
                }
                sb.Append(count);
                sb.Append(currentChar);
                i++;
            }

            st = sb.ToString();
        }

        return st;
    }
}
