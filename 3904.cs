public class Solution { 
    public int FirstStableIndex(int[] nums, int k) { 
        int n = nums.Length;
        int maxi = (int)-1e9;
        int mini = (int)1e9;

        int[] rightMini = new int[n];

        for (int idx = n - 1; idx >= 0; idx--) {
            mini = Math.Min(mini, nums[idx]);
            rightMini[idx] = mini;
        }

        for (int idx = 0; idx < n; idx++) {
            maxi = Math.Max(maxi, nums[idx]);
            int score = maxi - rightMini[idx];

            if (score <= k) {
                return idx;
            }
        }

        return -1;
    } 
}
