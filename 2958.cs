public class Solution {
    public int MaxSubarrayLength(int[] nums, int k) {
        int l = 0;
        int ans = 0;
        Dictionary<int, int> elementFrequency = new Dictionary<int, int>();
        for (int r = 0; r < nums.Length; r++){
            if (elementFrequency.ContainsKey(nums[r])){
                elementFrequency[nums[r]]++;
            }else{
                elementFrequency[nums[r]] = 1;
            }

            while (elementFrequency[nums[r]] > k){
                elementFrequency[nums[l]]--;
                if (elementFrequency[nums[l]] == 0){
                    elementFrequency.Remove(nums[l]);
                }
                l++;
            }
            ans = Math.Max(ans, r - l + 1);
        }
        return ans;
    }
}
