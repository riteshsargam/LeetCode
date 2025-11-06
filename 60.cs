public class Solution {
    public string GetPermutation(int n, int k) {
        List<int> nums = new List<int>();
        int[] fact = new int[n + 1];
        fact[0] = 1;
        for (int i = 1; i <= n; i++) {
            nums.Add(i);
            fact[i] = fact[i - 1] * i;
        }
        k--; 
        StringBuilder sb = new StringBuilder();
        for (int i = n; i >= 1; i--) {
            int idx = k / fact[i - 1];
            sb.Append(nums[idx]);
            nums.RemoveAt(idx);
            k %= fact[i - 1];
        }
        return sb.ToString();
    }
}
