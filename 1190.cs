public class Solution {
    public string ReverseParentheses(string s) {
        Stack<char> stack = new Stack<char>();

        foreach(char c in s){
            if (c == ')') {
                List<char> substring = new List<char>();
                while (stack.Count > 0 && stack.Peek() != '(') {
                    substring.Add(stack.Pop());
                }
                stack.Pop();
              
                foreach (char ch in substring) {
                    stack.Push(ch);
                }
            } else {
                stack.Push(c);
            }
        }

        char[] answer = stack.ToArray();
        Array.Reverse(answer);
        return new string(answer);
    }
}
