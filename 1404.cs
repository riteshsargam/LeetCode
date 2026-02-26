public class Solution {
    public int NumSteps(string s) {
        Stack<char> st = new Stack<char>();

        foreach (char c in s) {
            st.Push(c);
        }

        int res = 0;

        while (st.Count > 0) {
            if (st.Peek() == '0') {
                st.Pop();
                res++;
            } else {
                if (st.Count == 1 && st.Peek() == '1') 
                    break;
                
                res++; // 1 operation for adding 1
                while (st.Count > 0 && st.Peek() == '1') {
                    st.Pop();
                    res++; // 1 operation for each trailing zero that gets shifted out
                }
                
                if (st.Count > 0) {
                    st.Pop(); // Remove the '0' that absorbs the carry
                }
                st.Push('1'); // Push the carry bit back
            }
        }

        return res;
    }
}
