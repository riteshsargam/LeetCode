public class Solution {
    public int min(int a, int b){
        return ((a < b) ? a : b);
    }

    public int MinimumSumSubarray(IList<int> nums, int l, int r) {
        int n = nums.Count, output = 75001, curSum;
        int[] pref = new int[n + 1];

        for (int i = 1; i <= n; i++){
            pref[i] = pref[i - 1] + nums[i - 1];
        }
            
        for (int left = 0; left <= n - l; left++){
            for (int right = left + l; right <= min(left + r, n); right++){
                curSum = pref[right] - pref[left];
                if (curSum > 0){
                    output = min(output, curSum);
                }  
            }
        }
        return ((output != 75001) ? output : -1);
    }
}
