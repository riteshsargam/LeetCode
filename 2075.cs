public class Solution {
    public string DecodeCiphertext(string s, int rows) {
        if (string.IsNullOrEmpty(s)) return s;

        int cols = (int)Math.Ceiling((double)s.Length / rows);
        StringBuilder res = new StringBuilder();

        for (int start = 0; start < cols; start++) {
            int r = 0, c = start;
            while (r < rows && c < cols) {
                int idx = r * cols + c;
                if (idx < s.Length)
                    res.Append(s[idx]);
                r++;
                c++;
            }
        }

        return res.ToString().TrimEnd();
    }
}
