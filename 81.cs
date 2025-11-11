public class Solution {
    public bool Search(int[] nums, int target) {
        int i = 0;
        while (i < nums.Length - 1 && nums[i] <= nums[i+1])
        {
            if (nums[i] == target)
                return true;
            
            i++;
        }
        
        if (i < nums.Length && nums[i] == target)
            return true;
        
        int l = i + 1;
        int h = nums.Length - 1;
        while (l <= h)
        {
            int mid = (l + h) / 2;
            if (nums[mid] > target)
                h = mid - 1;
            else if (nums[mid] < target)
                l = mid + 1;
            else
                return true;
        }
        
        return false;
    }
}
