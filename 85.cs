public class Solution {
    public int MaximalRectangle(char[][] matrix) {
        if (matrix.Length == 0) return 0;
        int n = matrix[0].Length;
        int[] height = new int[n];
        int maxArea = 0;
        foreach (var row in matrix) {
            for (int i = 0; i < n; i++)
                height[i] = row[i] == '1' ? height[i] + 1 : 0;
            Stack<int> st = new Stack<int>();
            for (int i = 0; i <= n; i++) {
                int h = i == n ? 0 : height[i];
                while (st.Count > 0 && h < height[st.Peek()]) {
                    int top = st.Pop();
                    int width = st.Count == 0 ? i : i - st.Peek() - 1;
                    maxArea = Math.Max(maxArea, height[top] * width);
                }
                st.Push(i);
            }
        }
        return maxArea;
    }
}
