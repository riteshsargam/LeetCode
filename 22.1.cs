public class Solution {
    void Generate(List<string> ans, string s, int open, int close, int n) {
        if (open == n && close == n) {
            ans.Add(s);
            return;
        }

        if (open > close)
            Generate(ans, s + ")", open, close + 1, n);

        if (open < n)
            Generate(ans, s + "(", open + 1, close, n);
    }

    public IList<string> GenerateParenthesis(int n) {
        List<string> ans = new List<string>();
        Generate(ans, "", 0, 0, n);
        return ans;
    }
}
