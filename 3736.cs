public class Solution {
    public int MinMoves(int[] nums) {
        int mx = nums[0];
        foreach (int x in nums) {
            mx = Math.Max(mx, x);
        }
        int ans = 0;
        foreach (int x in nums) {
            ans += mx - x;
        }
        return ans;
    }
}
