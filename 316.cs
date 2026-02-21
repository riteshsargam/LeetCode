public class Solution {
    public string RemoveDuplicateLetters(string s) {
        Stack<char> stack = new Stack<char>();
        HashSet<char> seen = new HashSet<char>();
        Dictionary<char, int> lastOcc = new Dictionary<char, int>();
        for (int i = 0; i < s.Length; i++) {
            lastOcc[s[i]] = i;
        }
        
        for (int i = 0; i < s.Length; i++) {
            char c = s[i];
            if (!seen.Contains(c)) {
                while (stack.Count > 0 && c < stack.Peek() && i < lastOcc[stack.Peek()]) {
                    seen.Remove(stack.Pop());
                }
                seen.Add(c);
                stack.Push(c);
            }
        }
        
        char[] result = stack.ToArray();
        Array.Reverse(result);
        return new string(result);
    }
}
