public class Solution {
    public string SmallestSubsequence(string s) {
                    var indexes = new int[26];
            for (int i = 0; i < s.Length; i++)
                indexes[s[i] - 'a'] = i;

            var seen = new HashSet<char>();
            var stack = new Stack<char>();
            for (int i = 0; i < s.Length; i++)
            {
                var ch = s[i];
                if (seen.Contains(ch)) continue;

                while (stack.Count > 0 && stack.Peek() > ch && indexes[stack.Peek() - 'a'] > i)
                    seen.Remove(stack.Pop());

                seen.Add(ch);
                stack.Push(ch);
            }

            var chars = new char[stack.Count];
            for (int i = stack.Count - 1; i >= 0; i--)
                chars[i] = stack.Pop();

            return new string(chars);
    }
}
